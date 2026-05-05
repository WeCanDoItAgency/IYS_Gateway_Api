using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Kullanicilar
{
    public int Id { get; set; }

    public Guid UserGuid { get; set; }

    public string? PasaportNo { get; set; }

    public bool IsOpenPayment { get; set; }

    public string? CustomCode { get; set; }

    public string? CustomName { get; set; }

    public bool CanEnterPortal { get; set; }

    public string? Tc { get; set; }

    public int FirmId { get; set; }

    public int SubeId { get; set; }

    public string? Title { get; set; }

    public int? UserTypeId { get; set; }

    public int? UserRoleId { get; set; }

    public int? DepartmentId { get; set; }

    public string? Usr { get; set; }

    public string? Psswrd { get; set; }

    public string? Adi { get; set; }

    public string? Soyadi { get; set; }

    public string? AdaCode { get; set; }

    public string? DahiliNo { get; set; }

    public bool IsWbsrvc { get; set; }

    public bool IsWbsrvce { get; set; }

    public bool IsDesktop { get; set; }

    public bool IsfReports { get; set; }

    public bool IsbReports { get; set; }

    public bool IsuReports { get; set; }

    public bool? IsLocked { get; set; }

    public bool IsOnline { get; set; }

    public int? BrwId { get; set; }

    public int? MerkezId { get; set; }

    public int? AltSubeId { get; set; }

    public int? AltSubePersonelId { get; set; }

    public int? KatId { get; set; }

    public int? AltKatId { get; set; }

    public string? Email { get; set; }

    public string? Foriegntc { get; set; }

    public string? IpAdress { get; set; }

    public string? Gender { get; set; }

    public string? Telefon1 { get; set; }

    public int? UlkeId { get; set; }

    public int? SehirId { get; set; }

    public string? Ilce { get; set; }

    public string? Belde { get; set; }

    public string? Mahalle { get; set; }

    public string? Bulvar { get; set; }

    public string? Cadde { get; set; }

    public string? Sokak { get; set; }

    public string? BinaAdi { get; set; }

    public string? BinaNo { get; set; }

    public string? DaireNo { get; set; }

    public string? Telefon2 { get; set; }

    public string? PersonelCode { get; set; }

    public string? Departman { get; set; }

    public string? IseGirisTarihi { get; set; }

    public string? KanGrubu { get; set; }

    public string? DogumTarihi { get; set; }

    public string? DogumYeri { get; set; }

    public string? TokenId { get; set; }

    public DateTime? TokenExpireDate { get; set; }

    public string? SessionTokenId { get; set; }

    public string? IeToken { get; set; }

    public DateTime IeExpireDate { get; set; }

    public bool CanEnterHangfire { get; set; }

    public bool IsCallcenterOpen { get; set; }

    public bool CanHaveStaticToken { get; set; }

    public string? StaticToken { get; set; }

    public bool SmsActivated { get; set; }

    public string? SmsActivationCode { get; set; }

    public DateTime? SmsApproveDate { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? ProfilePicture { get; set; }

    public string? GcmToken { get; set; }

    public bool? CanEnterReference { get; set; }

    public bool CanSendPushNotifications { get; set; }

    public bool CanUseApi { get; set; }

    public int Day { get; set; }

    public DateTime PassExpireDate { get; set; }

    public bool CanSeeBalance { get; set; }

    public bool? CanSeeLocations { get; set; }

    public bool? SmsCampaign { get; set; }

    public bool? EmailCampaign { get; set; }

    public bool? CanSeeProduction { get; set; }

    public bool? CanCreatePoll { get; set; }

    public bool? CanManageDijipol { get; set; }

    public bool? CanSeeAccountancy { get; set; }

    public bool? CanTransferFile { get; set; }

    public bool? IsSuperadmin { get; set; }

    public bool? IsKontor { get; set; }

    public double KontorMiktari { get; set; }

    public double Kullanilan { get; set; }

    public double KalanKontor { get; set; }

    public bool? CanManuelSignature { get; set; }

    public bool? CanSearchProduction { get; set; }

    public bool? CanSeeOfferstatus { get; set; }

    public int? CreatedByUserId { get; set; }

    public string? MeslekKodu { get; set; }

    public string? MailgunAccessToken { get; set; }

    public string? PasswordSalt { get; set; }

    public bool Mfa { get; set; }

    public bool? IsSendPassMail { get; set; }

    public bool? IsSendPassSms { get; set; }

    public bool IsTeamLeader { get; set; }

    public int? TeamLeaderId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsSystemUser { get; set; }

    public bool? IsTechnicalPersonnel { get; set; }

    public bool? IsHaveUseSmsappPermission { get; set; }

    public bool? CanEnterOldRdp { get; set; }

    public bool? IsOperationLeader { get; set; }

    public int? OperationLeaderId { get; set; }

    public bool IsRdpTestUser { get; set; }

    public bool? Temsilci { get; set; }

    public bool? IsBotUser { get; set; }

    public Guid KullaniciGuid { get; set; }

    public bool? IsShowQueryScreenInRdp { get; set; }

    public bool? IsMailSystemUser { get; set; }

    public string? ProfilePicturePath { get; set; }

    public bool? IsShowCreditCard { get; set; }

    public bool? IsPoolUser { get; set; }

    public bool? SendWhatsApp { get; set; }

    public int? WhatsAppSmsQrId { get; set; }

    public string? MantisUserName { get; set; }

    public string? MantisPassword { get; set; }

    public int? ActivationStatus { get; set; }

    public bool? IsWhatsAppUser { get; set; }

    public bool? IsPazarlamaci { get; set; }

    public bool? IsBotTestUser { get; set; }

    public bool? SendAiWeeklyMail { get; set; }

    public virtual ICollection<A2elPoliceler> A2elPolicelerCalisilanuserNavigation { get; set; } = new List<A2elPoliceler>();

    public virtual ICollection<A2elPoliceler> A2elPolicelerKuser { get; set; } = new List<A2elPoliceler>();

    public virtual ICollection<A2elteklifBasliklar> A2elteklifBasliklarCalisilanuserNavigation { get; set; } = new List<A2elteklifBasliklar>();

    public virtual ICollection<A2elteklifBasliklar> A2elteklifBasliklarKuser { get; set; } = new List<A2elteklifBasliklar>();

    public virtual ICollection<AcenteOnlineCmssites> AcenteOnlineCmssites { get; set; } = new List<AcenteOnlineCmssites>();

    public virtual ICollection<AiUserTutorialScores> AiUserTutorialScores { get; set; } = new List<AiUserTutorialScores>();

    public virtual ICollection<AiUserWhatsAppGlobalPreferences> AiUserWhatsAppGlobalPreferences { get; set; } = new List<AiUserWhatsAppGlobalPreferences>();

    public virtual ICollection<AnlasmaliKurumUserFavs> AnlasmaliKurumUserFavs { get; set; } = new List<AnlasmaliKurumUserFavs>();

    public virtual ICollection<AnlasmaliKurumlarComments> AnlasmaliKurumlarComments { get; set; } = new List<AnlasmaliKurumlarComments>();

    public virtual ICollection<AnlasmaliServislerDirectionLog> AnlasmaliServislerDirectionLog { get; set; } = new List<AnlasmaliServislerDirectionLog>();

    public virtual ICollection<AracDetay> AracDetay { get; set; } = new List<AracDetay>();

    public virtual ICollection<BesBasliklar> BesBasliklarCalisilanuserNavigation { get; set; } = new List<BesBasliklar>();

    public virtual ICollection<BesBasliklar> BesBasliklarKuser { get; set; } = new List<BesBasliklar>();

    public virtual ICollection<BesPoliceler> BesPolicelerCalisilanuserNavigation { get; set; } = new List<BesPoliceler>();

    public virtual ICollection<BesPoliceler> BesPolicelerKuser { get; set; } = new List<BesPoliceler>();

    public virtual ICollection<BireyselSaglikBaslik> BireyselSaglikBaslikCalisilanuserNavigation { get; set; } = new List<BireyselSaglikBaslik>();

    public virtual ICollection<BireyselSaglikBaslik> BireyselSaglikBaslikKuser { get; set; } = new List<BireyselSaglikBaslik>();

    public virtual ICollection<BireyselSaglikPolice> BireyselSaglikPoliceCalisilanuserNavigation { get; set; } = new List<BireyselSaglikPolice>();

    public virtual ICollection<BireyselSaglikPolice> BireyselSaglikPoliceKuser { get; set; } = new List<BireyselSaglikPolice>();

    public virtual ICollection<CallCenterCredentials> CallCenterCredentialsAddedUser { get; set; } = new List<CallCenterCredentials>();

    public virtual ICollection<CallCenterCredentials> CallCenterCredentialsUpdatedUser { get; set; } = new List<CallCenterCredentials>();

    public virtual ICollection<CallCenterEvaluationResults> CallCenterEvaluationResults { get; set; } = new List<CallCenterEvaluationResults>();

    public virtual ICollection<CampaignCodes> CampaignCodes { get; set; } = new List<CampaignCodes>();

    public virtual ICollection<CampaignLogs> CampaignLogsApprovedByNavigation { get; set; } = new List<CampaignLogs>();

    public virtual ICollection<CampaignLogs> CampaignLogsUser { get; set; } = new List<CampaignLogs>();

    public virtual ICollection<CenterWaitingMessages> CenterWaitingMessages { get; set; } = new List<CenterWaitingMessages>();

    public virtual ICollection<CepTelefonBaslik> CepTelefonBaslikCalisilanuserNavigation { get; set; } = new List<CepTelefonBaslik>();

    public virtual ICollection<CepTelefonBaslik> CepTelefonBaslikKuser { get; set; } = new List<CepTelefonBaslik>();

    public virtual ICollection<CepTelefonPolice> CepTelefonPoliceCalisilanuserNavigation { get; set; } = new List<CepTelefonPolice>();

    public virtual ICollection<CepTelefonPolice> CepTelefonPoliceKuser { get; set; } = new List<CepTelefonPolice>();

    public virtual ICollection<CommonHeader> CommonHeaderCalisilanuserNavigation { get; set; } = new List<CommonHeader>();

    public virtual ICollection<CommonHeader> CommonHeaderKuser { get; set; } = new List<CommonHeader>();

    public virtual ICollection<CommonPolicy> CommonPolicyCalisilanuserNavigation { get; set; } = new List<CommonPolicy>();

    public virtual ICollection<CommonPolicy> CommonPolicyKuser { get; set; } = new List<CommonPolicy>();

    public virtual ICollection<DaskBasliklar> DaskBasliklarCalisilanuserNavigation { get; set; } = new List<DaskBasliklar>();

    public virtual ICollection<DaskBasliklar> DaskBasliklarKuser { get; set; } = new List<DaskBasliklar>();

    public virtual Departments? Department { get; set; }

    public virtual ICollection<DigitalMarketingTestUserGroup> DigitalMarketingTestUserGroup { get; set; } = new List<DigitalMarketingTestUserGroup>();

    public virtual ICollection<DsPoliceler> DsPolicelerCalisilanuserNavigation { get; set; } = new List<DsPoliceler>();

    public virtual ICollection<DsPoliceler> DsPolicelerKuser { get; set; } = new List<DsPoliceler>();

    public virtual ICollection<DugunBasliklar> DugunBasliklarCalisilanuserNavigation { get; set; } = new List<DugunBasliklar>();

    public virtual ICollection<DugunBasliklar> DugunBasliklarKuser { get; set; } = new List<DugunBasliklar>();

    public virtual ICollection<DugunPoliceler> DugunPolicelerCalisilanuserNavigation { get; set; } = new List<DugunPoliceler>();

    public virtual ICollection<DugunPoliceler> DugunPolicelerKuser { get; set; } = new List<DugunPoliceler>();

    public virtual ICollection<FerdikazaPoliceler> FerdikazaPolicelerCalisilanuserNavigation { get; set; } = new List<FerdikazaPoliceler>();

    public virtual ICollection<FerdikazaPoliceler> FerdikazaPolicelerKuser { get; set; } = new List<FerdikazaPoliceler>();

    public virtual ICollection<FerdikazateklifBasliklar> FerdikazateklifBasliklarCalisilanuserNavigation { get; set; } = new List<FerdikazateklifBasliklar>();

    public virtual ICollection<FerdikazateklifBasliklar> FerdikazateklifBasliklarKuser { get; set; } = new List<FerdikazateklifBasliklar>();

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual ICollection<ForgotPasswordTokens> ForgotPasswordTokens { get; set; } = new List<ForgotPasswordTokens>();

    public virtual ICollection<GenericVerifyCode> GenericVerifyCode { get; set; } = new List<GenericVerifyCode>();

    public virtual ICollection<Goals> GoalsApprovedByUser { get; set; } = new List<Goals>();

    public virtual ICollection<Goals> GoalsCreateUser { get; set; } = new List<Goals>();

    public virtual ICollection<Goals> GoalsUpdateUser { get; set; } = new List<Goals>();

    public virtual ICollection<Goals> GoalsUser { get; set; } = new List<Goals>();

    public virtual ICollection<HemsireBasliklar> HemsireBasliklarCalisilanuserNavigation { get; set; } = new List<HemsireBasliklar>();

    public virtual ICollection<HemsireBasliklar> HemsireBasliklarKuser { get; set; } = new List<HemsireBasliklar>();

    public virtual ICollection<HemsirePoliceler> HemsirePolicelerCalisilanuserNavigation { get; set; } = new List<HemsirePoliceler>();

    public virtual ICollection<HemsirePoliceler> HemsirePolicelerKuser { get; set; } = new List<HemsirePoliceler>();

    public virtual ICollection<ImmBasliklar> ImmBasliklarCalisilanuserNavigation { get; set; } = new List<ImmBasliklar>();

    public virtual ICollection<ImmBasliklar> ImmBasliklarKuser { get; set; } = new List<ImmBasliklar>();

    public virtual ICollection<ImmPoliceler> ImmPolicelerCalisilanuserNavigation { get; set; } = new List<ImmPoliceler>();

    public virtual ICollection<ImmPoliceler> ImmPolicelerKuser { get; set; } = new List<ImmPoliceler>();

    public virtual ICollection<IncPoliceler> IncPolicelerCalisilanuserNavigation { get; set; } = new List<IncPoliceler>();

    public virtual ICollection<IncPoliceler> IncPolicelerKuser { get; set; } = new List<IncPoliceler>();

    public virtual ICollection<IncomingBaslik> IncomingBaslikCalisilanuserNavigation { get; set; } = new List<IncomingBaslik>();

    public virtual ICollection<IncomingBaslik> IncomingBaslikKuser { get; set; } = new List<IncomingBaslik>();

    public virtual ICollection<KisaTrafikBasliklar> KisaTrafikBasliklarCalisilanuserNavigation { get; set; } = new List<KisaTrafikBasliklar>();

    public virtual ICollection<KisaTrafikBasliklar> KisaTrafikBasliklarKuser { get; set; } = new List<KisaTrafikBasliklar>();

    public virtual ICollection<KisaTrafikPoliceler> KisaTrafikPolicelerCalisilanuserNavigation { get; set; } = new List<KisaTrafikPoliceler>();

    public virtual ICollection<KisaTrafikPoliceler> KisaTrafikPolicelerKuser { get; set; } = new List<KisaTrafikPoliceler>();

    public virtual ICollection<KisaTrafikTeklifler> KisaTrafikTeklifler { get; set; } = new List<KisaTrafikTeklifler>();

    public virtual ICollection<KisavadetrafikBasliklar> KisavadetrafikBasliklarCalisilanuserNavigation { get; set; } = new List<KisavadetrafikBasliklar>();

    public virtual ICollection<KisavadetrafikBasliklar> KisavadetrafikBasliklarKuser { get; set; } = new List<KisavadetrafikBasliklar>();

    public virtual ICollection<KisavadetrafikPoliceler> KisavadetrafikPolicelerCalisilanuserNavigation { get; set; } = new List<KisavadetrafikPoliceler>();

    public virtual ICollection<KisavadetrafikPoliceler> KisavadetrafikPolicelerKuser { get; set; } = new List<KisavadetrafikPoliceler>();

    public virtual ICollection<KonutBasliklar> KonutBasliklarCalisilanuserNavigation { get; set; } = new List<KonutBasliklar>();

    public virtual ICollection<KonutBasliklar> KonutBasliklarKuser { get; set; } = new List<KonutBasliklar>();

    public virtual ICollection<KonutPoliceler> KonutPolicelerCalisilanuserNavigation { get; set; } = new List<KonutPoliceler>();

    public virtual ICollection<KonutPoliceler> KonutPolicelerKuser { get; set; } = new List<KonutPoliceler>();

    public virtual ICollection<KullanicilarToken> KullanicilarToken { get; set; } = new List<KullanicilarToken>();

    public virtual ICollection<MusteriAraclariUserMapping> MusteriAraclariUserMapping { get; set; } = new List<MusteriAraclariUserMapping>();

    public virtual ICollection<NakliyatBaslik> NakliyatBaslikCalisilanuserNavigation { get; set; } = new List<NakliyatBaslik>();

    public virtual ICollection<NakliyatBaslik> NakliyatBaslikKuser { get; set; } = new List<NakliyatBaslik>();

    public virtual ICollection<NakliyatPoliceler> NakliyatPolicelerCalisilanuserNavigation { get; set; } = new List<NakliyatPoliceler>();

    public virtual ICollection<NakliyatPoliceler> NakliyatPolicelerKuser { get; set; } = new List<NakliyatPoliceler>();

    public virtual ICollection<NewCommunications> NewCommunications { get; set; } = new List<NewCommunications>();

    public virtual ICollection<OutgPoliceler> OutgPolicelerCalisilanuserNavigation { get; set; } = new List<OutgPoliceler>();

    public virtual ICollection<OutgPoliceler> OutgPolicelerKuser { get; set; } = new List<OutgPoliceler>();

    public virtual ICollection<PackagesExceptCities> PackagesExceptCitiesCreatedUser { get; set; } = new List<PackagesExceptCities>();

    public virtual ICollection<PackagesExceptCities> PackagesExceptCitiesUpdatedUser { get; set; } = new List<PackagesExceptCities>();

    public virtual ICollection<PetSaglikBasliklar> PetSaglikBasliklarCalisilanuserNavigation { get; set; } = new List<PetSaglikBasliklar>();

    public virtual ICollection<PetSaglikBasliklar> PetSaglikBasliklarKuser { get; set; } = new List<PetSaglikBasliklar>();

    public virtual ICollection<PetSaglikPolice> PetSaglikPoliceCalisilanuserNavigation { get; set; } = new List<PetSaglikPolice>();

    public virtual ICollection<PetSaglikPolice> PetSaglikPoliceKuser { get; set; } = new List<PetSaglikPolice>();

    public virtual ICollection<QueryProductPrice> QueryProductPrice { get; set; } = new List<QueryProductPrice>();

    public virtual ICollection<RdpPartajUserAuths> RdpPartajUserAuths { get; set; } = new List<RdpPartajUserAuths>();

    public virtual ICollection<ReferenceCustomerEntitledUserMapping> ReferenceCustomerEntitledUserMappingCreatedUser { get; set; } = new List<ReferenceCustomerEntitledUserMapping>();

    public virtual ICollection<ReferenceCustomerEntitledUserMapping> ReferenceCustomerEntitledUserMappingEligibleUser { get; set; } = new List<ReferenceCustomerEntitledUserMapping>();

    public virtual ICollection<Smstracking> Smstracking { get; set; } = new List<Smstracking>();

    public virtual Subeler Sube { get; set; } = null!;

    public virtual ICollection<SubeQueryTransactions> SubeQueryTransactions { get; set; } = new List<SubeQueryTransactions>();

    public virtual ICollection<TamamlayiciSaglikBaslik> TamamlayiciSaglikBaslikCalisilanuserNavigation { get; set; } = new List<TamamlayiciSaglikBaslik>();

    public virtual ICollection<TamamlayiciSaglikBaslik> TamamlayiciSaglikBaslikKuser { get; set; } = new List<TamamlayiciSaglikBaslik>();

    public virtual ICollection<TamamlayiciSaglikPolice> TamamlayiciSaglikPoliceCalisilanuserNavigation { get; set; } = new List<TamamlayiciSaglikPolice>();

    public virtual ICollection<TamamlayiciSaglikPolice> TamamlayiciSaglikPoliceKuser { get; set; } = new List<TamamlayiciSaglikPolice>();

    public virtual ICollection<TeklifBasliklar> TeklifBasliklarCalisilanuserNavigation { get; set; } = new List<TeklifBasliklar>();

    public virtual ICollection<TeklifBasliklar> TeklifBasliklarKuser { get; set; } = new List<TeklifBasliklar>();

    public virtual ICollection<TkPoliceler> TkPolicelerCalisilanuserNavigation { get; set; } = new List<TkPoliceler>();

    public virtual ICollection<TkPoliceler> TkPolicelerKuser { get; set; } = new List<TkPoliceler>();

    public virtual ICollection<TrainingAttenders> TrainingAttenders { get; set; } = new List<TrainingAttenders>();

    public virtual ICollection<TrainingsTrainer> TrainingsTrainer { get; set; } = new List<TrainingsTrainer>();

    public virtual ICollection<UretimPolicyCount> UretimPolicyCountCreatedUser { get; set; } = new List<UretimPolicyCount>();

    public virtual ICollection<UretimPolicyCount> UretimPolicyCountUpdatedUser { get; set; } = new List<UretimPolicyCount>();

    public virtual ICollection<UserDayOffs> UserDayOffs { get; set; } = new List<UserDayOffs>();

    public virtual ICollection<WebNotifications> WebNotifications { get; set; } = new List<WebNotifications>();

    public virtual ICollection<WhatsappTracking> WhatsappTracking { get; set; } = new List<WhatsappTracking>();

    public virtual ICollection<YabanciSaglikBaslik> YabanciSaglikBaslikCalisilanuserNavigation { get; set; } = new List<YabanciSaglikBaslik>();

    public virtual ICollection<YabanciSaglikBaslik> YabanciSaglikBaslikKuser { get; set; } = new List<YabanciSaglikBaslik>();

    public virtual ICollection<YesilkartBasliklar> YesilkartBasliklarCalisilanuserNavigation { get; set; } = new List<YesilkartBasliklar>();

    public virtual ICollection<YesilkartBasliklar> YesilkartBasliklarKuser { get; set; } = new List<YesilkartBasliklar>();

    public virtual ICollection<YesilkartPoliceler> YesilkartPolicelerCalisilanuserNavigation { get; set; } = new List<YesilkartPoliceler>();

    public virtual ICollection<YesilkartPoliceler> YesilkartPolicelerKuser { get; set; } = new List<YesilkartPoliceler>();

    public virtual ICollection<YolferdikazaBasliklar> YolferdikazaBasliklarCalisilanuserNavigation { get; set; } = new List<YolferdikazaBasliklar>();

    public virtual ICollection<YolferdikazaBasliklar> YolferdikazaBasliklarKuser { get; set; } = new List<YolferdikazaBasliklar>();

    public virtual ICollection<YolferdikazaPoliceler> YolferdikazaPolicelerCalisilanuserNavigation { get; set; } = new List<YolferdikazaPoliceler>();

    public virtual ICollection<YolferdikazaPoliceler> YolferdikazaPolicelerKuser { get; set; } = new List<YolferdikazaPoliceler>();

    public virtual ICollection<YsPoliceler> YsPolicelerCalisilanuserNavigation { get; set; } = new List<YsPoliceler>();

    public virtual ICollection<YsPoliceler> YsPolicelerKuser { get; set; } = new List<YsPoliceler>();

    public virtual ICollection<ZorunlukoltukBasliklar> ZorunlukoltukBasliklarCalisilanuserNavigation { get; set; } = new List<ZorunlukoltukBasliklar>();

    public virtual ICollection<ZorunlukoltukBasliklar> ZorunlukoltukBasliklarKuser { get; set; } = new List<ZorunlukoltukBasliklar>();

    public virtual ICollection<ZorunlukoltukPoliceler> ZorunlukoltukPolicelerCalisilanuserNavigation { get; set; } = new List<ZorunlukoltukPoliceler>();

    public virtual ICollection<ZorunlukoltukPoliceler> ZorunlukoltukPolicelerKuser { get; set; } = new List<ZorunlukoltukPoliceler>();
}
