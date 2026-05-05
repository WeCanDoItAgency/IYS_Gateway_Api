using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PolicyDetailViews
{
    public long Id { get; set; }

    public string QueryType { get; set; } = null!;

    public string EntityId { get; set; } = null!;

    public string Ip { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime LastViewDate { get; set; }

    public int ViewCount { get; set; }
}
