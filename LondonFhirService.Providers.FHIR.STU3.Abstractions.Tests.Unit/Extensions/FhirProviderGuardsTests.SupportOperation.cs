// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using FluentAssertions;
using Hl7.Fhir.Model;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Extensions;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Models;


namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Extensions
{
    public partial class FhirProviderGuardsTests
    {
        [Fact]
        public void ReturnsTrueWhenOperationIsSupported()
        {
            // given
            IResourceOperation<Patient> resource = new TestPatientResource();
            OutputCapabilities(resource);

            // when
            bool result = resource.SupportsOperation("Everything");

            // then
            result.Should().BeTrue();
        }

        [Fact]
        public void ReturnsFalseWhenOperationIsNotSupported()
        {
            // given
            IResourceOperation<Patient> resource = new TestPatientResource();
            OutputCapabilities(resource);

            // when
            bool result = resource.SupportsOperation("Read");

            // then
            result.Should().BeFalse();
        }

        [Fact]
        public void ReturnsFalseWhenResourceIsNull()
        {
            // given
            IResourceOperation<Patient> resource = null;
            OutputCapabilities(resource);

            // when
            bool result = resource.SupportsOperation("Everything");

            // then
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ReturnsFalseWhenOperationNameIsNullOrWhitespace(string operationName)
        {
            // given
            IResourceOperation<Patient> resource = new TestPatientResource();
            OutputCapabilities(resource);

            // when
            bool result = resource.SupportsOperation(operationName);

            // then
            result.Should().BeFalse();
        }

        [Fact]
        public void ReturnsFalseWhenCaseDoesNotMatch()
        {
            // given
            IResourceOperation<Patient> resource = new TestPatientResource();
            OutputCapabilities(resource);

            // when
            bool result = resource.SupportsOperation("everything");

            // then
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("Everything", true)]
        [InlineData("Read", false)]
        [InlineData("Search", false)]
        public void EvaluatesKnownOperationsConsistently(string operationName, bool expected)
        {
            // given
            IResourceOperation<Patient> resource = new TestPatientResource();
            OutputCapabilities(resource);

            // when
            bool result = resource.SupportsOperation(operationName);

            // then
            result.Should().Be(expected);
        }
    }
}
