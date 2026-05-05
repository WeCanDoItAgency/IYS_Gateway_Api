using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Subeler
{
    public int Id { get; set; }

    public string? MuhasebeKodu { get; set; }

    public int FirmaId { get; set; }

    public int TemsilciId { get; set; }

    public int TipId { get; set; }

    public int UstSube { get; set; }

    public bool? IsConfirmed { get; set; }

    public bool IsKontor { get; set; }

    public Guid? Guid { get; set; }

    public string? SubeKod { get; set; }

    public string SubeAdi { get; set; } = null!;

    public string Unvan { get; set; } = null!;

    public string? VDairesi { get; set; }

    public string? VknNo { get; set; }

    public string? TcNo { get; set; }

    public string? PassportNumber { get; set; }

    public string? SahisAdi { get; set; }

    public string? SahisSoyadi { get; set; }

    public string? Yetkili { get; set; }

    public string? AdaCode { get; set; }

    public string? MailAdresi { get; set; }

    public int? UlkeId { get; set; }

    public int? SehirId { get; set; }

    public string? Ilce { get; set; }

    public string? MersisNo { get; set; }

    public string? Belde { get; set; }

    public string? Mahalle { get; set; }

    public string? Cadde { get; set; }

    public string? BinaAdi { get; set; }

    public string? Bulvar { get; set; }

    public string? BinaNo { get; set; }

    public string? DaireNo { get; set; }

    public string? Sokak { get; set; }

    public string? IpAdress { get; set; }

    public string? IpAdress2 { get; set; }

    public string? Telefon1 { get; set; }

    public string? Telefon2 { get; set; }

    public bool IsWbsrvc { get; set; }

    public bool IsWbsrvce { get; set; }

    public bool IsDesktop { get; set; }

    public bool? IsNotIpcode { get; set; }

    public string? Region { get; set; }

    public string? TicaretSicilNo { get; set; }

    public string? TicaretSicilMud { get; set; }

    public string? PostaKodu { get; set; }

    public bool IsHaveWebsite { get; set; }

    public string? WebAdress { get; set; }

    public bool IsHaveAskQuestionPermission { get; set; }

    public bool? IsHaveUseRdpPermission { get; set; }

    public string? Ust { get; set; }

    public string? SubeRefCode1 { get; set; }

    public string? SubeRefCode2 { get; set; }

    public string? SubeRefCode3 { get; set; }

    public string? SubeRefCode4 { get; set; }

    public string? SubeRefCode5 { get; set; }

    public string? SubeRefCode6 { get; set; }

    public string? SubeRefIdentityNumber { get; set; }

    public int? CodeType { get; set; }

    public double KontorMiktari { get; set; }

    public double Kullanilan { get; set; }

    public double KalanKontor { get; set; }

    public int? SatisciId { get; set; }

    public double UsdkontorMiktari { get; set; }

    public double? Usdkullanilan { get; set; }

    public double UsdkalanKontor { get; set; }

    public string? SigEttirenKod { get; set; }

    public bool CanUseApi { get; set; }

    public int PackageLevel { get; set; }

    public bool? IsCallwelcome { get; set; }

    public bool? CanPay3d { get; set; }

    public bool? CanOpenSubbranch { get; set; }

    public bool? PolicePermission { get; set; }

    public int? StatusId { get; set; }

    public bool? IsEvaluation1Confirmed { get; set; }

    public bool? IsEvaluation2Confirmed { get; set; }

    public bool? IsEvaluationAllConfirmed { get; set; }

    public int? Evaluated1ByUserId { get; set; }

    public int? Evaluated2ByUserId { get; set; }

    public bool? IsListed { get; set; }

    public string? Lat { get; set; }

    public string? Lon { get; set; }

    public string? Dahili { get; set; }

    public string? AcikAdres { get; set; }

    public string? MerkezTelefon { get; set; }

    public bool? CanOpenPayment { get; set; }

    public bool IsPriorityForBot { get; set; }

    public bool? IsRequireSmsLimitControl { get; set; }

    public bool? IsHaveUseCampaingPermission { get; set; }

    public bool? IsHaveUseEgmQueryPermission { get; set; }

    public bool IsHaveUseGulfIncomingIrakPermission { get; set; }

    public bool IsHaveUseSmsServicePermission { get; set; }

    public bool? Can3dPayment { get; set; }

    public bool SigortaEttirenKendisi { get; set; }

    public bool? KendiPaketiniMiKullanacak { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public Guid SubeGuid { get; set; }

    public int? BulkSmsfirmNotificationSettingsId { get; set; }

    public int? OtpsmsfirmNotificationSettingsId { get; set; }

    public int? EmailFirmNotificationSettingsId { get; set; }

    public int? NotificationFirmNotificationSettingsId { get; set; }

    public int? FirmNotificationSettingsId { get; set; }

    public bool? IsUseSite { get; set; }

    public bool? IsShowQueryScreenInRdp { get; set; }

    public int? SourceTokenCheckId { get; set; }

    public bool? IsShowContinueWithRdp { get; set; }

    public bool? IsShowRdpDevamEt { get; set; }

    public bool? SmpSorgudanBeslensinMi { get; set; }

    public bool? RdpDevamEtAcenteAcsinMi { get; set; }

    public bool? RdpLinkEkraniniGoster { get; set; }

    public bool? IsWorkScheduleJob { get; set; }

    public bool? IsWorkScheduleJobSecondarySystem { get; set; }

    public bool? RdpAcenteAcsinMi { get; set; }

    public bool? IsAutoWorkerActive { get; set; }

    public bool? IsUsePaymentRules { get; set; }

    public bool? DetayKomisyonuGorebilsinMi { get; set; }

    public string? ReferenceCode { get; set; }

    public bool? CagriMerkeziGorebilirMi { get; set; }

    public bool? IsPaymentLinkShow { get; set; }

    public bool? IysKontroluOlacakmi { get; set; }

    public bool? IsSendNotificationEmail { get; set; }

    public bool? IsSendNotificationSms { get; set; }

    public bool? IsOfferWorkQueue { get; set; }

    public bool? SendNotification { get; set; }

    public bool? CmsOzelAlanlarDonsunMu { get; set; }

    public bool? SendWhatsApp { get; set; }

    public bool? ZeyilKullanabilirMi { get; set; }

    public bool? IsSendCenterWaitingNotification { get; set; }

    public bool? DijipolTemplateKullansinMi { get; set; }

    public bool? AnkaraTelefonNumarasiniRandomOlustursunMu { get; set; }

    public bool? FormBirinciBolumOtomatikTeklifCalis { get; set; }

    public bool? HavuzSktsiMi { get; set; }

    public virtual ICollection<A2elPoliceler> A2elPolicelerBranch { get; set; } = new List<A2elPoliceler>();

    public virtual ICollection<A2elPoliceler> A2elPolicelerCalisilansubeNavigation { get; set; } = new List<A2elPoliceler>();

    public virtual ICollection<A2elteklifBasliklar> A2elteklifBasliklarBranch { get; set; } = new List<A2elteklifBasliklar>();

    public virtual ICollection<A2elteklifBasliklar> A2elteklifBasliklarCalisilansubeNavigation { get; set; } = new List<A2elteklifBasliklar>();

    public virtual ICollection<AcenteOnlineCmsblogCategories> AcenteOnlineCmsblogCategories { get; set; } = new List<AcenteOnlineCmsblogCategories>();

    public virtual ICollection<AcenteOnlineCmsblogPosts> AcenteOnlineCmsblogPosts { get; set; } = new List<AcenteOnlineCmsblogPosts>();

    public virtual ICollection<AcenteOnlineCmsblogTags> AcenteOnlineCmsblogTags { get; set; } = new List<AcenteOnlineCmsblogTags>();

    public virtual ICollection<AcenteOnlineCmscoverageCategories> AcenteOnlineCmscoverageCategories { get; set; } = new List<AcenteOnlineCmscoverageCategories>();

    public virtual ICollection<AcenteOnlineCmscoveragePosts> AcenteOnlineCmscoveragePosts { get; set; } = new List<AcenteOnlineCmscoveragePosts>();

    public virtual ICollection<AcenteOnlineCmscustomerFeedbacks> AcenteOnlineCmscustomerFeedbacks { get; set; } = new List<AcenteOnlineCmscustomerFeedbacks>();

    public virtual ICollection<AcenteOnlineCmsfaqCategories> AcenteOnlineCmsfaqCategories { get; set; } = new List<AcenteOnlineCmsfaqCategories>();

    public virtual ICollection<AcenteOnlineCmsfaqPosts> AcenteOnlineCmsfaqPosts { get; set; } = new List<AcenteOnlineCmsfaqPosts>();

    public virtual ICollection<AcenteOnlineCmsinsuranceBranches> AcenteOnlineCmsinsuranceBranches { get; set; } = new List<AcenteOnlineCmsinsuranceBranches>();

    public virtual ICollection<AcenteOnlineCmsinsuranceFirms> AcenteOnlineCmsinsuranceFirms { get; set; } = new List<AcenteOnlineCmsinsuranceFirms>();

    public virtual ICollection<AcenteOnlineCmslanguages> AcenteOnlineCmslanguages { get; set; } = new List<AcenteOnlineCmslanguages>();

    public virtual ICollection<AcenteOnlineCmspageCategories> AcenteOnlineCmspageCategories { get; set; } = new List<AcenteOnlineCmspageCategories>();

    public virtual ICollection<AcenteOnlineCmspages> AcenteOnlineCmspages { get; set; } = new List<AcenteOnlineCmspages>();

    public virtual ICollection<AcenteOnlineCmssettings> AcenteOnlineCmssettings { get; set; } = new List<AcenteOnlineCmssettings>();

    public virtual ICollection<AcenteOnlineCmssites> AcenteOnlineCmssites { get; set; } = new List<AcenteOnlineCmssites>();

    public virtual ICollection<AcenteOnlineCmssliders> AcenteOnlineCmssliders { get; set; } = new List<AcenteOnlineCmssliders>();

    public virtual ICollection<AracDetay> AracDetay { get; set; } = new List<AracDetay>();

    public virtual ICollection<AracKartlar> AracKartlar { get; set; } = new List<AracKartlar>();

    public virtual ICollection<AracKartlarHistory> AracKartlarHistory { get; set; } = new List<AracKartlarHistory>();

    public virtual ICollection<BesBasliklar> BesBasliklarBranch { get; set; } = new List<BesBasliklar>();

    public virtual ICollection<BesBasliklar> BesBasliklarCalisilansubeNavigation { get; set; } = new List<BesBasliklar>();

    public virtual ICollection<BesPoliceler> BesPolicelerBranch { get; set; } = new List<BesPoliceler>();

    public virtual ICollection<BesPoliceler> BesPolicelerCalisilansubeNavigation { get; set; } = new List<BesPoliceler>();

    public virtual ICollection<BireyselSaglikBaslik> BireyselSaglikBaslikBranch { get; set; } = new List<BireyselSaglikBaslik>();

    public virtual ICollection<BireyselSaglikBaslik> BireyselSaglikBaslikCalisilansubeNavigation { get; set; } = new List<BireyselSaglikBaslik>();

    public virtual ICollection<BireyselSaglikPolice> BireyselSaglikPoliceBranch { get; set; } = new List<BireyselSaglikPolice>();

    public virtual ICollection<BireyselSaglikPolice> BireyselSaglikPoliceCalisilansubeNavigation { get; set; } = new List<BireyselSaglikPolice>();

    public virtual ICollection<BranchQuerytypeAuth> BranchQuerytypeAuth { get; set; } = new List<BranchQuerytypeAuth>();

    public virtual ICollection<BranchTypeChanges> BranchTypeChanges { get; set; } = new List<BranchTypeChanges>();

    public virtual ICollection<BrandAttributeGroup> BrandAttributeGroup { get; set; } = new List<BrandAttributeGroup>();

    public virtual ICollection<CallCenterEvaluationResults> CallCenterEvaluationResults { get; set; } = new List<CallCenterEvaluationResults>();

    public virtual ICollection<CallCenterTriggerRulesInfoSktMapping> CallCenterTriggerRulesInfoSktMapping { get; set; } = new List<CallCenterTriggerRulesInfoSktMapping>();

    public virtual ICollection<CampaignLogs> CampaignLogs { get; set; } = new List<CampaignLogs>();

    public virtual ICollection<CepTelefonBaslik> CepTelefonBaslikBranch { get; set; } = new List<CepTelefonBaslik>();

    public virtual ICollection<CepTelefonBaslik> CepTelefonBaslikCalisilansubeNavigation { get; set; } = new List<CepTelefonBaslik>();

    public virtual ICollection<CepTelefonPolice> CepTelefonPoliceBranch { get; set; } = new List<CepTelefonPolice>();

    public virtual ICollection<CepTelefonPolice> CepTelefonPoliceCalisilansubeNavigation { get; set; } = new List<CepTelefonPolice>();

    public virtual ICollection<CommonHeader> CommonHeaderBranch { get; set; } = new List<CommonHeader>();

    public virtual ICollection<CommonHeader> CommonHeaderCalisilansubeNavigation { get; set; } = new List<CommonHeader>();

    public virtual ICollection<CommonPolicy> CommonPolicyBranch { get; set; } = new List<CommonPolicy>();

    public virtual ICollection<CommonPolicy> CommonPolicyCalisilansubeNavigation { get; set; } = new List<CommonPolicy>();

    public virtual ICollection<DaskBasliklar> DaskBasliklarBranch { get; set; } = new List<DaskBasliklar>();

    public virtual ICollection<DaskBasliklar> DaskBasliklarCalisilansubeNavigation { get; set; } = new List<DaskBasliklar>();

    public virtual ICollection<DsPoliceler> DsPolicelerBranch { get; set; } = new List<DsPoliceler>();

    public virtual ICollection<DsPoliceler> DsPolicelerCalisilansubeNavigation { get; set; } = new List<DsPoliceler>();

    public virtual ICollection<DugunBasliklar> DugunBasliklarBranch { get; set; } = new List<DugunBasliklar>();

    public virtual ICollection<DugunBasliklar> DugunBasliklarCalisilansubeNavigation { get; set; } = new List<DugunBasliklar>();

    public virtual ICollection<DugunPoliceler> DugunPolicelerBranch { get; set; } = new List<DugunPoliceler>();

    public virtual ICollection<DugunPoliceler> DugunPolicelerCalisilansubeNavigation { get; set; } = new List<DugunPoliceler>();

    public virtual ICollection<Feedbacks> Feedbacks { get; set; } = new List<Feedbacks>();

    public virtual ICollection<FerdikazaPoliceler> FerdikazaPolicelerBranch { get; set; } = new List<FerdikazaPoliceler>();

    public virtual ICollection<FerdikazaPoliceler> FerdikazaPolicelerCalisilansubeNavigation { get; set; } = new List<FerdikazaPoliceler>();

    public virtual ICollection<FerdikazateklifBasliklar> FerdikazateklifBasliklarBranch { get; set; } = new List<FerdikazateklifBasliklar>();

    public virtual ICollection<FerdikazateklifBasliklar> FerdikazateklifBasliklarCalisilansubeNavigation { get; set; } = new List<FerdikazateklifBasliklar>();

    public virtual NewFirms Firma { get; set; } = null!;

    public virtual ICollection<Goals> Goals { get; set; } = new List<Goals>();

    public virtual ICollection<HemsireBasliklar> HemsireBasliklarBranch { get; set; } = new List<HemsireBasliklar>();

    public virtual ICollection<HemsireBasliklar> HemsireBasliklarCalisilansubeNavigation { get; set; } = new List<HemsireBasliklar>();

    public virtual ICollection<HemsirePoliceler> HemsirePolicelerBranch { get; set; } = new List<HemsirePoliceler>();

    public virtual ICollection<HemsirePoliceler> HemsirePolicelerCalisilansubeNavigation { get; set; } = new List<HemsirePoliceler>();

    public virtual ICollection<ImmBasliklar> ImmBasliklarBranch { get; set; } = new List<ImmBasliklar>();

    public virtual ICollection<ImmBasliklar> ImmBasliklarCalisilansubeNavigation { get; set; } = new List<ImmBasliklar>();

    public virtual ICollection<ImmPoliceler> ImmPolicelerBranch { get; set; } = new List<ImmPoliceler>();

    public virtual ICollection<ImmPoliceler> ImmPolicelerCalisilansubeNavigation { get; set; } = new List<ImmPoliceler>();

    public virtual ICollection<IncPoliceler> IncPolicelerBranch { get; set; } = new List<IncPoliceler>();

    public virtual ICollection<IncPoliceler> IncPolicelerCalisilansubeNavigation { get; set; } = new List<IncPoliceler>();

    public virtual ICollection<IncomingBaslik> IncomingBaslikBranch { get; set; } = new List<IncomingBaslik>();

    public virtual ICollection<IncomingBaslik> IncomingBaslikCalisilansubeNavigation { get; set; } = new List<IncomingBaslik>();

    public virtual ICollection<KisaTrafikBasliklar> KisaTrafikBasliklarBranch { get; set; } = new List<KisaTrafikBasliklar>();

    public virtual ICollection<KisaTrafikBasliklar> KisaTrafikBasliklarCalisilansubeNavigation { get; set; } = new List<KisaTrafikBasliklar>();

    public virtual ICollection<KisaTrafikPoliceler> KisaTrafikPolicelerBranch { get; set; } = new List<KisaTrafikPoliceler>();

    public virtual ICollection<KisaTrafikPoliceler> KisaTrafikPolicelerCalisilansubeNavigation { get; set; } = new List<KisaTrafikPoliceler>();

    public virtual ICollection<KisaTrafikTeklifler> KisaTrafikTeklifler { get; set; } = new List<KisaTrafikTeklifler>();

    public virtual ICollection<KisavadetrafikBasliklar> KisavadetrafikBasliklarBranch { get; set; } = new List<KisavadetrafikBasliklar>();

    public virtual ICollection<KisavadetrafikBasliklar> KisavadetrafikBasliklarCalisilansubeNavigation { get; set; } = new List<KisavadetrafikBasliklar>();

    public virtual ICollection<KisavadetrafikPoliceler> KisavadetrafikPolicelerBranch { get; set; } = new List<KisavadetrafikPoliceler>();

    public virtual ICollection<KisavadetrafikPoliceler> KisavadetrafikPolicelerCalisilansubeNavigation { get; set; } = new List<KisavadetrafikPoliceler>();

    public virtual ICollection<KonutBasliklar> KonutBasliklarBranch { get; set; } = new List<KonutBasliklar>();

    public virtual ICollection<KonutBasliklar> KonutBasliklarCalisilansubeNavigation { get; set; } = new List<KonutBasliklar>();

    public virtual ICollection<KonutPoliceler> KonutPolicelerBranch { get; set; } = new List<KonutPoliceler>();

    public virtual ICollection<KonutPoliceler> KonutPolicelerCalisilansubeNavigation { get; set; } = new List<KonutPoliceler>();

    public virtual ICollection<Kullanicilar> Kullanicilar { get; set; } = new List<Kullanicilar>();

    public virtual ICollection<Mutabakat> Mutabakat { get; set; } = new List<Mutabakat>();

    public virtual ICollection<NakliyatBaslik> NakliyatBaslikBranch { get; set; } = new List<NakliyatBaslik>();

    public virtual ICollection<NakliyatBaslik> NakliyatBaslikCalisilansubeNavigation { get; set; } = new List<NakliyatBaslik>();

    public virtual ICollection<NakliyatPoliceler> NakliyatPolicelerBranch { get; set; } = new List<NakliyatPoliceler>();

    public virtual ICollection<NakliyatPoliceler> NakliyatPolicelerCalisilansubeNavigation { get; set; } = new List<NakliyatPoliceler>();

    public virtual ICollection<NewAccountancyPlannings> NewAccountancyPlannings { get; set; } = new List<NewAccountancyPlannings>();

    public virtual ICollection<NewCommunications> NewCommunications { get; set; } = new List<NewCommunications>();

    public virtual ICollection<NewManuelOffers> NewManuelOffers { get; set; } = new List<NewManuelOffers>();

    public virtual ICollection<OutgPoliceler> OutgPolicelerBranch { get; set; } = new List<OutgPoliceler>();

    public virtual ICollection<OutgPoliceler> OutgPolicelerCalisilansubeNavigation { get; set; } = new List<OutgPoliceler>();

    public virtual ICollection<PetSaglikBasliklar> PetSaglikBasliklarBranch { get; set; } = new List<PetSaglikBasliklar>();

    public virtual ICollection<PetSaglikBasliklar> PetSaglikBasliklarCalisilansubeNavigation { get; set; } = new List<PetSaglikBasliklar>();

    public virtual ICollection<PetSaglikPolice> PetSaglikPoliceBranch { get; set; } = new List<PetSaglikPolice>();

    public virtual ICollection<PetSaglikPolice> PetSaglikPoliceCalisilansubeNavigation { get; set; } = new List<PetSaglikPolice>();

    public virtual ICollection<QueryRules> QueryRules { get; set; } = new List<QueryRules>();

    public virtual ICollection<RdpBrandPartajSktAuthMap> RdpBrandPartajSktAuthMap { get; set; } = new List<RdpBrandPartajSktAuthMap>();

    public virtual ICollection<RdpBrandPartajSktAuthQueryTypeMap> RdpBrandPartajSktAuthQueryTypeMap { get; set; } = new List<RdpBrandPartajSktAuthQueryTypeMap>();

    public virtual ICollection<RdpPartajBranchAuths> RdpPartajBranchAuths { get; set; } = new List<RdpPartajBranchAuths>();

    public virtual UavtIl? Sehir { get; set; }

    public virtual ICollection<SourceTokenCheck> SourceTokenCheck { get; set; } = new List<SourceTokenCheck>();

    public virtual ICollection<SubBrandSktBlocks> SubBrandSktBlocks { get; set; } = new List<SubBrandSktBlocks>();

    public virtual ICollection<SubeQueryBakiye> SubeQueryBakiye { get; set; } = new List<SubeQueryBakiye>();

    public virtual ICollection<SubeQueryTransactions> SubeQueryTransactions { get; set; } = new List<SubeQueryTransactions>();

    public virtual ICollection<SubeYetki> SubeYetki { get; set; } = new List<SubeYetki>();

    public virtual ICollection<SubeYetki2> SubeYetki2 { get; set; } = new List<SubeYetki2>();

    public virtual ICollection<TamamlayiciSaglikBaslik> TamamlayiciSaglikBaslikBranch { get; set; } = new List<TamamlayiciSaglikBaslik>();

    public virtual ICollection<TamamlayiciSaglikBaslik> TamamlayiciSaglikBaslikCalisilansubeNavigation { get; set; } = new List<TamamlayiciSaglikBaslik>();

    public virtual ICollection<TamamlayiciSaglikPolice> TamamlayiciSaglikPoliceBranch { get; set; } = new List<TamamlayiciSaglikPolice>();

    public virtual ICollection<TamamlayiciSaglikPolice> TamamlayiciSaglikPoliceCalisilansubeNavigation { get; set; } = new List<TamamlayiciSaglikPolice>();

    public virtual ICollection<TeklifBasliklar> TeklifBasliklarBranch { get; set; } = new List<TeklifBasliklar>();

    public virtual ICollection<TeklifBasliklar> TeklifBasliklarCalisilansubeNavigation { get; set; } = new List<TeklifBasliklar>();

    public virtual BranchTypes Tip { get; set; } = null!;

    public virtual ICollection<TkPoliceler> TkPolicelerBranch { get; set; } = new List<TkPoliceler>();

    public virtual ICollection<TkPoliceler> TkPolicelerCalisilansubeNavigation { get; set; } = new List<TkPoliceler>();

    public virtual ICollection<WebNotifications> WebNotifications { get; set; } = new List<WebNotifications>();

    public virtual ICollection<YabanciSaglikBaslik> YabanciSaglikBaslikBranch { get; set; } = new List<YabanciSaglikBaslik>();

    public virtual ICollection<YabanciSaglikBaslik> YabanciSaglikBaslikCalisilansubeNavigation { get; set; } = new List<YabanciSaglikBaslik>();

    public virtual ICollection<YesilkartBasliklar> YesilkartBasliklarBranch { get; set; } = new List<YesilkartBasliklar>();

    public virtual ICollection<YesilkartBasliklar> YesilkartBasliklarCalisilansubeNavigation { get; set; } = new List<YesilkartBasliklar>();

    public virtual ICollection<YesilkartPoliceler> YesilkartPolicelerBranch { get; set; } = new List<YesilkartPoliceler>();

    public virtual ICollection<YesilkartPoliceler> YesilkartPolicelerCalisilansubeNavigation { get; set; } = new List<YesilkartPoliceler>();

    public virtual ICollection<YolferdikazaBasliklar> YolferdikazaBasliklarBranch { get; set; } = new List<YolferdikazaBasliklar>();

    public virtual ICollection<YolferdikazaBasliklar> YolferdikazaBasliklarCalisilansubeNavigation { get; set; } = new List<YolferdikazaBasliklar>();

    public virtual ICollection<YolferdikazaPoliceler> YolferdikazaPolicelerBranch { get; set; } = new List<YolferdikazaPoliceler>();

    public virtual ICollection<YolferdikazaPoliceler> YolferdikazaPolicelerCalisilansubeNavigation { get; set; } = new List<YolferdikazaPoliceler>();

    public virtual ICollection<YsPoliceler> YsPolicelerBranch { get; set; } = new List<YsPoliceler>();

    public virtual ICollection<YsPoliceler> YsPolicelerCalisilansubeNavigation { get; set; } = new List<YsPoliceler>();

    public virtual ICollection<ZorunlukoltukBasliklar> ZorunlukoltukBasliklarBranch { get; set; } = new List<ZorunlukoltukBasliklar>();

    public virtual ICollection<ZorunlukoltukBasliklar> ZorunlukoltukBasliklarCalisilansubeNavigation { get; set; } = new List<ZorunlukoltukBasliklar>();

    public virtual ICollection<ZorunlukoltukPoliceler> ZorunlukoltukPolicelerBranch { get; set; } = new List<ZorunlukoltukPoliceler>();

    public virtual ICollection<ZorunlukoltukPoliceler> ZorunlukoltukPolicelerCalisilansubeNavigation { get; set; } = new List<ZorunlukoltukPoliceler>();
}
