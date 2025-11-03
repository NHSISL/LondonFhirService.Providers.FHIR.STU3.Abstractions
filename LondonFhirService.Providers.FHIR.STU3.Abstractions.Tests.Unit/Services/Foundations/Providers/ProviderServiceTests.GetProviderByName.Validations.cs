// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Foundations.Providers.Exceptions;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Services.Foundations;
using Moq;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Services.Foundations.Providers
{
    public partial class ProviderServiceTests
    {
        [Fact]
        public async Task ShouldThrowNullValidationExceptionOnGetProviderByNameAsync()
        {
            // given
            IEnumerable<IFhirProvider> nullFhirProvider = null;
            string randomProviderName = GetRandomString();
            string inputProviderName = randomProviderName;

            var providerServiceMock = new Mock<ProviderService>(nullFhirProvider)
            {
                CallBase = true
            };

            var nullProviderServiceException =
                new NullProviderServiceException(message: "Provider is null.");

            var expectedProviderServiceValidationException =
                new ProviderServiceValidationException(
                    message: "Provider validation errors occurred, please try again.",
                    innerException: nullProviderServiceException);

            // when
            Action getProviderByNameAction = () =>
                providerServiceMock.Object.GetProviderByName(inputProviderName);

            ProviderServiceValidationException actualProviderServiceValidationException =
                Assert.Throws<ProviderServiceValidationException>(getProviderByNameAction);

            // then
            actualProviderServiceValidationException.Should()
                .BeEquivalentTo(expectedProviderServiceValidationException);

            providerServiceMock.Verify(service =>
                service.ValidateOnGetProviderByName(inputProviderName),
                    Times.Once);

            providerServiceMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnGetProviderByNameAsync(string invalidText)
        {
            // given
            string invalidProviderName = invalidText;

            var invalidProviderServiceException =
                new InvalidProviderServiceException(
                    message: "Invalid decision. Please correct the errors and try again.");

            invalidProviderServiceException.AddData(
                key: "providerName",
                values: "Text is required");

            var expectedProviderServiceValidationException =
                new ProviderServiceValidationException(
                    message: "Provider validation errors occurred, please try again.",
                    innerException: invalidProviderServiceException);

            // when
            Action getProviderByNameAction = () =>
                providerService.GetProviderByName(invalidProviderName);

            ProviderServiceValidationException actualProviderServiceValidationException =
                Assert.Throws<ProviderServiceValidationException>(getProviderByNameAction);

            // then
            actualProviderServiceValidationException.Should()
                .BeEquivalentTo(expectedProviderServiceValidationException);
        }
    }
}
