using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimdenCekilenPoliceler
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SktId { get; set; }

    public int? UserId { get; set; }

    public string? PartajNo { get; set; }

    public int? QueryTypeId { get; set; }

    public string? QueryType { get; set; }

    public string? PoliceGrupNo { get; set; }

    public string? PoliceNumarasi { get; set; }

    public int? ZeyilNumarasi { get; set; }

    public int? TecditNumarasi { get; set; }

    public string? IptalKayit { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public DateTime? KontrolTarihi { get; set; }

    public DateTime? RejistroTarihi { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? TanzimTarihi2 { get; set; }

    public int SubbrandId { get; set; }

    public string? UretimBrans { get; set; }

    public string? UretimBransAdi { get; set; }

    public string? MusteriAdi { get; set; }

    public string? MusteriEmail { get; set; }

    public string? MusteriTelefon { get; set; }

    public string? MusteriKimlikNo { get; set; }

    public bool? CariKartiOlusturulduMu { get; set; }

    public string? SigortaliAdi { get; set; }

    public DateTime? SigortaliDogumTarihi { get; set; }

    public string? SigortaliIl { get; set; }

    public string? SigortaliIlce { get; set; }

    public string? SigortaliAdresi { get; set; }

    public string? SigortaliAdresNo { get; set; }

    public string? SigortaEttiren { get; set; }

    public string? SigortaEttirenVknNo { get; set; }

    public DateTime? SigortaEttirenDogumTarihi { get; set; }

    public string? SigortaEttirenAdresi { get; set; }

    public string? SigortaEttirenAdresNo { get; set; }

    public DateTime? OnayTarihi { get; set; }

    public decimal BrutPrim { get; set; }

    public decimal NetPrim { get; set; }

    public decimal? SbrutPrim { get; set; }

    public decimal? SnetPrim { get; set; }

    public decimal? DnetPrim { get; set; }

    public decimal? DbrutPrim { get; set; }

    public string? Dcinsi { get; set; }

    public decimal? Dkur { get; set; }

    public decimal? Dkomisyon { get; set; }

    public decimal? Gv { get; set; }

    public decimal? Ysv { get; set; }

    public decimal? Gf { get; set; }

    public decimal? Thgf { get; set; }

    public short? IslenmeDurumu { get; set; }

    public int IptalSuresi { get; set; }

    public string? SktMuhasebeKodu { get; set; }

    public bool? UretimdekiAdaKodunaGoreKontrolEdildiMi { get; set; }

    public string? AdaMuhasebeKodu { get; set; }

    public bool? AdaMuhasebeKodundanRdpOlusturuldu { get; set; }

    public decimal? AcenteKomisyon { get; set; }

    public int? AcenteKomisyonOrani { get; set; }

    public decimal? SktKomisyon { get; set; }

    public string? SktKomisyonId { get; set; }

    public int? SktKomisyonOrani { get; set; }

    public decimal? KullaniciKomisyon { get; set; }

    public string? KullaniciKomisyonId { get; set; }

    public int? KullaniciKomisyonOrani { get; set; }

    public string? UavtKodu { get; set; }

    public string? Adres { get; set; }

    public string? RizikoAdres { get; set; }

    public string? PlakaNo { get; set; }

    public string? BelgeSeriNo { get; set; }

    public string? SasiNo { get; set; }

    public int? MarkaKodu { get; set; }

    public string? Marka { get; set; }

    public string? Model { get; set; }

    public int? ModelYili { get; set; }

    public string? MotorNo { get; set; }

    public string? AracTipi { get; set; }

    public string? AracRengi { get; set; }

    public DateTime? AracTescilTarihi { get; set; }

    public string? AracYakitCinsi { get; set; }

    public DateTime? HasarOdemeTarihi { get; set; }

    public string? HasarOdemeTipi { get; set; }

    public double? HasarOdemeTutari { get; set; }

    public int TaksitAdet { get; set; }

    public string? OdemeSekli { get; set; }

    public string? ExcelSirketAdi { get; set; }

    public bool? DonemKapandiMi { get; set; }

    public bool? IsManualInserted { get; set; }

    public bool IsAdaFile { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? LastUpdatePlace { get; set; }

    public int? LastUpdateJobId { get; set; }

    public string? HinsuraPoliceNo { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? HeaderEntityId { get; set; }

    public Guid? HeaderGuid { get; set; }

    public int? DetailEntityId { get; set; }

    public Guid? DetailGuid { get; set; }

    public int? PolicyEntityId { get; set; }

    public Guid? PolicyGuid { get; set; }

    public int? UretiCekmeEmirId { get; set; }

    public bool? UretimPolicedeAnaPoliceVarmi { get; set; }

    public string? EskiBrans { get; set; }

    public string? EskiBransAdi { get; set; }

    public int? EskiQueryTypeId { get; set; }

    public string? EskiQueryType { get; set; }

    public int? UpdatedWithNewBransValuesUserId { get; set; }

    public DateTime? UpdatedWithNewBransValuesDate { get; set; }

    public short? UpdatedWithNewBransValuesStatus { get; set; }
}
