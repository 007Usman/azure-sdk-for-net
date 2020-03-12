// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Core.Testing;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Specialized.Models;
using Azure.Storage.Common.Cryptography;
using Azure.Storage.Common.Cryptography.Models;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Cryptography.Tests
{
    public class EncryptedBlobClientTests : BlobTestBase
    {
        public EncryptedBlobClientTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region Utility

        private byte[] LocalManualEncryption(byte[] data, byte[] key, byte[] iv)
        {
            using (var aesProvider = new AesCryptoServiceProvider() { Key = key, IV = iv })
            using (var encryptor = aesProvider.CreateEncryptor())
            using (var memStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();
                return memStream.ToArray();
            }
        }

        private async Task<IKeyEncryptionKey> GetKeyvaultIKeyEncryptionKey()
        {
            var keyClient = GetKeyClient_TargetKeyClient();
            Security.KeyVault.Keys.KeyVaultKey key = await keyClient.CreateRsaKeyAsync(
                new Security.KeyVault.Keys.CreateRsaKeyOptions($"CloudRsaKey-{Guid.NewGuid()}", false));
            return new CryptographyClient(key.Id, GetTokenCredential_TargetKeyClient());
        }

        /// <summary>
        /// Creates an encrypted blob client from a container client. Note that this method does not copy over any
        /// client options from the container client. You must pass in your own options. These options will be mutated.
        /// </summary>
        public EncryptedBlobClient GetEncryptedBlobClient(
            BlobContainerClient containerClient,
            string blobName,
            ClientsideEncryptionOptions encryptionOptions)
            => InstrumentClient(containerClient.GetEncryptedBlobClient(
                blobName,
                encryptionOptions));

        #endregion

        [TestCase(16)] // a single cipher block
        [TestCase(14)] // a single unalligned cipher block
        [TestCase(Constants.KB)] // multiple blocks
        [TestCase(Constants.KB - 4)] // multiple unalligned blocks
        [TestCase(Constants.MB)] // larger test, increasing likelihood to trigger async extension usage bugs
        [LiveOnly] // cannot seed content encryption key
        public async Task UploadAsync(long dataSize)
        {
            var data = GetRandomBuffer(dataSize);
            var mockKey = new MockKeyEncryptionKey();
            await using (var disposable = await GetTestContainerAsync())
            {
                var blobName = GetNewBlobName();
                var blob = GetEncryptedBlobClient(
                    disposable.Container,
                    blobName,
                    new ClientsideEncryptionOptions()
                    {
                        KeyEncryptionKey = mockKey,
                        KeyResolver = mockKey
                    });

                // upload with encryption
                await blob.UploadAsync(new MemoryStream(data));

                // download without decrypting
                var encryptedDataStream = new MemoryStream();
                await disposable.Container.GetBlobClient(blobName).DownloadToAsync(encryptedDataStream);
                var encryptedData = encryptedDataStream.ToArray();

                // encrypt original data manually for comparison
                EncryptionData encryptionMetadata = ClientSideDecryptionPolicy.GetAndValidateEncryptionData(
                    (await blob.GetPropertiesAsync()).Value.Metadata);
                Assert.NotNull(encryptionMetadata, "Never encrypted data.");
                byte[] expectedEncryptedData = LocalManualEncryption(
                    data,
                    (await mockKey.UnwrapKeyAsync(null, encryptionMetadata.WrappedContentKey.EncryptedKey)
                        .ConfigureAwait(false)).ToArray(),
                    encryptionMetadata.ContentEncryptionIV);

                // compare data
                Assert.AreEqual(expectedEncryptedData, encryptedData);
            }
        }

        [TestCase(16)] // a single cipher block
        [TestCase(14)] // a single unalligned cipher block
        [TestCase(Constants.KB)] // multiple blocks
        [TestCase(Constants.KB - 4)] // multiple unalligned blocks
        [LiveOnly] // cannot seed content encryption key
        public async Task RoundtripAsync(long dataSize)
        {
            var data = GetRandomBuffer(dataSize);
            var mockKey = new MockKeyEncryptionKey();
            await using (var disposable = await GetTestContainerAsync())
            {
                var blob = GetEncryptedBlobClient(
                    disposable.Container,
                    GetNewBlobName(),
                    new ClientsideEncryptionOptions()
                    {
                        KeyEncryptionKey = mockKey,
                        KeyResolver = mockKey
                    });

                // upload with encryption
                await blob.UploadAsync(new MemoryStream(data));

                // download with decryption
                byte[] downloadData;
                using (var stream = new MemoryStream())
                {
                    await blob.DownloadToAsync(stream);
                    downloadData = stream.ToArray();
                }

                // compare data
                Assert.AreEqual(data, downloadData);
            }
        }

        [TestCase(0, 16)]  // first block
        [TestCase(16, 16)] // not first block
        [TestCase(32, 32)] // multiple blocks; IV not at blob start
        [TestCase(16, 17)] // overlap end of block
        [TestCase(32, 17)] // overlap end of block; IV not at blob start
        [TestCase(15, 17)] // overlap beginning of block
        [TestCase(31, 17)] // overlap beginning of block; IV not at blob start
        [TestCase(15, 18)] // overlap both sides
        [TestCase(31, 18)] // overlap both sides; IV not at blob start
        [TestCase(16, null)]
        [LiveOnly] // cannot seed content encryption key
        public async Task PartialDownloadAsync(int offset, int? count)
        {
            var data = GetRandomBuffer(offset + (count ?? 16) + 32); // ensure we have enough room in original data
            var mockKey = new MockKeyEncryptionKey();
            await using (var disposable = await GetTestContainerAsync())
            {
                var blob = GetEncryptedBlobClient(
                    disposable.Container,
                    GetNewBlobName(),
                    new ClientsideEncryptionOptions()
                    {
                        KeyEncryptionKey = mockKey,
                        KeyResolver = mockKey
                    });

                // upload with encryption
                await blob.UploadAsync(new MemoryStream(data));

                // download range with decryption
                byte[] downloadData; // no overload that takes Stream and HttpRange; we must buffer read
                Stream downloadStream = (await blob.DownloadAsync(new HttpRange(offset, count))).Value.Content;
                byte[] buffer = new byte[Constants.KB];
                using (MemoryStream stream = new MemoryStream())
                {
                    int read;
                    while ((read = downloadStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, read);
                    }
                    downloadData = stream.ToArray();
                }

                // compare range of original data to downloaded data
                var slice = data.Skip(offset);
                slice = count.HasValue
                    ? slice.Take(count.Value)
                    : slice;
                var sliceArray = slice.ToArray();
                Assert.AreEqual(sliceArray, downloadData);
            }
        }

        [Test]
        [LiveOnly] // cannot seed content encryption key
        public async Task Track2DownloadTrack1Blob()
        {
            var data = GetRandomBuffer(Constants.KB);
            var mockKey = new MockKeyEncryptionKey();
            await using (var disposable = await GetTestContainerAsync())
            {
                var track2Blob = GetEncryptedBlobClient(
                    disposable.Container,
                    GetNewBlobName(),
                    new ClientsideEncryptionOptions()
                    {
                        KeyEncryptionKey = mockKey,
                        KeyResolver = mockKey
                    });

                // upload with track 1
                var creds = GetNewSharedKeyCredentials();
                var track1Blob = new Microsoft.Azure.Storage.Blob.CloudBlockBlob(
                    track2Blob.Uri,
                    new Microsoft.Azure.Storage.Auth.StorageCredentials(creds.AccountName, creds.GetAccountKey()));
                await track1Blob.UploadFromByteArrayAsync(
                    data, 0, data.Length, default,
                    new Microsoft.Azure.Storage.Blob.BlobRequestOptions()
                    {
                        EncryptionPolicy = new Microsoft.Azure.Storage.Blob.BlobEncryptionPolicy(mockKey, mockKey)
                    },
                    default, default);

                // download with track 2
                var downloadStream = new MemoryStream();
                await track2Blob.DownloadToAsync(downloadStream);

                // compare original data to downloaded data
                Assert.AreEqual(data, downloadStream.ToArray());
            }
        }

        [Test]
        [LiveOnly] // cannot seed content encryption key
        public async Task Track1DownloadTrack2Blob()
        {
            var data = GetRandomBuffer(Constants.KB); // ensure we have enough room in original data
            var mockKey = new MockKeyEncryptionKey();
            await using (var disposable = await GetTestContainerAsync())
            {
                var track2Blob = GetEncryptedBlobClient(
                    disposable.Container,
                    GetNewBlobName(),
                    new ClientsideEncryptionOptions()
                    {
                        KeyEncryptionKey = mockKey,
                        KeyResolver = mockKey
                    });

                // upload with track 2
                await track2Blob.UploadAsync(new MemoryStream(data));

                // download with track 1
                var creds = GetNewSharedKeyCredentials();
                var track1Blob = new Microsoft.Azure.Storage.Blob.CloudBlockBlob(
                    track2Blob.Uri,
                    new Microsoft.Azure.Storage.Auth.StorageCredentials(creds.AccountName, creds.GetAccountKey()));
                var downloadData = new byte[data.Length];
                await track1Blob.DownloadToByteArrayAsync(downloadData, 0, default,
                    new Microsoft.Azure.Storage.Blob.BlobRequestOptions()
                    {
                        EncryptionPolicy = new Microsoft.Azure.Storage.Blob.BlobEncryptionPolicy(mockKey, mockKey)
                    },
                    default, default);

                // compare original data to downloaded data
                Assert.AreEqual(data, downloadData);
            }
        }

        [Test]
        [LiveOnly] // need access to keyvault service && cannot seed content encryption key
        public async Task RoundtripWithKeyvaultProvider()
        {
            var data = GetRandomBuffer(Constants.KB);
            IKeyEncryptionKey key = await GetKeyvaultIKeyEncryptionKey();
            await using (var disposable = await GetTestContainerAsync())
            {
                var blob = GetEncryptedBlobClient(
                    disposable.Container,
                    GetNewBlobName(),
                    new ClientsideEncryptionOptions()
                    {
                        KeyEncryptionKey = key,
                        EncryptionKeyWrapAlgorithm = "RSA-OAEP-256"
                    });

                await blob.UploadAsync(new MemoryStream(data));

                var downloadStream = new MemoryStream();
                await blob.DownloadToAsync(downloadStream);

                Assert.AreEqual(data, downloadStream.ToArray());
            }
        }

        [Test]
        [LiveOnly] // cannot seed content encryption key
        [Explicit] // big stress test
        public async Task StressAsync()
        {
            static async Task<byte[]> RoundTripDataHelper(BlobClient client, byte[] data)
            {
                using (var dataStream = new MemoryStream(data))
                {
                    await client.UploadAsync(dataStream);
                }

                using (var downloadStream = new MemoryStream())
                {
                    await client.DownloadToAsync(downloadStream);
                    return downloadStream.ToArray();
                }
            }

            var data = GetRandomBuffer(10 * Constants.MB);
            var key = new MockKeyEncryptionKey();
            await using (var disposable = await GetTestContainerAsync())
            {
                var downloadTasks = new List<Task<byte[]>>();
                foreach (var _ in Enumerable.Range(0, 10))
                {
                    var blob = GetEncryptedBlobClient(
                        disposable.Container,
                        GetNewBlobName(),
                        new ClientsideEncryptionOptions()
                        {
                            KeyEncryptionKey = key,
                            KeyResolver = key
                        });

                    downloadTasks.Add(RoundTripDataHelper(blob, data));
                }

                var downloads = await Task.WhenAll(downloadTasks);

                foreach (byte[] downloadData in downloads)
                {
                    Assert.AreEqual(data, downloadData);
                }
            }
        }
    }
}
