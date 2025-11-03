// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions
{
    /// <summary>Aggregates multiple STU3 providers.</summary>
    public interface IFhirAbstractionProvider
    {
        IReadOnlyCollection<IFhirProvider> FhirProviders { get; }
        /// <summary>Access FHIR Account resources.</summary>
        IAccountResource Accounts(string providerName);
        /// <summary>Access FHIR ActivityDefinition resources.</summary>
        IActivityDefinitionResource ActivityDefinitions(string providerName);
        /// <summary>Access FHIR AdverseEvent resources.</summary>
        IAdverseEventResource AdverseEvents(string providerName);
        /// <summary>Access FHIR AllergyIntolerance resources.</summary>
        IAllergyIntoleranceResource AllergyIntolerances(string providerName);
        /// <summary>Access FHIR Appointment resources.</summary>
        IAppointmentResource Appointments(string providerName);
        /// <summary>Access FHIR AppointmentResponse resources.</summary>
        IAppointmentResponseResource AppointmentResponses(string providerName);
        /// <summary>Access FHIR AuditEvent resources.</summary>
        IAuditEventResource AuditEvents(string providerName);
        /// <summary>Access FHIR Basic resources.</summary>
        IBasicResource Basics(string providerName);
        /// <summary>Access FHIR Binary resources.</summary>
        IBinaryResource Binaries(string providerName);
        /// <summary>Access FHIR BodySite resources.</summary>
        IBodySiteResource BodySites(string providerName);
        /// <summary>Access FHIR Bundle resources.</summary>
        IBundleResource Bundles(string providerName);
        /// <summary>Access FHIR CapabilityStatement resources.</summary>
        ICapabilityStatementResource CapabilityStatements(string providerName);
        /// <summary>Access FHIR CarePlan resources.</summary>
        ICarePlanResource CarePlans(string providerName);
        /// <summary>Access FHIR CareTeam resources.</summary>
        ICareTeamResource CareTeams(string providerName);
        /// <summary>Access FHIR ChargeItem resources.</summary>
        IChargeItemResource ChargeItems(string providerName);
        /// <summary>Access FHIR Claim resources.</summary>
        IClaimResource Claims(string providerName);
        /// <summary>Access FHIR ClaimResponse resources.</summary>
        IClaimResponseResource ClaimResponses(string providerName);
        /// <summary>Access FHIR ClinicalImpression resources.</summary>
        IClinicalImpressionResource ClinicalImpressions(string providerName);
        /// <summary>Access FHIR CodeSystem resources.</summary>
        ICodeSystemResource CodeSystems(string providerName);
        /// <summary>Access FHIR Communication resources.</summary>
        ICommunicationResource Communications(string providerName);
        /// <summary>Access FHIR CommunicationRequest resources.</summary>
        ICommunicationRequestResource CommunicationRequests(string providerName);
        /// <summary>Access FHIR CompartmentDefinition resources.</summary>
        ICompartmentDefinitionResource CompartmentDefinitions(string providerName);
        /// <summary>Access FHIR Composition resources.</summary>
        ICompositionResource Compositions(string providerName);
        /// <summary>Access FHIR ConceptMap resources.</summary>
        IConceptMapResource ConceptMaps(string providerName);
        /// <summary>Access FHIR Condition resources.</summary>
        IConditionResource Conditions(string providerName);
        /// <summary>Access FHIR Consent resources.</summary>
        IConsentResource Consents(string providerName);
        /// <summary>Access FHIR Contract resources.</summary>
        IContractResource Contracts(string providerName);
        /// <summary>Access FHIR Coverage resources.</summary>
        ICoverageResource Coverages(string providerName);
        /// <summary>Access FHIR DataElement resources.</summary>
        IDataElementResource DataElements(string providerName);
        /// <summary>Access FHIR DetectedIssue resources.</summary>
        IDetectedIssueResource DetectedIssues(string providerName);
        /// <summary>Access FHIR Device resources.</summary>
        IDeviceResource Devices(string providerName);
        /// <summary>Access FHIR DeviceComponent resources.</summary>
        IDeviceComponentResource DeviceComponents(string providerName);
        /// <summary>Access FHIR DeviceMetric resources.</summary>
        IDeviceMetricResource DeviceMetrics(string providerName);
        /// <summary>Access FHIR DeviceRequest resources.</summary>
        IDeviceRequestResource DeviceRequests(string providerName);
        /// <summary>Access FHIR DeviceUseStatement resources.</summary>
        IDeviceUseStatementResource DeviceUseStatements(string providerName);
        /// <summary>Access FHIR DiagnosticReport resources.</summary>
        IDiagnosticReportResource DiagnosticReports(string providerName);
        /// <summary>Access FHIR DocumentManifest resources.</summary>
        IDocumentManifestResource DocumentManifests(string providerName);
        /// <summary>Access FHIR DocumentReference resources.</summary>
        IDocumentReferenceResource DocumentReferences(string providerName);
        /// <summary>Access FHIR EligibilityRequest resources.</summary>
        IEligibilityRequestResource EligibilityRequests(string providerName);
        /// <summary>Access FHIR EligibilityResponse resources.</summary>
        IEligibilityResponseResource EligibilityResponses(string providerName);
        /// <summary>Access FHIR Encounter resources.</summary>
        IEncounterResource Encounters(string providerName);
        /// <summary>Access FHIR Endpoint resources.</summary>
        IEndpointResource Endpoints(string providerName);
        /// <summary>Access FHIR EnrollmentRequest resources.</summary>
        IEnrollmentRequestResource EnrollmentRequests(string providerName);
        /// <summary>Access FHIR EnrollmentResponse resources.</summary>
        IEnrollmentResponseResource EnrollmentResponses(string providerName);
        /// <summary>Access FHIR EpisodeOfCare resources.</summary>
        IEpisodeOfCareResource EpisodeOfCares(string providerName);
        /// <summary>Access FHIR ExpansionProfile resources.</summary>
        IExpansionProfileResource ExpansionProfiles(string providerName);
        /// <summary>Access FHIR ExplanationOfBenefit resources.</summary>
        IExplanationOfBenefitResource ExplanationOfBenefits(string providerName);
        /// <summary>Access FHIR FamilyMemberHistory resources.</summary>
        IFamilyMemberHistoryResource FamilyMemberHistories(string providerName);
        /// <summary>Access FHIR Flag resources.</summary>
        IFlagResource Flags(string providerName);
        /// <summary>Access FHIR Goal resources.</summary>
        IGoalResource Goals(string providerName);
        /// <summary>Access FHIR GraphDefinition resources.</summary>
        IGraphDefinitionResource GraphDefinitions(string providerName);
        /// <summary>Access FHIR Group resources.</summary>
        IGroupResource Groups(string providerName);
        /// <summary>Access FHIR GuidanceResponse resources.</summary>
        IGuidanceResponseResource GuidanceResponses(string providerName);
        /// <summary>Access FHIR HealthcareService resources.</summary>
        IHealthcareServiceResource HealthcareServices(string providerName);
        /// <summary>Access FHIR ImagingManifest resources.</summary>
        IImagingManifestResource ImagingManifests(string providerName);
        /// <summary>Access FHIR ImagingStudy resources.</summary>
        IImagingStudyResource ImagingStudies(string providerName);
        /// <summary>Access FHIR Immunization resources.</summary>
        IImmunizationResource Immunizations(string providerName);
        /// <summary>Access FHIR ImmunizationRecommendation resources.</summary>
        IImmunizationRecommendationResource ImmunizationRecommendations(string providerName);
        /// <summary>Access FHIR ImplementationGuide resources.</summary>
        IImplementationGuideResource ImplementationGuides(string providerName);
        /// <summary>Access FHIR Library resources.</summary>
        ILibraryResource Libraries(string providerName);
        /// <summary>Access FHIR Linkage resources.</summary>
        ILinkageResource Linkages(string providerName);
        /// <summary>Access FHIR List resources.</summary>
        IListResource Lists(string providerName);
        /// <summary>Access FHIR Location resources.</summary>
        ILocationResource Locations(string providerName);
        /// <summary>Access FHIR Measure resources.</summary>
        IMeasureResource Measures(string providerName);
        /// <summary>Access FHIR MeasureReport resources.</summary>
        IMeasureReportResource MeasureReports(string providerName);
        /// <summary>Access FHIR Media resources.</summary>
        IMediaResource Media(string providerName);
        /// <summary>Access FHIR Medication resources.</summary>
        IMedicationResource Medications(string providerName);
        /// <summary>Access FHIR MedicationAdministration resources.</summary>
        IMedicationAdministrationResource MedicationAdministrations(string providerName);
        /// <summary>Access FHIR MedicationDispense resources.</summary>
        IMedicationDispenseResource MedicationDispenses(string providerName);
        /// <summary>Access FHIR MedicationRequest resources.</summary>
        IMedicationRequestResource MedicationRequests(string providerName);
        /// <summary>Access FHIR MedicationStatement resources.</summary>
        IMedicationStatementResource MedicationStatements(string providerName);
        /// <summary>Access FHIR MessageDefinition resources.</summary>
        IMessageDefinitionResource MessageDefinitions(string providerName);
        /// <summary>Access FHIR MessageHeader resources.</summary>
        IMessageHeaderResource MessageHeaders(string providerName);
        /// <summary>Access FHIR NamingSystem resources.</summary>
        INamingSystemResource NamingSystems(string providerName);
        /// <summary>Access FHIR NutritionOrder resources.</summary>
        INutritionOrderResource NutritionOrders(string providerName);
        /// <summary>Access FHIR Observation resources.</summary>
        IObservationResource Observations(string providerName);
        /// <summary>Access FHIR OperationDefinition resources.</summary>
        IOperationDefinitionResource OperationDefinitions(string providerName);
        /// <summary>Access FHIR OperationOutcome resources.</summary>
        IOperationOutcomeResource OperationOutcomes(string providerName);
        /// <summary>Access FHIR Organization resources.</summary>
        IOrganizationResource Organizations(string providerName);
        /// <summary>Access FHIR Parameters resources.</summary>
        IParametersResource Parameters(string providerName);
        /// <summary>Access FHIR Patient resources.</summary>
        IPatientResource Patients(string providerName);
        /// <summary>Access FHIR PaymentNotice resources.</summary>
        IPaymentNoticeResource PaymentNotices(string providerName);
        /// <summary>Access FHIR PaymentReconciliation resources.</summary>
        IPaymentReconciliationResource PaymentReconciliations(string providerName);
        /// <summary>Access FHIR Person resources.</summary>
        IPersonResource Persons(string providerName);
        /// <summary>Access FHIR PlanDefinition resources.</summary>
        IPlanDefinitionResource PlanDefinitions(string providerName);
        /// <summary>Access FHIR Practitioner resources.</summary>
        IPractitionerResource Practitioners(string providerName);
        /// <summary>Access FHIR PractitionerRole resources.</summary>
        IPractitionerRoleResource PractitionerRoles(string providerName);
        /// <summary>Access FHIR Procedure resources.</summary>
        IProcedureResource Procedures(string providerName);
        /// <summary>Access FHIR ProcedureRequest resources.</summary>
        IProcedureRequestResource ProcedureRequests(string providerName);
        /// <summary>Access FHIR ProcessRequest resources.</summary>
        IProcessRequestResource ProcessRequests(string providerName);
        /// <summary>Access FHIR ProcessResponse resources.</summary>
        IProcessResponseResource ProcessResponses(string providerName);
        /// <summary>Access FHIR Provenance resources.</summary>
        IProvenanceResource Provenances(string providerName);
        /// <summary>Access FHIR Questionnaire resources.</summary>
        IQuestionnaireResource Questionnaires(string providerName);
        /// <summary>Access FHIR QuestionnaireResponse resources.</summary>
        IQuestionnaireResponseResource QuestionnaireResponses(string providerName);
        /// <summary>Access FHIR ReferralRequest resources.</summary>
        IReferralRequestResource ReferralRequests(string providerName);
        /// <summary>Access FHIR RelatedPerson resources.</summary>
        IRelatedPersonResource RelatedPersons(string providerName);
        /// <summary>Access FHIR RequestGroup resources.</summary>
        IRequestGroupResource RequestGroups(string providerName);
        /// <summary>Access FHIR ResearchStudy resources.</summary>
        IResearchStudyResource ResearchStudies(string providerName);
        /// <summary>Access FHIR ResearchSubject resources.</summary>
        IResearchSubjectResource ResearchSubjects(string providerName);
        /// <summary>Access FHIR RiskAssessment resources.</summary>
        IRiskAssessmentResource RiskAssessments(string providerName);
        /// <summary>Access FHIR Schedule resources.</summary>
        IScheduleResource Schedules(string providerName);
        /// <summary>Access FHIR SearchParameter resources.</summary>
        ISearchParameterResource SearchParameters(string providerName);
        /// <summary>Access FHIR Sequence resources.</summary>
        ISequenceResource Sequences(string providerName);
        /// <summary>Access FHIR ServiceDefinition resources.</summary>
        IServiceDefinitionResource ServiceDefinitions(string providerName);
        /// <summary>Access FHIR Slot resources.</summary>
        ISlotResource Slots(string providerName);
        /// <summary>Access FHIR Specimen resources.</summary>
        ISpecimenResource Specimens(string providerName);
        /// <summary>Access FHIR StructureDefinition resources.</summary>
        IStructureDefinitionResource StructureDefinitions(string providerName);
        /// <summary>Access FHIR StructureMap resources.</summary>
        IStructureMapResource StructureMaps(string providerName);
        /// <summary>Access FHIR Subscription resources.</summary>
        ISubscriptionResource Subscriptions(string providerName);
        /// <summary>Access FHIR Substance resources.</summary>
        ISubstanceResource Substances(string providerName);
        /// <summary>Access FHIR SupplyDelivery resources.</summary>
        ISupplyDeliveryResource SupplyDeliveries(string providerName);
        /// <summary>Access FHIR SupplyRequest resources.</summary>
        ISupplyRequestResource SupplyRequests(string providerName);
        /// <summary>Access FHIR Task resources.</summary>
        ITaskResource Tasks(string providerName);
        /// <summary>Access FHIR TestScript resources.</summary>
        ITestScriptResource TestScripts(string providerName);
        /// <summary>Access FHIR TestReport resources.</summary>
        ITestReportResource TestReports(string providerName);
        /// <summary>Access FHIR ValueSet resources.</summary>
        IValueSetResource ValueSets(string providerName);
        /// <summary>Access FHIR VisionPrescription resources.</summary>
        IVisionPrescriptionResource VisionPrescriptions(string providerName);
    }
}
