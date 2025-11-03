// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Extensions
{
    /// <summary>
    /// Guard methods for checking whether a provider or resource operation
    /// supports specific resources or operations.
    /// </summary>
    public static class FhirProviderGuards
    {
        /// <summary>
        /// Checks whether a single provider supports a given resource and, optionally, an operation.
        /// If <paramref name="operationName"/> is <c>null</c>, this checks for the resource only.
        /// An empty/whitespace operation name returns <c>false</c>.
        /// Comparisons are <see cref="StringComparison.Ordinal"/>.
        /// </summary>
        public static bool SupportsResource(
            this IFhirProvider provider,
            string resourceName,
            string operationName = null)
        {
            if (provider?.Capabilities?.SupportedResources == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(resourceName))
            {
                return false;
            }

            var match = provider.Capabilities.SupportedResources
                .FirstOrDefault(resource =>
                    string.Equals(resource.ResourceName, resourceName, StringComparison.Ordinal));

            if (match == null)
            {
                return false;
            }

            if (operationName is null)
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(operationName))
            {
                return false;
            }

            var operations = match.SupportedOperations ?? Enumerable.Empty<string>();

            return operations.Any(operation =>
                string.Equals(operation, operationName, StringComparison.Ordinal));
        }

        /// <summary>
        /// Filters an enumerable of providers by whether they support a resource
        /// and, optionally, a specific operation on that resource.
        /// If <paramref name="operationName"/> is <c>null</c>, matches by resource only.
        /// Comparisons are <see cref="StringComparison.Ordinal"/>.
        /// </summary>
        public static IEnumerable<IFhirProvider> SupportsResource(
            this IEnumerable<IFhirProvider> providers,
            string resourceName,
            string operationName = null)
        {
            if (providers is null || string.IsNullOrWhiteSpace(resourceName))
            {
                return Enumerable.Empty<IFhirProvider>();
            }

            return providers.Where(provider =>
                provider?.Capabilities?.SupportedResources?.Any(resource =>
                    string.Equals(resource.ResourceName, resourceName, StringComparison.Ordinal) &&
                    (operationName == null ||
                        resource.SupportedOperations?.Any(operation =>
                            string.Equals(operation, operationName, StringComparison.Ordinal)) == true)) == true);
        }

        /// <summary>
        /// Checks whether a resource implementation supports a specific operation name.
        /// Comparisons are <see cref="StringComparison.Ordinal"/>.
        /// </summary>
        public static bool SupportsOperation<TResource>(
            this IResourceOperation<TResource> resource,
            string operationName)
            where TResource : Resource
        {
            if (resource?.Capabilities?.SupportedOperations == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(operationName))
            {
                return false;
            }

            return resource.Capabilities.SupportedOperations.Any(operation =>
                string.Equals(operation, operationName, StringComparison.Ordinal));
        }
    }
}
