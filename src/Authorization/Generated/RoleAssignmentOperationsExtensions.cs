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
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;

namespace Microsoft.Azure.Management.Authorization
{
    public static partial class RoleAssignmentOperationsExtensions
    {
        /// <summary>
        /// Create role assignment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='scope'>
        /// Required. Scope.
        /// </param>
        /// <param name='roleAssignmentName'>
        /// Required. Role assignment name.
        /// </param>
        /// <param name='parameters'>
        /// Required. Role assignment.
        /// </param>
        /// <returns>
        /// Role assignments creation results
        /// </returns>
        public static RoleAssignmentCreateResult Create(this IRoleAssignmentOperations operations, string scope, Guid roleAssignmentName, RoleAssignmentCreateParameters parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRoleAssignmentOperations)s).CreateAsync(scope, roleAssignmentName, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Create role assignment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='scope'>
        /// Required. Scope.
        /// </param>
        /// <param name='roleAssignmentName'>
        /// Required. Role assignment name.
        /// </param>
        /// <param name='parameters'>
        /// Required. Role assignment.
        /// </param>
        /// <returns>
        /// Role assignments creation results
        /// </returns>
        public static Task<RoleAssignmentCreateResult> CreateAsync(this IRoleAssignmentOperations operations, string scope, Guid roleAssignmentName, RoleAssignmentCreateParameters parameters)
        {
            return operations.CreateAsync(scope, roleAssignmentName, parameters, CancellationToken.None);
        }
        
        /// <summary>
        /// Create role assignment by Id.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='roleAssignmentId'>
        /// Required. Role assignment Id
        /// </param>
        /// <param name='parameters'>
        /// Required. Role assignment.
        /// </param>
        /// <returns>
        /// Role assignments creation results
        /// </returns>
        public static RoleAssignmentCreateResult CreateById(this IRoleAssignmentOperations operations, string roleAssignmentId, RoleAssignmentCreateParameters parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRoleAssignmentOperations)s).CreateByIdAsync(roleAssignmentId, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Create role assignment by Id.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='roleAssignmentId'>
        /// Required. Role assignment Id
        /// </param>
        /// <param name='parameters'>
        /// Required. Role assignment.
        /// </param>
        /// <returns>
        /// Role assignments creation results
        /// </returns>
        public static Task<RoleAssignmentCreateResult> CreateByIdAsync(this IRoleAssignmentOperations operations, string roleAssignmentId, RoleAssignmentCreateParameters parameters)
        {
            return operations.CreateByIdAsync(roleAssignmentId, parameters, CancellationToken.None);
        }
        
        /// <summary>
        /// Delete role assignment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='scope'>
        /// Required. Scope.
        /// </param>
        /// <param name='roleAssignmentName'>
        /// Required. Role assignment name.
        /// </param>
        /// <returns>
        /// Role assignments delete result
        /// </returns>
        public static RoleAssignmentDeleteResult Delete(this IRoleAssignmentOperations operations, string scope, Guid roleAssignmentName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRoleAssignmentOperations)s).DeleteAsync(scope, roleAssignmentName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Delete role assignment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='scope'>
        /// Required. Scope.
        /// </param>
        /// <param name='roleAssignmentName'>
        /// Required. Role assignment name.
        /// </param>
        /// <returns>
        /// Role assignments delete result
        /// </returns>
        public static Task<RoleAssignmentDeleteResult> DeleteAsync(this IRoleAssignmentOperations operations, string scope, Guid roleAssignmentName)
        {
            return operations.DeleteAsync(scope, roleAssignmentName, CancellationToken.None);
        }
        
        /// <summary>
        /// Delete role assignment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='roleAssignmentId'>
        /// Required. Role assignment Id
        /// </param>
        /// <returns>
        /// Role assignments delete result
        /// </returns>
        public static RoleAssignmentDeleteResult DeleteById(this IRoleAssignmentOperations operations, string roleAssignmentId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRoleAssignmentOperations)s).DeleteByIdAsync(roleAssignmentId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Delete role assignment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='roleAssignmentId'>
        /// Required. Role assignment Id
        /// </param>
        /// <returns>
        /// Role assignments delete result
        /// </returns>
        public static Task<RoleAssignmentDeleteResult> DeleteByIdAsync(this IRoleAssignmentOperations operations, string roleAssignmentId)
        {
            return operations.DeleteByIdAsync(roleAssignmentId, CancellationToken.None);
        }
        
        /// <summary>
        /// Get single role assignment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='scope'>
        /// Required. Scope.
        /// </param>
        /// <param name='roleAssignmentName'>
        /// Required. Role assignment name.
        /// </param>
        /// <returns>
        /// Role assignment get operation result.
        /// </returns>
        public static RoleAssignmentGetResult Get(this IRoleAssignmentOperations operations, string scope, Guid roleAssignmentName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRoleAssignmentOperations)s).GetAsync(scope, roleAssignmentName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Get single role assignment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='scope'>
        /// Required. Scope.
        /// </param>
        /// <param name='roleAssignmentName'>
        /// Required. Role assignment name.
        /// </param>
        /// <returns>
        /// Role assignment get operation result.
        /// </returns>
        public static Task<RoleAssignmentGetResult> GetAsync(this IRoleAssignmentOperations operations, string scope, Guid roleAssignmentName)
        {
            return operations.GetAsync(scope, roleAssignmentName, CancellationToken.None);
        }
        
        /// <summary>
        /// Get single role assignment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='roleAssignmentId'>
        /// Required. Role assignment Id
        /// </param>
        /// <returns>
        /// Role assignment get operation result.
        /// </returns>
        public static RoleAssignmentGetResult GetById(this IRoleAssignmentOperations operations, string roleAssignmentId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRoleAssignmentOperations)s).GetByIdAsync(roleAssignmentId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Get single role assignment.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='roleAssignmentId'>
        /// Required. Role assignment Id
        /// </param>
        /// <returns>
        /// Role assignment get operation result.
        /// </returns>
        public static Task<RoleAssignmentGetResult> GetByIdAsync(this IRoleAssignmentOperations operations, string roleAssignmentId)
        {
            return operations.GetByIdAsync(roleAssignmentId, CancellationToken.None);
        }
        
        /// <summary>
        /// Gets role assignments of the subscription.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='parameters'>
        /// Optional. List operation filters. If null will return all role
        /// assignments at, above or below the subscription.
        /// </param>
        /// <returns>
        /// Role assignment list operation result.
        /// </returns>
        public static RoleAssignmentListResult List(this IRoleAssignmentOperations operations, ListAssignmentsFilterParameters parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRoleAssignmentOperations)s).ListAsync(parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Gets role assignments of the subscription.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='parameters'>
        /// Optional. List operation filters. If null will return all role
        /// assignments at, above or below the subscription.
        /// </param>
        /// <returns>
        /// Role assignment list operation result.
        /// </returns>
        public static Task<RoleAssignmentListResult> ListAsync(this IRoleAssignmentOperations operations, ListAssignmentsFilterParameters parameters)
        {
            return operations.ListAsync(parameters, CancellationToken.None);
        }
        
        /// <summary>
        /// Gets role assignments of the resource.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='identity'>
        /// Required. Resource identity.
        /// </param>
        /// <param name='parameters'>
        /// Optional. List operation filters. If null will return all role
        /// assignments at, above or below the resource.
        /// </param>
        /// <returns>
        /// Role assignment list operation result.
        /// </returns>
        public static RoleAssignmentListResult ListForResource(this IRoleAssignmentOperations operations, string resourceGroupName, ResourceIdentity identity, ListAssignmentsFilterParameters parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRoleAssignmentOperations)s).ListForResourceAsync(resourceGroupName, identity, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Gets role assignments of the resource.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='identity'>
        /// Required. Resource identity.
        /// </param>
        /// <param name='parameters'>
        /// Optional. List operation filters. If null will return all role
        /// assignments at, above or below the resource.
        /// </param>
        /// <returns>
        /// Role assignment list operation result.
        /// </returns>
        public static Task<RoleAssignmentListResult> ListForResourceAsync(this IRoleAssignmentOperations operations, string resourceGroupName, ResourceIdentity identity, ListAssignmentsFilterParameters parameters)
        {
            return operations.ListForResourceAsync(resourceGroupName, identity, parameters, CancellationToken.None);
        }
        
        /// <summary>
        /// Gets role assignments of the resource group.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Optional. Resource group name.
        /// </param>
        /// <param name='parameters'>
        /// Optional. List operation filters. If null will return all role
        /// assignments at, above or below the resource group.
        /// </param>
        /// <returns>
        /// Role assignment list operation result.
        /// </returns>
        public static RoleAssignmentListResult ListForResourceGroup(this IRoleAssignmentOperations operations, string resourceGroupName, ListAssignmentsFilterParameters parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRoleAssignmentOperations)s).ListForResourceGroupAsync(resourceGroupName, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Gets role assignments of the resource group.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Optional. Resource group name.
        /// </param>
        /// <param name='parameters'>
        /// Optional. List operation filters. If null will return all role
        /// assignments at, above or below the resource group.
        /// </param>
        /// <returns>
        /// Role assignment list operation result.
        /// </returns>
        public static Task<RoleAssignmentListResult> ListForResourceGroupAsync(this IRoleAssignmentOperations operations, string resourceGroupName, ListAssignmentsFilterParameters parameters)
        {
            return operations.ListForResourceGroupAsync(resourceGroupName, parameters, CancellationToken.None);
        }
        
        /// <summary>
        /// Gets role assignments of the scope.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='scope'>
        /// Required. Scope.
        /// </param>
        /// <param name='parameters'>
        /// Optional. List operation filters. If null will return all role
        /// assignments at, above or below the subscription.
        /// </param>
        /// <returns>
        /// Role assignment list operation result.
        /// </returns>
        public static RoleAssignmentListResult ListForScope(this IRoleAssignmentOperations operations, string scope, ListAssignmentsFilterParameters parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRoleAssignmentOperations)s).ListForScopeAsync(scope, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Gets role assignments of the scope.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.Authorization.IRoleAssignmentOperations.
        /// </param>
        /// <param name='scope'>
        /// Required. Scope.
        /// </param>
        /// <param name='parameters'>
        /// Optional. List operation filters. If null will return all role
        /// assignments at, above or below the subscription.
        /// </param>
        /// <returns>
        /// Role assignment list operation result.
        /// </returns>
        public static Task<RoleAssignmentListResult> ListForScopeAsync(this IRoleAssignmentOperations operations, string scope, ListAssignmentsFilterParameters parameters)
        {
            return operations.ListForScopeAsync(scope, parameters, CancellationToken.None);
        }
    }
}
