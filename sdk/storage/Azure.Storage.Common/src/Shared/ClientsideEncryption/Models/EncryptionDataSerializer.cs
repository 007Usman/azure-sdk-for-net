﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Azure.Storage.Common.Cryptography.Models
{
    internal static class EncryptionDataSerializer
    {
        #region Serialize
        public static string Serialize(EncryptionData data)
        {
            return Encoding.UTF8.GetString(SerializeEncryptionData(data).ToArray());
        }

        public static ReadOnlyMemory<byte> SerializeEncryptionData(EncryptionData data)
        {
            var writer = new Core.ArrayBufferWriter<byte>();
            using var json = new Utf8JsonWriter(writer);

            json.WriteStartObject();
            WriteEncryptionData(json, data);
            json.WriteEndObject();

            json.Flush();
            return writer.WrittenMemory;
        }

        public static void WriteEncryptionData(Utf8JsonWriter json, EncryptionData data)
        {
            json.WriteString(nameof(data.EncryptionMode), data.EncryptionMode);

            json.WriteStartObject(nameof(data.WrappedContentKey));
            WriteWrappedKey(json, data.WrappedContentKey);
            json.WriteEndObject();

            json.WriteStartObject(nameof(data.EncryptionAgent));
            WriteEncryptionAgent(json, data.EncryptionAgent);
            json.WriteEndObject();

            json.WriteString(nameof(data.ContentEncryptionIV), Convert.ToBase64String(data.ContentEncryptionIV));

            json.WriteStartObject(nameof(data.KeyWrappingMetadata));
            WriteDictionary(json, data.KeyWrappingMetadata);
            json.WriteEndObject();
        }

        private static void WriteWrappedKey(Utf8JsonWriter json, WrappedKey key)
        {
            json.WriteString(nameof(key.KeyId), key.KeyId);
            json.WriteString(nameof(key.EncryptedKey), Convert.ToBase64String(key.EncryptedKey));
            json.WriteString(nameof(key.Algorithm), key.Algorithm);
        }

        private static void WriteEncryptionAgent(Utf8JsonWriter json, EncryptionAgent encryptionAgent)
        {
            json.WriteString(nameof(encryptionAgent.Protocol), encryptionAgent.Protocol);
            json.WriteString(nameof(encryptionAgent.EncryptionAlgorithm), encryptionAgent.EncryptionAlgorithm.ToString());
        }

        private static void WriteDictionary(Utf8JsonWriter json, IDictionary<string, string> dictionary)
        {
            foreach (var entry in dictionary)
            {
                json.WriteString(entry.Key, entry.Value);
            }
        }
        #endregion

        #region Deserialize
        public static EncryptionData Deserialize(string serializedData)
        {
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(serializedData));
            return DeserializeEncryptionData(ref reader);
        }

        public static EncryptionData DeserializeEncryptionData(ref Utf8JsonReader reader)
        {
            using JsonDocument json = JsonDocument.ParseValue(ref reader);
            JsonElement root = json.RootElement;
            return ReadEncryptionData(root);
        }

        public static EncryptionData ReadEncryptionData(JsonElement root)
        {
            var data = new EncryptionData();
            foreach (var property in root.EnumerateObject())
            {
                ReadPropertyValue(data, property);
            }
            return data;
        }

        private static void ReadPropertyValue(EncryptionData data, JsonProperty property)
        {
            if (property.NameEquals(nameof(data.EncryptionMode)))
            {
                data.EncryptionMode = property.Value.GetString();
            }
            else if (property.NameEquals(nameof(data.WrappedContentKey)))
            {
                var key = new WrappedKey();
                foreach (var subProperty in property.Value.EnumerateObject())
                {
                    ReadPropertyValue(key, subProperty);
                }
                data.WrappedContentKey = key;
            }
            else if (property.NameEquals(nameof(data.EncryptionAgent)))
            {
                var agent = new EncryptionAgent();
                foreach (var subProperty in property.Value.EnumerateObject())
                {
                    ReadPropertyValue(agent, subProperty);
                }
                data.EncryptionAgent = agent;
            }
            else if (property.NameEquals(nameof(data.ContentEncryptionIV)))
            {
                data.ContentEncryptionIV = Convert.FromBase64String(property.Value.GetString());
            }
            else if (property.NameEquals(nameof(data.KeyWrappingMetadata)))
            {
                var metadata = new Dictionary<string, string>();
                foreach (var entry in property.Value.EnumerateObject())
                {
                    metadata.Add(entry.Name, entry.Value.GetString());
                }
                data.KeyWrappingMetadata = metadata;
            }
        }

        private static void ReadPropertyValue(WrappedKey key, JsonProperty property)
        {
            if (property.NameEquals(nameof(key.Algorithm)))
            {
                key.Algorithm = property.Value.GetString();
            }
            else if (property.NameEquals(nameof(key.EncryptedKey)))
            {
                key.EncryptedKey = Convert.FromBase64String(property.Value.GetString());
            }
            else if (property.NameEquals(nameof(key.KeyId)))
            {
                key.KeyId = property.Value.GetString();
            }
        }

        private static void ReadPropertyValue(EncryptionAgent agent, JsonProperty property)
        {
            if (property.NameEquals(nameof(agent.EncryptionAlgorithm)))
            {
                agent.EncryptionAlgorithm = new ClientSideEncryptionAlgorithm(property.Value.GetString());
            }
            else if (property.NameEquals(nameof(agent.Protocol)))
            {
                agent.Protocol = property.Value.GetString();
            }
        }
        #endregion
    }
}
