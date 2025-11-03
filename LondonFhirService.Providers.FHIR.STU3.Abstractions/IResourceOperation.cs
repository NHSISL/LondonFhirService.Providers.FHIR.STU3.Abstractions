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
    /// <summary>Canonical FHIR REST surface for a STU3 resource type.</summary>
    /// <typeparam name="TResource">FHIR STU3 resource type.</typeparam>
    public interface IResourceOperation<TResource> where TResource : Resource
    {
        /// <summary>Capability info for this resource provider.</summary>
        ResourceCapabilities Capabilities { get; }

        ValueTask<TResource> Read(string id, CancellationToken cancellationToken = default);
        ValueTask<TResource> VRead(string id, string versionId, CancellationToken cancellationToken = default);
        ValueTask<Bundle> HistoryInstance(
            string id, DateTimeOffset? since = null, int? count = null,
            CancellationToken cancellationToken = default);
        ValueTask<Bundle> Search(SearchParams @params, CancellationToken cancellationToken = default);
        ValueTask<Bundle> HistoryType(
            DateTimeOffset? since = null, int? count = null, CancellationToken cancellationToken = default);
        ValueTask<Bundle> HistorySystem(
            DateTimeOffset? since = null, int? count = null, CancellationToken cancellationToken = default);
        ValueTask<TResource> Create(TResource resource, CancellationToken cancellationToken = default);
        ValueTask<TResource> Update(TResource resource, CancellationToken cancellationToken = default);
        ValueTask<TResource> Patch(
            string id, Parameters patchParameters, CancellationToken cancellationToken = default);
        ValueTask<OperationOutcome> Delete(string id, CancellationToken cancellationToken = default);
    }
}
