using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimDurums
{
    public int Id { get; set; }

    public int UretimId { get; set; }

    public int IslemTipi { get; set; }

    public DateTime KayitTarihi { get; set; }

    public DateTime? YvadeBaslangic { get; set; }

    public DateTime? YvadeBitis { get; set; }

    public string? YsirketKodu { get; set; }

    public string? YacenteNo { get; set; }

    public string? YpoliceNo { get; set; }

    public string? YyenilemeNo { get; set; }

    public bool IsPolice { get; set; }

    public bool IsClosed { get; set; }

    public DateTime IslemTarihi { get; set; }

    public int GunSayisi { get; set; }

    public string? Hata { get; set; }

    public bool IsHata { get; set; }

    public int FirmaId { get; set; }

    public bool IsFirma { get; set; }

    public int SigortaId { get; set; }
}
