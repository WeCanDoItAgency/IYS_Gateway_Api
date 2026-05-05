using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UtahPoliceler
{
    public int Id { get; set; }

    public string? UretimCekilenPolicelerMongoId { get; set; }

    public int FirmId { get; set; }

    public Guid FirmGuid { get; set; }

    public int? SktId { get; set; }

    public Guid? SktGuid { get; set; }

    public string? SktMuhasebeKodu { get; set; }

    public int? UserId { get; set; }

    public Guid? UserGuid { get; set; }

    public string? PartajNo { get; set; }

    public int? BrandId { get; set; }

    public string? ApiName { get; set; }

    public int? SubbrandId { get; set; }

    public string? SubbrandName { get; set; }

    public string UretimBrans { get; set; } = null!;

    public string? UretimBransAdi { get; set; }

    public int? QueryTypeId { get; set; }

    public string? QueryType { get; set; }

    public string? QueryTypeName { get; set; }

    public string? PoliceGrupNo { get; set; }

    public string PoliceNumarasi { get; set; } = null!;

    public bool? UretimPolicedeAnaPoliceVarmi { get; set; }

    public int ZeyilNumarasi { get; set; }

    public int TecditNumarasi { get; set; }

    public DateTime TanzimTarihi { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public string? IptalKayit { get; set; }

    public bool? IptalMi { get; set; }

    public int? PoliceDurumu { get; set; }

    public string? PoliceDurumuText { get; set; }

    public bool? MevcutCari { get; set; }

    public int? CariId { get; set; }

    public decimal BrutPrim { get; set; }

    public decimal NetPrim { get; set; }

    public decimal? DovizBrutPrim { get; set; }

    public decimal? DovizNetPrim { get; set; }

    public int? DovizTuruId { get; set; }

    public string? DovizCode { get; set; }

    public decimal? DovizKur { get; set; }

    public decimal? DovizAcenteKomisyon { get; set; }

    public decimal? DovizVergiToplami { get; set; }

    public decimal? VergiToplami { get; set; }

    public string? ZeyilTuru { get; set; }

    public string? ZeyilAdi { get; set; }

    public decimal? Gv { get; set; }

    public decimal? Ysv { get; set; }

    public decimal? Gf { get; set; }

    public decimal? Thgf { get; set; }

    public int? TaksitAdet { get; set; }

    public string? OdemeSekli { get; set; }

    public DateTime? ExtraInfoRejistroTarihi { get; set; }

    public DateTime? ExtraInfoOnayTarihi { get; set; }

    public DateTime? ExtraInfoTanzimTarihi { get; set; }

    public string? ExtraInfoHinsuraPoliceNumarasi { get; set; }

    public string? SigortaliKimlikNo { get; set; }

    public string? SigortaliTamAd { get; set; }

    public string? SigortaliMusteriNo { get; set; }

    public string? SigortaliAdi { get; set; }

    public string? SigortaliSoyadi { get; set; }

    public DateTime? SigortaliDogumTarihi { get; set; }

    public string? SigortaliIl { get; set; }

    public string? SigortaliIlce { get; set; }

    public string? SigortaliAdresi { get; set; }

    public string? SigortaliAdresNo { get; set; }

    public string? RizikoAdres { get; set; }

    public string? SigortaliMail { get; set; }

    public string? SigortaliTelefon { get; set; }

    public string? SigortaEttirenKimlikNo { get; set; }

    public string? SigortaEttirenTamAd { get; set; }

    public string? SigortaEttirenMusteriNo { get; set; }

    public string? SigortaEttirenAdi { get; set; }

    public string? SigortaEttirenSoyadi { get; set; }

    public DateTime? SigortaEttirenDogumTarihi { get; set; }

    public string? SigortaEttirenAdresi { get; set; }

    public string? SigortaEttirenAdresNo { get; set; }

    public string? UavtKodu { get; set; }

    public string? DaskPoliceNo { get; set; }

    public string? EskiPoliceNo { get; set; }

    public bool? RapordanGectiMi { get; set; }

    public DateTime? RaporKontrolTarihi { get; set; }

    public int? IptalSuresiGun { get; set; }

    public string? AdaMuhasebeKodu { get; set; }

    public decimal? AcenteKomisyon { get; set; }

    public string? PlakaNo { get; set; }

    public string? BelgeSeriNo { get; set; }

    public string? SasiNo { get; set; }

    public string? AracKullanimSekli { get; set; }

    public string? AracMarkaKodu { get; set; }

    public string? AracMarka { get; set; }

    public string? AracModel { get; set; }

    public int? AracModelYili { get; set; }

    public string? AracMotorNo { get; set; }

    public string? AracTipi { get; set; }

    public string? AracRengi { get; set; }

    public DateTime? AracTescilTarihi { get; set; }

    public string? AracYakitCinsi { get; set; }

    public bool? DonemKapandiMi { get; set; }

    public Guid? HeaderGuid { get; set; }

    public Guid? DetailGuid { get; set; }

    public Guid? PolicyGuid { get; set; }

    public int? SonGuncelleyenVeriKaynagi { get; set; }

    public string? SonGuncelleyenVeriKaynagiText { get; set; }

    public int? EkleyenVeriKaynagi { get; set; }

    public string? EkleyenVeriKaynagiText { get; set; }

    public string? EskiBrans { get; set; }

    public string? EskiBransAdi { get; set; }

    public int? EskiQueryTypeId { get; set; }

    public string? EskiQueryType { get; set; }

    public int? UpdatedWithNewBransValuesUserId { get; set; }

    public DateTime? UpdatedWithNewBransValuesDate { get; set; }

    public byte? UpdatedWithNewBransValuesStatus { get; set; }

    public string? EkleyenTalepMongoId { get; set; }

    public DateTime? EklenmeTarihi { get; set; }

    public string? SonGuncelleyenTalepMongoId { get; set; }

    public DateTime? SonGuncellenmeTarihi { get; set; }

    public string? PlakaNoRaw { get; set; }

    public string? BelgeSeriNoRaw { get; set; }
}
