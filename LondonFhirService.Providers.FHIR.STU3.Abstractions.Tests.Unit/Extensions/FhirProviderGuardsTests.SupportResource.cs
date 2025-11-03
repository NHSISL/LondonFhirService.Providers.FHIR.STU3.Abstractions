// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using FluentAssertions;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Extensions;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Models;


namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Extensions
{
    public partial class FhirProviderGuardsTests
    {
        [Fact]
        public void ReturnsTrueWhenResourceIsSupported()
        {
            // given
            IFhirProvider provider = new TestFhirProvider();
            OutputCapabilities(provider);

            // when
            var result = provider.SupportsResource("Patients");

            // then
            result.Should().BeTrue();
        }

        [Fact]
        public void ReturnsFalseWhenResourceIsNotSupported()
        {
            // given
            IFhirProvider provider = new TestFhirProvider();
            OutputCapabilities(provider);

            // when
            var result = provider.SupportsResource("Observation");

            // then
            result.Should().BeFalse();
        }

        [Fact]
        public void ReturnsTrueWhenResourceAndOperationAreSupported()
        {
            // given
            IFhirProvider provider = new TestFhirProvider();
            OutputCapabilities(provider);

            // when
            var result = provider.SupportsResource("Patients", "Everything");

            // then
            result.Should().BeTrue();
        }

        [Fact]
        public void ReturnsFalseWhenOperationIsNotSupportedOnResource()
        {
            // given
            IFhirProvider provider = new TestFhirProvider();
            OutputCapabilities(provider);

            // when
            var result = provider.SupportsResource("Patient", "Read");

            // then
            result.Should().BeFalse();
        }

        [Fact]
        public void ReturnsFalseWhenProviderIsNull()
        {
            // given
            IFhirProvider provider = null;
            OutputCapabilities(provider);

            // when
            var r1 = provider.SupportsResource("Patient");
            var r2 = provider.SupportsResource("Patient", "Everything");

            // then
            r1.Should().BeFalse();
            r2.Should().BeFalse();
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", null)]
        [InlineData("   ", null)]
        [InlineData(null, "Everything")]
        [InlineData("   ", "Everything")]
        public void ReturnsFalseWhenResourceIsNullOrWhitespace(string resourceName, string operationName)
        {
            // given
            IFhirProvider provider = new TestFhirProvider();
            OutputCapabilities(provider);

            // when
            var result = provider.SupportsResource(resourceName, operationName);

            // then
            result.Should().BeFalse();
        }

        [Fact]
        public void TreatsNullOperationAsResourceOnly()
        {
            // given
            IFhirProvider provider = new TestFhirProvider();
            OutputCapabilities(provider);

            // when
            var result = provider.SupportsResource("Patients", null);

            // then
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("\t")]
        [InlineData("\n")]
        [InlineData("\r\n")]
        public void ReturnsFalseWhenOperationIsWhitespace(string operationName)
        {
            // given
            IFhirProvider provider = new TestFhirProvider();
            OutputCapabilities(provider);

            // when
            var result = provider.SupportsResource("Patients", operationName);

            // then
            result.Should().BeFalse();
        }

        [Fact]
        public void ReturnsFalseWhenCaseDoesNotMatchOnResource()
        {
            // given
            IFhirProvider provider = new TestFhirProvider();
            OutputCapabilities(provider);

            // when
            var result1 = provider.SupportsResource("patient");
            var result2 = provider.SupportsResource("Patient", "everything");

            // then
            result1.Should().BeFalse();
            result2.Should().BeFalse();
        }

        [Fact]
        public void ReturnsFalseForEmptyProvider()
        {
            // given
            IFhirProvider provider = new EmptyFhirProvider();
            OutputCapabilities(provider);

            // when
            var result1 = provider.SupportsResource("Patient");
            var result2 = provider.SupportsResource("Patient", "Everything");

            // then
            result1.Should().BeFalse();
            result2.Should().BeFalse();
        }
    }
}
