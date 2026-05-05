using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TeklifHesaplar
{
    public int Id { get; set; }

    public int TeklifId { get; set; }

    public double? BrutPrim { get; set; }

    public string? DovizAdi { get; set; }

    public string? DovizKod { get; set; }

    public double? DovizKuru { get; set; }

    public double? GarantiFonu { get; set; }

    public double? GiderVergi { get; set; }

    public double? Komisyon { get; set; }

    public double? NetPrim { get; set; }

    public string? OdemeTipi { get; set; }

    public double? Thgf { get; set; }

    public double? Ysv { get; set; }

    public double? OPlanTutar { get; set; }

    public DateTime? OPlanVade { get; set; }
}
