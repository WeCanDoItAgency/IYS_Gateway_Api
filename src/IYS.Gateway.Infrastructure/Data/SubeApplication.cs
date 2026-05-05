using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SubeApplication
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public string? AdSoyad { get; set; }

    public string? TicariUnvan { get; set; }

    public bool? IsSube { get; set; }

    public string? SubeAdi { get; set; }

    public string? AcenteAdi { get; set; }

    public string? PersonelAdsoyad { get; set; }

    public string? PersonelEgitim { get; set; }

    public string? PersonelTelefon { get; set; }

    public string? Email { get; set; }

    public string? CompanyTelefon { get; set; }

    public string? Adres { get; set; }

    public string? Gms { get; set; }

    public string? Fax { get; set; }

    public string? Subeil { get; set; }

    public string? Subeilce { get; set; }

    public string? ReferansTelefon { get; set; }

    public string? ReferansFax { get; set; }

    public string? Notlar { get; set; }

    public bool? AdvertisementAgreement { get; set; }

    public bool? PrivacyAgreement { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateUserId { get; set; }
}
