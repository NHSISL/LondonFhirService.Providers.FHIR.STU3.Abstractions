// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Foundations.Providers.Exceptions;
using Xeptions;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Services.Foundations
{
    internal partial class ProviderService : IProviderService
    {
        virtual internal void ValidateOnGetProviderByName(string providerName)
        {
            ValidateProvidersIsNotNull(this.fhirProviders);

            Validate<InvalidProviderServiceException>(
               message: "Invalid decision. Please correct the errors and try again.",
               (Rule: IsInvalid(providerName), Parameter: nameof(providerName)));
        }

        private void ValidateProvidersIsNotNull(IEnumerable<IFhirProvider> fhirProviders)
        {
            if (fhirProviders is null || fhirProviders.Count() == 0)
            {
                throw new NullProviderServiceException(message: "Provider is null.");
            }
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static void Validate<T>(string message, params (dynamic Rule, string Parameter)[] validations)
            where T : Xeption
        {
            var invalidDataException = (T)Activator.CreateInstance(typeof(T), message);

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidDataException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidDataException.ThrowIfContainsErrors();
        }
    }
}
