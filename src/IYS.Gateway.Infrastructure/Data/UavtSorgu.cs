using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UavtSorgu
{
    public int Id { get; set; }

    public string? AcikAdres { get; set; }

    public long? AdresNo { get; set; }

    public bool? AdresNoSpecified { get; set; }

    public int? AdresTipi { get; set; }

    public bool? AdresTipiSpecified { get; set; }

    public bool? BeyanTarihiSpecified { get; set; }

    public bool? BeyandaBulunanKimlikNoSpecified { get; set; }

    public string? BinaAda { get; set; }

    public string? BinaBlokAdi { get; set; }

    public int? BinaKodu { get; set; }

    public bool? BinaKoduSpecified { get; set; }

    public string? BinaPafta { get; set; }

    public string? BinaParsel { get; set; }

    public string? BinaSiteAdi { get; set; }

    public string? Bucak { get; set; }

    public bool? BucakKoduSpecified { get; set; }

    public string? Csbm { get; set; }

    public int? CsbmKodu { get; set; }

    public bool? CsbmKoduSpecified { get; set; }

    public string? DisKapiNo { get; set; }

    public string? IcKapiNo { get; set; }

    public string? IlAd { get; set; }

    public string? IlKodu { get; set; }

    public string? IlceAd { get; set; }

    public string? IlceKodu { get; set; }

    public string? KimlikNo { get; set; }

    public bool? KimlikNoSpecified { get; set; }

    public string? Koy { get; set; }

    public bool? KoyKayitNoSpecified { get; set; }

    public bool? KoyKoduSpecified { get; set; }

    public DateTime? KpsdenSorgulanmaTarihi { get; set; }

    public bool? KpsdenSorgulanmaTarihiSpecified { get; set; }

    public string? Mahalle { get; set; }

    public int? MahalleKodu { get; set; }

    public bool? MahalleKoduSpecified { get; set; }

    public int? MernisIlKodu { get; set; }

    public bool? MernisIlKoduSpecified { get; set; }

    public int? MernisIlceKodu { get; set; }

    public bool? MernisIlceKoduSpecified { get; set; }

    public bool? TasinmaTarihiSpecified { get; set; }

    public bool? TescilTarihiSpecified { get; set; }

    public string? VeriKonum { get; set; }

    public string? YabanciAdres { get; set; }

    public string? YabanciSehir { get; set; }

    public string? YabanciUlke { get; set; }

    public bool? YabanciUlkeKoduSpecified { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UserId { get; set; }
}
