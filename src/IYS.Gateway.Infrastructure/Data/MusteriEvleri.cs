using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MusteriEvleri
{
    public Guid Guid { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? MusteriVknNo { get; set; }

    public string? UavtKodu { get; set; }

    public int? IlKodu { get; set; }

    public int? IlceKodu { get; set; }

    public int? BeldeKodu { get; set; }

    public int? MahalleKodu { get; set; }

    public int? SokakKodu { get; set; }

    public int? BinaNo { get; set; }

    public string? Ada { get; set; }

    public string? SayfaNo { get; set; }

    public string? Pafta { get; set; }

    public string? BagimsizBolum { get; set; }

    public string? Parsel { get; set; }

    public int? BrutYuzOlcum { get; set; }

    public int? InsaaTarzi { get; set; }

    public int? KullanimSekli { get; set; }

    public int? ToplamKat { get; set; }

    public int? InsaatYili { get; set; }

    public int? BulunduguKat { get; set; }

    public int? OncekiHasar { get; set; }

    public string? DainiMurtehin { get; set; }

    public string? BankaKodu { get; set; }

    public string? BsubeKodu { get; set; }

    public string? FinansKurumu { get; set; }

    public string? VergiDairesi { get; set; }

    public int? Type { get; set; }

    public bool? IsActive { get; set; }

    public string? TeminatBina { get; set; }

    public string? TeminatEsya { get; set; }

    public string? TeminatCam { get; set; }

    public string? TeminatDekorasyon { get; set; }

    public bool? EvBosKaliyorMu { get; set; }

    public bool? IsOwner { get; set; }
}
