using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AracKartlarHistory
{
    public long Id { get; set; }

    public int FirmId { get; set; }

    public int SubeId { get; set; }

    public string? Plaka { get; set; }

    public string? RuhsatNo { get; set; }

    public string? AsbisNo { get; set; }

    public string? MarkaKodu { get; set; }

    public int? ModelYili { get; set; }

    public string? MotorNo { get; set; }

    public string? SasiNo { get; set; }

    public DateTime? TrafikCikisTarihi { get; set; }

    public DateTime? TrafikTescilTarihi { get; set; }

    public string? AracTarzKodu { get; set; }

    public string? TarifeKodu { get; set; }

    public string? KullanimSekliKodu { get; set; }

    public int? YakitTipi { get; set; }

    public int? GarajTipi { get; set; }

    public string? RenkKodu { get; set; }

    public string? KoltukSayisi { get; set; }

    public int? MarkaId { get; set; }

    public string? ModelKodu { get; set; }

    public decimal? AracBedeli { get; set; }

    public double? Radyoteyp { get; set; }

    public double? Navigasyon { get; set; }

    public double? Celikjant { get; set; }

    public double? Televizyon { get; set; }

    public double? Digeraksesuar { get; set; }

    public int? AracAltTip { get; set; }

    public bool? IsYk { get; set; }

    public bool? IsAksesuar { get; set; }

    public double? Lpg { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual Subeler Sube { get; set; } = null!;
}
