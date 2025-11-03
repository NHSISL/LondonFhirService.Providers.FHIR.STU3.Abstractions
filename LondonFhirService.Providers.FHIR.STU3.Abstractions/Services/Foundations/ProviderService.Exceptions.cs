// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Foundations.Providers.Exceptions;
using Xeptions;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Services.Foundations
{
    internal partial class ProviderService : IProviderService
    {
        private delegate IFhirProvider ReturningFhirProviderFunction();

        private IFhirProvider TryCatch(ReturningFhirProviderFunction returningFhirProviderFunction)
        {
            try
            {
                return returningFhirProviderFunction();
            }
            catch (NullProviderServiceException nullProviderServiceException)
            {
                throw CreateValidationException(nullProviderServiceException);
            }
            catch (InvalidProviderServiceException invalidProviderServiceException)
            {
                throw CreateValidationException(invalidProviderServiceException);
            }
            catch (Exception exception)
            {
                var failedProviderServiceException =
                    new FailedProviderServiceException(
                        message: "Failed provider service occurred, please contact support",
                        innerException: exception);

                throw CreateServiceException(failedProviderServiceException);
            }
        }

        private ProviderServiceValidationException CreateValidationException(Xeption exception)
        {
            var providerServiceValidationException =
                new ProviderServiceValidationException(
                    message: "Provider validation errors occurred, please try again.",
                    innerException: exception);

            return providerServiceValidationException;
        }

        private ProviderServiceException CreateServiceException(
            Xeption exception)
        {
            var providerServiceException =
                new ProviderServiceException(
                    message: "Provider service error occurred, contact support.",
                    innerException: exception);

            return providerServiceException;
        }
    }
}
