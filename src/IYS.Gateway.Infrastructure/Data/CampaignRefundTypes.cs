using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CampaignRefundTypes
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? CurrencyType { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<CampaignCodeRules> CampaignCodeRules { get; set; } = new List<CampaignCodeRules>();

    public virtual ICollection<CampaignMessages> CampaignMessages { get; set; } = new List<CampaignMessages>();

    public virtual ICollection<Campaigns> Campaigns { get; set; } = new List<Campaigns>();
}
