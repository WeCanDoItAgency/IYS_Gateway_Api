using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SubeQueryTransactions
{
    public int Id { get; set; }

    public int SubeId { get; set; }

    public decimal Amount { get; set; }

    public DateTime ProcessDate { get; set; }

    public int ProcessByUserId { get; set; }

    public virtual Kullanicilar ProcessByUser { get; set; } = null!;

    public virtual Subeler Sube { get; set; } = null!;
}
