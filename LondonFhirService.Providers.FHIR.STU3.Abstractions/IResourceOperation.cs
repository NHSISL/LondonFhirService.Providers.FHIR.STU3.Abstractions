// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Capabilities;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions
{
    /// <summary>
    /// Canonical FHIR REST surface for a resource type.
    /// </summary>
    /// <typeparam name="TResource">FHIR STU3 resource type.</typeparam>
    public interface IResourceOperation<TResource> where TResource : Resource
    {
        /// <summary>
        /// Gets the capability statement for this resource. Describes which FHIR operations
        /// are supported, enabling discovery and validation of provider functionality at runtime.
        /// </summary>
        ResourceCapabilities Capabilities { get; }

        /// <summary>
        /// Read the current state of a resource by id.
        /// </summary>
        /// <param name="id">Logical id of the resource.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. 
        /// Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        ValueTask<TResource> Read(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Read a specific version of a resource.
        /// </summary>
        /// <param name="id">Logical id of the resource.</param>
        /// <param name="versionId">Version id of the resource.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. 
        /// Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        ValueTask<TResource> VRead(string id, string versionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve the change history for a specific resource.
        /// </summary>
        /// <param name="id">Logical id of the resource.</param>
        /// <param name="since">Optional: Only include changes since this time (_since).</param>
        /// <param name="count">Optional: Maximum number of results (_count).</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. 
        /// Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        ValueTask<Bundle> HistoryInstance(
            string id,
            DateTimeOffset? since = null,
            int? count = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Search for resources matching the given parameters.
        /// </summary>
        /// <param name="params">FHIR search parameters (query).</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. 
        /// Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        ValueTask<Bundle> Search(SearchParams @params, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve the history across all instances of the resource type.
        /// </summary>
        /// <param name="since">Optional: Only include changes since this time (_since).</param>
        /// <param name="count">Optional: Maximum number of results (_count).</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. 
        /// Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        ValueTask<Bundle> HistoryType(
            DateTimeOffset? since = null,
            int? count = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve the history across all resource types in the system.
        /// </summary>
        /// <param name="since">Optional: Only include changes since this time (_since).</param>
        /// <param name="count">Optional: Maximum number of results (_count).</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. 
        /// Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        ValueTask<Bundle> HistorySystem(
            DateTimeOffset? since = null,
            int? count = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a new resource.
        /// </summary>
        /// <param name="resource">The resource to create.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. 
        /// Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        ValueTask<TResource> Create(TResource resource, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update an existing resource by id.
        /// </summary>
        /// <param name="resource">The resource to update.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. 
        /// Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        ValueTask<TResource> Update(TResource resource, CancellationToken cancellationToken = default);

        /// <summary>
        /// Apply a patch to an existing resource.
        /// </summary>
        /// <param name="id">Logical id of the resource to patch.</param>
        /// <param name="patchParameters">Patch parameters (FHIR Parameters resource).</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. 
        /// Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        ValueTask<TResource> Patch(string id, Parameters patchParameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a resource by id.
        /// </summary>
        /// <param name="id">Logical id of the resource to delete.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. 
        /// Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        ValueTask<OperationOutcome> Delete(string id, CancellationToken cancellationToken = default);
    }
}
