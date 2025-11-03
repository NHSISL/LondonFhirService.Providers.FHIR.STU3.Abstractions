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
        public async Task ShouldThrowServiceExceptionOnGetProviderByNameAsync()
        {
            // given
            IEnumerable<IFhirProvider> nullFhirProvider = null;
            string randomProviderName = GetRandomString();
            string inputProviderName = randomProviderName;

            string randomMessage = GetRandomString();
            var serviceException = new Exception(message: randomMessage);

            var providerServiceMock = new Mock<ProviderService>(nullFhirProvider)
            {
                CallBase = true
            };

            providerServiceMock.Setup(service =>
                service.ValidateOnGetProviderByName(It.IsAny<string>()))
                    .Throws(serviceException);

            var failedProviderServiceException =
                new FailedProviderServiceException(
                    message: "Failed provider service occurred, please contact support",
                    innerException: serviceException);

            var expectedProviderServiceException =
                new ProviderServiceException(
                    message: "Provider service error occurred, contact support.",
                    innerException: failedProviderServiceException);

            // when
            Action getProviderByNameAction = () =>
                providerServiceMock.Object.GetProviderByName(inputProviderName);

            ProviderServiceException actualProviderServiceException =
                Assert.Throws<ProviderServiceException>(getProviderByNameAction);

            // then
            actualProviderServiceException.Should()
                .BeEquivalentTo(expectedProviderServiceException);

            providerServiceMock.Verify(service =>
                service.ValidateOnGetProviderByName(It.IsAny<string>()),
                    Times.Once);

            providerServiceMock.VerifyNoOtherCalls();
        }
    }
}
