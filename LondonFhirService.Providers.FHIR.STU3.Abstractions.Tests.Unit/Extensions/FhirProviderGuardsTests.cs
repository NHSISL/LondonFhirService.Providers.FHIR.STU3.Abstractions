// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Capabilities;
using Moq;
using Xunit.Abstractions;


namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Extensions
{
    public partial class FhirProviderGuardsTests
    {
        ITestOutputHelper output;

        public FhirProviderGuardsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        private void OutputCapabilities(IFhirProvider provider)
        {
            if (provider == null)
            {
                output.WriteLine("Provider Capabilities: null");

                return;
            }

            output.WriteLine($"Provider Name: {provider.Capabilities.ProviderName}");
            output.WriteLine("   - Supported Resources:");

            foreach (var resource in provider.Capabilities.SupportedResources)
            {
                output.WriteLine($"      - {resource.ResourceName}");
                output.WriteLine($"         - Supported Operations:");

                foreach (var operation in resource.SupportedOperations)
                {
                    output.WriteLine($"            - {operation}");
                }

                output.WriteLine("");
            }
        }

        private void OutputCapabilities<TResource>(IResourceOperation<TResource> resource)
            where TResource : Resource
        {
            if (resource == null)
            {
                output.WriteLine("Resource Capabilities: null");

                return;
            }

            output.WriteLine($"Resource Name: {resource.Capabilities.ResourceName}");
            output.WriteLine("   - Supported Operations:");

            foreach (var operation in resource.Capabilities.SupportedOperations)
            {
                output.WriteLine($"      - {operation}");
            }

            output.WriteLine(string.Empty);
        }

        private static IFhirProvider MakeProvider(
            string name,
            params (string Resource, string[] Operations)[] resources)
        {
            var providerCaps = new ProviderCapabilities
            {
                ProviderName = name,
                SupportedResources = resources.Select(r => new ResourceCapabilities
                {
                    ResourceName = r.Resource,
                    SupportedOperations = r.Operations?.ToList()
                }).ToList()
            };

            var mock = new Mock<IFhirProvider>(MockBehavior.Strict);
            mock.SetupGet(p => p.Capabilities).Returns(providerCaps);

            // If IFhirProvider has more required members, add minimal setups here.

            return mock.Object;
        }

        private static IFhirProvider MakeProviderWithNullCapabilities()
        {
            var mock = new Mock<IFhirProvider>(MockBehavior.Strict);
            mock.SetupGet(p => p.Capabilities).Returns((ProviderCapabilities)null);
            return mock.Object;
        }

        private static IFhirProvider MakeProviderWithNullResources(string name)
        {
            var providerCaps = new ProviderCapabilities
            {
                ProviderName = name,
                SupportedResources = null
            };

            var mock = new Mock<IFhirProvider>(MockBehavior.Strict);
            mock.SetupGet(p => p.Capabilities).Returns(providerCaps);
            return mock.Object;
        }

        private static IFhirProvider MakeProviderWithNullOps(string name, string resourceName)
        {
            var providerCaps = new ProviderCapabilities
            {
                ProviderName = name,
                SupportedResources = new List<ResourceCapabilities>
                {
                    new ResourceCapabilities
                    {
                        ResourceName = resourceName,
                        SupportedOperations = null
                    }
                }
            };

            var mock = new Mock<IFhirProvider>(MockBehavior.Strict);
            mock.SetupGet(p => p.Capabilities).Returns(providerCaps);
            return mock.Object;
        }
    }
}
