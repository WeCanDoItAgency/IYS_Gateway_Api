using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewQueryTypes
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? QueryType { get; set; }

    public int? QueryTypeMainGroupId { get; set; }

    public double? MinCommissionAmount { get; set; }

    public bool? IsVisibleLowestPrice { get; set; }

    public bool? IsUseOrder { get; set; }

    public string? DescriptionForSite { get; set; }

    public string? DescriptionForSiteTitle { get; set; }

    public int? PriorityOrder { get; set; }

    public int? ListOfferWaitDurationSn { get; set; }

    public string? BotQueueNameSuffix { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? DeleteUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? IleriVadeTaramaTarihiBaslangic { get; set; }

    public DateTime? IleriVadeTaramaTarihiBitis { get; set; }

    public bool? IleriVadeTarama { get; set; }

    public Guid Guid { get; set; }

    public virtual ICollection<AracDetay> AracDetay { get; set; } = new List<AracDetay>();

    public virtual ICollection<BranchQuerytypeAuth> BranchQuerytypeAuth { get; set; } = new List<BranchQuerytypeAuth>();

    public virtual ICollection<BrandQuerytypeBotAuth> BrandQuerytypeBotAuth { get; set; } = new List<BrandQuerytypeBotAuth>();

    public virtual ICollection<CampaignCodeRules> CampaignCodeRules { get; set; } = new List<CampaignCodeRules>();

    public virtual ICollection<CampaignLogs> CampaignLogs { get; set; } = new List<CampaignLogs>();

    public virtual ICollection<CampaignMessages> CampaignMessages { get; set; } = new List<CampaignMessages>();

    public virtual ICollection<CampaignQueryTypeMapping> CampaignQueryTypeMapping { get; set; } = new List<CampaignQueryTypeMapping>();

    public virtual ICollection<DepartmanQueryTypeMapping> DepartmanQueryTypeMapping { get; set; } = new List<DepartmanQueryTypeMapping>();

    public virtual ICollection<Goals> Goals { get; set; } = new List<Goals>();

    public virtual ICollection<NewBrandDocuments> NewBrandDocuments { get; set; } = new List<NewBrandDocuments>();

    public virtual ICollection<NewBrandProducts> NewBrandProducts { get; set; } = new List<NewBrandProducts>();

    public virtual ICollection<NewCommissions> NewCommissions { get; set; } = new List<NewCommissions>();

    public virtual ICollection<NewCommissionsUser> NewCommissionsUser { get; set; } = new List<NewCommissionsUser>();

    public virtual ICollection<NewManuelOffers> NewManuelOffers { get; set; } = new List<NewManuelOffers>();

    public virtual NewQueryTypeMainGroups? QueryTypeMainGroup { get; set; }

    public virtual ICollection<RdpBrandPartajSktAuthQueryTypeMap> RdpBrandPartajSktAuthQueryTypeMap { get; set; } = new List<RdpBrandPartajSktAuthQueryTypeMap>();

    public virtual ICollection<RdpBrandPartajUserQueryTypeAuthMap> RdpBrandPartajUserQueryTypeAuthMap { get; set; } = new List<RdpBrandPartajUserQueryTypeAuthMap>();

    public virtual ICollection<RdpBrandPartajsQueryTypeMap> RdpBrandPartajsQueryTypeMap { get; set; } = new List<RdpBrandPartajsQueryTypeMap>();

    public virtual ICollection<SktRequestSubBrandAuths> SktRequestSubBrandAuths { get; set; } = new List<SktRequestSubBrandAuths>();

    public virtual ICollection<SubBrandQueryTypeMapping> SubBrandQueryTypeMapping { get; set; } = new List<SubBrandQueryTypeMapping>();

    public virtual ICollection<SubeYetki> SubeYetki { get; set; } = new List<SubeYetki>();

    public virtual ICollection<SubeYetki2> SubeYetki2 { get; set; } = new List<SubeYetki2>();
}
