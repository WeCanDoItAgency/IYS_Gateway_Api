using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AracHasarBilgisi
{
    public int Id { get; set; }

    public long AracId { get; set; }

    public DateTime HasarTarihi { get; set; }

    public string HasarNedeni { get; set; } = null!;

    public decimal HasarTutari { get; set; }

    public int? EgmqueryHistoryId { get; set; }

    public virtual AracKartlar Arac { get; set; } = null!;

    public virtual EgmqueryHistory? EgmqueryHistory { get; set; }
}
