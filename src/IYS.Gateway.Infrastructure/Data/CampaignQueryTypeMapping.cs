using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CampaignQueryTypeMapping
{
    public int Id { get; set; }

    public int? CampaignId { get; set; }

    public int? QueryTypeId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Campaigns? Campaign { get; set; }

    public virtual NewQueryTypes? QueryType { get; set; }
}
