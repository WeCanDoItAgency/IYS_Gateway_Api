using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewSubBrands
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BrandId { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }

    public string? AgencyPassword { get; set; }

    public string? ApiKey { get; set; }

    public string? AgentCode { get; set; }

    public string? AgencyUsername { get; set; }

    public bool? IsWebService { get; set; }

    public string? WsagencyCode { get; set; }

    public string? Wsusername { get; set; }

    public string? Wspassword { get; set; }

    public string? WsauthUsername { get; set; }

    public string? WsauthPassword { get; set; }

    public string? ProductionChannel { get; set; }

    public string? ProductionUsername { get; set; }

    public string? ProductionPassword { get; set; }

    public string? IpAddress { get; set; }

    public bool? IsProduction { get; set; }

    public bool IsProductionWebService { get; set; }

    public bool IsProductionBot { get; set; }

    public bool IsProductionMail { get; set; }

    public bool IsProductionManuel { get; set; }

    public bool IsPaymentTransfer { get; set; }

    public bool IsPaymentTransferWebService { get; set; }

    public bool IsPaymentTransferBot { get; set; }

    public int? CommissionId { get; set; }

    public string? ProductionAuthUser { get; set; }

    public string? ProductionAuthPass { get; set; }

    public bool? IsRdp { get; set; }

    public bool? IsAskCenter { get; set; }

    public string? AuthKey { get; set; }

    public string? KaynakKod { get; set; }

    public string? SubeKod { get; set; }

    public bool? IsProductionForHealth { get; set; }

    public string? ProductionChannelForHealth { get; set; }

    public string? ProductionUsernameForHealth { get; set; }

    public string? ProductionPasswordForHealth { get; set; }

    public bool? IsProductionForLife { get; set; }

    public string? ProductionChannelForLife { get; set; }

    public string? ProductionUsernameForLife { get; set; }

    public string? ProductionPasswordForLife { get; set; }

    public bool? IsOpenPayment { get; set; }

    public string? CurrentToken { get; set; }

    public DateTime? CurrentTokenExpireDate { get; set; }

    public bool? IsHaveAuthorizationRequestPermission { get; set; }

    public bool? IsHaveDiscountRequestPermission { get; set; }

    public bool IsHaveAdditionalPremiumDiscountPermission { get; set; }

    public string? ExtraAgencyNo { get; set; }

    public string? ExtraUsername { get; set; }

    public string? ExtraPassword { get; set; }

    public string? ExtraInfoDescription { get; set; }

    public bool IsRunTrafficSfsbot { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? DeleteUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IlerıVadeBotaGonderilsinMi { get; set; }

    public bool? IsTestOrLive { get; set; }

    public string? TrafikApiKey { get; set; }

    public string? NewWebserviceUsername { get; set; }

    public string? NewWebservicePassword { get; set; }

    public string? OpenPaymentUserName { get; set; }

    public string? OpenPaymentPassword { get; set; }

    public string? OpenPaymentAgentCode { get; set; }

    public string? OpenPaymentApiKey { get; set; }

    public string? KkToken { get; set; }

    public bool? EgmCalissinMi { get; set; }

    public bool? KpsCalissinMi { get; set; }

    public bool? BelgeSeriCalissinMi { get; set; }

    public bool? DaskUavtCalissinMi { get; set; }

    public bool? DaskEskiPoliceCalissinMi { get; set; }

    public bool? TcPlakaSorguCalissinMi { get; set; }

    public bool? SmpSorguCalissinMi { get; set; }

    public bool? EgmRawCalissinMi { get; set; }

    public bool? DaskUavtAdresCalissinMi { get; set; }

    public bool? AltSigortaSirketiMi { get; set; }

    public virtual ICollection<AracDetay> AracDetay { get; set; } = new List<AracDetay>();

    public virtual ICollection<BotQueueNames> BotQueueNames { get; set; } = new List<BotQueueNames>();

    public virtual NewBrands? Brand { get; set; }

    public virtual ICollection<CampaignLogs> CampaignLogs { get; set; } = new List<CampaignLogs>();

    public virtual NewFirms? Firm { get; set; }

    public virtual ICollection<FirmApiAdresses> FirmApiAdresses { get; set; } = new List<FirmApiAdresses>();

    public virtual ICollection<Goals> Goals { get; set; } = new List<Goals>();

    public virtual ICollection<KisaTrafikPoliceler> KisaTrafikPoliceler { get; set; } = new List<KisaTrafikPoliceler>();

    public virtual ICollection<KisaTrafikTeklifler> KisaTrafikTeklifler { get; set; } = new List<KisaTrafikTeklifler>();

    public virtual ICollection<NewCommissions> NewCommissions { get; set; } = new List<NewCommissions>();

    public virtual ICollection<NewCommissionsUser> NewCommissionsUser { get; set; } = new List<NewCommissionsUser>();

    public virtual ICollection<NewManuelOffers> NewManuelOffers { get; set; } = new List<NewManuelOffers>();

    public virtual ICollection<QueryRules> QueryRules { get; set; } = new List<QueryRules>();

    public virtual ICollection<SktRequestSubBrandAuths> SktRequestSubBrandAuths { get; set; } = new List<SktRequestSubBrandAuths>();

    public virtual ICollection<SubBrandQueryTypeMapping> SubBrandQueryTypeMapping { get; set; } = new List<SubBrandQueryTypeMapping>();

    public virtual ICollection<SubBrandSktBlocks> SubBrandSktBlocks { get; set; } = new List<SubBrandSktBlocks>();

    public virtual ICollection<SubQueryRules> SubQueryRules { get; set; } = new List<SubQueryRules>();

    public virtual ICollection<SubeYetki> SubeYetki { get; set; } = new List<SubeYetki>();

    public virtual ICollection<SubeYetki2> SubeYetki2 { get; set; } = new List<SubeYetki2>();

    public virtual ICollection<TrainingsInsurances> TrainingsInsurances { get; set; } = new List<TrainingsInsurances>();
}
