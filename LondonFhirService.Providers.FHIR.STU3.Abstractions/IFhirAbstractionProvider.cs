// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions
{
    /// <summary>Aggregates multiple STU3 providers and exposes resource entry points per provider name.</summary>
    public interface IFhirAbstractionProvider
    {
        /// <summary>Gets the set of registered FHIR STU3 providers.</summary>
        IReadOnlyCollection<IFhirProvider> FhirProviders { get; }

        /// <summary>Access FHIR STU3 Account resources for a specific provider.</summary>
        IAccountResource Accounts(string providerName);

        /// <summary>Access FHIR STU3 ActivityDefinition resources for a specific provider.</summary>
        IActivityDefinitionResource ActivityDefinitions(string providerName);

        /// <summary>Access FHIR STU3 AllergyIntolerance resources for a specific provider.</summary>
        IAllergyIntoleranceResource AllergyIntolerances(string providerName);

        /// <summary>Access FHIR STU3 Appointment resources for a specific provider.</summary>
        IAppointmentResource Appointments(string providerName);

        /// <summary>Access FHIR STU3 AppointmentResponse resources for a specific provider.</summary>
        IAppointmentResponseResource AppointmentResponses(string providerName);

        /// <summary>Access FHIR STU3 AuditEvent resources for a specific provider.</summary>
        IAuditEventResource AuditEvents(string providerName);

        /// <summary>Access FHIR STU3 Basic resources for a specific provider.</summary>
        IBasicResource Basics(string providerName);

        /// <summary>Access FHIR STU3 Binary resources for a specific provider.</summary>
        IBinaryResource Binaries(string providerName);

        /// <summary>Access FHIR STU3 BodySite resources for a specific provider.</summary>
        IBodySiteResource BodySites(string providerName);

        /// <summary>Access FHIR STU3 Bundle resources for a specific provider.</summary>
        IBundleResource Bundles(string providerName);

        /// <summary>Access FHIR STU3 CapabilityStatement resources for a specific provider.</summary>
        ICapabilityStatementResource CapabilityStatements(string providerName);

        /// <summary>Access FHIR STU3 CarePlan resources for a specific provider.</summary>
        ICarePlanResource CarePlans(string providerName);

        /// <summary>Access FHIR STU3 CareTeam resources for a specific provider.</summary>
        ICareTeamResource CareTeams(string providerName);

        /// <summary>Access FHIR STU3 Claim resources for a specific provider.</summary>
        IClaimResource Claims(string providerName);

        /// <summary>Access FHIR STU3 ClaimResponse resources for a specific provider.</summary>
        IClaimResponseResource ClaimResponses(string providerName);

        /// <summary>Access FHIR STU3 ClinicalImpression resources for a specific provider.</summary>
        IClinicalImpressionResource ClinicalImpressions(string providerName);

        /// <summary>Access FHIR STU3 CodeSystem resources for a specific provider.</summary>
        ICodeSystemResource CodeSystems(string providerName);

        /// <summary>Access FHIR STU3 Communication resources for a specific provider.</summary>
        ICommunicationResource Communications(string providerName);

        /// <summary>Access FHIR STU3 CommunicationRequest resources for a specific provider.</summary>
        ICommunicationRequestResource CommunicationRequests(string providerName);

        /// <summary>Access FHIR STU3 CompartmentDefinition resources for a specific provider.</summary>
        ICompartmentDefinitionResource CompartmentDefinitions(string providerName);

        /// <summary>Access FHIR STU3 Composition resources for a specific provider.</summary>
        ICompositionResource Compositions(string providerName);

        /// <summary>Access FHIR STU3 ConceptMap resources for a specific provider.</summary>
        IConceptMapResource ConceptMaps(string providerName);

        /// <summary>Access FHIR STU3 Condition resources for a specific provider.</summary>
        IConditionResource Conditions(string providerName);

        /// <summary>Access FHIR STU3 Consent resources for a specific provider.</summary>
        IConsentResource Consents(string providerName);

        /// <summary>Access FHIR STU3 Contract resources for a specific provider.</summary>
        IContractResource Contracts(string providerName);

        /// <summary>Access FHIR STU3 Coverage resources for a specific provider.</summary>
        ICoverageResource Coverages(string providerName);

        /// <summary>Access FHIR STU3 EligibilityRequest resources for a specific provider.</summary>
        IEligibilityRequestResource EligibilityRequests(string providerName);

        /// <summary>Access FHIR STU3 EligibilityResponse resources for a specific provider.</summary>
        IEligibilityResponseResource EligibilityResponses(string providerName);

        /// <summary>Access FHIR STU3 DetectedIssue resources for a specific provider.</summary>
        IDetectedIssueResource DetectedIssues(string providerName);

        /// <summary>Access FHIR STU3 Device resources for a specific provider.</summary>
        IDeviceResource Devices(string providerName);

        /// <summary>Access FHIR STU3 DeviceMetric resources for a specific provider.</summary>
        IDeviceMetricResource DeviceMetrics(string providerName);

        /// <summary>Access FHIR STU3 DeviceRequest resources for a specific provider.</summary>
        IDeviceRequestResource DeviceRequests(string providerName);

        /// <summary>Access FHIR STU3 DeviceUseStatement resources for a specific provider.</summary>
        IDeviceUseStatementResource DeviceUseStatements(string providerName);

        /// <summary>Access FHIR STU3 DiagnosticReport resources for a specific provider.</summary>
        IDiagnosticReportResource DiagnosticReports(string providerName);

        /// <summary>Access FHIR STU3 DocumentManifest resources for a specific provider.</summary>
        IDocumentManifestResource DocumentManifests(string providerName);

        /// <summary>Access FHIR STU3 DocumentReference resources for a specific provider.</summary>
        IDocumentReferenceResource DocumentReferences(string providerName);

        /// <summary>Access FHIR STU3 Encounter resources for a specific provider.</summary>
        IEncounterResource Encounters(string providerName);

        /// <summary>Access FHIR STU3 Endpoint resources for a specific provider.</summary>
        IEndpointResource Endpoints(string providerName);

        /// <summary>Access FHIR STU3 EnrollmentRequest resources for a specific provider.</summary>
        IEnrollmentRequestResource EnrollmentRequests(string providerName);

        /// <summary>Access FHIR STU3 EnrollmentResponse resources for a specific provider.</summary>
        IEnrollmentResponseResource EnrollmentResponses(string providerName);

        /// <summary>Access FHIR STU3 EpisodeOfCare resources for a specific provider.</summary>
        IEpisodeOfCareResource EpisodeOfCares(string providerName);

        /// <summary>Access FHIR STU3 ExplanationOfBenefit resources for a specific provider.</summary>
        IExplanationOfBenefitResource ExplanationOfBenefits(string providerName);

        /// <summary>Access FHIR STU3 FamilyMemberHistory resources for a specific provider.</summary>
        IFamilyMemberHistoryResource FamilyMemberHistories(string providerName);

        /// <summary>Access FHIR STU3 Flag resources for a specific provider.</summary>
        IFlagResource Flags(string providerName);

        /// <summary>Access FHIR STU3 Goal resources for a specific provider.</summary>
        IGoalResource Goals(string providerName);

        /// <summary>Access FHIR STU3 GraphDefinition resources for a specific provider.</summary>
        IGraphDefinitionResource GraphDefinitions(string providerName);

        /// <summary>Access FHIR STU3 Group resources for a specific provider.</summary>
        IGroupResource Groups(string providerName);

        /// <summary>Access FHIR STU3 GuidanceResponse resources for a specific provider.</summary>
        IGuidanceResponseResource GuidanceResponses(string providerName);

        /// <summary>Access FHIR STU3 HealthcareService resources for a specific provider.</summary>
        IHealthcareServiceResource HealthcareServices(string providerName);

        /// <summary>Access FHIR STU3 ImagingStudy resources for a specific provider.</summary>
        IImagingStudyResource ImagingStudies(string providerName);

        /// <summary>Access FHIR STU3 Immunization resources for a specific provider.</summary>
        IImmunizationResource Immunizations(string providerName);

        /// <summary>Access FHIR STU3 ImmunizationRecommendation resources for a specific provider.</summary>
        IImmunizationRecommendationResource ImmunizationRecommendations(string providerName);

        /// <summary>Access FHIR STU3 ImplementationGuide resources for a specific provider.</summary>
        IImplementationGuideResource ImplementationGuides(string providerName);

        /// <summary>Access FHIR STU3 Library resources for a specific provider.</summary>
        ILibraryResource Libraries(string providerName);

        /// <summary>Access FHIR STU3 Linkage resources for a specific provider.</summary>
        ILinkageResource Linkages(string providerName);

        /// <summary>Access FHIR STU3 List resources for a specific provider.</summary>
        IListResource Lists(string providerName);

        /// <summary>Access FHIR STU3 Location resources for a specific provider.</summary>
        ILocationResource Locations(string providerName);

        /// <summary>Access FHIR STU3 Measure resources for a specific provider.</summary>
        IMeasureResource Measures(string providerName);

        /// <summary>Access FHIR STU3 MeasureReport resources for a specific provider.</summary>
        IMeasureReportResource MeasureReports(string providerName);

        /// <summary>Access FHIR STU3 Media resources for a specific provider.</summary>
        IMediaResource Media(string providerName);

        /// <summary>Access FHIR STU3 Medication resources for a specific provider.</summary>
        IMedicationResource Medications(string providerName);

        /// <summary>Access FHIR STU3 MedicationAdministration resources for a specific provider.</summary>
        IMedicationAdministrationResource MedicationAdministrations(string providerName);

        /// <summary>Access FHIR STU3 MedicationDispense resources for a specific provider.</summary>
        IMedicationDispenseResource MedicationDispenses(string providerName);

        /// <summary>Access FHIR STU3 MedicationRequest resources for a specific provider.</summary>
        IMedicationRequestResource MedicationRequests(string providerName);

        /// <summary>Access FHIR STU3 MedicationStatement resources for a specific provider.</summary>
        IMedicationStatementResource MedicationStatements(string providerName);

        /// <summary>Access FHIR STU3 MessageDefinition resources for a specific provider.</summary>
        IMessageDefinitionResource MessageDefinitions(string providerName);

        /// <summary>Access FHIR STU3 MessageHeader resources for a specific provider.</summary>
        IMessageHeaderResource MessageHeaders(string providerName);

        /// <summary>Access FHIR STU3 Sequence resources for a specific provider.</summary>
        ISequenceResource Sequences(string providerName);

        /// <summary>Access FHIR STU3 NamingSystem resources for a specific provider.</summary>
        INamingSystemResource NamingSystems(string providerName);

        /// <summary>Access FHIR STU3 NutritionOrder resources for a specific provider.</summary>
        INutritionOrderResource NutritionOrders(string providerName);

        /// <summary>Access FHIR STU3 Observation resources for a specific provider.</summary>
        IObservationResource Observations(string providerName);

        /// <summary>Access FHIR STU3 OperationDefinition resources for a specific provider.</summary>
        IOperationDefinitionResource OperationDefinitions(string providerName);

        /// <summary>Access FHIR STU3 OperationOutcome resources for a specific provider.</summary>
        IOperationOutcomeResource OperationOutcomes(string providerName);

        /// <summary>Access FHIR STU3 Organization resources for a specific provider.</summary>
        IOrganizationResource Organizations(string providerName);

        /// <summary>Access FHIR STU3 Parameters resources for a specific provider.</summary>
        IParametersResource Parameterss(string providerName);

        /// <summary>Access FHIR STU3 Patient resources for a specific provider.</summary>
        IPatientResource Patients(string providerName);

        /// <summary>Access FHIR STU3 PaymentNotice resources for a specific provider.</summary>
        IPaymentNoticeResource PaymentNotices(string providerName);

        /// <summary>Access FHIR STU3 PaymentReconciliation resources for a specific provider.</summary>
        IPaymentReconciliationResource PaymentReconciliations(string providerName);

        /// <summary>Access FHIR STU3 Person resources for a specific provider.</summary>
        IPersonResource Persons(string providerName);

        /// <summary>Access FHIR STU3 PlanDefinition resources for a specific provider.</summary>
        IPlanDefinitionResource PlanDefinitions(string providerName);

        /// <summary>Access FHIR STU3 Practitioner resources for a specific provider.</summary>
        IPractitionerResource Practitioners(string providerName);

        /// <summary>Access FHIR STU3 PractitionerRole resources for a specific provider.</summary>
        IPractitionerRoleResource PractitionerRoles(string providerName);

        /// <summary>Access FHIR STU3 Procedure resources for a specific provider.</summary>
        IProcedureResource Procedures(string providerName);

        /// <summary>Access FHIR STU3 ProcedureRequest resources for a specific provider.</summary>
        IProcedureRequestResource ProcedureRequests(string providerName);

        /// <summary>Access FHIR STU3 Provenance resources for a specific provider.</summary>
        IProvenanceResource Provenances(string providerName);

        /// <summary>Access FHIR STU3 Questionnaire resources for a specific provider.</summary>
        IQuestionnaireResource Questionnaires(string providerName);

        /// <summary>Access FHIR STU3 QuestionnaireResponse resources for a specific provider.</summary>
        IQuestionnaireResponseResource QuestionnaireResponses(string providerName);

        /// <summary>Access FHIR STU3 RelatedPerson resources for a specific provider.</summary>
        IRelatedPersonResource RelatedPersons(string providerName);

        /// <summary>Access FHIR STU3 RequestGroup resources for a specific provider.</summary>
        IRequestGroupResource RequestGroups(string providerName);

        /// <summary>Access FHIR STU3 ResearchStudy resources for a specific provider.</summary>
        IResearchStudyResource ResearchStudies(string providerName);

        /// <summary>Access FHIR STU3 ResearchSubject resources for a specific provider.</summary>
        IResearchSubjectResource ResearchSubjects(string providerName);

        /// <summary>Access FHIR STU3 RiskAssessment resources for a specific provider.</summary>
        IRiskAssessmentResource RiskAssessments(string providerName);

        /// <summary>Access FHIR STU3 Schedule resources for a specific provider.</summary>
        IScheduleResource Schedules(string providerName);

        /// <summary>Access FHIR STU3 SearchParameter resources for a specific provider.</summary>
        ISearchParameterResource SearchParameters(string providerName);

        /// <summary>Access FHIR STU3 Slot resources for a specific provider.</summary>
        ISlotResource Slots(string providerName);

        /// <summary>Access FHIR STU3 Specimen resources for a specific provider.</summary>
        ISpecimenResource Specimens(string providerName);

        /// <summary>Access FHIR STU3 StructureDefinition resources for a specific provider.</summary>
        IStructureDefinitionResource StructureDefinitions(string providerName);

        /// <summary>Access FHIR STU3 StructureMap resources for a specific provider.</summary>
        IStructureMapResource StructureMaps(string providerName);

        /// <summary>Access FHIR STU3 Subscription resources for a specific provider.</summary>
        ISubscriptionResource Subscriptions(string providerName);

        /// <summary>Access FHIR STU3 Substance resources for a specific provider.</summary>
        ISubstanceResource Substances(string providerName);

        /// <summary>Access FHIR STU3 SupplyDelivery resources for a specific provider.</summary>
        ISupplyDeliveryResource SupplyDeliveries(string providerName);

        /// <summary>Access FHIR STU3 SupplyRequest resources for a specific provider.</summary>
        ISupplyRequestResource SupplyRequests(string providerName);

        /// <summary>Access FHIR STU3 Task resources for a specific provider.</summary>
        ITaskResource Tasks(string providerName);

        /// <summary>Access FHIR STU3 TestReport resources for a specific provider.</summary>
        ITestReportResource TestReports(string providerName);

        /// <summary>Access FHIR STU3 TestScript resources for a specific provider.</summary>
        ITestScriptResource TestScripts(string providerName);

        /// <summary>Access FHIR STU3 ValueSet resources for a specific provider.</summary>
        IValueSetResource ValueSets(string providerName);

        /// <summary>Access FHIR STU3 VisionPrescription resources for a specific provider.</summary>
        IVisionPrescriptionResource VisionPrescriptions(string providerName);
    }
}
