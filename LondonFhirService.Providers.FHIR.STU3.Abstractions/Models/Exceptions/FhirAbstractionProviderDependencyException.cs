// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections;
using Xeptions;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Exceptions
{
    public class FhirAbstractionProviderDependencyException : Xeption, IFhirDependencyException
    {
        public FhirAbstractionProviderDependencyException(string message, Xeption innerException, IDictionary data)
            : base(message, innerException, data)
        { }
    }
}
