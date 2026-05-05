using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimReports
{
    public int Period { get; set; }

    public int RowId { get; set; }

    public int SigortaId { get; set; }

    public int QueryId { get; set; }

    public double BrutToplam { get; set; }

    public double NetToplam { get; set; }

    public double BrutIptal { get; set; }

    public double NetIptal { get; set; }

    public double BrutGenel { get; set; }

    public double NetGenel { get; set; }

    public double? NormalGv { get; set; }

    public double? IptalGv { get; set; }

    public double? NormalYsv { get; set; }

    public double? IptalYsv { get; set; }

    public double? NormalGf { get; set; }

    public double? IptalGf { get; set; }

    public double? NormalThgf { get; set; }

    public double? IptalThgf { get; set; }

    public int? PolicyCount { get; set; }

    public double? GenelGv { get; set; }

    public double? GenelYsv { get; set; }

    public double? GenelGf { get; set; }

    public double? GenelThgf { get; set; }

    public double? NormalAcenteKomisyon { get; set; }

    public double? IptalAcenteKomisyon { get; set; }

    public double? GenelAcenteKomisyon { get; set; }

    public double? NormalMusteriKomisyon { get; set; }

    public double? IptalMusteriKomisyon { get; set; }

    public double? GenelMusteriKomisyon { get; set; }

    public double? NormalSktKomisyon { get; set; }

    public double? IptalSktKomisyon { get; set; }

    public double? GenelSktKomisyon { get; set; }
}
