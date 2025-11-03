// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources
{
    /// <summary>
    /// STU3 Patient provider
    /// </summary>
    public interface IPatientResource : IResourceOperation<Patient>
    {
        /// <summary>
        /// Patient plus all related resources.
        /// Returns a Bundle (usually type "searchset").
        /// Optional parameters: start, end, _type, _since, _count (exposed as arguments here).
        /// </summary>
        /// <param name="id">Logical id of the patient resource.</param>
        /// <param name="start">Optional start date/time for records to include.</param>
        /// <param name="end">Optional end date/time for records to include.</param>
        /// <param name="typeFilter">Optional FHIR resource type filter (_type).</param>
        /// <param name="since">Optional date/time to restrict results to resources updated since this point (_since).</param>
        /// <param name="count">Optional maximum number of resources to return (_count).</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation.  
        /// Defaults to <see cref="CancellationToken.None"/> if not supplied.
        /// </param>
        ValueTask<Bundle> Everything(
            string id,
            DateTimeOffset? start = null,
            DateTimeOffset? end = null,
            string typeFilter = null,
            DateTimeOffset? since = null,
            int? count = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Patient matching operation.
        /// Request/response are Parameters/Bundle per spec (response Bundle type "searchset").
        /// </summary>
        /// <param name="parameters">Parameters resource containing the match criteria.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation.  
        /// Defaults to <see cref="CancellationToken.None"/> if not supplied.
        /// </param>
        ValueTask<Bundle> Match(
            Parameters parameters,
            CancellationToken cancellationToken = default);

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
        ValueTask<Bundle> GetStructuredRecord(
            string nhsNumber,
            DateTime? dateOfBirth = null,
            bool? demographicsOnly = null,
            bool? includeInactivePatients = null,
            CancellationToken cancellationToken = default);
    }
}
