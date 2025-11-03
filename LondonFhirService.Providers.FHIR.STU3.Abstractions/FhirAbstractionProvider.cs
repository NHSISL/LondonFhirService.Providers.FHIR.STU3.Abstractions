// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

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

        public FhirAbstractionProvider(IEnumerable<IFhirProvider> fhirProviders)
        {
            this.FhirProviders = fhirProviders.ToImmutableArray();
            this.providerService = new ProviderService(this.FhirProviders);
        }
        /// <summary>Access FHIR Account resources for a specific provider.</summary>
        public IAccountResource Accounts(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Accounts);
        /// <summary>Access FHIR ActivityDefinition resources for a specific provider.</summary>
        public IActivityDefinitionResource ActivityDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ActivityDefinitions);
        /// <summary>Access FHIR AdverseEvent resources for a specific provider.</summary>
        public IAdverseEventResource AdverseEvents(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).AdverseEvents);
        /// <summary>Access FHIR AllergyIntolerance resources for a specific provider.</summary>
        public IAllergyIntoleranceResource AllergyIntolerances(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).AllergyIntolerances);
        /// <summary>Access FHIR Appointment resources for a specific provider.</summary>
        public IAppointmentResource Appointments(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Appointments);
        /// <summary>Access FHIR AppointmentResponse resources for a specific provider.</summary>
        public IAppointmentResponseResource AppointmentResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).AppointmentResponses);
        /// <summary>Access FHIR AuditEvent resources for a specific provider.</summary>
        public IAuditEventResource AuditEvents(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).AuditEvents);
        /// <summary>Access FHIR Basic resources for a specific provider.</summary>
        public IBasicResource Basics(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Basics);
        /// <summary>Access FHIR Binary resources for a specific provider.</summary>
        public IBinaryResource Binaries(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Binaries);
        /// <summary>Access FHIR BodySite resources for a specific provider.</summary>
        public IBodySiteResource BodySites(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).BodySites);
        /// <summary>Access FHIR Bundle resources for a specific provider.</summary>
        public IBundleResource Bundles(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Bundles);
        /// <summary>Access FHIR CapabilityStatement resources for a specific provider.</summary>
        public ICapabilityStatementResource CapabilityStatements(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).CapabilityStatements);
        /// <summary>Access FHIR CarePlan resources for a specific provider.</summary>
        public ICarePlanResource CarePlans(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).CarePlans);
        /// <summary>Access FHIR CareTeam resources for a specific provider.</summary>
        public ICareTeamResource CareTeams(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).CareTeams);
        /// <summary>Access FHIR ChargeItem resources for a specific provider.</summary>
        public IChargeItemResource ChargeItems(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ChargeItems);
        /// <summary>Access FHIR Claim resources for a specific provider.</summary>
        public IClaimResource Claims(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Claims);
        /// <summary>Access FHIR ClaimResponse resources for a specific provider.</summary>
        public IClaimResponseResource ClaimResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ClaimResponses);
        /// <summary>Access FHIR ClinicalImpression resources for a specific provider.</summary>
        public IClinicalImpressionResource ClinicalImpressions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ClinicalImpressions);
        /// <summary>Access FHIR CodeSystem resources for a specific provider.</summary>
        public ICodeSystemResource CodeSystems(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).CodeSystems);
        /// <summary>Access FHIR Communication resources for a specific provider.</summary>
        public ICommunicationResource Communications(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Communications);
        /// <summary>Access FHIR CommunicationRequest resources for a specific provider.</summary>
        public ICommunicationRequestResource CommunicationRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).CommunicationRequests);
        /// <summary>Access FHIR CompartmentDefinition resources for a specific provider.</summary>
        public ICompartmentDefinitionResource CompartmentDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).CompartmentDefinitions);
        /// <summary>Access FHIR Composition resources for a specific provider.</summary>
        public ICompositionResource Compositions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Compositions);
        /// <summary>Access FHIR ConceptMap resources for a specific provider.</summary>
        public IConceptMapResource ConceptMaps(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ConceptMaps);
        /// <summary>Access FHIR Condition resources for a specific provider.</summary>
        public IConditionResource Conditions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Conditions);
        /// <summary>Access FHIR Consent resources for a specific provider.</summary>
        public IConsentResource Consents(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Consents);
        /// <summary>Access FHIR Contract resources for a specific provider.</summary>
        public IContractResource Contracts(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Contracts);
        /// <summary>Access FHIR Coverage resources for a specific provider.</summary>
        public ICoverageResource Coverages(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Coverages);
        /// <summary>Access FHIR DataElement resources for a specific provider.</summary>
        public IDataElementResource DataElements(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DataElements);
        /// <summary>Access FHIR DetectedIssue resources for a specific provider.</summary>
        public IDetectedIssueResource DetectedIssues(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DetectedIssues);
        /// <summary>Access FHIR Device resources for a specific provider.</summary>
        public IDeviceResource Devices(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Devices);
        /// <summary>Access FHIR DeviceComponent resources for a specific provider.</summary>
        public IDeviceComponentResource DeviceComponents(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DeviceComponents);
        /// <summary>Access FHIR DeviceMetric resources for a specific provider.</summary>
        public IDeviceMetricResource DeviceMetrics(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DeviceMetrics);
        /// <summary>Access FHIR DeviceRequest resources for a specific provider.</summary>
        public IDeviceRequestResource DeviceRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DeviceRequests);
        /// <summary>Access FHIR DeviceUseStatement resources for a specific provider.</summary>
        public IDeviceUseStatementResource DeviceUseStatements(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DeviceUseStatements);
        /// <summary>Access FHIR DiagnosticReport resources for a specific provider.</summary>
        public IDiagnosticReportResource DiagnosticReports(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DiagnosticReports);
        /// <summary>Access FHIR DocumentManifest resources for a specific provider.</summary>
        public IDocumentManifestResource DocumentManifests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DocumentManifests);
        /// <summary>Access FHIR DocumentReference resources for a specific provider.</summary>
        public IDocumentReferenceResource DocumentReferences(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).DocumentReferences);
        /// <summary>Access FHIR EligibilityRequest resources for a specific provider.</summary>
        public IEligibilityRequestResource EligibilityRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).EligibilityRequests);
        /// <summary>Access FHIR EligibilityResponse resources for a specific provider.</summary>
        public IEligibilityResponseResource EligibilityResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).EligibilityResponses);
        /// <summary>Access FHIR Encounter resources for a specific provider.</summary>
        public IEncounterResource Encounters(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Encounters);
        /// <summary>Access FHIR Endpoint resources for a specific provider.</summary>
        public IEndpointResource Endpoints(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Endpoints);
        /// <summary>Access FHIR EnrollmentRequest resources for a specific provider.</summary>
        public IEnrollmentRequestResource EnrollmentRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).EnrollmentRequests);
        /// <summary>Access FHIR EnrollmentResponse resources for a specific provider.</summary>
        public IEnrollmentResponseResource EnrollmentResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).EnrollmentResponses);
        /// <summary>Access FHIR EpisodeOfCare resources for a specific provider.</summary>
        public IEpisodeOfCareResource EpisodeOfCares(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).EpisodeOfCares);
        /// <summary>Access FHIR ExpansionProfile resources for a specific provider.</summary>
        public IExpansionProfileResource ExpansionProfiles(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ExpansionProfiles);
        /// <summary>Access FHIR ExplanationOfBenefit resources for a specific provider.</summary>
        public IExplanationOfBenefitResource ExplanationOfBenefits(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ExplanationOfBenefits);
        /// <summary>Access FHIR FamilyMemberHistory resources for a specific provider.</summary>
        public IFamilyMemberHistoryResource FamilyMemberHistories(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).FamilyMemberHistories);
        /// <summary>Access FHIR Flag resources for a specific provider.</summary>
        public IFlagResource Flags(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Flags);
        /// <summary>Access FHIR Goal resources for a specific provider.</summary>
        public IGoalResource Goals(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Goals);
        /// <summary>Access FHIR GraphDefinition resources for a specific provider.</summary>
        public IGraphDefinitionResource GraphDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).GraphDefinitions);
        /// <summary>Access FHIR Group resources for a specific provider.</summary>
        public IGroupResource Groups(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Groups);
        /// <summary>Access FHIR GuidanceResponse resources for a specific provider.</summary>
        public IGuidanceResponseResource GuidanceResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).GuidanceResponses);
        /// <summary>Access FHIR HealthcareService resources for a specific provider.</summary>
        public IHealthcareServiceResource HealthcareServices(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).HealthcareServices);
        /// <summary>Access FHIR ImagingManifest resources for a specific provider.</summary>
        public IImagingManifestResource ImagingManifests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ImagingManifests);
        /// <summary>Access FHIR ImagingStudy resources for a specific provider.</summary>
        public IImagingStudyResource ImagingStudies(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ImagingStudies);
        /// <summary>Access FHIR Immunization resources for a specific provider.</summary>
        public IImmunizationResource Immunizations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Immunizations);
        /// <summary>Access FHIR ImmunizationRecommendation resources for a specific provider.</summary>
        public IImmunizationRecommendationResource ImmunizationRecommendations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ImmunizationRecommendations);
        /// <summary>Access FHIR ImplementationGuide resources for a specific provider.</summary>
        public IImplementationGuideResource ImplementationGuides(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ImplementationGuides);
        /// <summary>Access FHIR Library resources for a specific provider.</summary>
        public ILibraryResource Libraries(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Libraries);
        /// <summary>Access FHIR Linkage resources for a specific provider.</summary>
        public ILinkageResource Linkages(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Linkages);
        /// <summary>Access FHIR List resources for a specific provider.</summary>
        public IListResource Lists(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Lists);
        /// <summary>Access FHIR Location resources for a specific provider.</summary>
        public ILocationResource Locations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Locations);
        /// <summary>Access FHIR Measure resources for a specific provider.</summary>
        public IMeasureResource Measures(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Measures);
        /// <summary>Access FHIR MeasureReport resources for a specific provider.</summary>
        public IMeasureReportResource MeasureReports(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MeasureReports);
        /// <summary>Access FHIR Media resources for a specific provider.</summary>
        public IMediaResource Media(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Media);
        /// <summary>Access FHIR Medication resources for a specific provider.</summary>
        public IMedicationResource Medications(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Medications);
        /// <summary>Access FHIR MedicationAdministration resources for a specific provider.</summary>
        public IMedicationAdministrationResource MedicationAdministrations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MedicationAdministrations);
        /// <summary>Access FHIR MedicationDispense resources for a specific provider.</summary>
        public IMedicationDispenseResource MedicationDispenses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MedicationDispenses);
        /// <summary>Access FHIR MedicationRequest resources for a specific provider.</summary>
        public IMedicationRequestResource MedicationRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MedicationRequests);
        /// <summary>Access FHIR MedicationStatement resources for a specific provider.</summary>
        public IMedicationStatementResource MedicationStatements(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MedicationStatements);
        /// <summary>Access FHIR MessageDefinition resources for a specific provider.</summary>
        public IMessageDefinitionResource MessageDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MessageDefinitions);
        /// <summary>Access FHIR MessageHeader resources for a specific provider.</summary>
        public IMessageHeaderResource MessageHeaders(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).MessageHeaders);
        /// <summary>Access FHIR NamingSystem resources for a specific provider.</summary>
        public INamingSystemResource NamingSystems(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).NamingSystems);
        /// <summary>Access FHIR NutritionOrder resources for a specific provider.</summary>
        public INutritionOrderResource NutritionOrders(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).NutritionOrders);
        /// <summary>Access FHIR Observation resources for a specific provider.</summary>
        public IObservationResource Observations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Observations);
        /// <summary>Access FHIR OperationDefinition resources for a specific provider.</summary>
        public IOperationDefinitionResource OperationDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).OperationDefinitions);
        /// <summary>Access FHIR OperationOutcome resources for a specific provider.</summary>
        public IOperationOutcomeResource OperationOutcomes(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).OperationOutcomes);
        /// <summary>Access FHIR Organization resources for a specific provider.</summary>
        public IOrganizationResource Organizations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Organizations);
        /// <summary>Access FHIR Parameters resources for a specific provider.</summary>
        public IParametersResource Parameters(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Parameters);
        /// <summary>Access FHIR Patient resources for a specific provider.</summary>
        public IPatientResource Patients(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Patients);
        /// <summary>Access FHIR PaymentNotice resources for a specific provider.</summary>
        public IPaymentNoticeResource PaymentNotices(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).PaymentNotices);
        /// <summary>Access FHIR PaymentReconciliation resources for a specific provider.</summary>
        public IPaymentReconciliationResource PaymentReconciliations(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).PaymentReconciliations);
        /// <summary>Access FHIR Person resources for a specific provider.</summary>
        public IPersonResource Persons(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Persons);
        /// <summary>Access FHIR PlanDefinition resources for a specific provider.</summary>
        public IPlanDefinitionResource PlanDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).PlanDefinitions);
        /// <summary>Access FHIR Practitioner resources for a specific provider.</summary>
        public IPractitionerResource Practitioners(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Practitioners);
        /// <summary>Access FHIR PractitionerRole resources for a specific provider.</summary>
        public IPractitionerRoleResource PractitionerRoles(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).PractitionerRoles);
        /// <summary>Access FHIR Procedure resources for a specific provider.</summary>
        public IProcedureResource Procedures(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Procedures);
        /// <summary>Access FHIR ProcedureRequest resources for a specific provider.</summary>
        public IProcedureRequestResource ProcedureRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ProcedureRequests);
        /// <summary>Access FHIR ProcessRequest resources for a specific provider.</summary>
        public IProcessRequestResource ProcessRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ProcessRequests);
        /// <summary>Access FHIR ProcessResponse resources for a specific provider.</summary>
        public IProcessResponseResource ProcessResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ProcessResponses);
        /// <summary>Access FHIR Provenance resources for a specific provider.</summary>
        public IProvenanceResource Provenances(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Provenances);
        /// <summary>Access FHIR Questionnaire resources for a specific provider.</summary>
        public IQuestionnaireResource Questionnaires(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Questionnaires);
        /// <summary>Access FHIR QuestionnaireResponse resources for a specific provider.</summary>
        public IQuestionnaireResponseResource QuestionnaireResponses(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).QuestionnaireResponses);
        /// <summary>Access FHIR ReferralRequest resources for a specific provider.</summary>
        public IReferralRequestResource ReferralRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ReferralRequests);
        /// <summary>Access FHIR RelatedPerson resources for a specific provider.</summary>
        public IRelatedPersonResource RelatedPersons(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).RelatedPersons);
        /// <summary>Access FHIR RequestGroup resources for a specific provider.</summary>
        public IRequestGroupResource RequestGroups(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).RequestGroups);
        /// <summary>Access FHIR ResearchStudy resources for a specific provider.</summary>
        public IResearchStudyResource ResearchStudies(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ResearchStudies);
        /// <summary>Access FHIR ResearchSubject resources for a specific provider.</summary>
        public IResearchSubjectResource ResearchSubjects(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ResearchSubjects);
        /// <summary>Access FHIR RiskAssessment resources for a specific provider.</summary>
        public IRiskAssessmentResource RiskAssessments(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).RiskAssessments);
        /// <summary>Access FHIR Schedule resources for a specific provider.</summary>
        public IScheduleResource Schedules(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Schedules);
        /// <summary>Access FHIR SearchParameter resources for a specific provider.</summary>
        public ISearchParameterResource SearchParameters(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).SearchParameters);
        /// <summary>Access FHIR Sequence resources for a specific provider.</summary>
        public ISequenceResource Sequences(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Sequences);
        /// <summary>Access FHIR ServiceDefinition resources for a specific provider.</summary>
        public IServiceDefinitionResource ServiceDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ServiceDefinitions);
        /// <summary>Access FHIR Slot resources for a specific provider.</summary>
        public ISlotResource Slots(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Slots);
        /// <summary>Access FHIR Specimen resources for a specific provider.</summary>
        public ISpecimenResource Specimens(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Specimens);
        /// <summary>Access FHIR StructureDefinition resources for a specific provider.</summary>
        public IStructureDefinitionResource StructureDefinitions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).StructureDefinitions);
        /// <summary>Access FHIR StructureMap resources for a specific provider.</summary>
        public IStructureMapResource StructureMaps(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).StructureMaps);
        /// <summary>Access FHIR Subscription resources for a specific provider.</summary>
        public ISubscriptionResource Subscriptions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Subscriptions);
        /// <summary>Access FHIR Substance resources for a specific provider.</summary>
        public ISubstanceResource Substances(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Substances);
        /// <summary>Access FHIR SupplyDelivery resources for a specific provider.</summary>
        public ISupplyDeliveryResource SupplyDeliveries(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).SupplyDeliveries);
        /// <summary>Access FHIR SupplyRequest resources for a specific provider.</summary>
        public ISupplyRequestResource SupplyRequests(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).SupplyRequests);
        /// <summary>Access FHIR Task resources for a specific provider.</summary>
        public ITaskResource Tasks(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).Tasks);
        /// <summary>Access FHIR TestScript resources for a specific provider.</summary>
        public ITestScriptResource TestScripts(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).TestScripts);
        /// <summary>Access FHIR TestReport resources for a specific provider.</summary>
        public ITestReportResource TestReports(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).TestReports);
        /// <summary>Access FHIR ValueSet resources for a specific provider.</summary>
        public IValueSetResource ValueSets(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).ValueSets);
        /// <summary>Access FHIR VisionPrescription resources for a specific provider.</summary>
        public IVisionPrescriptionResource VisionPrescriptions(string providerName) =>
            TryCatch(() => providerService.GetProviderByName(providerName).VisionPrescriptions);
    }
}
