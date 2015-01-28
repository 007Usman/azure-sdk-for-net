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
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Management.Resources
{
    public static partial class DeploymentOperationsExtensions
    {
        /// <summary>
        /// Cancel a currently running template deployment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Resources.IDeploymentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group. The name is case
        /// insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// Required. The name of the deployment.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static AzureOperationResponse Cancel(this IDeploymentOperations operations, string resourceGroupName, string deploymentName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IDeploymentOperations)s).CancelAsync(resourceGroupName, deploymentName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Cancel a currently running template deployment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Resources.IDeploymentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group. The name is case
        /// insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// Required. The name of the deployment.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<AzureOperationResponse> CancelAsync(this IDeploymentOperations operations, string resourceGroupName, string deploymentName)
        {
            return operations.CancelAsync(resourceGroupName, deploymentName, CancellationToken.None);
        }
        
        /// <summary>
        /// Create a named template deployment using a template.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Resources.IDeploymentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group. The name is case
        /// insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// Required. The name of the deployment.
        /// </param>
        /// <param name='parameters'>
        /// Required. Additional parameters supplied to the operation.
        /// </param>
        /// <returns>
        /// Template deployment operation create result.
        /// </returns>
        public static DeploymentOperationsCreateResult CreateOrUpdate(this IDeploymentOperations operations, string resourceGroupName, string deploymentName, BasicDeployment parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IDeploymentOperations)s).CreateOrUpdateAsync(resourceGroupName, deploymentName, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Create a named template deployment using a template.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Resources.IDeploymentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group. The name is case
        /// insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// Required. The name of the deployment.
        /// </param>
        /// <param name='parameters'>
        /// Required. Additional parameters supplied to the operation.
        /// </param>
        /// <returns>
        /// Template deployment operation create result.
        /// </returns>
        public static Task<DeploymentOperationsCreateResult> CreateOrUpdateAsync(this IDeploymentOperations operations, string resourceGroupName, string deploymentName, BasicDeployment parameters)
        {
            return operations.CreateOrUpdateAsync(resourceGroupName, deploymentName, parameters, CancellationToken.None);
        }
        
        /// <summary>
        /// Get a deployment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Resources.IDeploymentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group to get. The name is case
        /// insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// Required. The name of the deployment.
        /// </param>
        /// <returns>
        /// Template deployment information.
        /// </returns>
        public static DeploymentGetResult Get(this IDeploymentOperations operations, string resourceGroupName, string deploymentName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IDeploymentOperations)s).GetAsync(resourceGroupName, deploymentName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Get a deployment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Resources.IDeploymentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group to get. The name is case
        /// insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// Required. The name of the deployment.
        /// </param>
        /// <returns>
        /// Template deployment information.
        /// </returns>
        public static Task<DeploymentGetResult> GetAsync(this IDeploymentOperations operations, string resourceGroupName, string deploymentName)
        {
            return operations.GetAsync(resourceGroupName, deploymentName, CancellationToken.None);
        }
        
        /// <summary>
        /// Get a list of deployments.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Resources.IDeploymentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group to filter by. The name is
        /// case insensitive.
        /// </param>
        /// <param name='parameters'>
        /// Optional. Query parameters. If null is passed returns all
        /// deployments.
        /// </param>
        /// <returns>
        /// List of deployments.
        /// </returns>
        public static DeploymentListResult List(this IDeploymentOperations operations, string resourceGroupName, DeploymentListParameters parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IDeploymentOperations)s).ListAsync(resourceGroupName, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Get a list of deployments.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Resources.IDeploymentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group to filter by. The name is
        /// case insensitive.
        /// </param>
        /// <param name='parameters'>
        /// Optional. Query parameters. If null is passed returns all
        /// deployments.
        /// </param>
        /// <returns>
        /// List of deployments.
        /// </returns>
        public static Task<DeploymentListResult> ListAsync(this IDeploymentOperations operations, string resourceGroupName, DeploymentListParameters parameters)
        {
            return operations.ListAsync(resourceGroupName, parameters, CancellationToken.None);
        }
        
        /// <summary>
        /// Get a list of deployments.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Resources.IDeploymentOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. NextLink from the previous successful call to List
        /// operation.
        /// </param>
        /// <returns>
        /// List of deployments.
        /// </returns>
        public static DeploymentListResult ListNext(this IDeploymentOperations operations, string nextLink)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IDeploymentOperations)s).ListNextAsync(nextLink);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Get a list of deployments.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Resources.IDeploymentOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. NextLink from the previous successful call to List
        /// operation.
        /// </param>
        /// <returns>
        /// List of deployments.
        /// </returns>
        public static Task<DeploymentListResult> ListNextAsync(this IDeploymentOperations operations, string nextLink)
        {
            return operations.ListNextAsync(nextLink, CancellationToken.None);
        }
        
        /// <summary>
        /// Validate a deployment template.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Resources.IDeploymentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group. The name is case
        /// insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// Required. The name of the deployment.
        /// </param>
        /// <param name='parameters'>
        /// Required. Deployment to validate.
        /// </param>
        /// <returns>
        /// Information from validate template deployment response.
        /// </returns>
        public static DeploymentValidateResponse Validate(this IDeploymentOperations operations, string resourceGroupName, string deploymentName, BasicDeployment parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IDeploymentOperations)s).ValidateAsync(resourceGroupName, deploymentName, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Validate a deployment template.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Resources.IDeploymentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group. The name is case
        /// insensitive.
        /// </param>
        /// <param name='deploymentName'>
        /// Required. The name of the deployment.
        /// </param>
        /// <param name='parameters'>
        /// Required. Deployment to validate.
        /// </param>
        /// <returns>
        /// Information from validate template deployment response.
        /// </returns>
        public static Task<DeploymentValidateResponse> ValidateAsync(this IDeploymentOperations operations, string resourceGroupName, string deploymentName, BasicDeployment parameters)
        {
            return operations.ValidateAsync(resourceGroupName, deploymentName, parameters, CancellationToken.None);
        }
    }
}
