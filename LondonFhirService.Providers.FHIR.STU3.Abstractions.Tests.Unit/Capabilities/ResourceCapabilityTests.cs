// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Linq;
using FluentAssertions;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Models;
using Xunit.Abstractions;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Capabilities
{
    public partial class ResourceCapabilityTests
    {
        ITestOutputHelper output;

        public ResourceCapabilityTests(ITestOutputHelper output) =>
            this.output = output;

        [Fact]
        public void CapabilitiesShouldContainOnlyEverything()
        {
            // given
            var resource = new TestPatientResource();

            var resourceName =
                resource.GetType().Name.EndsWith("Resource", StringComparison.Ordinal)
                    ? resource.GetType().Name[..^"Resource".Length]
                    : resource.GetType().Name;

            // when
            var capabilities = resource.Capabilities;

            // then
            output.WriteLine($"Resource Name: {capabilities.ResourceName}");
            output.WriteLine($"Supported Operations: ");

            foreach (var operation in capabilities.SupportedOperations)
            {
                output.WriteLine($"- {operation}");
            }

            capabilities.ResourceName.Should().Be(resourceName);
            var operations = capabilities.SupportedOperations.ToArray();
            operations.Single();
            operations.Should().Contain("EverythingAsync");
        }
    }
}
