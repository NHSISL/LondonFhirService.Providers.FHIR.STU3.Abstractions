// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections;
using Xeptions;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Exceptions
{
    public class FhirAbstractionProviderServiceException : Xeption, IFhirServiceException
    {
        public FhirAbstractionProviderServiceException(string message, Exception innerException, IDictionary data)
            : base(message, innerException, data)
        { }
    }
}