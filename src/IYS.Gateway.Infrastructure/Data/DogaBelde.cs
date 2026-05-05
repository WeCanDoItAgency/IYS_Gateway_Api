using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class DogaBelde
{
    public int Id { get; set; }

    public string BeldeKodu { get; set; } = null!;

    public string IlAdi { get; set; } = null!;

    public string IlceAdi { get; set; } = null!;

    public string BeldeAdi { get; set; } = null!;

    public string? IlKodu { get; set; }

    public string? IlceKodu { get; set; }
}
