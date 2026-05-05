using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AracKm
{
    public int Id { get; set; }

    public long AracId { get; set; }

    public string GuncelKm { get; set; } = null!;

    public DateTime QueryDate { get; set; }

    public int EgmqueryHistoryId { get; set; }

    public virtual AracKartlar Arac { get; set; } = null!;

    public virtual EgmqueryHistory EgmqueryHistory { get; set; } = null!;
}
