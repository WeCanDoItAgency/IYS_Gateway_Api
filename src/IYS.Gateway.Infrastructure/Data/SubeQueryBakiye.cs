using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SubeQueryBakiye
{
    public int Id { get; set; }

    public int SubeId { get; set; }

    public decimal Bakiye { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public virtual Subeler Sube { get; set; } = null!;
}
