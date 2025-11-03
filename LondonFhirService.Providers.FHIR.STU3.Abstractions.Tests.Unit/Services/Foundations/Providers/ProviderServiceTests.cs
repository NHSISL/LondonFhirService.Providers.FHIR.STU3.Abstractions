// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;
using System.Collections.Immutable;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Services.Foundations;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Models;
using Tynamix.ObjectFiller;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Services.Foundations.Providers
{
    public partial class ProviderServiceTests
    {
        private readonly IEnumerable<IFhirProvider> fhirProviders;
        private readonly ProviderService providerService;

        public ProviderServiceTests()
        {
            this.fhirProviders = new List<IFhirProvider>
            {
                new TestFhirProvider()
            };

            this.providerService = new ProviderService(this.fhirProviders.ToImmutableArray());
        }

        private static string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();
    }
}
