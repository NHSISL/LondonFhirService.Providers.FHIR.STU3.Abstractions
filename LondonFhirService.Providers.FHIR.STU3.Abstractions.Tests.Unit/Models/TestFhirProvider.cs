// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Models
{
    public sealed class TestFhirProvider : FhirProviderBase, IFhirProvider
    {
        public override IPatientResource Patients => new TestPatientResource();

        public override string Source => throw new System.NotImplementedException();

        public override string Code => throw new System.NotImplementedException();

        public override string System => throw new System.NotImplementedException();

        public override string DisplayName => throw new System.NotImplementedException();

        public override string FhirVersion => throw new System.NotImplementedException();
    }
}
