using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UtahPolicelerRapor
{
    public int Period { get; set; }

    public int RowId { get; set; }

    public int SigortaId { get; set; }

    public int QueryId { get; set; }

    public decimal? BrutToplam { get; set; }

    public decimal? NetToplam { get; set; }

    public decimal? BrutIptal { get; set; }

    public decimal? NetIptal { get; set; }

    public decimal? BrutGenel { get; set; }

    public decimal? NetGenel { get; set; }

    public decimal? NormalGv { get; set; }

    public decimal? IptalGv { get; set; }

    public decimal? NormalYsv { get; set; }

    public decimal? IptalYsv { get; set; }

    public decimal? NormalGf { get; set; }

    public decimal? IptalGf { get; set; }

    public decimal? NormalThgf { get; set; }

    public decimal? IptalThgf { get; set; }

    public int? PolicyCount { get; set; }

    public decimal? GenelGv { get; set; }

    public decimal? GenelYsv { get; set; }

    public decimal? GenelGf { get; set; }

    public decimal? GenelThgf { get; set; }

    public decimal? NormalAcenteKomisyon { get; set; }

    public decimal? IptalAcenteKomisyon { get; set; }

    public decimal? GenelAcenteKomisyon { get; set; }

    public int? FirmId { get; set; }

    public DateTime? OlusturmaTarihi { get; set; }

    public int? TalepEdenUserId { get; set; }
}
