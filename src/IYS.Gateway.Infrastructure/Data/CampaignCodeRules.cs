using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CampaignCodeRules
{
    public int Id { get; set; }

    public int? CampaignId { get; set; }

    public string? Name { get; set; }

    public int? QueryTypeId { get; set; }

    public decimal MinAmount { get; set; }

    public decimal MaxAmount { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public int? DiscountType { get; set; }

    public decimal? Discount { get; set; }

    public string? ReferansCode { get; set; }

    public virtual Campaigns? Campaign { get; set; }

    public virtual ICollection<CampaignCodes> CampaignCodes { get; set; } = new List<CampaignCodes>();

    public virtual ICollection<CampaignLogs> CampaignLogs { get; set; } = new List<CampaignLogs>();

    public virtual CampaignRefundTypes? DiscountTypeNavigation { get; set; }

    public virtual NewQueryTypes? QueryType { get; set; }
}
