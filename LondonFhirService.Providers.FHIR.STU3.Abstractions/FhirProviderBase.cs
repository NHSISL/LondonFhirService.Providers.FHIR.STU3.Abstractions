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
    /// <summary>
    /// Base class for concrete STU3 providers. By default, resource properties
    /// return <c>null</c>. <see cref="Capabilities"/> are computed by reflection
    /// from non-null resource properties implementing IResourceOperation&lt;T&gt;.
    /// </summary>
    public abstract class FhirProviderBase : IFhirProvider
    {
        private ProviderCapabilities providerCapabilities;

        /// <summary>
        /// Unique name to identify the provider. Defaults to the full type name.
        /// </summary>
        public virtual string ProviderName => GetType().FullName ?? GetType().Name;

        /// <summary>Source system URI for Bundle.meta.source.</summary>
        public abstract string Source { get; }

        /// <summary>Provider code for Bundle.meta.tag.code.</summary>
        public abstract string Code { get; }

        /// <summary>CodeSystem for Bundle.meta.tag.system.</summary>
        public abstract string System { get; }

        /// <summary>Provider capabilities computed lazily.</summary>
        public ProviderCapabilities Capabilities => providerCapabilities ??= ComputeCapabilities();

        /// <summary>Computes capabilities by reflecting resource properties.</summary>
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
                if (instance is null) continue;

                if (TryGetResourceCapabilities(instance, out var implCaps))
                {
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

        private static bool ImplementsIResourceOperation(Type type) =>
            type.GetInterfaces().Any(@interface =>
                @interface.IsGenericType &&
                @interface.GetGenericTypeDefinition() == typeof(IResourceOperation<>));

        private static bool TryGetResourceCapabilities(
            object instance,
            out ResourceCapabilities capabilities)
        {
            var property = instance.GetType().GetProperty(
                name: "Capabilities",
                bindingAttr: BindingFlags.Public | BindingFlags.Instance);

            if (property != null &&
                typeof(ResourceCapabilities).IsAssignableFrom(property.PropertyType))
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
        /// <summary>Access FHIR Account resources.</summary>
        public virtual IAccountResource Accounts => null!;
        /// <summary>Access FHIR ActivityDefinition resources.</summary>
        public virtual IActivityDefinitionResource ActivityDefinitions => null!;
        /// <summary>Access FHIR AdverseEvent resources.</summary>
        public virtual IAdverseEventResource AdverseEvents => null!;
        /// <summary>Access FHIR AllergyIntolerance resources.</summary>
        public virtual IAllergyIntoleranceResource AllergyIntolerances => null!;
        /// <summary>Access FHIR Appointment resources.</summary>
        public virtual IAppointmentResource Appointments => null!;
        /// <summary>Access FHIR AppointmentResponse resources.</summary>
        public virtual IAppointmentResponseResource AppointmentResponses => null!;
        /// <summary>Access FHIR AuditEvent resources.</summary>
        public virtual IAuditEventResource AuditEvents => null!;
        /// <summary>Access FHIR Basic resources.</summary>
        public virtual IBasicResource Basics => null!;
        /// <summary>Access FHIR Binary resources.</summary>
        public virtual IBinaryResource Binaries => null!;
        /// <summary>Access FHIR BodySite resources.</summary>
        public virtual IBodySiteResource BodySites => null!;
        /// <summary>Access FHIR Bundle resources.</summary>
        public virtual IBundleResource Bundles => null!;
        /// <summary>Access FHIR CapabilityStatement resources.</summary>
        public virtual ICapabilityStatementResource CapabilityStatements => null!;
        /// <summary>Access FHIR CarePlan resources.</summary>
        public virtual ICarePlanResource CarePlans => null!;
        /// <summary>Access FHIR CareTeam resources.</summary>
        public virtual ICareTeamResource CareTeams => null!;
        /// <summary>Access FHIR ChargeItem resources.</summary>
        public virtual IChargeItemResource ChargeItems => null!;
        /// <summary>Access FHIR Claim resources.</summary>
        public virtual IClaimResource Claims => null!;
        /// <summary>Access FHIR ClaimResponse resources.</summary>
        public virtual IClaimResponseResource ClaimResponses => null!;
        /// <summary>Access FHIR ClinicalImpression resources.</summary>
        public virtual IClinicalImpressionResource ClinicalImpressions => null!;
        /// <summary>Access FHIR CodeSystem resources.</summary>
        public virtual ICodeSystemResource CodeSystems => null!;
        /// <summary>Access FHIR Communication resources.</summary>
        public virtual ICommunicationResource Communications => null!;
        /// <summary>Access FHIR CommunicationRequest resources.</summary>
        public virtual ICommunicationRequestResource CommunicationRequests => null!;
        /// <summary>Access FHIR CompartmentDefinition resources.</summary>
        public virtual ICompartmentDefinitionResource CompartmentDefinitions => null!;
        /// <summary>Access FHIR Composition resources.</summary>
        public virtual ICompositionResource Compositions => null!;
        /// <summary>Access FHIR ConceptMap resources.</summary>
        public virtual IConceptMapResource ConceptMaps => null!;
        /// <summary>Access FHIR Condition resources.</summary>
        public virtual IConditionResource Conditions => null!;
        /// <summary>Access FHIR Consent resources.</summary>
        public virtual IConsentResource Consents => null!;
        /// <summary>Access FHIR Contract resources.</summary>
        public virtual IContractResource Contracts => null!;
        /// <summary>Access FHIR Coverage resources.</summary>
        public virtual ICoverageResource Coverages => null!;
        /// <summary>Access FHIR DataElement resources.</summary>
        public virtual IDataElementResource DataElements => null!;
        /// <summary>Access FHIR DetectedIssue resources.</summary>
        public virtual IDetectedIssueResource DetectedIssues => null!;
        /// <summary>Access FHIR Device resources.</summary>
        public virtual IDeviceResource Devices => null!;
        /// <summary>Access FHIR DeviceComponent resources.</summary>
        public virtual IDeviceComponentResource DeviceComponents => null!;
        /// <summary>Access FHIR DeviceMetric resources.</summary>
        public virtual IDeviceMetricResource DeviceMetrics => null!;
        /// <summary>Access FHIR DeviceRequest resources.</summary>
        public virtual IDeviceRequestResource DeviceRequests => null!;
        /// <summary>Access FHIR DeviceUseStatement resources.</summary>
        public virtual IDeviceUseStatementResource DeviceUseStatements => null!;
        /// <summary>Access FHIR DiagnosticReport resources.</summary>
        public virtual IDiagnosticReportResource DiagnosticReports => null!;
        /// <summary>Access FHIR DocumentManifest resources.</summary>
        public virtual IDocumentManifestResource DocumentManifests => null!;
        /// <summary>Access FHIR DocumentReference resources.</summary>
        public virtual IDocumentReferenceResource DocumentReferences => null!;
        /// <summary>Access FHIR EligibilityRequest resources.</summary>
        public virtual IEligibilityRequestResource EligibilityRequests => null!;
        /// <summary>Access FHIR EligibilityResponse resources.</summary>
        public virtual IEligibilityResponseResource EligibilityResponses => null!;
        /// <summary>Access FHIR Encounter resources.</summary>
        public virtual IEncounterResource Encounters => null!;
        /// <summary>Access FHIR Endpoint resources.</summary>
        public virtual IEndpointResource Endpoints => null!;
        /// <summary>Access FHIR EnrollmentRequest resources.</summary>
        public virtual IEnrollmentRequestResource EnrollmentRequests => null!;
        /// <summary>Access FHIR EnrollmentResponse resources.</summary>
        public virtual IEnrollmentResponseResource EnrollmentResponses => null!;
        /// <summary>Access FHIR EpisodeOfCare resources.</summary>
        public virtual IEpisodeOfCareResource EpisodeOfCares => null!;
        /// <summary>Access FHIR ExpansionProfile resources.</summary>
        public virtual IExpansionProfileResource ExpansionProfiles => null!;
        /// <summary>Access FHIR ExplanationOfBenefit resources.</summary>
        public virtual IExplanationOfBenefitResource ExplanationOfBenefits => null!;
        /// <summary>Access FHIR FamilyMemberHistory resources.</summary>
        public virtual IFamilyMemberHistoryResource FamilyMemberHistories => null!;
        /// <summary>Access FHIR Flag resources.</summary>
        public virtual IFlagResource Flags => null!;
        /// <summary>Access FHIR Goal resources.</summary>
        public virtual IGoalResource Goals => null!;
        /// <summary>Access FHIR GraphDefinition resources.</summary>
        public virtual IGraphDefinitionResource GraphDefinitions => null!;
        /// <summary>Access FHIR Group resources.</summary>
        public virtual IGroupResource Groups => null!;
        /// <summary>Access FHIR GuidanceResponse resources.</summary>
        public virtual IGuidanceResponseResource GuidanceResponses => null!;
        /// <summary>Access FHIR HealthcareService resources.</summary>
        public virtual IHealthcareServiceResource HealthcareServices => null!;
        /// <summary>Access FHIR ImagingManifest resources.</summary>
        public virtual IImagingManifestResource ImagingManifests => null!;
        /// <summary>Access FHIR ImagingStudy resources.</summary>
        public virtual IImagingStudyResource ImagingStudies => null!;
        /// <summary>Access FHIR Immunization resources.</summary>
        public virtual IImmunizationResource Immunizations => null!;
        /// <summary>Access FHIR ImmunizationRecommendation resources.</summary>
        public virtual IImmunizationRecommendationResource ImmunizationRecommendations => null!;
        /// <summary>Access FHIR ImplementationGuide resources.</summary>
        public virtual IImplementationGuideResource ImplementationGuides => null!;
        /// <summary>Access FHIR Library resources.</summary>
        public virtual ILibraryResource Libraries => null!;
        /// <summary>Access FHIR Linkage resources.</summary>
        public virtual ILinkageResource Linkages => null!;
        /// <summary>Access FHIR List resources.</summary>
        public virtual IListResource Lists => null!;
        /// <summary>Access FHIR Location resources.</summary>
        public virtual ILocationResource Locations => null!;
        /// <summary>Access FHIR Measure resources.</summary>
        public virtual IMeasureResource Measures => null!;
        /// <summary>Access FHIR MeasureReport resources.</summary>
        public virtual IMeasureReportResource MeasureReports => null!;
        /// <summary>Access FHIR Media resources.</summary>
        public virtual IMediaResource Media => null!;
        /// <summary>Access FHIR Medication resources.</summary>
        public virtual IMedicationResource Medications => null!;
        /// <summary>Access FHIR MedicationAdministration resources.</summary>
        public virtual IMedicationAdministrationResource MedicationAdministrations => null!;
        /// <summary>Access FHIR MedicationDispense resources.</summary>
        public virtual IMedicationDispenseResource MedicationDispenses => null!;
        /// <summary>Access FHIR MedicationRequest resources.</summary>
        public virtual IMedicationRequestResource MedicationRequests => null!;
        /// <summary>Access FHIR MedicationStatement resources.</summary>
        public virtual IMedicationStatementResource MedicationStatements => null!;
        /// <summary>Access FHIR MessageDefinition resources.</summary>
        public virtual IMessageDefinitionResource MessageDefinitions => null!;
        /// <summary>Access FHIR MessageHeader resources.</summary>
        public virtual IMessageHeaderResource MessageHeaders => null!;
        /// <summary>Access FHIR NamingSystem resources.</summary>
        public virtual INamingSystemResource NamingSystems => null!;
        /// <summary>Access FHIR NutritionOrder resources.</summary>
        public virtual INutritionOrderResource NutritionOrders => null!;
        /// <summary>Access FHIR Observation resources.</summary>
        public virtual IObservationResource Observations => null!;
        /// <summary>Access FHIR OperationDefinition resources.</summary>
        public virtual IOperationDefinitionResource OperationDefinitions => null!;
        /// <summary>Access FHIR OperationOutcome resources.</summary>
        public virtual IOperationOutcomeResource OperationOutcomes => null!;
        /// <summary>Access FHIR Organization resources.</summary>
        public virtual IOrganizationResource Organizations => null!;
        /// <summary>Access FHIR Parameters resources.</summary>
        public virtual IParametersResource Parameters => null!;
        /// <summary>Access FHIR Patient resources.</summary>
        public virtual IPatientResource Patients => null!;
        /// <summary>Access FHIR PaymentNotice resources.</summary>
        public virtual IPaymentNoticeResource PaymentNotices => null!;
        /// <summary>Access FHIR PaymentReconciliation resources.</summary>
        public virtual IPaymentReconciliationResource PaymentReconciliations => null!;
        /// <summary>Access FHIR Person resources.</summary>
        public virtual IPersonResource Persons => null!;
        /// <summary>Access FHIR PlanDefinition resources.</summary>
        public virtual IPlanDefinitionResource PlanDefinitions => null!;
        /// <summary>Access FHIR Practitioner resources.</summary>
        public virtual IPractitionerResource Practitioners => null!;
        /// <summary>Access FHIR PractitionerRole resources.</summary>
        public virtual IPractitionerRoleResource PractitionerRoles => null!;
        /// <summary>Access FHIR Procedure resources.</summary>
        public virtual IProcedureResource Procedures => null!;
        /// <summary>Access FHIR ProcedureRequest resources.</summary>
        public virtual IProcedureRequestResource ProcedureRequests => null!;
        /// <summary>Access FHIR ProcessRequest resources.</summary>
        public virtual IProcessRequestResource ProcessRequests => null!;
        /// <summary>Access FHIR ProcessResponse resources.</summary>
        public virtual IProcessResponseResource ProcessResponses => null!;
        /// <summary>Access FHIR Provenance resources.</summary>
        public virtual IProvenanceResource Provenances => null!;
        /// <summary>Access FHIR Questionnaire resources.</summary>
        public virtual IQuestionnaireResource Questionnaires => null!;
        /// <summary>Access FHIR QuestionnaireResponse resources.</summary>
        public virtual IQuestionnaireResponseResource QuestionnaireResponses => null!;
        /// <summary>Access FHIR ReferralRequest resources.</summary>
        public virtual IReferralRequestResource ReferralRequests => null!;
        /// <summary>Access FHIR RelatedPerson resources.</summary>
        public virtual IRelatedPersonResource RelatedPersons => null!;
        /// <summary>Access FHIR RequestGroup resources.</summary>
        public virtual IRequestGroupResource RequestGroups => null!;
        /// <summary>Access FHIR ResearchStudy resources.</summary>
        public virtual IResearchStudyResource ResearchStudies => null!;
        /// <summary>Access FHIR ResearchSubject resources.</summary>
        public virtual IResearchSubjectResource ResearchSubjects => null!;
        /// <summary>Access FHIR RiskAssessment resources.</summary>
        public virtual IRiskAssessmentResource RiskAssessments => null!;
        /// <summary>Access FHIR Schedule resources.</summary>
        public virtual IScheduleResource Schedules => null!;
        /// <summary>Access FHIR SearchParameter resources.</summary>
        public virtual ISearchParameterResource SearchParameters => null!;
        /// <summary>Access FHIR Sequence resources.</summary>
        public virtual ISequenceResource Sequences => null!;
        /// <summary>Access FHIR ServiceDefinition resources.</summary>
        public virtual IServiceDefinitionResource ServiceDefinitions => null!;
        /// <summary>Access FHIR Slot resources.</summary>
        public virtual ISlotResource Slots => null!;
        /// <summary>Access FHIR Specimen resources.</summary>
        public virtual ISpecimenResource Specimens => null!;
        /// <summary>Access FHIR StructureDefinition resources.</summary>
        public virtual IStructureDefinitionResource StructureDefinitions => null!;
        /// <summary>Access FHIR StructureMap resources.</summary>
        public virtual IStructureMapResource StructureMaps => null!;
        /// <summary>Access FHIR Subscription resources.</summary>
        public virtual ISubscriptionResource Subscriptions => null!;
        /// <summary>Access FHIR Substance resources.</summary>
        public virtual ISubstanceResource Substances => null!;
        /// <summary>Access FHIR SupplyDelivery resources.</summary>
        public virtual ISupplyDeliveryResource SupplyDeliveries => null!;
        /// <summary>Access FHIR SupplyRequest resources.</summary>
        public virtual ISupplyRequestResource SupplyRequests => null!;
        /// <summary>Access FHIR Task resources.</summary>
        public virtual ITaskResource Tasks => null!;
        /// <summary>Access FHIR TestScript resources.</summary>
        public virtual ITestScriptResource TestScripts => null!;
        /// <summary>Access FHIR TestReport resources.</summary>
        public virtual ITestReportResource TestReports => null!;
        /// <summary>Access FHIR ValueSet resources.</summary>
        public virtual IValueSetResource ValueSets => null!;
        /// <summary>Access FHIR VisionPrescription resources.</summary>
        public virtual IVisionPrescriptionResource VisionPrescriptions => null!;
    }
}
