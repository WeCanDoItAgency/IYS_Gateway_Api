using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewFirms
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Title { get; set; }

    public string? TaxOffice { get; set; }

    public string? NationalNumber { get; set; }

    public string? TaxNumber { get; set; }

    public string? Email { get; set; }

    public string? AuthorizedName { get; set; }

    public string? AuthorizedSurname { get; set; }

    public string? ProxyAddress { get; set; }

    public string? ProxyPort { get; set; }

    public string? ProxyUsername { get; set; }

    public string? ProxyPassword { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public int? CountyId { get; set; }

    public string? AddressDetail { get; set; }

    public string? LogoPath { get; set; }

    public int StatusId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? WorkPhone { get; set; }

    public string? RegistrationNo { get; set; }

    public string? MersisNo { get; set; }

    public string? KepAddress { get; set; }

    public bool? CanOpenSubbranch { get; set; }

    public string? IpAddress { get; set; }

    public bool? IsBlackList { get; set; }

    public bool? IsRdp { get; set; }

    public string? SignatureImageName { get; set; }

    public string? ApiBaseUrl { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? DeleteUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? IsActive { get; set; }

    public string? ProductionProcessName { get; set; }

    public string? FirmEmailExtension { get; set; }

    public bool? CanUseBot { get; set; }

    public Guid FirmGuid { get; set; }

    public bool? KomisyonGizlensinMi { get; set; }

    public bool? SmpSorgudanBeslensinMi { get; set; }

    public bool? EmailRastgeleMi { get; set; }

    public string? RastgeleEmailDomain { get; set; }

    public bool? IsAutoWorker { get; set; }

    public bool? CanUseVirtualSign { get; set; }

    public string? VirtualSignLogoPath { get; set; }

    public bool? IsSendWhatsappNotificationPerm { get; set; }

    public bool? CagriMerkeziGorebilirMi { get; set; }

    public string? IysUsername { get; set; }

    public string? IysPassword { get; set; }

    public string? IysBrand { get; set; }

    public string? IysCustomerCode { get; set; }

    public bool? IsIysSystemActive { get; set; }

    public bool? ZeyilKullanabilirMi { get; set; }

    public string? FirmSiteUrl { get; set; }

    public string? ShortLinkDomainUrl { get; set; }

    public bool? WhatsappOtpGonderilecekMi { get; set; }

    public bool IsSeeChatBot { get; set; }

    public string? SunucuAdi { get; set; }

    public string? SunucuIp { get; set; }

    public bool? AltFirmaMi { get; set; }

    public int? UstFirmId { get; set; }

    public string? WpGroupId { get; set; }

    public bool? DemoMod { get; set; }

    public virtual ICollection<A2elPoliceler> A2elPolicelerCalisilanfirmaNavigation { get; set; } = new List<A2elPoliceler>();

    public virtual ICollection<A2elPoliceler> A2elPolicelerFirm { get; set; } = new List<A2elPoliceler>();

    public virtual ICollection<A2elteklifBasliklar> A2elteklifBasliklarCalisilanfirmaNavigation { get; set; } = new List<A2elteklifBasliklar>();

    public virtual ICollection<A2elteklifBasliklar> A2elteklifBasliklarFirm { get; set; } = new List<A2elteklifBasliklar>();

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

    public virtual ICollection<BesBasliklar> BesBasliklarCalisilanfirmaNavigation { get; set; } = new List<BesBasliklar>();

    public virtual ICollection<BesBasliklar> BesBasliklarFirm { get; set; } = new List<BesBasliklar>();

    public virtual ICollection<BesPoliceler> BesPolicelerCalisilanfirmaNavigation { get; set; } = new List<BesPoliceler>();

    public virtual ICollection<BesPoliceler> BesPolicelerFirm { get; set; } = new List<BesPoliceler>();

    public virtual ICollection<BireyselSaglikBaslik> BireyselSaglikBaslikCalisilanfirmaNavigation { get; set; } = new List<BireyselSaglikBaslik>();

    public virtual ICollection<BireyselSaglikBaslik> BireyselSaglikBaslikFirm { get; set; } = new List<BireyselSaglikBaslik>();

    public virtual ICollection<BireyselSaglikPolice> BireyselSaglikPoliceCalisilanfirmaNavigation { get; set; } = new List<BireyselSaglikPolice>();

    public virtual ICollection<BireyselSaglikPolice> BireyselSaglikPoliceFirm { get; set; } = new List<BireyselSaglikPolice>();

    public virtual ICollection<BranchQuerytypeAuth> BranchQuerytypeAuth { get; set; } = new List<BranchQuerytypeAuth>();

    public virtual ICollection<BranchTypes> BranchTypes { get; set; } = new List<BranchTypes>();

    public virtual ICollection<CallCenterEvaluationResults> CallCenterEvaluationResults { get; set; } = new List<CallCenterEvaluationResults>();

    public virtual ICollection<CallCenterTriggerRules> CallCenterTriggerRules { get; set; } = new List<CallCenterTriggerRules>();

    public virtual ICollection<CallCenterTriggerRulesInfo> CallCenterTriggerRulesInfo { get; set; } = new List<CallCenterTriggerRulesInfo>();

    public virtual ICollection<CampaignLogs> CampaignLogs { get; set; } = new List<CampaignLogs>();

    public virtual ICollection<Campaigns> Campaigns { get; set; } = new List<Campaigns>();

    public virtual ICollection<CepTelefonBaslik> CepTelefonBaslikCalisilanfirmaNavigation { get; set; } = new List<CepTelefonBaslik>();

    public virtual ICollection<CepTelefonBaslik> CepTelefonBaslikFirm { get; set; } = new List<CepTelefonBaslik>();

    public virtual ICollection<CepTelefonPolice> CepTelefonPoliceCalisilanfirmaNavigation { get; set; } = new List<CepTelefonPolice>();

    public virtual ICollection<CepTelefonPolice> CepTelefonPoliceFirm { get; set; } = new List<CepTelefonPolice>();

    public virtual ICollection<CommonHeader> CommonHeaderCalisilanfirmaNavigation { get; set; } = new List<CommonHeader>();

    public virtual ICollection<CommonHeader> CommonHeaderFirm { get; set; } = new List<CommonHeader>();

    public virtual ICollection<CommonPolicy> CommonPolicyCalisilanfirmaNavigation { get; set; } = new List<CommonPolicy>();

    public virtual ICollection<CommonPolicy> CommonPolicyFirm { get; set; } = new List<CommonPolicy>();

    public virtual ICollection<CustomerTagInformation> CustomerTagInformation { get; set; } = new List<CustomerTagInformation>();

    public virtual ICollection<CustomerTagRules> CustomerTagRules { get; set; } = new List<CustomerTagRules>();

    public virtual ICollection<DaskBasliklar> DaskBasliklarCalisilanfirmaNavigation { get; set; } = new List<DaskBasliklar>();

    public virtual ICollection<DaskBasliklar> DaskBasliklarFirm { get; set; } = new List<DaskBasliklar>();

    public virtual ICollection<DsPoliceler> DsPolicelerCalisilanfirmaNavigation { get; set; } = new List<DsPoliceler>();

    public virtual ICollection<DsPoliceler> DsPolicelerFirm { get; set; } = new List<DsPoliceler>();

    public virtual ICollection<DugunBasliklar> DugunBasliklarCalisilanfirmaNavigation { get; set; } = new List<DugunBasliklar>();

    public virtual ICollection<DugunBasliklar> DugunBasliklarFirm { get; set; } = new List<DugunBasliklar>();

    public virtual ICollection<DugunPoliceler> DugunPolicelerCalisilanfirmaNavigation { get; set; } = new List<DugunPoliceler>();

    public virtual ICollection<DugunPoliceler> DugunPolicelerFirm { get; set; } = new List<DugunPoliceler>();

    public virtual ICollection<FerdikazaPoliceler> FerdikazaPolicelerCalisilanfirmaNavigation { get; set; } = new List<FerdikazaPoliceler>();

    public virtual ICollection<FerdikazaPoliceler> FerdikazaPolicelerFirm { get; set; } = new List<FerdikazaPoliceler>();

    public virtual ICollection<FerdikazateklifBasliklar> FerdikazateklifBasliklarCalisilanfirmaNavigation { get; set; } = new List<FerdikazateklifBasliklar>();

    public virtual ICollection<FerdikazateklifBasliklar> FerdikazateklifBasliklarFirm { get; set; } = new List<FerdikazateklifBasliklar>();

    public virtual ICollection<FirmApiAdresses> FirmApiAdresses { get; set; } = new List<FirmApiAdresses>();

    public virtual ICollection<FirmPackageAggrements> FirmPackageAggrements { get; set; } = new List<FirmPackageAggrements>();

    public virtual ICollection<FirmPermissions> FirmPermissions { get; set; } = new List<FirmPermissions>();

    public virtual ICollection<GenericVerifyCode> GenericVerifyCode { get; set; } = new List<GenericVerifyCode>();

    public virtual ICollection<Goals> Goals { get; set; } = new List<Goals>();

    public virtual ICollection<HemsireBasliklar> HemsireBasliklarCalisilanfirmaNavigation { get; set; } = new List<HemsireBasliklar>();

    public virtual ICollection<HemsireBasliklar> HemsireBasliklarFirm { get; set; } = new List<HemsireBasliklar>();

    public virtual ICollection<HemsirePoliceler> HemsirePolicelerCalisilanfirmaNavigation { get; set; } = new List<HemsirePoliceler>();

    public virtual ICollection<HemsirePoliceler> HemsirePolicelerFirm { get; set; } = new List<HemsirePoliceler>();

    public virtual ICollection<ImmBasliklar> ImmBasliklarCalisilanfirmaNavigation { get; set; } = new List<ImmBasliklar>();

    public virtual ICollection<ImmBasliklar> ImmBasliklarFirm { get; set; } = new List<ImmBasliklar>();

    public virtual ICollection<ImmPoliceler> ImmPolicelerCalisilanfirmaNavigation { get; set; } = new List<ImmPoliceler>();

    public virtual ICollection<ImmPoliceler> ImmPolicelerFirm { get; set; } = new List<ImmPoliceler>();

    public virtual ICollection<IncPoliceler> IncPolicelerCalisilanfirmaNavigation { get; set; } = new List<IncPoliceler>();

    public virtual ICollection<IncPoliceler> IncPolicelerFirm { get; set; } = new List<IncPoliceler>();

    public virtual ICollection<IncomingBaslik> IncomingBaslikCalisilanfirmaNavigation { get; set; } = new List<IncomingBaslik>();

    public virtual ICollection<IncomingBaslik> IncomingBaslikFirm { get; set; } = new List<IncomingBaslik>();

    public virtual ICollection<KisaTrafikBasliklar> KisaTrafikBasliklarCalisilanfirmaNavigation { get; set; } = new List<KisaTrafikBasliklar>();

    public virtual ICollection<KisaTrafikBasliklar> KisaTrafikBasliklarFirm { get; set; } = new List<KisaTrafikBasliklar>();

    public virtual ICollection<KisaTrafikPoliceler> KisaTrafikPolicelerCalisilanfirmaNavigation { get; set; } = new List<KisaTrafikPoliceler>();

    public virtual ICollection<KisaTrafikPoliceler> KisaTrafikPolicelerFirm { get; set; } = new List<KisaTrafikPoliceler>();

    public virtual ICollection<KisaTrafikTeklifler> KisaTrafikTeklifler { get; set; } = new List<KisaTrafikTeklifler>();

    public virtual ICollection<KisavadetrafikBasliklar> KisavadetrafikBasliklarCalisilanfirmaNavigation { get; set; } = new List<KisavadetrafikBasliklar>();

    public virtual ICollection<KisavadetrafikBasliklar> KisavadetrafikBasliklarFirm { get; set; } = new List<KisavadetrafikBasliklar>();

    public virtual ICollection<KisavadetrafikPoliceler> KisavadetrafikPolicelerCalisilanfirmaNavigation { get; set; } = new List<KisavadetrafikPoliceler>();

    public virtual ICollection<KisavadetrafikPoliceler> KisavadetrafikPolicelerFirm { get; set; } = new List<KisavadetrafikPoliceler>();

    public virtual ICollection<KonutBasliklar> KonutBasliklarCalisilanfirmaNavigation { get; set; } = new List<KonutBasliklar>();

    public virtual ICollection<KonutBasliklar> KonutBasliklarFirm { get; set; } = new List<KonutBasliklar>();

    public virtual ICollection<KonutPoliceler> KonutPolicelerCalisilanfirmaNavigation { get; set; } = new List<KonutPoliceler>();

    public virtual ICollection<KonutPoliceler> KonutPolicelerFirm { get; set; } = new List<KonutPoliceler>();

    public virtual ICollection<Kullanicilar> Kullanicilar { get; set; } = new List<Kullanicilar>();

    public virtual ICollection<Mutabakat> Mutabakat { get; set; } = new List<Mutabakat>();

    public virtual ICollection<NakliyatBaslik> NakliyatBaslikCalisilanfirmaNavigation { get; set; } = new List<NakliyatBaslik>();

    public virtual ICollection<NakliyatBaslik> NakliyatBaslikFirm { get; set; } = new List<NakliyatBaslik>();

    public virtual ICollection<NakliyatPoliceler> NakliyatPolicelerCalisilanfirmaNavigation { get; set; } = new List<NakliyatPoliceler>();

    public virtual ICollection<NakliyatPoliceler> NakliyatPolicelerFirm { get; set; } = new List<NakliyatPoliceler>();

    public virtual ICollection<NewCabTypes> NewCabTypes { get; set; } = new List<NewCabTypes>();

    public virtual ICollection<NewCases> NewCases { get; set; } = new List<NewCases>();

    public virtual ICollection<NewCommissionsUser> NewCommissionsUser { get; set; } = new List<NewCommissionsUser>();

    public virtual ICollection<NewCommunications> NewCommunications { get; set; } = new List<NewCommunications>();

    public virtual ICollection<NewManuelOffers> NewManuelOffers { get; set; } = new List<NewManuelOffers>();

    public virtual ICollection<NewProductBrands> NewProductBrands { get; set; } = new List<NewProductBrands>();

    public virtual ICollection<NewProductCategories> NewProductCategories { get; set; } = new List<NewProductCategories>();

    public virtual ICollection<NewProductFamilies> NewProductFamilies { get; set; } = new List<NewProductFamilies>();

    public virtual ICollection<NewProductGroups> NewProductGroups { get; set; } = new List<NewProductGroups>();

    public virtual ICollection<NewProductModels> NewProductModels { get; set; } = new List<NewProductModels>();

    public virtual ICollection<NewProductSubGroups> NewProductSubGroups { get; set; } = new List<NewProductSubGroups>();

    public virtual ICollection<NewProductTypes> NewProductTypes { get; set; } = new List<NewProductTypes>();

    public virtual ICollection<NewRdpBrandPartajs> NewRdpBrandPartajs { get; set; } = new List<NewRdpBrandPartajs>();

    public virtual ICollection<NewSubBrands> NewSubBrands { get; set; } = new List<NewSubBrands>();

    public virtual ICollection<OutgPoliceler> OutgPolicelerCalisilanfirmaNavigation { get; set; } = new List<OutgPoliceler>();

    public virtual ICollection<OutgPoliceler> OutgPolicelerFirm { get; set; } = new List<OutgPoliceler>();

    public virtual ICollection<PetSaglikBasliklar> PetSaglikBasliklarCalisilanfirmaNavigation { get; set; } = new List<PetSaglikBasliklar>();

    public virtual ICollection<PetSaglikBasliklar> PetSaglikBasliklarFirm { get; set; } = new List<PetSaglikBasliklar>();

    public virtual ICollection<PetSaglikPolice> PetSaglikPoliceCalisilanfirmaNavigation { get; set; } = new List<PetSaglikPolice>();

    public virtual ICollection<PetSaglikPolice> PetSaglikPoliceFirm { get; set; } = new List<PetSaglikPolice>();

    public virtual ICollection<QueryRules> QueryRules { get; set; } = new List<QueryRules>();

    public virtual ICollection<RdpBrandPartajs> RdpBrandPartajs { get; set; } = new List<RdpBrandPartajs>();

    public virtual ICollection<SubBrandSktBlocks> SubBrandSktBlocks { get; set; } = new List<SubBrandSktBlocks>();

    public virtual ICollection<Subeler> Subeler { get; set; } = new List<Subeler>();

    public virtual ICollection<TamamlayiciSaglikBaslik> TamamlayiciSaglikBaslikCalisilanfirmaNavigation { get; set; } = new List<TamamlayiciSaglikBaslik>();

    public virtual ICollection<TamamlayiciSaglikBaslik> TamamlayiciSaglikBaslikFirm { get; set; } = new List<TamamlayiciSaglikBaslik>();

    public virtual ICollection<TamamlayiciSaglikPolice> TamamlayiciSaglikPoliceCalisilanfirmaNavigation { get; set; } = new List<TamamlayiciSaglikPolice>();

    public virtual ICollection<TamamlayiciSaglikPolice> TamamlayiciSaglikPoliceFirm { get; set; } = new List<TamamlayiciSaglikPolice>();

    public virtual ICollection<TeklifBasliklar> TeklifBasliklarCalisilanfirmaNavigation { get; set; } = new List<TeklifBasliklar>();

    public virtual ICollection<TeklifBasliklar> TeklifBasliklarFirm { get; set; } = new List<TeklifBasliklar>();

    public virtual ICollection<TkPoliceler> TkPolicelerCalisilanfirmaNavigation { get; set; } = new List<TkPoliceler>();

    public virtual ICollection<TkPoliceler> TkPolicelerFirm { get; set; } = new List<TkPoliceler>();

    public virtual ICollection<UserDayOffs> UserDayOffs { get; set; } = new List<UserDayOffs>();

    public virtual ICollection<WebNotifications> WebNotifications { get; set; } = new List<WebNotifications>();

    public virtual ICollection<YabanciSaglikBaslik> YabanciSaglikBaslikCalisilanfirmaNavigation { get; set; } = new List<YabanciSaglikBaslik>();

    public virtual ICollection<YabanciSaglikBaslik> YabanciSaglikBaslikFirm { get; set; } = new List<YabanciSaglikBaslik>();

    public virtual ICollection<YesilkartBasliklar> YesilkartBasliklarCalisilanfirmaNavigation { get; set; } = new List<YesilkartBasliklar>();

    public virtual ICollection<YesilkartBasliklar> YesilkartBasliklarFirm { get; set; } = new List<YesilkartBasliklar>();

    public virtual ICollection<YesilkartPoliceler> YesilkartPolicelerCalisilanfirmaNavigation { get; set; } = new List<YesilkartPoliceler>();

    public virtual ICollection<YesilkartPoliceler> YesilkartPolicelerFirm { get; set; } = new List<YesilkartPoliceler>();

    public virtual ICollection<YolferdikazaBasliklar> YolferdikazaBasliklarCalisilanfirmaNavigation { get; set; } = new List<YolferdikazaBasliklar>();

    public virtual ICollection<YolferdikazaBasliklar> YolferdikazaBasliklarFirm { get; set; } = new List<YolferdikazaBasliklar>();

    public virtual ICollection<YolferdikazaPoliceler> YolferdikazaPolicelerCalisilanfirmaNavigation { get; set; } = new List<YolferdikazaPoliceler>();

    public virtual ICollection<YolferdikazaPoliceler> YolferdikazaPolicelerFirm { get; set; } = new List<YolferdikazaPoliceler>();

    public virtual ICollection<YsPoliceler> YsPolicelerCalisilanfirmaNavigation { get; set; } = new List<YsPoliceler>();

    public virtual ICollection<YsPoliceler> YsPolicelerFirm { get; set; } = new List<YsPoliceler>();

    public virtual ICollection<ZorunlukoltukBasliklar> ZorunlukoltukBasliklarCalisilanfirmaNavigation { get; set; } = new List<ZorunlukoltukBasliklar>();

    public virtual ICollection<ZorunlukoltukBasliklar> ZorunlukoltukBasliklarFirm { get; set; } = new List<ZorunlukoltukBasliklar>();

    public virtual ICollection<ZorunlukoltukPoliceler> ZorunlukoltukPolicelerCalisilanfirmaNavigation { get; set; } = new List<ZorunlukoltukPoliceler>();

    public virtual ICollection<ZorunlukoltukPoliceler> ZorunlukoltukPolicelerFirm { get; set; } = new List<ZorunlukoltukPoliceler>();
}
