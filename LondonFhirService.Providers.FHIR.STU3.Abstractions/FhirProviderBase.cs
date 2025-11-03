// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Capabilities;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions
{
    /// <summary>Base class for concrete FHIR STU3 providers. Override the resources you support.</summary>
    public abstract class FhirProviderBase : IFhirProvider
    {
        private ProviderCapabilities providerCapabilities;

        /// <summary>Gets the unique name used to identify the provider. Defaults to the full type name.</summary>
        public virtual string ProviderName => GetType().FullName ?? GetType().Name;

        /// <summary>Gets the source system URI used for <c>Bundle.meta.source</c>.</summary>
        public abstract string Source { get; }

        /// <summary>Gets the provider code used for <c>Bundle.meta.tag.code</c>.</summary>
        public abstract string Code { get; }

        /// <summary>Gets the CodeSystem used for <c>Bundle.meta.tag.system</c>.</summary>
        public abstract string System { get; }

        /// <summary>
        /// Gets the provider capabilities, including the set of supported resources. This is computed lazily
        /// by scanning all public instance properties that implement <see cref="IResourceOperation{TResource}"/>
        /// and are non-null, and then reading each instance’s <c>Capabilities</c> property.
        /// </summary>
        public ProviderCapabilities Capabilities => providerCapabilities ??= ComputeCapabilities();

        /// <summary>
        /// Computes the provider capabilities by reflecting over resource properties.
        /// </summary>
        /// <returns>The computed <see cref="ProviderCapabilities"/>.</returns>
        protected virtual ProviderCapabilities ComputeCapabilities()
        {
            var resourceCapabilities = new List<ResourceCapabilities>();

            var properties = GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(property => property.GetMethod != null &&
                    ImplementsIResourceOperation(property.PropertyType));

            foreach (var property in properties)
            {
                var instance = property.GetValue(this);
                if (instance is null)
                    continue;

                if (TryGetResourceCapabilities(instance, out var implCaps))
                {
                    // IMPORTANT: Use the PROVIDER PROPERTY NAME for the resource name,
                    // but keep the supported operations from the implementation.
                    resourceCapabilities.Add(new ResourceCapabilities
                    {
                        ResourceName = property.Name,
                        SupportedOperations = implCaps.SupportedOperations
                    });
                }
            }

            var uniqueSorted = resourceCapabilities
                .Where(capability => capability is not null)
                .GroupBy(capability => capability.ResourceName, StringComparer.Ordinal)
                .Select(group => group.First())
                .OrderBy(capability => capability.ResourceName, StringComparer.Ordinal)
                .ToArray();

            return new ProviderCapabilities
            {
                ProviderName = ProviderName,
                SupportedResources = uniqueSorted
            };
        }

        /// <summary>
        /// Checks whether a type implements <see cref="IResourceOperation{TResource}"/> for any T.
        /// </summary>
        private static bool ImplementsIResourceOperation(Type type) =>
            type.GetInterfaces().Any(@interface =>
                @interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IResourceOperation<>));

        /// <summary>
        /// Attempts to read a <see cref="ResourceCapabilities"/> instance from the provided resource object by
        /// accessing its public <c>Capabilities</c> property.
        /// </summary>
        private static bool TryGetResourceCapabilities(
            object instance,
            out ResourceCapabilities capabilities)
        {
            var property = instance.GetType().GetProperty(
                name: "Capabilities",
                bindingAttr: BindingFlags.Public | BindingFlags.Instance);

            if (property != null && typeof(ResourceCapabilities).IsAssignableFrom(property.PropertyType))
            {
                var value = property.GetValue(instance);

                if (value is ResourceCapabilities resourceCapabilities)
                {
                    capabilities = resourceCapabilities;

                    return true;
                }
            }

            capabilities = default!;

            return false;
        }


        /// <summary>Access FHIR STU3 Account resources.</summary>
        public virtual IAccountResource Accounts => null!;

        /// <summary>Access FHIR STU3 ActivityDefinition resources.</summary>
        public virtual IActivityDefinitionResource ActivityDefinitions => null!;

        /// <summary>Access FHIR STU3 AllergyIntolerance resources.</summary>
        public virtual IAllergyIntoleranceResource AllergyIntolerances => null!;

        /// <summary>Access FHIR STU3 Appointment resources.</summary>
        public virtual IAppointmentResource Appointments => null!;

        /// <summary>Access FHIR STU3 AppointmentResponse resources.</summary>
        public virtual IAppointmentResponseResource AppointmentResponses => null!;

        /// <summary>Access FHIR STU3 AuditEvent resources.</summary>
        public virtual IAuditEventResource AuditEvents => null!;

        /// <summary>Access FHIR STU3 Basic resources.</summary>
        public virtual IBasicResource Basics => null!;

        /// <summary>Access FHIR STU3 Binary resources.</summary>
        public virtual IBinaryResource Binaries => null!;

        /// <summary>Access FHIR STU3 BodySite resources.</summary>
        public virtual IBodySiteResource BodySites => null!;

        /// <summary>Access FHIR STU3 Bundle resources.</summary>
        public virtual IBundleResource Bundles => null!;

        /// <summary>Access FHIR STU3 CapabilityStatement resources.</summary>
        public virtual ICapabilityStatementResource CapabilityStatements => null!;

        /// <summary>Access FHIR STU3 CarePlan resources.</summary>
        public virtual ICarePlanResource CarePlans => null!;

        /// <summary>Access FHIR STU3 CareTeam resources.</summary>
        public virtual ICareTeamResource CareTeams => null!;

        /// <summary>Access FHIR STU3 Claim resources.</summary>
        public virtual IClaimResource Claims => null!;

        /// <summary>Access FHIR STU3 ClaimResponse resources.</summary>
        public virtual IClaimResponseResource ClaimResponses => null!;

        /// <summary>Access FHIR STU3 ClinicalImpression resources.</summary>
        public virtual IClinicalImpressionResource ClinicalImpressions => null!;

        /// <summary>Access FHIR STU3 CodeSystem resources.</summary>
        public virtual ICodeSystemResource CodeSystems => null!;

        /// <summary>Access FHIR STU3 Communication resources.</summary>
        public virtual ICommunicationResource Communications => null!;

        /// <summary>Access FHIR STU3 CommunicationRequest resources.</summary>
        public virtual ICommunicationRequestResource CommunicationRequests => null!;

        /// <summary>Access FHIR STU3 CompartmentDefinition resources.</summary>
        public virtual ICompartmentDefinitionResource CompartmentDefinitions => null!;

        /// <summary>Access FHIR STU3 Composition resources.</summary>
        public virtual ICompositionResource Compositions => null!;

        /// <summary>Access FHIR STU3 ConceptMap resources.</summary>
        public virtual IConceptMapResource ConceptMaps => null!;

        /// <summary>Access FHIR STU3 Condition resources.</summary>
        public virtual IConditionResource Conditions => null!;

        /// <summary>Access FHIR STU3 Consent resources.</summary>
        public virtual IConsentResource Consents => null!;

        /// <summary>Access FHIR STU3 Contract resources.</summary>
        public virtual IContractResource Contracts => null!;

        /// <summary>Access FHIR STU3 Coverage resources.</summary>
        public virtual ICoverageResource Coverages => null!;

        /// <summary>Access FHIR STU3 EligibilityRequest resources.</summary>
        public virtual IEligibilityRequestResource EligibilityRequests => null!;

        /// <summary>Access FHIR STU3 EligibilityResponse resources.</summary>
        public virtual IEligibilityResponseResource EligibilityResponses => null!;

        /// <summary>Access FHIR STU3 DetectedIssue resources.</summary>
        public virtual IDetectedIssueResource DetectedIssues => null!;

        /// <summary>Access FHIR STU3 Device resources.</summary>
        public virtual IDeviceResource Devices => null!;

        /// <summary>Access FHIR STU3 DeviceMetric resources.</summary>
        public virtual IDeviceMetricResource DeviceMetrics => null!;

        /// <summary>Access FHIR STU3 DeviceRequest resources.</summary>
        public virtual IDeviceRequestResource DeviceRequests => null!;

        /// <summary>Access FHIR STU3 DeviceUseStatement resources.</summary>
        public virtual IDeviceUseStatementResource DeviceUseStatements => null!;

        /// <summary>Access FHIR STU3 DiagnosticReport resources.</summary>
        public virtual IDiagnosticReportResource DiagnosticReports => null!;

        /// <summary>Access FHIR STU3 DocumentManifest resources.</summary>
        public virtual IDocumentManifestResource DocumentManifests => null!;

        /// <summary>Access FHIR STU3 DocumentReference resources.</summary>
        public virtual IDocumentReferenceResource DocumentReferences => null!;

        /// <summary>Access FHIR STU3 Encounter resources.</summary>
        public virtual IEncounterResource Encounters => null!;

        /// <summary>Access FHIR STU3 Endpoint resources.</summary>
        public virtual IEndpointResource Endpoints => null!;

        /// <summary>Access FHIR STU3 EnrollmentRequest resources.</summary>
        public virtual IEnrollmentRequestResource EnrollmentRequests => null!;

        /// <summary>Access FHIR STU3 EnrollmentResponse resources.</summary>
        public virtual IEnrollmentResponseResource EnrollmentResponses => null!;

        /// <summary>Access FHIR STU3 EpisodeOfCare resources.</summary>
        public virtual IEpisodeOfCareResource EpisodeOfCares => null!;

        /// <summary>Access FHIR STU3 ExplanationOfBenefit resources.</summary>
        public virtual IExplanationOfBenefitResource ExplanationOfBenefits => null!;

        /// <summary>Access FHIR STU3 FamilyMemberHistory resources.</summary>
        public virtual IFamilyMemberHistoryResource FamilyMemberHistories => null!;

        /// <summary>Access FHIR STU3 Flag resources.</summary>
        public virtual IFlagResource Flags => null!;

        /// <summary>Access FHIR STU3 Goal resources.</summary>
        public virtual IGoalResource Goals => null!;

        /// <summary>Access FHIR STU3 GraphDefinition resources.</summary>
        public virtual IGraphDefinitionResource GraphDefinitions => null!;

        /// <summary>Access FHIR STU3 Group resources.</summary>
        public virtual IGroupResource Groups => null!;

        /// <summary>Access FHIR STU3 GuidanceResponse resources.</summary>
        public virtual IGuidanceResponseResource GuidanceResponses => null!;

        /// <summary>Access FHIR STU3 HealthcareService resources.</summary>
        public virtual IHealthcareServiceResource HealthcareServices => null!;

        /// <summary>Access FHIR STU3 ImagingStudy resources.</summary>
        public virtual IImagingStudyResource ImagingStudies => null!;

        /// <summary>Access FHIR STU3 Immunization resources.</summary>
        public virtual IImmunizationResource Immunizations => null!;

        /// <summary>Access FHIR STU3 ImmunizationRecommendation resources.</summary>
        public virtual IImmunizationRecommendationResource ImmunizationRecommendations => null!;

        /// <summary>Access FHIR STU3 ImplementationGuide resources.</summary>
        public virtual IImplementationGuideResource ImplementationGuides => null!;

        /// <summary>Access FHIR STU3 Library resources.</summary>
        public virtual ILibraryResource Libraries => null!;

        /// <summary>Access FHIR STU3 Linkage resources.</summary>
        public virtual ILinkageResource Linkages => null!;

        /// <summary>Access FHIR STU3 List resources.</summary>
        public virtual IListResource Lists => null!;

        /// <summary>Access FHIR STU3 Location resources.</summary>
        public virtual ILocationResource Locations => null!;

        /// <summary>Access FHIR STU3 Measure resources.</summary>
        public virtual IMeasureResource Measures => null!;

        /// <summary>Access FHIR STU3 MeasureReport resources.</summary>
        public virtual IMeasureReportResource MeasureReports => null!;

        /// <summary>Access FHIR STU3 Media resources.</summary>
        public virtual IMediaResource Media => null!;

        /// <summary>Access FHIR STU3 Medication resources.</summary>
        public virtual IMedicationResource Medications => null!;

        /// <summary>Access FHIR STU3 MedicationAdministration resources.</summary>
        public virtual IMedicationAdministrationResource MedicationAdministrations => null!;

        /// <summary>Access FHIR STU3 MedicationDispense resources.</summary>
        public virtual IMedicationDispenseResource MedicationDispenses => null!;

        /// <summary>Access FHIR STU3 MedicationRequest resources.</summary>
        public virtual IMedicationRequestResource MedicationRequests => null!;

        /// <summary>Access FHIR STU3 MedicationStatement resources.</summary>
        public virtual IMedicationStatementResource MedicationStatements => null!;

        /// <summary>Access FHIR STU3 MessageDefinition resources.</summary>
        public virtual IMessageDefinitionResource MessageDefinitions => null!;

        /// <summary>Access FHIR STU3 MessageHeader resources.</summary>
        public virtual IMessageHeaderResource MessageHeaders => null!;

        /// <summary>Access FHIR STU3 Sequence resources.</summary>
        public virtual ISequenceResource Sequences => null!;

        /// <summary>Access FHIR STU3 NamingSystem resources.</summary>
        public virtual INamingSystemResource NamingSystems => null!;

        /// <summary>Access FHIR STU3 NutritionOrder resources.</summary>
        public virtual INutritionOrderResource NutritionOrders => null!;

        /// <summary>Access FHIR STU3 Observation resources.</summary>
        public virtual IObservationResource Observations => null!;

        /// <summary>Access FHIR STU3 OperationDefinition resources.</summary>
        public virtual IOperationDefinitionResource OperationDefinitions => null!;

        /// <summary>Access FHIR STU3 OperationOutcome resources.</summary>
        public virtual IOperationOutcomeResource OperationOutcomes => null!;

        /// <summary>Access FHIR STU3 Organization resources.</summary>
        public virtual IOrganizationResource Organizations => null!;

        /// <summary>Access FHIR STU3 Parameters resources.</summary>
        public virtual IParametersResource Parameterss => null!;

        /// <summary>Access FHIR STU3 Patient resources.</summary>
        public virtual IPatientResource Patients => null!;

        /// <summary>Access FHIR STU3 PaymentNotice resources.</summary>
        public virtual IPaymentNoticeResource PaymentNotices => null!;

        /// <summary>Access FHIR STU3 PaymentReconciliation resources.</summary>
        public virtual IPaymentReconciliationResource PaymentReconciliations => null!;

        /// <summary>Access FHIR STU3 Person resources.</summary>
        public virtual IPersonResource Persons => null!;

        /// <summary>Access FHIR STU3 PlanDefinition resources.</summary>
        public virtual IPlanDefinitionResource PlanDefinitions => null!;

        /// <summary>Access FHIR STU3 Practitioner resources.</summary>
        public virtual IPractitionerResource Practitioners => null!;

        /// <summary>Access FHIR STU3 PractitionerRole resources.</summary>
        public virtual IPractitionerRoleResource PractitionerRoles => null!;

        /// <summary>Access FHIR STU3 Procedure resources.</summary>
        public virtual IProcedureResource Procedures => null!;

        /// <summary>Access FHIR STU3 ProcedureRequest resources.</summary>
        public virtual IProcedureRequestResource ProcedureRequests => null!;

        /// <summary>Access FHIR STU3 Provenance resources.</summary>
        public virtual IProvenanceResource Provenances => null!;

        /// <summary>Access FHIR STU3 Questionnaire resources.</summary>
        public virtual IQuestionnaireResource Questionnaires => null!;

        /// <summary>Access FHIR STU3 QuestionnaireResponse resources.</summary>
        public virtual IQuestionnaireResponseResource QuestionnaireResponses => null!;

        /// <summary>Access FHIR STU3 RelatedPerson resources.</summary>
        public virtual IRelatedPersonResource RelatedPersons => null!;

        /// <summary>Access FHIR STU3 RequestGroup resources.</summary>
        public virtual IRequestGroupResource RequestGroups => null!;

        /// <summary>Access FHIR STU3 ResearchStudy resources.</summary>
        public virtual IResearchStudyResource ResearchStudies => null!;

        /// <summary>Access FHIR STU3 ResearchSubject resources.</summary>
        public virtual IResearchSubjectResource ResearchSubjects => null!;

        /// <summary>Access FHIR STU3 RiskAssessment resources.</summary>
        public virtual IRiskAssessmentResource RiskAssessments => null!;

        /// <summary>Access FHIR STU3 Schedule resources.</summary>
        public virtual IScheduleResource Schedules => null!;

        /// <summary>Access FHIR STU3 SearchParameter resources.</summary>
        public virtual ISearchParameterResource SearchParameters => null!;

        /// <summary>Access FHIR STU3 Slot resources.</summary>
        public virtual ISlotResource Slots => null!;

        /// <summary>Access FHIR STU3 Specimen resources.</summary>
        public virtual ISpecimenResource Specimens => null!;

        /// <summary>Access FHIR STU3 StructureDefinition resources.</summary>
        public virtual IStructureDefinitionResource StructureDefinitions => null!;

        /// <summary>Access FHIR STU3 StructureMap resources.</summary>
        public virtual IStructureMapResource StructureMaps => null!;

        /// <summary>Access FHIR STU3 Subscription resources.</summary>
        public virtual ISubscriptionResource Subscriptions => null!;

        /// <summary>Access FHIR STU3 Substance resources.</summary>
        public virtual ISubstanceResource Substances => null!;

        /// <summary>Access FHIR STU3 SupplyDelivery resources.</summary>
        public virtual ISupplyDeliveryResource SupplyDeliveries => null!;

        /// <summary>Access FHIR STU3 SupplyRequest resources.</summary>
        public virtual ISupplyRequestResource SupplyRequests => null!;

        /// <summary>Access FHIR STU3 Task resources.</summary>
        public virtual ITaskResource Tasks => null!;

        /// <summary>Access FHIR STU3 TestReport resources.</summary>
        public virtual ITestReportResource TestReports => null!;

        /// <summary>Access FHIR STU3 TestScript resources.</summary>
        public virtual ITestScriptResource TestScripts => null!;

        /// <summary>Access FHIR STU3 ValueSet resources.</summary>
        public virtual IValueSetResource ValueSets => null!;

        /// <summary>Access FHIR STU3 VisionPrescription resources.</summary>
        public virtual IVisionPrescriptionResource VisionPrescriptions => null!;

    }
}
