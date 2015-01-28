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

using Hyak.Common;
using Microsoft.Azure;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Internal.Subscriptions.Rdfe.Models
{
    /// <summary>
    /// A standard service response including an HTTP status code and request
    /// ID.
    /// </summary>
    public partial class SubscriptionListOperationResponse : AzureOperationResponse, IEnumerable<Subscription>
    {
        private IList<Subscription> _subscriptions;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<Subscription> Subscriptions
        {
            get { return this._subscriptions; }
            set { this._subscriptions = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the SubscriptionListOperationResponse
        /// class.
        /// </summary>
        public SubscriptionListOperationResponse()
        {
            this.Subscriptions = new LazyList<Subscription>();
        }
        
        /// <summary>
        /// Gets the sequence of Subscriptions.
        /// </summary>
        public IEnumerator<Subscription> GetEnumerator()
        {
            return this.Subscriptions.GetEnumerator();
        }
        
        /// <summary>
        /// Gets the sequence of Subscriptions.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
