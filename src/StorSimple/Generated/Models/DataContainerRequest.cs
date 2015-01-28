// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Management.StorSimple.Models
{
    /// <summary>
    /// Info about the data container
    /// </summary>
    public partial class DataContainerRequest
    {
        private int _bandwidthRate;
        
        /// <summary>
        /// Required. Gets or sets the Bandwidth Rate.
        /// </summary>
        public int BandwidthRate
        {
            get { return this._bandwidthRate; }
            set { this._bandwidthRate = value; }
        }
        
        private string _encryptionKey;
        
        /// <summary>
        /// Optional. Gets or sets the encryption key.
        /// </summary>
        public string EncryptionKey
        {
            get { return this._encryptionKey; }
            set { this._encryptionKey = value; }
        }
        
        private string _instanceId;
        
        /// <summary>
        /// Optional. The instance identifier
        /// </summary>
        public string InstanceId
        {
            get { return this._instanceId; }
            set { this._instanceId = value; }
        }
        
        private bool _isDefault;
        
        /// <summary>
        /// Required. Gets or sets a value indicating whether this instance is
        /// default.
        /// </summary>
        public bool IsDefault
        {
            get { return this._isDefault; }
            set { this._isDefault = value; }
        }
        
        private bool _isEncryptionEnabled;
        
        /// <summary>
        /// Required. Gets or sets a value indicating whether this instance is
        /// encryption enabled.
        /// </summary>
        public bool IsEncryptionEnabled
        {
            get { return this._isEncryptionEnabled; }
            set { this._isEncryptionEnabled = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Required. The name of the entity
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private OperationInProgress _operationInProgress;
        
        /// <summary>
        /// Optional. Is operation in progress
        /// </summary>
        public OperationInProgress OperationInProgress
        {
            get { return this._operationInProgress; }
            set { this._operationInProgress = value; }
        }
        
        private bool _owned;
        
        /// <summary>
        /// Optional. Gets or sets a value indicating whether this
        /// DataContainer is owned.
        /// </summary>
        public bool Owned
        {
            get { return this._owned; }
            set { this._owned = value; }
        }
        
        private StorageAccountCredentialResponse _primaryStorageAccountCredential;
        
        /// <summary>
        /// Required. Gets or sets the Primary Storage Account Credential
        /// </summary>
        public StorageAccountCredentialResponse PrimaryStorageAccountCredential
        {
            get { return this._primaryStorageAccountCredential; }
            set { this._primaryStorageAccountCredential = value; }
        }
        
        private string _secretsEncryptionThumbprint;
        
        /// <summary>
        /// Optional. Gets or sets the SecretsEncryptionThumbprint.
        /// </summary>
        public string SecretsEncryptionThumbprint
        {
            get { return this._secretsEncryptionThumbprint; }
            set { this._secretsEncryptionThumbprint = value; }
        }
        
        private int _volumeCount;
        
        /// <summary>
        /// Optional. Gets or sets the volume count
        /// </summary>
        public int VolumeCount
        {
            get { return this._volumeCount; }
            set { this._volumeCount = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the DataContainerRequest class.
        /// </summary>
        public DataContainerRequest()
        {
        }
    }
}
