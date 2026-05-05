using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CampaignCodes
{
    public int Id { get; set; }

    public int CampaignId { get; set; }

    public int RuleId { get; set; }

    public string Code { get; set; } = null!;

    public string? ShortDescription { get; set; }

    public string? LongDescription { get; set; }

    public int? MaxUseCount { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool IsUsed { get; set; }

    public virtual Campaigns Campaign { get; set; } = null!;

    public virtual Kullanicilar? CreatedUser { get; set; }

    public virtual CampaignCodeRules Rule { get; set; } = null!;
}
