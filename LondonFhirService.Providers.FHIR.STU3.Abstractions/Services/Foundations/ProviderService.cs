// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Services.Foundations
{
    internal partial class ProviderService : IProviderService
    {
        private readonly IReadOnlyCollection<IFhirProvider> fhirProviders;

        public ProviderService(IReadOnlyCollection<IFhirProvider> fhirProviders)
        {
            this.fhirProviders = fhirProviders;
        }

        public IFhirProvider GetProviderByName(string providerName) =>
        TryCatch(() =>
        {
            ValidateOnGetProviderByName(providerName);

            IFhirProvider fhirProvider = this.fhirProviders.FirstOrDefault(provider =>
                string.Equals(provider.ProviderName, providerName, StringComparison.OrdinalIgnoreCase));

            return fhirProvider;
        });
    }
}
