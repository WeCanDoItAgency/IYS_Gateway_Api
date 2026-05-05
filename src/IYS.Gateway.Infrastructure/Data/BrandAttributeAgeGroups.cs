using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandAttributeAgeGroups
{
    public int Id { get; set; }

    public int? GroupValueId { get; set; }

    public int? ApiBrandAttributeValueId { get; set; }

    public int? BotBrandAttibuteValueId { get; set; }

    public int? StartAge { get; set; }

    public int? EndAge { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool? ShowInCenterWaiting { get; set; }
}
