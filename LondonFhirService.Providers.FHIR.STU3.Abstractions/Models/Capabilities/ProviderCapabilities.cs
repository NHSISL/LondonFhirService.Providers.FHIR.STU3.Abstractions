// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Capabilities
{
    /// <summary>Capabilities for a single STU3 provider.</summary>
    public sealed class ProviderCapabilities
    {
        /// <summary>Canonical provider name.</summary>
        public string ProviderName { get; init; } = string.Empty;

        /// <summary>Implemented resources on this provider.</summary>
        public IReadOnlyCollection<ResourceCapabilities> SupportedResources { get; init; } =
            Array.Empty<ResourceCapabilities>();
    }
}
