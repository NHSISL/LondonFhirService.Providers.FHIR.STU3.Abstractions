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
            bool result = resource.SupportsOperation("EverythingAsync");

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
            bool result = resource.SupportsOperation("ReadAsync");

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
            bool result = resource.SupportsOperation("EverythingAsync");

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
            bool result = resource.SupportsOperation("everythingAsync");

            // then
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("EverythingAsync", true)]
        [InlineData("ReadAsync", false)]
        [InlineData("SearchAsync", false)]
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
