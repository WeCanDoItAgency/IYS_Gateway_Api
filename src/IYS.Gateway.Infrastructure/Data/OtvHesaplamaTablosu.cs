using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class OtvHesaplamaTablosu
{
    public int Id { get; set; }

    public int? MinCc { get; set; }

    public int? MaxCc { get; set; }

    public decimal? VergisizSatisTutariMin { get; set; }

    public decimal? VergisizSatisTutariMax { get; set; }

    public double? Otv { get; set; }

    public double? Kdv { get; set; }

    public int? AracTipi { get; set; }

    public double? MaxKw { get; set; }

    public double? MinKw { get; set; }

    public bool? Elektriklimi { get; set; }

    public bool? Hibritmi { get; set; }
}
