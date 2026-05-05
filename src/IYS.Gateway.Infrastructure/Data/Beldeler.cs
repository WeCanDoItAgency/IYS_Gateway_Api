using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Beldeler
{
    public string BeldeKodu { get; set; } = null!;

    public string? IlAdi { get; set; }

    public string? IlceAdi { get; set; }

    public string? BeldeAdi { get; set; }

    public int? IlKodu { get; set; }

    public int? IlceKodu { get; set; }
}
