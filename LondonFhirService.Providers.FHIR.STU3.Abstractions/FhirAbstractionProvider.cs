// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Services.Foundations;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions
{

    /// <summary>Resolves per-provider resource facades.</summary>
    public partial class FhirAbstractionProvider : IFhirAbstractionProvider
    {
        private IProviderService providerService { get; set; }
        public IReadOnlyCollection<IFhirProvider> FhirProviders { get; private set; }


        /// <summary>Creates a new abstraction over concrete STU3 providers.</summary>
        /// <param name="fhirProviders">Concrete providers to register.</param>
        public FhirAbstractionProvider(IEnumerable<IFhirProvider> fhirProviders)
        {
            fhirProviders ??= Array.Empty<IFhirProvider>();
            this.FhirProviders = fhirProviders.ToImmutableArray();
            this.providerService = new ProviderService(this.FhirProviders);
        }


        /// <summary>Access FHIR STU3 Account resources for a specific provider.</summary>
        public IAccountResource Accounts(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Accounts);

        /// <summary>Access FHIR STU3 ActivityDefinition resources for a specific provider.</summary>
        public IActivityDefinitionResource ActivityDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ActivityDefinitions);

        /// <summary>Access FHIR STU3 AllergyIntolerance resources for a specific provider.</summary>
        public IAllergyIntoleranceResource AllergyIntolerances(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).AllergyIntolerances);

        /// <summary>Access FHIR STU3 Appointment resources for a specific provider.</summary>
        public IAppointmentResource Appointments(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Appointments);

        /// <summary>Access FHIR STU3 AppointmentResponse resources for a specific provider.</summary>
        public IAppointmentResponseResource AppointmentResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).AppointmentResponses);

        /// <summary>Access FHIR STU3 AuditEvent resources for a specific provider.</summary>
        public IAuditEventResource AuditEvents(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).AuditEvents);

        /// <summary>Access FHIR STU3 Basic resources for a specific provider.</summary>
        public IBasicResource Basics(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Basics);

        /// <summary>Access FHIR STU3 Binary resources for a specific provider.</summary>
        public IBinaryResource Binaries(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Binaries);

        /// <summary>Access FHIR STU3 BodySite resources for a specific provider.</summary>
        public IBodySiteResource BodySites(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).BodySites);

        /// <summary>Access FHIR STU3 Bundle resources for a specific provider.</summary>
        public IBundleResource Bundles(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Bundles);

        /// <summary>Access FHIR STU3 CapabilityStatement resources for a specific provider.</summary>
        public ICapabilityStatementResource CapabilityStatements(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).CapabilityStatements);

        /// <summary>Access FHIR STU3 CarePlan resources for a specific provider.</summary>
        public ICarePlanResource CarePlans(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).CarePlans);

        /// <summary>Access FHIR STU3 CareTeam resources for a specific provider.</summary>
        public ICareTeamResource CareTeams(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).CareTeams);

        /// <summary>Access FHIR STU3 Claim resources for a specific provider.</summary>
        public IClaimResource Claims(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Claims);

        /// <summary>Access FHIR STU3 ClaimResponse resources for a specific provider.</summary>
        public IClaimResponseResource ClaimResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ClaimResponses);

        /// <summary>Access FHIR STU3 ClinicalImpression resources for a specific provider.</summary>
        public IClinicalImpressionResource ClinicalImpressions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ClinicalImpressions);

        /// <summary>Access FHIR STU3 CodeSystem resources for a specific provider.</summary>
        public ICodeSystemResource CodeSystems(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).CodeSystems);

        /// <summary>Access FHIR STU3 Communication resources for a specific provider.</summary>
        public ICommunicationResource Communications(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Communications);

        /// <summary>Access FHIR STU3 CommunicationRequest resources for a specific provider.</summary>
        public ICommunicationRequestResource CommunicationRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).CommunicationRequests);

        /// <summary>Access FHIR STU3 CompartmentDefinition resources for a specific provider.</summary>
        public ICompartmentDefinitionResource CompartmentDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).CompartmentDefinitions);

        /// <summary>Access FHIR STU3 Composition resources for a specific provider.</summary>
        public ICompositionResource Compositions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Compositions);

        /// <summary>Access FHIR STU3 ConceptMap resources for a specific provider.</summary>
        public IConceptMapResource ConceptMaps(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ConceptMaps);

        /// <summary>Access FHIR STU3 Condition resources for a specific provider.</summary>
        public IConditionResource Conditions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Conditions);

        /// <summary>Access FHIR STU3 Consent resources for a specific provider.</summary>
        public IConsentResource Consents(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Consents);

        /// <summary>Access FHIR STU3 Contract resources for a specific provider.</summary>
        public IContractResource Contracts(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Contracts);

        /// <summary>Access FHIR STU3 Coverage resources for a specific provider.</summary>
        public ICoverageResource Coverages(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Coverages);

        /// <summary>Access FHIR STU3 EligibilityRequest resources for a specific provider.</summary>
        public IEligibilityRequestResource EligibilityRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).EligibilityRequests);

        /// <summary>Access FHIR STU3 EligibilityResponse resources for a specific provider.</summary>
        public IEligibilityResponseResource EligibilityResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).EligibilityResponses);

        /// <summary>Access FHIR STU3 DetectedIssue resources for a specific provider.</summary>
        public IDetectedIssueResource DetectedIssues(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DetectedIssues);

        /// <summary>Access FHIR STU3 Device resources for a specific provider.</summary>
        public IDeviceResource Devices(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Devices);

        /// <summary>Access FHIR STU3 DeviceMetric resources for a specific provider.</summary>
        public IDeviceMetricResource DeviceMetrics(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DeviceMetrics);

        /// <summary>Access FHIR STU3 DeviceRequest resources for a specific provider.</summary>
        public IDeviceRequestResource DeviceRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DeviceRequests);

        /// <summary>Access FHIR STU3 DeviceUseStatement resources for a specific provider.</summary>
        public IDeviceUseStatementResource DeviceUseStatements(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DeviceUseStatements);

        /// <summary>Access FHIR STU3 DiagnosticReport resources for a specific provider.</summary>
        public IDiagnosticReportResource DiagnosticReports(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DiagnosticReports);

        /// <summary>Access FHIR STU3 DocumentManifest resources for a specific provider.</summary>
        public IDocumentManifestResource DocumentManifests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DocumentManifests);

        /// <summary>Access FHIR STU3 DocumentReference resources for a specific provider.</summary>
        public IDocumentReferenceResource DocumentReferences(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DocumentReferences);

        /// <summary>Access FHIR STU3 Encounter resources for a specific provider.</summary>
        public IEncounterResource Encounters(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Encounters);

        /// <summary>Access FHIR STU3 Endpoint resources for a specific provider.</summary>
        public IEndpointResource Endpoints(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Endpoints);

        /// <summary>Access FHIR STU3 EnrollmentRequest resources for a specific provider.</summary>
        public IEnrollmentRequestResource EnrollmentRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).EnrollmentRequests);

        /// <summary>Access FHIR STU3 EnrollmentResponse resources for a specific provider.</summary>
        public IEnrollmentResponseResource EnrollmentResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).EnrollmentResponses);

        /// <summary>Access FHIR STU3 EpisodeOfCare resources for a specific provider.</summary>
        public IEpisodeOfCareResource EpisodeOfCares(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).EpisodeOfCares);

        /// <summary>Access FHIR STU3 ExplanationOfBenefit resources for a specific provider.</summary>
        public IExplanationOfBenefitResource ExplanationOfBenefits(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ExplanationOfBenefits);

        /// <summary>Access FHIR STU3 FamilyMemberHistory resources for a specific provider.</summary>
        public IFamilyMemberHistoryResource FamilyMemberHistories(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).FamilyMemberHistories);

        /// <summary>Access FHIR STU3 Flag resources for a specific provider.</summary>
        public IFlagResource Flags(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Flags);

        /// <summary>Access FHIR STU3 Goal resources for a specific provider.</summary>
        public IGoalResource Goals(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Goals);

        /// <summary>Access FHIR STU3 GraphDefinition resources for a specific provider.</summary>
        public IGraphDefinitionResource GraphDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).GraphDefinitions);

        /// <summary>Access FHIR STU3 Group resources for a specific provider.</summary>
        public IGroupResource Groups(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Groups);

        /// <summary>Access FHIR STU3 GuidanceResponse resources for a specific provider.</summary>
        public IGuidanceResponseResource GuidanceResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).GuidanceResponses);

        /// <summary>Access FHIR STU3 HealthcareService resources for a specific provider.</summary>
        public IHealthcareServiceResource HealthcareServices(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).HealthcareServices);

        /// <summary>Access FHIR STU3 ImagingStudy resources for a specific provider.</summary>
        public IImagingStudyResource ImagingStudies(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ImagingStudies);

        /// <summary>Access FHIR STU3 Immunization resources for a specific provider.</summary>
        public IImmunizationResource Immunizations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Immunizations);

        /// <summary>Access FHIR STU3 ImmunizationRecommendation resources for a specific provider.</summary>
        public IImmunizationRecommendationResource ImmunizationRecommendations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ImmunizationRecommendations);

        /// <summary>Access FHIR STU3 ImplementationGuide resources for a specific provider.</summary>
        public IImplementationGuideResource ImplementationGuides(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ImplementationGuides);

        /// <summary>Access FHIR STU3 Library resources for a specific provider.</summary>
        public ILibraryResource Libraries(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Libraries);

        /// <summary>Access FHIR STU3 Linkage resources for a specific provider.</summary>
        public ILinkageResource Linkages(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Linkages);

        /// <summary>Access FHIR STU3 List resources for a specific provider.</summary>
        public IListResource Lists(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Lists);

        /// <summary>Access FHIR STU3 Location resources for a specific provider.</summary>
        public ILocationResource Locations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Locations);

        /// <summary>Access FHIR STU3 Measure resources for a specific provider.</summary>
        public IMeasureResource Measures(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Measures);

        /// <summary>Access FHIR STU3 MeasureReport resources for a specific provider.</summary>
        public IMeasureReportResource MeasureReports(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MeasureReports);

        /// <summary>Access FHIR STU3 Media resources for a specific provider.</summary>
        public IMediaResource Media(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Media);

        /// <summary>Access FHIR STU3 Medication resources for a specific provider.</summary>
        public IMedicationResource Medications(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Medications);

        /// <summary>Access FHIR STU3 MedicationAdministration resources for a specific provider.</summary>
        public IMedicationAdministrationResource MedicationAdministrations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MedicationAdministrations);

        /// <summary>Access FHIR STU3 MedicationDispense resources for a specific provider.</summary>
        public IMedicationDispenseResource MedicationDispenses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MedicationDispenses);

        /// <summary>Access FHIR STU3 MedicationRequest resources for a specific provider.</summary>
        public IMedicationRequestResource MedicationRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MedicationRequests);

        /// <summary>Access FHIR STU3 MedicationStatement resources for a specific provider.</summary>
        public IMedicationStatementResource MedicationStatements(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MedicationStatements);

        /// <summary>Access FHIR STU3 MessageDefinition resources for a specific provider.</summary>
        public IMessageDefinitionResource MessageDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MessageDefinitions);

        /// <summary>Access FHIR STU3 MessageHeader resources for a specific provider.</summary>
        public IMessageHeaderResource MessageHeaders(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MessageHeaders);

        /// <summary>Access FHIR STU3 Sequence resources for a specific provider.</summary>
        public ISequenceResource Sequences(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Sequences);

        /// <summary>Access FHIR STU3 NamingSystem resources for a specific provider.</summary>
        public INamingSystemResource NamingSystems(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).NamingSystems);

        /// <summary>Access FHIR STU3 NutritionOrder resources for a specific provider.</summary>
        public INutritionOrderResource NutritionOrders(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).NutritionOrders);

        /// <summary>Access FHIR STU3 Observation resources for a specific provider.</summary>
        public IObservationResource Observations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Observations);

        /// <summary>Access FHIR STU3 OperationDefinition resources for a specific provider.</summary>
        public IOperationDefinitionResource OperationDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).OperationDefinitions);

        /// <summary>Access FHIR STU3 OperationOutcome resources for a specific provider.</summary>
        public IOperationOutcomeResource OperationOutcomes(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).OperationOutcomes);

        /// <summary>Access FHIR STU3 Organization resources for a specific provider.</summary>
        public IOrganizationResource Organizations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Organizations);

        /// <summary>Access FHIR STU3 Parameters resources for a specific provider.</summary>
        public IParametersResource Parameterss(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Parameterss);

        /// <summary>Access FHIR STU3 Patient resources for a specific provider.</summary>
        public IPatientResource Patients(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Patients);

        /// <summary>Access FHIR STU3 PaymentNotice resources for a specific provider.</summary>
        public IPaymentNoticeResource PaymentNotices(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).PaymentNotices);

        /// <summary>Access FHIR STU3 PaymentReconciliation resources for a specific provider.</summary>
        public IPaymentReconciliationResource PaymentReconciliations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).PaymentReconciliations);

        /// <summary>Access FHIR STU3 Person resources for a specific provider.</summary>
        public IPersonResource Persons(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Persons);

        /// <summary>Access FHIR STU3 PlanDefinition resources for a specific provider.</summary>
        public IPlanDefinitionResource PlanDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).PlanDefinitions);

        /// <summary>Access FHIR STU3 Practitioner resources for a specific provider.</summary>
        public IPractitionerResource Practitioners(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Practitioners);

        /// <summary>Access FHIR STU3 PractitionerRole resources for a specific provider.</summary>
        public IPractitionerRoleResource PractitionerRoles(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).PractitionerRoles);

        /// <summary>Access FHIR STU3 Procedure resources for a specific provider.</summary>
        public IProcedureResource Procedures(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Procedures);

        /// <summary>Access FHIR STU3 ProcedureRequest resources for a specific provider.</summary>
        public IProcedureRequestResource ProcedureRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ProcedureRequests);

        /// <summary>Access FHIR STU3 Provenance resources for a specific provider.</summary>
        public IProvenanceResource Provenances(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Provenances);

        /// <summary>Access FHIR STU3 Questionnaire resources for a specific provider.</summary>
        public IQuestionnaireResource Questionnaires(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Questionnaires);

        /// <summary>Access FHIR STU3 QuestionnaireResponse resources for a specific provider.</summary>
        public IQuestionnaireResponseResource QuestionnaireResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).QuestionnaireResponses);

        /// <summary>Access FHIR STU3 RelatedPerson resources for a specific provider.</summary>
        public IRelatedPersonResource RelatedPersons(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).RelatedPersons);

        /// <summary>Access FHIR STU3 RequestGroup resources for a specific provider.</summary>
        public IRequestGroupResource RequestGroups(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).RequestGroups);

        /// <summary>Access FHIR STU3 ResearchStudy resources for a specific provider.</summary>
        public IResearchStudyResource ResearchStudies(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ResearchStudies);

        /// <summary>Access FHIR STU3 ResearchSubject resources for a specific provider.</summary>
        public IResearchSubjectResource ResearchSubjects(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ResearchSubjects);

        /// <summary>Access FHIR STU3 RiskAssessment resources for a specific provider.</summary>
        public IRiskAssessmentResource RiskAssessments(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).RiskAssessments);

        /// <summary>Access FHIR STU3 Schedule resources for a specific provider.</summary>
        public IScheduleResource Schedules(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Schedules);

        /// <summary>Access FHIR STU3 SearchParameter resources for a specific provider.</summary>
        public ISearchParameterResource SearchParameters(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).SearchParameters);

        /// <summary>Access FHIR STU3 Slot resources for a specific provider.</summary>
        public ISlotResource Slots(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Slots);

        /// <summary>Access FHIR STU3 Specimen resources for a specific provider.</summary>
        public ISpecimenResource Specimens(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Specimens);

        /// <summary>Access FHIR STU3 StructureDefinition resources for a specific provider.</summary>
        public IStructureDefinitionResource StructureDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).StructureDefinitions);

        /// <summary>Access FHIR STU3 StructureMap resources for a specific provider.</summary>
        public IStructureMapResource StructureMaps(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).StructureMaps);

        /// <summary>Access FHIR STU3 Subscription resources for a specific provider.</summary>
        public ISubscriptionResource Subscriptions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Subscriptions);

        /// <summary>Access FHIR STU3 Substance resources for a specific provider.</summary>
        public ISubstanceResource Substances(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Substances);

        /// <summary>Access FHIR STU3 SupplyDelivery resources for a specific provider.</summary>
        public ISupplyDeliveryResource SupplyDeliveries(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).SupplyDeliveries);

        /// <summary>Access FHIR STU3 SupplyRequest resources for a specific provider.</summary>
        public ISupplyRequestResource SupplyRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).SupplyRequests);

        /// <summary>Access FHIR STU3 Task resources for a specific provider.</summary>
        public ITaskResource Tasks(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Tasks);

        /// <summary>Access FHIR STU3 TestReport resources for a specific provider.</summary>
        public ITestReportResource TestReports(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).TestReports);

        /// <summary>Access FHIR STU3 TestScript resources for a specific provider.</summary>
        public ITestScriptResource TestScripts(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).TestScripts);

        /// <summary>Access FHIR STU3 ValueSet resources for a specific provider.</summary>
        public IValueSetResource ValueSets(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ValueSets);

        /// <summary>Access FHIR STU3 VisionPrescription resources for a specific provider.</summary>
        public IVisionPrescriptionResource VisionPrescriptions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).VisionPrescriptions);
    }
}
