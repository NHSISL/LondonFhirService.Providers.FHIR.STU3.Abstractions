// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Capabilities
{
    /// <summary>Capabilities for a single STU3 resource.</summary>
    public sealed class ResourceCapabilities
    {
        /// <summary>Canonical FHIR resource name (for example, "Patient").</summary>
        public string ResourceName { get; init; } = string.Empty;

        /// <summary>Supported operation names on this resource.</summary>
        public IReadOnlyCollection<string> SupportedOperations { get; init; } =
            Array.Empty<string>();
    }
}
