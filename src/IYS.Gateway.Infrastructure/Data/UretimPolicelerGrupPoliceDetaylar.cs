using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimPolicelerGrupPoliceDetaylar
{
    public int Id { get; set; }

    public int? UretimPoliceId { get; set; }

    public string? Brans { get; set; }

    public string? VknNo { get; set; }

    public string? SigortaliAdi { get; set; }

    public DateTime? SigortaliDogumTarihi { get; set; }

    public string? SigortaEttiren { get; set; }

    public string? SigortaEttirenVknNo { get; set; }

    public DateTime? SigortaEttirenDogumTarihi { get; set; }

    public double BrutPrim { get; set; }

    public double NetPrim { get; set; }

    public double? Gv { get; set; }

    public double? Ysv { get; set; }

    public double? Gf { get; set; }

    public double? Thgf { get; set; }

    public double? AcenteKomisyon { get; set; }

    public DateTime? CreateDate { get; set; }
}
