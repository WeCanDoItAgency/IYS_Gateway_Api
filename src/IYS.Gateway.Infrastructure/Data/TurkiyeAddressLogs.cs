using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TurkiyeAddressLogs
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? UserId { get; set; }

    public string? IpAddress { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? KimlikNo { get; set; }

    public string? AdresNo { get; set; }

    public string? AdresTipi { get; set; }

    public string? BinaAda { get; set; }

    public string? BinaBlokAdi { get; set; }

    public string? BinaKodu { get; set; }

    public string? BinaPafta { get; set; }

    public string? BinaParsel { get; set; }

    public string? Csbm { get; set; }

    public string? CsbmKodu { get; set; }

    public string? DisKapiNo { get; set; }

    public string? IcKapiNo { get; set; }

    public string? IlAd { get; set; }

    public string? IlKodu { get; set; }

    public string? IlceAd { get; set; }

    public string? IlceKodu { get; set; }

    public DateTime? KpsdenSorgulanmaTarihi { get; set; }

    public string? Mahalle { get; set; }

    public string? MahalleKodu { get; set; }

    public string? MernisIlceKodu { get; set; }

    public string? VeriKonum { get; set; }

    public string? BinaSiteAdi { get; set; }

    public string? InfoMessage { get; set; }

    public string? MernisIlKodu { get; set; }

    public string? AcikAdres { get; set; }

    public string? Koy { get; set; }

    public string? Bucak { get; set; }

    public DateTime? CreateDate { get; set; }
}
