using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CampaignTypeMapping
{
    public int Id { get; set; }

    public int CampaignId { get; set; }

    public int CampaignTypeId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public virtual Campaigns Campaign { get; set; } = null!;
}
