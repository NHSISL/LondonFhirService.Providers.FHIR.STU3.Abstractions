// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections;
using Xeptions;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Exceptions
{
    public class FhirAbstractionProviderValidationException : Xeption, IFhirValidationException
    {
        public FhirAbstractionProviderValidationException(string message, Xeption innerException, IDictionary data)
            : base(message, innerException, data)
        { }
    }
}