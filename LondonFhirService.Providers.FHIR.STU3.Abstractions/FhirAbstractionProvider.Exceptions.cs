// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Exceptions;
using Xeptions;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions
{
    /// <summary>Exception mapping helpers for FhirAbstractionProvider.</summary>
    public partial class FhirAbstractionProvider
    {
        private delegate T ReturningFunction<T>();

        private T TryCatch<T>(ReturningFunction<T> returningFunction)
        {
            try
            {
                return returningFunction();
            }
            catch (Xeption x) when
                (x is IFhirValidationException || x is IFhirDependencyException)
            {
                throw CreateDependencyException(x);
            }
            catch (Exception exception)
            {
                throw CreateServiceException(exception);
            }
        }

        private Exception CreateDependencyException(Exception exception) => exception;
        private Exception CreateServiceException(Exception exception) => exception;
    }
}
