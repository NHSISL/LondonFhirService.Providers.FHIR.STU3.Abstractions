// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Capabilities;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions
{

    /// <summary>FHIR STU3 provider contract that exposes typed resource entry points and capability metadata.</summary>
    public interface IFhirProvider
    {
        /// <summary>Gets the unique name used to identify the provider.</summary>
        string ProviderName { get; }

        /// <summary>Gets the source system URI used for <c>Bundle.meta.source</c>.</summary>
        string Source { get; }

        /// <summary>Gets the provider code used for <c>Bundle.meta.tag.code</c>.</summary>
        string Code { get; }

        /// <summary>Gets the CodeSystem used for <c>Bundle.meta.tag.system</c>.</summary>
        string System { get; }

        /// <summary>Gets capability metadata that describes supported resources and operations.</summary>
        ProviderCapabilities Capabilities { get; }

        /// <summary>Access FHIR STU3 Account resources.</summary>
        IAccountResource Accounts { get; }

        /// <summary>Access FHIR STU3 ActivityDefinition resources.</summary>
        IActivityDefinitionResource ActivityDefinitions { get; }

        /// <summary>Access FHIR STU3 AllergyIntolerance resources.</summary>
        IAllergyIntoleranceResource AllergyIntolerances { get; }

        /// <summary>Access FHIR STU3 Appointment resources.</summary>
        IAppointmentResource Appointments { get; }

        /// <summary>Access FHIR STU3 AppointmentResponse resources.</summary>
        IAppointmentResponseResource AppointmentResponses { get; }

        /// <summary>Access FHIR STU3 AuditEvent resources.</summary>
        IAuditEventResource AuditEvents { get; }

        /// <summary>Access FHIR STU3 Basic resources.</summary>
        IBasicResource Basics { get; }

        /// <summary>Access FHIR STU3 Binary resources.</summary>
        IBinaryResource Binaries { get; }

        /// <summary>Access FHIR STU3 BodySite resources.</summary>
        IBodySiteResource BodySites { get; }

        /// <summary>Access FHIR STU3 Bundle resources.</summary>
        IBundleResource Bundles { get; }

        /// <summary>Access FHIR STU3 CapabilityStatement resources.</summary>
        ICapabilityStatementResource CapabilityStatements { get; }

        /// <summary>Access FHIR STU3 CarePlan resources.</summary>
        ICarePlanResource CarePlans { get; }

        /// <summary>Access FHIR STU3 CareTeam resources.</summary>
        ICareTeamResource CareTeams { get; }

        /// <summary>Access FHIR STU3 Claim resources.</summary>
        IClaimResource Claims { get; }

        /// <summary>Access FHIR STU3 ClaimResponse resources.</summary>
        IClaimResponseResource ClaimResponses { get; }

        /// <summary>Access FHIR STU3 ClinicalImpression resources.</summary>
        IClinicalImpressionResource ClinicalImpressions { get; }

        /// <summary>Access FHIR STU3 CodeSystem resources.</summary>
        ICodeSystemResource CodeSystems { get; }

        /// <summary>Access FHIR STU3 Communication resources.</summary>
        ICommunicationResource Communications { get; }

        /// <summary>Access FHIR STU3 CommunicationRequest resources.</summary>
        ICommunicationRequestResource CommunicationRequests { get; }

        /// <summary>Access FHIR STU3 CompartmentDefinition resources.</summary>
        ICompartmentDefinitionResource CompartmentDefinitions { get; }

        /// <summary>Access FHIR STU3 Composition resources.</summary>
        ICompositionResource Compositions { get; }

        /// <summary>Access FHIR STU3 ConceptMap resources.</summary>
        IConceptMapResource ConceptMaps { get; }

        /// <summary>Access FHIR STU3 Condition resources.</summary>
        IConditionResource Conditions { get; }

        /// <summary>Access FHIR STU3 Consent resources.</summary>
        IConsentResource Consents { get; }

        /// <summary>Access FHIR STU3 Contract resources.</summary>
        IContractResource Contracts { get; }

        /// <summary>Access FHIR STU3 Coverage resources.</summary>
        ICoverageResource Coverages { get; }

        /// <summary>Access FHIR STU3 EligibilityRequest resources.</summary>
        IEligibilityRequestResource EligibilityRequests { get; }

        /// <summary>Access FHIR STU3 EligibilityResponse resources.</summary>
        IEligibilityResponseResource EligibilityResponses { get; }

        /// <summary>Access FHIR STU3 DetectedIssue resources.</summary>
        IDetectedIssueResource DetectedIssues { get; }

        /// <summary>Access FHIR STU3 Device resources.</summary>
        IDeviceResource Devices { get; }

        /// <summary>Access FHIR STU3 DeviceMetric resources.</summary>
        IDeviceMetricResource DeviceMetrics { get; }

        /// <summary>Access FHIR STU3 DeviceRequest resources.</summary>
        IDeviceRequestResource DeviceRequests { get; }

        /// <summary>Access FHIR STU3 DeviceUseStatement resources.</summary>
        IDeviceUseStatementResource DeviceUseStatements { get; }

        /// <summary>Access FHIR STU3 DiagnosticReport resources.</summary>
        IDiagnosticReportResource DiagnosticReports { get; }

        /// <summary>Access FHIR STU3 DocumentManifest resources.</summary>
        IDocumentManifestResource DocumentManifests { get; }

        /// <summary>Access FHIR STU3 DocumentReference resources.</summary>
        IDocumentReferenceResource DocumentReferences { get; }

        /// <summary>Access FHIR STU3 Encounter resources.</summary>
        IEncounterResource Encounters { get; }

        /// <summary>Access FHIR STU3 Endpoint resources.</summary>
        IEndpointResource Endpoints { get; }

        /// <summary>Access FHIR STU3 EnrollmentRequest resources.</summary>
        IEnrollmentRequestResource EnrollmentRequests { get; }

        /// <summary>Access FHIR STU3 EnrollmentResponse resources.</summary>
        IEnrollmentResponseResource EnrollmentResponses { get; }

        /// <summary>Access FHIR STU3 EpisodeOfCare resources.</summary>
        IEpisodeOfCareResource EpisodeOfCares { get; }

        /// <summary>Access FHIR STU3 ExplanationOfBenefit resources.</summary>
        IExplanationOfBenefitResource ExplanationOfBenefits { get; }

        /// <summary>Access FHIR STU3 FamilyMemberHistory resources.</summary>
        IFamilyMemberHistoryResource FamilyMemberHistories { get; }

        /// <summary>Access FHIR STU3 Flag resources.</summary>
        IFlagResource Flags { get; }

        /// <summary>Access FHIR STU3 Goal resources.</summary>
        IGoalResource Goals { get; }

        /// <summary>Access FHIR STU3 GraphDefinition resources.</summary>
        IGraphDefinitionResource GraphDefinitions { get; }

        /// <summary>Access FHIR STU3 Group resources.</summary>
        IGroupResource Groups { get; }

        /// <summary>Access FHIR STU3 GuidanceResponse resources.</summary>
        IGuidanceResponseResource GuidanceResponses { get; }

        /// <summary>Access FHIR STU3 HealthcareService resources.</summary>
        IHealthcareServiceResource HealthcareServices { get; }

        /// <summary>Access FHIR STU3 ImagingStudy resources.</summary>
        IImagingStudyResource ImagingStudies { get; }

        /// <summary>Access FHIR STU3 Immunization resources.</summary>
        IImmunizationResource Immunizations { get; }

        /// <summary>Access FHIR STU3 ImmunizationRecommendation resources.</summary>
        IImmunizationRecommendationResource ImmunizationRecommendations { get; }

        /// <summary>Access FHIR STU3 ImplementationGuide resources.</summary>
        IImplementationGuideResource ImplementationGuides { get; }

        /// <summary>Access FHIR STU3 Library resources.</summary>
        ILibraryResource Libraries { get; }

        /// <summary>Access FHIR STU3 Linkage resources.</summary>
        ILinkageResource Linkages { get; }

        /// <summary>Access FHIR STU3 List resources.</summary>
        IListResource Lists { get; }

        /// <summary>Access FHIR STU3 Location resources.</summary>
        ILocationResource Locations { get; }

        /// <summary>Access FHIR STU3 Measure resources.</summary>
        IMeasureResource Measures { get; }

        /// <summary>Access FHIR STU3 MeasureReport resources.</summary>
        IMeasureReportResource MeasureReports { get; }

        /// <summary>Access FHIR STU3 Media resources.</summary>
        IMediaResource Media { get; }

        /// <summary>Access FHIR STU3 Medication resources.</summary>
        IMedicationResource Medications { get; }

        /// <summary>Access FHIR STU3 MedicationAdministration resources.</summary>
        IMedicationAdministrationResource MedicationAdministrations { get; }

        /// <summary>Access FHIR STU3 MedicationDispense resources.</summary>
        IMedicationDispenseResource MedicationDispenses { get; }

        /// <summary>Access FHIR STU3 MedicationRequest resources.</summary>
        IMedicationRequestResource MedicationRequests { get; }

        /// <summary>Access FHIR STU3 MedicationStatement resources.</summary>
        IMedicationStatementResource MedicationStatements { get; }

        /// <summary>Access FHIR STU3 MessageDefinition resources.</summary>
        IMessageDefinitionResource MessageDefinitions { get; }

        /// <summary>Access FHIR STU3 MessageHeader resources.</summary>
        IMessageHeaderResource MessageHeaders { get; }

        /// <summary>Access FHIR STU3 Sequence resources.</summary>
        ISequenceResource Sequences { get; }

        /// <summary>Access FHIR STU3 NamingSystem resources.</summary>
        INamingSystemResource NamingSystems { get; }

        /// <summary>Access FHIR STU3 NutritionOrder resources.</summary>
        INutritionOrderResource NutritionOrders { get; }

        /// <summary>Access FHIR STU3 Observation resources.</summary>
        IObservationResource Observations { get; }

        /// <summary>Access FHIR STU3 OperationDefinition resources.</summary>
        IOperationDefinitionResource OperationDefinitions { get; }

        /// <summary>Access FHIR STU3 OperationOutcome resources.</summary>
        IOperationOutcomeResource OperationOutcomes { get; }

        /// <summary>Access FHIR STU3 Organization resources.</summary>
        IOrganizationResource Organizations { get; }

        /// <summary>Access FHIR STU3 Parameters resources.</summary>
        IParametersResource Parameterss { get; }

        /// <summary>Access FHIR STU3 Patient resources.</summary>
        IPatientResource Patients { get; }

        /// <summary>Access FHIR STU3 PaymentNotice resources.</summary>
        IPaymentNoticeResource PaymentNotices { get; }

        /// <summary>Access FHIR STU3 PaymentReconciliation resources.</summary>
        IPaymentReconciliationResource PaymentReconciliations { get; }

        /// <summary>Access FHIR STU3 Person resources.</summary>
        IPersonResource Persons { get; }

        /// <summary>Access FHIR STU3 PlanDefinition resources.</summary>
        IPlanDefinitionResource PlanDefinitions { get; }

        /// <summary>Access FHIR STU3 Practitioner resources.</summary>
        IPractitionerResource Practitioners { get; }

        /// <summary>Access FHIR STU3 PractitionerRole resources.</summary>
        IPractitionerRoleResource PractitionerRoles { get; }

        /// <summary>Access FHIR STU3 Procedure resources.</summary>
        IProcedureResource Procedures { get; }

        /// <summary>Access FHIR STU3 ProcedureRequest resources.</summary>
        IProcedureRequestResource ProcedureRequests { get; }

        /// <summary>Access FHIR STU3 Provenance resources.</summary>
        IProvenanceResource Provenances { get; }

        /// <summary>Access FHIR STU3 Questionnaire resources.</summary>
        IQuestionnaireResource Questionnaires { get; }

        /// <summary>Access FHIR STU3 QuestionnaireResponse resources.</summary>
        IQuestionnaireResponseResource QuestionnaireResponses { get; }

        /// <summary>Access FHIR STU3 RelatedPerson resources.</summary>
        IRelatedPersonResource RelatedPersons { get; }

        /// <summary>Access FHIR STU3 RequestGroup resources.</summary>
        IRequestGroupResource RequestGroups { get; }

        /// <summary>Access FHIR STU3 ResearchStudy resources.</summary>
        IResearchStudyResource ResearchStudies { get; }

        /// <summary>Access FHIR STU3 ResearchSubject resources.</summary>
        IResearchSubjectResource ResearchSubjects { get; }

        /// <summary>Access FHIR STU3 RiskAssessment resources.</summary>
        IRiskAssessmentResource RiskAssessments { get; }

        /// <summary>Access FHIR STU3 Schedule resources.</summary>
        IScheduleResource Schedules { get; }

        /// <summary>Access FHIR STU3 SearchParameter resources.</summary>
        ISearchParameterResource SearchParameters { get; }

        /// <summary>Access FHIR STU3 Slot resources.</summary>
        ISlotResource Slots { get; }

        /// <summary>Access FHIR STU3 Specimen resources.</summary>
        ISpecimenResource Specimens { get; }

        /// <summary>Access FHIR STU3 StructureDefinition resources.</summary>
        IStructureDefinitionResource StructureDefinitions { get; }

        /// <summary>Access FHIR STU3 StructureMap resources.</summary>
        IStructureMapResource StructureMaps { get; }

        /// <summary>Access FHIR STU3 Subscription resources.</summary>
        ISubscriptionResource Subscriptions { get; }

        /// <summary>Access FHIR STU3 Substance resources.</summary>
        ISubstanceResource Substances { get; }

        /// <summary>Access FHIR STU3 SupplyDelivery resources.</summary>
        ISupplyDeliveryResource SupplyDeliveries { get; }

        /// <summary>Access FHIR STU3 SupplyRequest resources.</summary>
        ISupplyRequestResource SupplyRequests { get; }

        /// <summary>Access FHIR STU3 Task resources.</summary>
        ITaskResource Tasks { get; }

        /// <summary>Access FHIR STU3 TestReport resources.</summary>
        ITestReportResource TestReports { get; }

        /// <summary>Access FHIR STU3 TestScript resources.</summary>
        ITestScriptResource TestScripts { get; }

        /// <summary>Access FHIR STU3 ValueSet resources.</summary>
        IValueSetResource ValueSets { get; }

        /// <summary>Access FHIR STU3 VisionPrescription resources.</summary>
        IVisionPrescriptionResource VisionPrescriptions { get; }
    }
}
