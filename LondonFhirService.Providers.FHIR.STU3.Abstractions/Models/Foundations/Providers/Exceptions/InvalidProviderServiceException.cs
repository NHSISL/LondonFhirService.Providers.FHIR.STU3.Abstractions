// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Xeptions;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Foundations.Providers.Exceptions
{
    public class InvalidProviderServiceException : Xeption
    {
        public InvalidProviderServiceException(string message)
            : base(message)
        { }
    }
}