// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Linq;
using FluentAssertions;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Models;
using Xunit.Abstractions;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Capabilities
{
    public partial class ProviderCapabilityTests
    {
        ITestOutputHelper output;

        public ProviderCapabilityTests(ITestOutputHelper output) =>
            this.output = output;

        [Fact]
        public void CapabilitiesShouldContainOnlyEverything()
        {
            // given
            var provider = new TestFhirProvider();
            var providerName = provider.GetType().FullName ?? GetType().Name;
            var patientResourceName = nameof(TestFhirProvider.Patients);

            // when
            var capabilities = provider.Capabilities;

            // then
            output.WriteLine($"Provider Name: {capabilities.ProviderName}");
            output.WriteLine("   - Supported Resources:");

            foreach (var resource in capabilities.SupportedResources)
            {
                output.WriteLine($"      - {resource.ResourceName}");
                output.WriteLine($"         - Supported Operations:");
                foreach (var operation in resource.SupportedOperations)
                {
                    output.WriteLine($"            - {operation}");
                }
                output.WriteLine("");
            }

            providerName.Should().Be(capabilities.ProviderName);
            capabilities.SupportedResources.Should().ContainSingle();
            var patientResource = capabilities.SupportedResources.Single();
            patientResource.ResourceName.Should().Be(patientResourceName);
            patientResource.SupportedOperations.Should().ContainSingle();
            patientResource.SupportedOperations.Should().Contain("Everything");
        }
    }
}
