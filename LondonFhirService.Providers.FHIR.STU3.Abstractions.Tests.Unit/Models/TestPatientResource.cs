// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Capabilities;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Models
{
    /// <summary>
    /// Patient resource operations. Demonstrates a non-standard operation (<c>$everything</c>) included via
    /// <see cref="FhirOperationAttribute"/>.
    /// </summary>
    public sealed class TestPatientResource : ResourceOperationBase<Patient>, IPatientResource
    {
        /// <summary>
        /// Returns the patient and related resources. The method name appears in capabilities because it is decorated
        /// with <see cref="FhirOperationAttribute"/>.
        /// </summary>
        /// <param name="id">Patient id.</param>
        /// <param name="start">Optional lower bound for event period.</param>
        /// <param name="end">Optional upper bound for event period.</param>
        /// <param name="typeFilter">Optional comma-separated type filter.</param>
        /// <param name="since">Optional timestamp to restrict to changes since.</param>
        /// <param name="count">Optional page size limit.</param>
        /// <returns>A bundle of resources related to the patient.</returns>
        [FhirOperation]
        public async ValueTask<Bundle> Everything(
            string id,
            DateTimeOffset? start = null,
            DateTimeOffset? end = null,
            string typeFilter = null,
            DateTimeOffset? since = null,
            int? count = null,
            CancellationToken cancellationToken = default)
        {
            return new Bundle { Type = Bundle.BundleType.Searchset };
        }

        /// <summary>
        /// Retrieves a patient's structured record using the GP Connect / CareConnect STU3
        /// <c>getstructuredrecord</c> operation (invoked against <see cref="Patient"/>),
        /// supplying a <see cref="Parameters"/> request per the operation definition.
        /// </summary>
        /// <remarks>
        /// Typical input parameters include:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <c>patientNHSNumber</c> — Identifier with system
        /// <c>https://fhir.hl7.org.uk/Id/nhs-number</c>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <c>patientDOB</c> (optional) — Identifier with system
        /// <c>https://fhir.hl7.org.uk/Id/dob</c>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <c>demographicsOnly</c> (optional) — Boolean flag, supplied as a part parameter
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <c>includeInactivePatients</c> (optional) — Boolean flag, supplied as a part parameter
        /// </description>
        /// </item>
        /// </list>
        /// Returns a <see cref="Bundle"/> (typically of type <c>collection</c> or <c>searchset</c>)
        /// containing the structured record content supported by the provider.
        /// </remarks>
        /// <param name="parameters">
        /// A <see cref="Parameters"/> resource conforming to the GP Connect / CareConnect
        /// operation definition for <c>getstructuredrecord</c>.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation.
        /// Defaults to <see cref="CancellationToken.None"/> if not supplied.
        /// </param>
        public ValueTask<Bundle> GetStructuredRecord(
            string nhsNumber,
            DateTime? dateOfBirth = null,
            bool? demographicsOnly = null,
            bool? includeInactivePatients = null,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        /// <summary>
        /// Patient matching operation. Not decorated, so it will not appear in capabilities.
        /// </summary>
        /// <param name="parameters">FHIR parameters for the match operation.</param>
        /// <returns>A bundle with match results.</returns>
        public async ValueTask<Bundle> Match(Parameters parameters,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();
    }
}
