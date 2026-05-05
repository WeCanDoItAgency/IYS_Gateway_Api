using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandNoClaimDiscounts
{
    public int Id { get; set; }

    public int? BrandId { get; set; }

    public int? Stage { get; set; }

    public int? DiscountRate { get; set; }

    public string? DisplayText { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public bool? IsActive { get; set; }
}
