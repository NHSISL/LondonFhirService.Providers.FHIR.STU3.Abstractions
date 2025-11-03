// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Services.Foundations
{
    internal interface IProviderService
    {
        IFhirProvider GetProviderByName(string providerName);
    }
}
