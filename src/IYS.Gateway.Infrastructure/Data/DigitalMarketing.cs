using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class DigitalMarketing
{
    public int Id { get; set; }

    public string? CampaignName { get; set; }

    public string? CampaignDescription { get; set; }

    public string? MongoId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }
}
