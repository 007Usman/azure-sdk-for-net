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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;

namespace Microsoft.WindowsAzure.Management.TrafficManager
{
    /// <summary>
    /// The Traffic Manager API includes operations for managing definitions
    /// for a specified profile.
    /// </summary>
    public partial interface IDefinitionOperations
    {
        /// <summary>
        /// Creates a new definition for a specified profile.  (see
        /// http://msdn.microsoft.com/en-us/library/hh758257.aspx for more
        /// information)
        /// </summary>
        /// <param name='profileName'>
        /// The name of the profile to create a new definition for.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create Definition operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<AzureOperationResponse> CreateAsync(string profileName, DefinitionCreateParameters parameters, CancellationToken cancellationToken);
        
        /// <summary>
        /// Returns an existing profile definition.  (see
        /// http://msdn.microsoft.com/en-us/library/hh758248.aspx for more
        /// information)
        /// </summary>
        /// <param name='profileName'>
        /// The name of the profile to get definition from.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get Definition operation response.
        /// </returns>
        Task<DefinitionGetResponse> GetAsync(string profileName, CancellationToken cancellationToken);
        
        /// <summary>
        /// Returns all definitions of a profile  (see
        /// http://msdn.microsoft.com/en-us/library/hh758252.aspx for more
        /// information)
        /// </summary>
        /// <param name='profileName'>
        /// The name of the profile to return all definitions
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List Definitions operation response.
        /// </returns>
        Task<DefinitionsListResponse> ListAsync(string profileName, CancellationToken cancellationToken);
    }
}
