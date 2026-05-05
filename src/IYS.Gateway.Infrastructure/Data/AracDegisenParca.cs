using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AracDegisenParca
{
    public int Id { get; set; }

    public string AracDegisenParca1 { get; set; } = null!;

    public long AracId { get; set; }

    public int? EgmqueryHistoryId { get; set; }

    public virtual AracKartlar Arac { get; set; } = null!;

    public virtual EgmqueryHistory? EgmqueryHistory { get; set; }
}
