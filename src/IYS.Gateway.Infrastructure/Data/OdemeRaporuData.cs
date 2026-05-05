using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class OdemeRaporuData
{
    public long Id { get; set; }

    public int FirmId { get; set; }

    public int SigortaId { get; set; }

    public string? BolgeKodu { get; set; }

    public string? KkrsistemNo { get; set; }

    public long? MakbuzNo { get; set; }

    public string? KrediKartiNo { get; set; }

    public string? Cvv { get; set; }

    public string? SonKullanmaTarihi { get; set; }

    public DateTime? VadeTarihi { get; set; }

    public DateTime? KapanisTarihi { get; set; }

    public decimal? Tutar { get; set; }

    public string? KartBorclusu { get; set; }

    public string? Partaj { get; set; }

    public string? Durum { get; set; }

    public DateTime? GirisTarihi { get; set; }

    public string? UrunKod { get; set; }

    public string? PoliceNo { get; set; }

    public string? TecditNo { get; set; }

    public string? ZeyilNo { get; set; }

    public string? MusteriAdi { get; set; }

    public byte? Taksit { get; set; }

    public decimal? PoliceDagilan { get; set; }

    public DateTime? PoliceTarihi { get; set; }

    public string? SanalPosBankasi { get; set; }

    public int? SubeNo { get; set; }

    public int? KaynakNo { get; set; }

    public string? AcenteAdi { get; set; }

    public long? RefNo { get; set; }

    public string? Doviz { get; set; }

    public string? Hata { get; set; }

    public int? UnsurNo { get; set; }

    public string? KartBankasi { get; set; }

    public decimal? Kur { get; set; }

    public DateTime? TevdiTarihi { get; set; }

    public string? UyeIsYeri { get; set; }

    public string? OdemeSekli { get; set; }

    public string? BankaCevabi { get; set; }

    public string? SiparisNo { get; set; }

    public string? Provizyon { get; set; }

    public DateTime? TaksitTarihi { get; set; }

    public string? TahsilatNo { get; set; }

    public byte? BelgeTipi { get; set; }

    public string? TahGrupRefNo { get; set; }

    public string? TahRefNo { get; set; }

    public string? BordroNo { get; set; }

    public decimal? TutarDoviz { get; set; }

    public decimal? BelgeGrupToplami { get; set; }

    public decimal? BelgeGrupToplamiTl { get; set; }

    public string? CekHesapNo { get; set; }

    public string? CirolayanAdSoyad { get; set; }

    public string? KesideYeri { get; set; }

    public string? Aciklama { get; set; }

    public string? OncekiDurum { get; set; }

    public string? OncekiDurumAdi { get; set; }

    public string? DurumAdi { get; set; }

    public string? SonDurumKodu { get; set; }

    public string? SonDurumAdi { get; set; }

    public byte? NakitlesmeSonDurumu { get; set; }

    public string? BasitHesapGrubu { get; set; }

    public string? BankaSubeKodu { get; set; }

    public string? BankaSubeAdi { get; set; }

    public string? CodUyeIsYeriNo { get; set; }

    public string? Brans { get; set; }

    public string? SeferNo { get; set; }

    public string? ZeyilSeferNo { get; set; }

    public string? SigortaliKimliktipi { get; set; }

    public string? ProvizyonSekli { get; set; }

    public string? ProvizyonYeri { get; set; }

    public string? AuthorizationCode { get; set; }

    public string? GirenKullanici { get; set; }

    public string? ChargebackAciklama { get; set; }

    public DateTime? ChargebackTarihi { get; set; }

    public string? ChargebackFisNo { get; set; }

    public string? Bnk { get; set; }

    public bool? Odeme3d { get; set; }

    public string? FileName { get; set; }

    public string? İslemTipi { get; set; }

    public string? TarifeGrup { get; set; }

    public string? TarifeAdi { get; set; }

    public DateTime? SenetTanzimTarihi { get; set; }

    public DateTime? HareketTarihi { get; set; }

    public DateTime? KurTarihi { get; set; }

    public string? CustomerNo { get; set; }

    public DateTime? RefundDate { get; set; }

    public DateTime AddedDate { get; set; }
}
