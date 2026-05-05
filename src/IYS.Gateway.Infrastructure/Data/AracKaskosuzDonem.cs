using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AracKaskosuzDonem
{
    public int Id { get; set; }

    public DateTime KaskosuzDonemBaslangic { get; set; }

    public DateTime KaskosuzDonemBitis { get; set; }

    public long AracId { get; set; }

    public int? EgmqueryHistoryId { get; set; }

    public virtual AracKartlar Arac { get; set; } = null!;

    public virtual EgmqueryHistory? EgmqueryHistory { get; set; }
}
