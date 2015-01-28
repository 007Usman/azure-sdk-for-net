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
using Microsoft.WindowsAzure.Management.ServiceBus;
using Microsoft.WindowsAzure.Management.ServiceBus.Models;

namespace Microsoft.WindowsAzure.Management.ServiceBus
{
    /// <summary>
    /// The Service Bus Management API is a REST API for managing Service Bus
    /// queues, topics, rules and subscriptions.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780776.aspx for
    /// more information)
    /// </summary>
    public static partial class QueueOperationsExtensions
    {
        /// <summary>
        /// Creates a new queue. Once created, this queue's resource manifest
        /// is immutable. This operation is idempotent. Repeating the create
        /// call, after a queue with same name has been created successfully,
        /// will result in a 409 Conflict error message.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj856295.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.IQueueOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='queue'>
        /// Required. The service bus queue.
        /// </param>
        /// <returns>
        /// A response to a request for a particular queue.
        /// </returns>
        public static ServiceBusQueueResponse Create(this IQueueOperations operations, string namespaceName, ServiceBusQueueCreateParameters queue)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IQueueOperations)s).CreateAsync(namespaceName, queue);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Creates a new queue. Once created, this queue's resource manifest
        /// is immutable. This operation is idempotent. Repeating the create
        /// call, after a queue with same name has been created successfully,
        /// will result in a 409 Conflict error message.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj856295.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.IQueueOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='queue'>
        /// Required. The service bus queue.
        /// </param>
        /// <returns>
        /// A response to a request for a particular queue.
        /// </returns>
        public static Task<ServiceBusQueueResponse> CreateAsync(this IQueueOperations operations, string namespaceName, ServiceBusQueueCreateParameters queue)
        {
            return operations.CreateAsync(namespaceName, queue, CancellationToken.None);
        }
        
        /// <summary>
        /// Deletes an existing queue. This operation will also remove all
        /// associated state including messages in the queue.  (see
        /// http://msdn.microsoft.com/en-us/library/hh780747.aspx for more
        /// information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.IQueueOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='queueName'>
        /// Required. The queue name.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static AzureOperationResponse Delete(this IQueueOperations operations, string namespaceName, string queueName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IQueueOperations)s).DeleteAsync(namespaceName, queueName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Deletes an existing queue. This operation will also remove all
        /// associated state including messages in the queue.  (see
        /// http://msdn.microsoft.com/en-us/library/hh780747.aspx for more
        /// information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.IQueueOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='queueName'>
        /// Required. The queue name.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<AzureOperationResponse> DeleteAsync(this IQueueOperations operations, string namespaceName, string queueName)
        {
            return operations.DeleteAsync(namespaceName, queueName, CancellationToken.None);
        }
        
        /// <summary>
        /// The queue description is an XML AtomPub document that defines the
        /// desired semantics for a subscription. The queue description
        /// contains the following properties. For more information, see the
        /// QueueDescription Properties topic.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780773.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.IQueueOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='queueName'>
        /// Required. The queue name.
        /// </param>
        /// <returns>
        /// A response to a request for a particular queue.
        /// </returns>
        public static ServiceBusQueueResponse Get(this IQueueOperations operations, string namespaceName, string queueName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IQueueOperations)s).GetAsync(namespaceName, queueName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// The queue description is an XML AtomPub document that defines the
        /// desired semantics for a subscription. The queue description
        /// contains the following properties. For more information, see the
        /// QueueDescription Properties topic.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780773.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.IQueueOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='queueName'>
        /// Required. The queue name.
        /// </param>
        /// <returns>
        /// A response to a request for a particular queue.
        /// </returns>
        public static Task<ServiceBusQueueResponse> GetAsync(this IQueueOperations operations, string namespaceName, string queueName)
        {
            return operations.GetAsync(namespaceName, queueName, CancellationToken.None);
        }
        
        /// <summary>
        /// Gets the set of connection strings for a queue.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.IQueueOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='queueName'>
        /// Required. The queue name.
        /// </param>
        /// <returns>
        /// The set of connection details for a service bus entity.
        /// </returns>
        public static ServiceBusConnectionDetailsResponse GetConnectionDetails(this IQueueOperations operations, string namespaceName, string queueName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IQueueOperations)s).GetConnectionDetailsAsync(namespaceName, queueName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Gets the set of connection strings for a queue.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.IQueueOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='queueName'>
        /// Required. The queue name.
        /// </param>
        /// <returns>
        /// The set of connection details for a service bus entity.
        /// </returns>
        public static Task<ServiceBusConnectionDetailsResponse> GetConnectionDetailsAsync(this IQueueOperations operations, string namespaceName, string queueName)
        {
            return operations.GetConnectionDetailsAsync(namespaceName, queueName, CancellationToken.None);
        }
        
        /// <summary>
        /// Enumerates the queues in the service namespace. The result is
        /// returned in pages, each containing up to 100 queues. If the
        /// namespace contains more than 100 queues, a feed is returned that
        /// contains the first page and a next link with the URI to view the
        /// next page of data.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780759.asp
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.IQueueOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <returns>
        /// A response to a request for a list of queues.
        /// </returns>
        public static ServiceBusQueuesResponse List(this IQueueOperations operations, string namespaceName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IQueueOperations)s).ListAsync(namespaceName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Enumerates the queues in the service namespace. The result is
        /// returned in pages, each containing up to 100 queues. If the
        /// namespace contains more than 100 queues, a feed is returned that
        /// contains the first page and a next link with the URI to view the
        /// next page of data.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780759.asp
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.IQueueOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <returns>
        /// A response to a request for a list of queues.
        /// </returns>
        public static Task<ServiceBusQueuesResponse> ListAsync(this IQueueOperations operations, string namespaceName)
        {
            return operations.ListAsync(namespaceName, CancellationToken.None);
        }
        
        /// <summary>
        /// Updates the queue description and makes a call to update
        /// corresponding DB entries.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj856305.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.IQueueOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='queue'>
        /// Required. The service bus queue.
        /// </param>
        /// <returns>
        /// A response to a request for a particular queue.
        /// </returns>
        public static ServiceBusQueueResponse Update(this IQueueOperations operations, string namespaceName, ServiceBusQueue queue)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IQueueOperations)s).UpdateAsync(namespaceName, queue);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Updates the queue description and makes a call to update
        /// corresponding DB entries.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj856305.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.IQueueOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// Required. The namespace name.
        /// </param>
        /// <param name='queue'>
        /// Required. The service bus queue.
        /// </param>
        /// <returns>
        /// A response to a request for a particular queue.
        /// </returns>
        public static Task<ServiceBusQueueResponse> UpdateAsync(this IQueueOperations operations, string namespaceName, ServiceBusQueue queue)
        {
            return operations.UpdateAsync(namespaceName, queue, CancellationToken.None);
        }
    }
}
