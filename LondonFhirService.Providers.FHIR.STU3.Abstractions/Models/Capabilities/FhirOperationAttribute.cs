// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Capabilities
{
    /// <summary>
    /// Marks a method as a named FHIR operation supported by the provider.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class FhirOperationAttribute : Attribute
    {
        /// <summary>The canonical operation name (for example, "$everything").</summary>
        public string OperationName { get; }

        /// <summary>Creates the attribute for a given operation name.</summary>
        public FhirOperationAttribute(string operationName) =>
            OperationName = operationName ?? string.Empty;

        /// <summary>Creates the attribute with no explicit name.</summary>
        public FhirOperationAttribute() => OperationName = string.Empty;
    }
}
