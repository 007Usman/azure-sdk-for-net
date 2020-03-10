﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json;
using Azure.Storage.Common.Cryptography.Models;

namespace Azure.Storage.Queues.Specialized.Models
{
    internal static class EncryptedMessageSerializer
    {
        #region Serialize
        public static string Serialize(EncryptedMessage data)
        {
            return Encoding.UTF8.GetString(SerializeEncryptionData(data).ToArray());
        }

        public static ReadOnlyMemory<byte> SerializeEncryptionData(EncryptedMessage message)
        {
            var writer = new Core.ArrayBufferWriter<byte>();
            using var json = new Utf8JsonWriter(writer);

            json.WriteStartObject();
            WriteEncryptedMessage(json, message);
            json.WriteEndObject();

            json.Flush();
            return writer.WrittenMemory;
        }

        public static void WriteEncryptedMessage(Utf8JsonWriter json, EncryptedMessage message)
        {
            json.WriteString(nameof(message.EncryptedMessageContents), message.EncryptedMessageContents);

            json.WriteStartObject(nameof(message.EncryptionData));
            EncryptionDataSerializer.WriteEncryptionData(json, message.EncryptionData);
            json.WriteEndObject();
        }
        #endregion

        #region Deserialize
        public static EncryptedMessage Deserialize(string serializedData)
        {
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(serializedData));
            return DeserializeEncryptionData(ref reader);
        }

        public static EncryptedMessage DeserializeEncryptionData(ref Utf8JsonReader reader)
        {
            using JsonDocument json = JsonDocument.ParseValue(ref reader);
            JsonElement root = json.RootElement;
            return ReadEncryptionData(root);
        }

        private static EncryptedMessage ReadEncryptionData(JsonElement root)
        {
            var data = new EncryptedMessage();
            foreach (var property in root.EnumerateObject())
            {
                ReadPropertyValue(data, property);
            }
            return data;
        }

        private static void ReadPropertyValue(EncryptedMessage data, JsonProperty property)
        {
            if (property.NameEquals(nameof(data.EncryptedMessageContents)))
            {
                data.EncryptedMessageContents = property.Value.GetString();
            }
            else if (property.NameEquals(nameof(data.EncryptionData)))
            {
                data.EncryptionData = EncryptionDataSerializer.ReadEncryptionData(property.Value);
            }
        }
        #endregion
    }
}
