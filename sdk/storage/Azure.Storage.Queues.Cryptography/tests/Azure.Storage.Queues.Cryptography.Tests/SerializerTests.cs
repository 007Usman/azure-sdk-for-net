﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Common.Cryptography;
using Azure.Storage.Common.Cryptography.Models;
using Azure.Storage.Queues.Specialized.Models;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Queues.Cryptography.Tests
{
    public class SerializerTests // doesn't inherit our test base because there are no network tests
    {
        private const string TestMessage = "This can technically be a valid encrypted message.";
        private const string KeyWrapAlgorithm = "my_key_wrap_algorithm";

        [Test]
        public void SerializeEncryptedMessage()
        {
            var result = Utility.BufferedEncryptInternal(
                new MemoryStream(Encoding.UTF8.GetBytes(TestMessage)),
                new MockKeyEncryptionKey(),
                KeyWrapAlgorithm,
                async: false,
                default).EnsureCompleted();
            var encryptedMessage = new EncryptedMessage()
            {
                EncryptedMessageContents = Convert.ToBase64String(result.ciphertext),
                EncryptionData = result.encryptionData
            };

            var serializedMessage = EncryptedMessageSerializer.Serialize(encryptedMessage);

            // success = don't throw. test values in another test with deserialization (can't control serialization order)
        }

        [Test]
        public void DeserializeEncryptedMessage()
        {
            var result = Utility.BufferedEncryptInternal(
                   new MemoryStream(Encoding.UTF8.GetBytes(TestMessage)),
                   new MockKeyEncryptionKey(),
                   KeyWrapAlgorithm,
                   async: false,
                   default).EnsureCompleted();
            var encryptedMessage = new EncryptedMessage()
            {
                EncryptedMessageContents = Convert.ToBase64String(result.ciphertext),
                EncryptionData = result.encryptionData
            };
            var serializedMessage = EncryptedMessageSerializer.Serialize(encryptedMessage);

            var parsedEncryptedMessage = EncryptedMessageSerializer.Deserialize(serializedMessage);

            Assert.IsTrue(AreEqual(encryptedMessage, parsedEncryptedMessage));
        }

        [Test]
        public void TryDeserializeEncryptedMessage()
        {
            var result = Utility.BufferedEncryptInternal(
                   new MemoryStream(Encoding.UTF8.GetBytes(TestMessage)),
                   new MockKeyEncryptionKey(),
                   KeyWrapAlgorithm,
                   async: false,
                   default).EnsureCompleted();
            var encryptedMessage = new EncryptedMessage()
            {
                EncryptedMessageContents = Convert.ToBase64String(result.ciphertext),
                EncryptionData = result.encryptionData
            };
            var serializedMessage = EncryptedMessageSerializer.Serialize(encryptedMessage);

            bool tryResult = EncryptedMessageSerializer.TryDeserialize(serializedMessage, out var parsedEncryptedMessage);

            Assert.AreEqual(true, tryResult);
            Assert.IsTrue(AreEqual(encryptedMessage, parsedEncryptedMessage));
        }

        [Test]
        public void TryDeserializeEncryptedMessageFail()
        {
            bool tryResult = EncryptedMessageSerializer.TryDeserialize("this is not even valid json", out var parsedEncryptedMessage);

            Assert.AreEqual(false, tryResult);
            Assert.AreEqual(default, parsedEncryptedMessage);
        }

        #region ModelComparison
        private static bool AreEqual(EncryptedMessage left, EncryptedMessage right)
            => left.EncryptedMessageContents.Equals(right.EncryptedMessageContents, StringComparison.InvariantCulture)
            && AreEqual(left.EncryptionData, right.EncryptionData);

        private static bool AreEqual(EncryptionData left, EncryptionData right)
            => left.EncryptionMode.Equals(right.EncryptionMode, StringComparison.InvariantCulture)
            && AreEqual(left.WrappedContentKey, right.WrappedContentKey)
            && AreEqual(left.EncryptionAgent, right.EncryptionAgent)
            && left.ContentEncryptionIV.SequenceEqual(right.ContentEncryptionIV)
            && AreEqual(left.KeyWrappingMetadata, right.KeyWrappingMetadata);

        private static bool AreEqual(WrappedKey left, WrappedKey right)
            => left.KeyId.Equals(right.KeyId, StringComparison.InvariantCulture)
            && left.EncryptedKey.SequenceEqual(right.EncryptedKey)
            && left.Algorithm.Equals(right.Algorithm, StringComparison.InvariantCulture);

        private static bool AreEqual(EncryptionAgent left, EncryptionAgent right)
            => left.EncryptionAlgorithm.Equals(right.EncryptionAlgorithm)
            && left.Protocol.Equals(right.Protocol, StringComparison.InvariantCulture);

        private static bool AreEqual(IDictionary<string, string> left, IDictionary<string, string> right)
        {
            if (left.Count != right.Count)
            {
                return false;
            }
            foreach (KeyValuePair<string, string> leftPair in left)
            {
                if (!right.TryGetValue(leftPair.Key, out string rightValue))
                {
                    return false;
                }
                if (!leftPair.Value.Equals(rightValue, StringComparison.InvariantCulture))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}
