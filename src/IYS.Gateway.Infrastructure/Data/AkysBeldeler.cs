using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AkysBeldeler
{
    public int Id { get; set; }

    public int? IlKodu { get; set; }

    public string IlAdi { get; set; } = null!;

    public string BeldeAdi { get; set; } = null!;

    public string BeldeKodu { get; set; } = null!;
}
