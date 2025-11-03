// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Models
{
    public sealed class EmptyFhirProvider : FhirProviderBase, IFhirProvider
    {
        public override string Source => throw new System.NotImplementedException();

        public override string Code => throw new System.NotImplementedException();

        public override string System => throw new System.NotImplementedException();
    }
}
