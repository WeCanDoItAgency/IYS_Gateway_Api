using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Tahsilatlar
{
    public int Id { get; set; }

    public string? KayitReferansNo { get; set; }

    public int? FirmaId { get; set; }

    public Guid? FirmGuid { get; set; }

    public string? FirmaAdi { get; set; }

    public int? SktId { get; set; }

    public Guid? SktGuid { get; set; }

    public string? SktName { get; set; }

    public int? TalepEdenKullaniciId { get; set; }

    public string? TalepEdenKullaniciAdi { get; set; }

    public string? BotUretimCekmeTalepleriMongoId { get; set; }

    public string? UretimCekmeAnaEmirTaleplerId { get; set; }

    public int? TahsilatGenelTuru { get; set; }

    public string? TahsilatGenelTuruText { get; set; }

    public int? OdemeKonumTuru { get; set; }

    public string? OdemeKonumTuruText { get; set; }

    public int? GuvenliOdemeTuru { get; set; }

    public string? GuvenliOdemeTuruText { get; set; }

    public int? SigortaSirketiId { get; set; }

    public string? SigortaSirketiAdi { get; set; }

    public string? SigortaSirketiApiName { get; set; }

    public string? UretimBransKodu { get; set; }

    public string? UretimBransAdi { get; set; }

    public string? QueryType { get; set; }

    public string? QueryTypeName { get; set; }

    public string? PoliceNumarasi { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public int? TecditNo { get; set; }

    public int? ZeyilNo { get; set; }

    public decimal? BrutPrim { get; set; }

    public decimal? NetPrim { get; set; }

    public string? BankaAdi { get; set; }

    public string? KartSahibiAdSoyad { get; set; }

    public string? HesapCekNo { get; set; }

    public string? HesapCekNoSonKullanmaTarihi { get; set; }

    public bool? SirketKartiMi { get; set; }

    public int? SirketKartiId { get; set; }

    public int? TaksitNo { get; set; }

    public int? ToplamTaksitSayisi { get; set; }

    public decimal? Tutar { get; set; }

    public decimal? Gv { get; set; }

    public decimal? Thgf { get; set; }

    public decimal? Ghp { get; set; }

    public decimal? Ysv { get; set; }

    public int? DovizTipi { get; set; }

    public string? DovizTipiText { get; set; }

    public decimal? DovizKur { get; set; }

    public decimal? DovizTutar { get; set; }

    public string? AcenteNo { get; set; }

    public string? AcenteAdi { get; set; }

    public string? IslemiYapan { get; set; }

    public DateTime? IslemGirisTarihi { get; set; }

    public bool? IptalBoolean { get; set; }

    public string? IptalText { get; set; }

    public string? SigortaliKimlikNo { get; set; }

    public string? SigortaliAdi { get; set; }

    public string? SigortaEttirenKimlikNo { get; set; }

    public string? SigortaEttirenAdi { get; set; }

    public string? OperasyonTip { get; set; }

    public string? OperasyonDurum { get; set; }

    public decimal? Komisyon { get; set; }

    public bool? KomisyonMu { get; set; }

    public DateTime? KapanisTarihi { get; set; }

    public DateTime? Vade { get; set; }

    public string? MakbuzNo { get; set; }

    public string? Aciklama { get; set; }

    public string? SiparisTipi { get; set; }

    public int? RdpProductionId { get; set; }

    public int? UretimPolicelerId { get; set; }

    public int? PoliceId { get; set; }

    public bool? DonemKapatmadaIslendi { get; set; }

    public bool? MutabakattaIslendi { get; set; }

    public DateTime CreatedDate { get; set; }
}
