using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Koyuncahopluyormu
{
    public int Id { get; set; }

    public int SigortaId { get; set; }

    public string? ExcelSirketAdi { get; set; }

    public string? Brans { get; set; }

    public string? BransAdi { get; set; }
}
