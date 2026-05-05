using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimPoliceler
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SktId { get; set; }

    public int? UserId { get; set; }

    public string? PartajNo { get; set; }

    public int SigortaId { get; set; }

    public string? Brans { get; set; }

    public string? BransAdi { get; set; }

    public string? MusteriAdi { get; set; }

    public string? MusteriEmail { get; set; }

    public string? MusteriTelefon { get; set; }

    public string? VknNo { get; set; }

    public string? SigortaliAdi { get; set; }

    public DateTime? SigortaliDogumTarihi { get; set; }

    public string? SigortaliAdresi { get; set; }

    public string? SigortaliAdresNo { get; set; }

    public string? SigortaEttiren { get; set; }

    public string? SigortaEttirenVknNo { get; set; }

    public DateTime? SigortaEttirenDogumTarihi { get; set; }

    public string? SigortaEttirenAdresi { get; set; }

    public string? SigortaEttirenAdresNo { get; set; }

    public DateTime? IslemTarihi { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? Tanzim1 { get; set; }

    public DateTime? Baslama { get; set; }

    public DateTime? Bitis { get; set; }

    public DateTime? KontrolTarihi { get; set; }

    public DateTime? RejistroTarihi { get; set; }

    public DateTime? OnayTarihi { get; set; }

    public string? PoliceNo { get; set; }

    public string? ZeyilNo { get; set; }

    public string? TecditNo { get; set; }

    public string? IptalKayit { get; set; }

    public double BrutPrim { get; set; }

    public double NetPrim { get; set; }

    public double? SbrutPrim { get; set; }

    public double? SnetPrim { get; set; }

    public double? DnetPrim { get; set; }

    public double? DbrutPrim { get; set; }

    public string? Dcinsi { get; set; }

    public double? Dkur { get; set; }

    public double? Dkomisyon { get; set; }

    public double? Gv { get; set; }

    public double? Ysv { get; set; }

    public double? Gf { get; set; }

    public double? Thgf { get; set; }

    public short? Durum { get; set; }

    public int IptalSuresi { get; set; }

    public string? MuhKod { get; set; }

    public double? AcenteKomisyon { get; set; }

    public double? AcenteKomisyonOrani { get; set; }

    public double? MusteriKomisyon { get; set; }

    public double? MusteriKomisyonOrani { get; set; }

    public double? KomisyonOrani { get; set; }

    public double? NewMusteriKomisyon { get; set; }

    public double? NewMusteriKomisyonOrani { get; set; }

    public string? RizikoAdres { get; set; }

    public string? PlakaNo { get; set; }

    public string? BelgeSeriNo { get; set; }

    public string? SasiNo { get; set; }

    public string? MarkaKodu { get; set; }

    public string? Marka { get; set; }

    public string? Model { get; set; }

    public int? ModelYili { get; set; }

    public string? MotorNo { get; set; }

    public string? KullanimTarzi { get; set; }

    public string? AracRengi { get; set; }

    public DateTime? TescilTarihi { get; set; }

    public string? YakitCinsi { get; set; }

    public DateTime? HasarOdemeTarihi { get; set; }

    public string? HasarOdemeTipi { get; set; }

    public double? HasarOdemeTutari { get; set; }

    public string? UavtKodu { get; set; }

    public int TaksitAdet { get; set; }

    public string? OdemeSekli { get; set; }

    public int? ReprCommentId { get; set; }

    public bool IsClosed { get; set; }

    public string? Konum { get; set; }

    public int? UuserId { get; set; }

    public string? ExcelSirketAdi { get; set; }

    public string? Adres { get; set; }

    public string? Bildirim { get; set; }

    public bool? IsChangedKomisyon { get; set; }

    public int? KomisyonChangedBy { get; set; }

    public DateTime? KomisyonChangedDate { get; set; }

    public bool? IsPeriodClosed { get; set; }

    public decimal? BranchCommission { get; set; }

    public int? BranchCommissionType { get; set; }

    public int? BranchComissionId { get; set; }

    public decimal? UserCommission { get; set; }

    public int? UserCommissionType { get; set; }

    public int? UserComissionId { get; set; }

    public string? PolicyGroupNo { get; set; }

    public string? AdaMuhasebeKodu { get; set; }

    public bool? IsManualInserted { get; set; }

    public int? QueryTypeId { get; set; }

    public string? QueryType { get; set; }

    public bool IsAdaFile { get; set; }

    public bool? ImportFromAdaCodeControl { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? LastUpdatePlace { get; set; }

    public int? LastUpdateJobId { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public bool? AdresBotSync { get; set; }

    public string? HinsuraPoliceNo { get; set; }

    public int? HeaderId { get; set; }

    public int? DetailId { get; set; }

    public int? PaymentId { get; set; }

    public bool? EslestirmeKontrol { get; set; }

    public int? CreatedJobId { get; set; }

    public bool? AdaControl { get; set; }

    public bool? UretimPolicedeAnaPoliceVarmi { get; set; }

    public string? OldBrans { get; set; }

    public string? OldBransAdi { get; set; }

    public int? OldQueryTypeId { get; set; }

    public string? OldQueryType { get; set; }

    public int? UpdatedWithNewBransValuesUserId { get; set; }

    public DateTime? UpdatedWithNewBransValuesDate { get; set; }

    public short? UpdatedWithNewBransValuesStatus { get; set; }
}
