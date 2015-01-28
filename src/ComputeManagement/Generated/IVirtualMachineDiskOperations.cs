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
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Management.Compute
{
    /// <summary>
    /// The Service Management API includes operations for managing the disks
    /// in your subscription.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157188.aspx for
    /// more information)
    /// </summary>
    public partial interface IVirtualMachineDiskOperations
    {
        /// <summary>
        /// The Create Data Disk operation adds a data disk to a virtual
        /// machine. There are three ways to create the data disk using the
        /// Add Data Disk operation. Option 1 - Attach an empty data disk to
        /// the role by specifying the disk label and location of the disk
        /// image. Do not include the DiskName and SourceMediaLink elements in
        /// the request body. Include the MediaLink element and reference a
        /// blob that is in the same geographical region as the role. You can
        /// also omit the MediaLink element. In this usage, Azure will create
        /// the data disk in the storage account configured as default for the
        /// role. Option 2 - Attach an existing data disk that is in the image
        /// repository. Do not include the DiskName and SourceMediaLink
        /// elements in the request body. Specify the data disk to use by
        /// including the DiskName element. Note: If included the in the
        /// response body, the MediaLink and LogicalDiskSizeInGB elements are
        /// ignored. Option 3 - Specify the location of a blob in your storage
        /// account that contain a disk image to use. Include the
        /// SourceMediaLink element. Note: If the MediaLink element
        /// isincluded, it is ignored.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157199.aspx
        /// for more information)
        /// </summary>
        /// <param name='serviceName'>
        /// The name of your service.
        /// </param>
        /// <param name='deploymentName'>
        /// The name of the deployment.
        /// </param>
        /// <param name='roleName'>
        /// The name of the role to add the data disk to.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create Virtual Machine Data Disk
        /// operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<AzureOperationResponse> BeginCreatingDataDiskAsync(string serviceName, string deploymentName, string roleName, VirtualMachineDataDiskCreateParameters parameters, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Begin Deleting Data Disk operation removes the specified data
        /// disk from a virtual machine.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157179.aspx
        /// for more information)
        /// </summary>
        /// <param name='serviceName'>
        /// The name of your service.
        /// </param>
        /// <param name='deploymentName'>
        /// The name of the deployment.
        /// </param>
        /// <param name='roleName'>
        /// The name of the role to delete the data disk from.
        /// </param>
        /// <param name='logicalUnitNumber'>
        /// The logical unit number of the disk.
        /// </param>
        /// <param name='deleteFromStorage'>
        /// Specifies that the source blob for the disk should also be deleted
        /// from storage.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<AzureOperationResponse> BeginDeletingDataDiskAsync(string serviceName, string deploymentName, string roleName, int logicalUnitNumber, bool deleteFromStorage, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Create Data Disk operation adds a data disk to a virtual
        /// machine. There are three ways to create the data disk using the
        /// Add Data Disk operation. Option 1 - Attach an empty data disk to
        /// the role by specifying the disk label and location of the disk
        /// image. Do not include the DiskName and SourceMediaLink elements in
        /// the request body. Include the MediaLink element and reference a
        /// blob that is in the same geographical region as the role. You can
        /// also omit the MediaLink element. In this usage, Azure will create
        /// the data disk in the storage account configured as default for the
        /// role. Option 2 - Attach an existing data disk that is in the image
        /// repository. Do not include the DiskName and SourceMediaLink
        /// elements in the request body. Specify the data disk to use by
        /// including the DiskName element. Note: If included the in the
        /// response body, the MediaLink and LogicalDiskSizeInGB elements are
        /// ignored. Option 3 - Specify the location of a blob in your storage
        /// account that contain a disk image to use. Include the
        /// SourceMediaLink element. Note: If the MediaLink element
        /// isincluded, it is ignored.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157199.aspx
        /// for more information)
        /// </summary>
        /// <param name='serviceName'>
        /// The name of your service.
        /// </param>
        /// <param name='deploymentName'>
        /// The name of the deployment.
        /// </param>
        /// <param name='roleName'>
        /// The name of the role to add the data disk to.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create Virtual Machine Data Disk
        /// operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself. If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request. If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request and error information regarding
        /// the failure.
        /// </returns>
        Task<OperationStatusResponse> CreateDataDiskAsync(string serviceName, string deploymentName, string roleName, VirtualMachineDataDiskCreateParameters parameters, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Create Disk operation adds a disk to the user image repository.
        /// The disk can be an operating system disk or a data disk.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157178.aspx
        /// for more information)
        /// </summary>
        /// <param name='parameters'>
        /// Parameters supplied to the Create Virtual Machine Disk operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A virtual machine disk associated with your subscription.
        /// </returns>
        Task<VirtualMachineDiskCreateResponse> CreateDiskAsync(VirtualMachineDiskCreateParameters parameters, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Delete Data Disk operation removes the specified data disk from
        /// a virtual machine.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157179.aspx
        /// for more information)
        /// </summary>
        /// <param name='serviceName'>
        /// The name of your service.
        /// </param>
        /// <param name='deploymentName'>
        /// The name of the deployment.
        /// </param>
        /// <param name='roleName'>
        /// The name of the role to delete the data disk from.
        /// </param>
        /// <param name='logicalUnitNumber'>
        /// The logical unit number of the disk.
        /// </param>
        /// <param name='deleteFromStorage'>
        /// Specifies that the source blob for the disk should also be deleted
        /// from storage.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself. If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request. If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request and error information regarding
        /// the failure.
        /// </returns>
        Task<OperationStatusResponse> DeleteDataDiskAsync(string serviceName, string deploymentName, string roleName, int logicalUnitNumber, bool deleteFromStorage, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Delete Disk operation deletes the specified data or operating
        /// system disk from your image repository.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157200.aspx
        /// for more information)
        /// </summary>
        /// <param name='name'>
        /// The name of the disk to delete.
        /// </param>
        /// <param name='deleteFromStorage'>
        /// Specifies that the source blob for the disk should also be deleted
        /// from storage.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<AzureOperationResponse> DeleteDiskAsync(string name, bool deleteFromStorage, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Get Data Disk operation retrieves the specified data disk from
        /// a virtual machine.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157180.aspx
        /// for more information)
        /// </summary>
        /// <param name='serviceName'>
        /// The name of your service.
        /// </param>
        /// <param name='deploymentName'>
        /// The name of the deployment.
        /// </param>
        /// <param name='roleName'>
        /// The name of the role.
        /// </param>
        /// <param name='logicalUnitNumber'>
        /// The logical unit number of the disk.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get Data Disk operation response.
        /// </returns>
        Task<VirtualMachineDataDiskGetResponse> GetDataDiskAsync(string serviceName, string deploymentName, string roleName, int logicalUnitNumber, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Get Disk operation retrieves a disk from the user image
        /// repository. The disk can be an operating system disk or a data
        /// disk.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157178.aspx
        /// for more information)
        /// </summary>
        /// <param name='name'>
        /// The name of the disk.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A virtual machine disk associated with your subscription.
        /// </returns>
        Task<VirtualMachineDiskGetResponse> GetDiskAsync(string name, CancellationToken cancellationToken);
        
        /// <summary>
        /// The List Disks operation retrieves a list of the disks in your
        /// image repository.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157176.aspx
        /// for more information)
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List Disks operation response.
        /// </returns>
        Task<VirtualMachineDiskListResponse> ListDisksAsync(CancellationToken cancellationToken);
        
        /// <summary>
        /// The Update Data Disk operation updates the specified data disk
        /// attached to the specified virtual machine.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157190.aspx
        /// for more information)
        /// </summary>
        /// <param name='serviceName'>
        /// The name of your service.
        /// </param>
        /// <param name='deploymentName'>
        /// The name of the deployment.
        /// </param>
        /// <param name='roleName'>
        /// The name of the role to add the data disk to.
        /// </param>
        /// <param name='logicalUnitNumber'>
        /// The logical unit number of the disk.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Update Virtual Machine Data Disk
        /// operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<AzureOperationResponse> UpdateDataDiskAsync(string serviceName, string deploymentName, string roleName, int logicalUnitNumber, VirtualMachineDataDiskUpdateParameters parameters, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Add Disk operation adds a disk to the user image repository.
        /// The disk can be an operating system disk or a data disk.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj157178.aspx
        /// for more information)
        /// </summary>
        /// <param name='name'>
        /// The name of the disk being updated.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Update Virtual Machine Disk operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A virtual machine disk associated with your subscription.
        /// </returns>
        Task<VirtualMachineDiskUpdateResponse> UpdateDiskAsync(string name, VirtualMachineDiskUpdateParameters parameters, CancellationToken cancellationToken);
    }
}
