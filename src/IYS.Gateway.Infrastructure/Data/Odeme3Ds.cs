using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Odeme3Ds
{
    public long Id { get; set; }

    public string TypeCode { get; set; } = null!;

    public int DetayNo { get; set; }

    /// <summary>
    /// 0-Yeni 1-provizyon 3-Kapat
    /// </summary>
    public short Durumu { get; set; }

    public string? BankaNo { get; set; }

    public string? KartNo { get; set; }

    public string? Cvv { get; set; }

    public string? Ay { get; set; }

    public string? Yil { get; set; }

    public string? UrunKodu { get; set; }

    public string? Adi { get; set; }

    public string? Soyadi { get; set; }

    public string? VposId { get; set; }

    public string? VposOrderId { get; set; }

    public string? Taksit { get; set; }

    public string? KartKodu { get; set; }

    public int VposCount { get; set; }
}
