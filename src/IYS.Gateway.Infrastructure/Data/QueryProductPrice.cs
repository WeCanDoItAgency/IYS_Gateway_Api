using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class QueryProductPrice
{
    public int Id { get; set; }

    public string QueryTypeName { get; set; } = null!;

    public decimal Price { get; set; }

    public int ChangedUserId { get; set; }

    public DateTime ChangedDate { get; set; }

    public string PriceIdentityCode { get; set; } = null!;

    public virtual Kullanicilar ChangedUser { get; set; } = null!;
}
