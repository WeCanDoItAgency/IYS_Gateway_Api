using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimPolicelerN
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? UserId { get; set; }

    public int SigortaId { get; set; }

    public string? Brans { get; set; }

    public string? BransAdi { get; set; }

    public string? MusteriAdi { get; set; }

    public string? SigortaliAdi { get; set; }

    public string? SigortaEttiren { get; set; }

    public string? VknNo { get; set; }

    public string? PlakaNo { get; set; }

    public string? SasiNo { get; set; }

    public DateTime? IslemTarihi { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? Baslama { get; set; }

    public DateTime? Bitis { get; set; }

    public string? PoliceNo { get; set; }

    public string? ZeyilNo { get; set; }

    public string? TecditNo { get; set; }

    public string? IptalKayit { get; set; }

    public double BrutPrim { get; set; }

    public double NetPrim { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? KontrolTarihi { get; set; }

    public double? SbrutPrim { get; set; }

    public double? SnetPrim { get; set; }

    public short? Durum { get; set; }

    public int IptalSuresi { get; set; }

    public string? MuhKod { get; set; }

    public double? AcenteKomisyon { get; set; }

    public double? MusteriKomisyon { get; set; }

    public string? RizikoAdres { get; set; }

    public string? Marka { get; set; }

    public string? Model { get; set; }

    public string? MotorNo { get; set; }

    public int? ReprCommentId { get; set; }

    public bool IsClosed { get; set; }

    public DateTime? RejistroTarihi { get; set; }

    public DateTime? OnayTarihi { get; set; }

    public DateTime? Tanzim1 { get; set; }

    public string? Konum { get; set; }

    public int? UuserId { get; set; }

    public string? ExcelSirketAdi { get; set; }

    public string? BelgeSeriNo { get; set; }

    public string? Adres { get; set; }

    public int TaksitAdet { get; set; }

    public string? Bildirim { get; set; }

    public double? KomisyonOrani { get; set; }

    public double? NewMusteriKomisyon { get; set; }

    public double? NewMusteriKomisyonOrani { get; set; }

    public bool? IsChangedKomisyon { get; set; }

    public int? KomisyonChangedBy { get; set; }

    public DateTime? KomisyonChangedDate { get; set; }

    public double? DnetPrim { get; set; }

    public double? DbrutPrim { get; set; }

    public string? Dcinsi { get; set; }

    public double? Dkur { get; set; }

    public double? Dkomisyon { get; set; }

    public double? Gv { get; set; }

    public double? Ysv { get; set; }

    public double? Gf { get; set; }

    public double? Thgf { get; set; }

    public bool? IsPeriodClosed { get; set; }
}
