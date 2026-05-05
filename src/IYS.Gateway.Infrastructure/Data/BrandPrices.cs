using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandPrices
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public string QueryType { get; set; } = null!;

    public double PriceMultiplier { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UserId { get; set; }
}
