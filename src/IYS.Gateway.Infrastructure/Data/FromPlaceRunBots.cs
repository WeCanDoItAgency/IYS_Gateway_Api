using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FromPlaceRunBots
{
    public int Id { get; set; }

    public int? QueryTypeId { get; set; }

    public int? FromPlaceId { get; set; }

    public bool? RunOfferBot { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public bool? IsActive { get; set; }
}
