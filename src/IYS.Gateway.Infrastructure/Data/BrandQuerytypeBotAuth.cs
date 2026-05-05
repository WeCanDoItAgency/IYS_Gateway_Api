using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandQuerytypeBotAuth
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public int QueryTypeId { get; set; }

    public int BotType { get; set; }

    public bool IsAuth { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public int? BotRetryCount { get; set; }

    public decimal? MinValue { get; set; }

    public decimal? MaxValue { get; set; }

    public virtual NewBrands Brand { get; set; } = null!;

    public virtual NewQueryTypes QueryType { get; set; } = null!;
}
