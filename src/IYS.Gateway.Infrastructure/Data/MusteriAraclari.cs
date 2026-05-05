using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MusteriAraclari
{
    public Guid Guid { get; set; }

    public int? MarkaId { get; set; }

    public int? ModelId { get; set; }

    public string? MarkaKodu { get; set; }

    public string? ModelKodu { get; set; }

    public decimal? AracBedeli { get; set; }

    public int? Renk { get; set; }

    public string? ImageUrl { get; set; }

    public int? AracTipi { get; set; }

    public string? AracPlaka { get; set; }

    public string? AracRuhsat { get; set; }

    public string? MusteriVknNo { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public double? Radyoteyp { get; set; }

    public double? Navigasyon { get; set; }

    public double? Celikjant { get; set; }

    public double? Televizyon { get; set; }

    public double? Lpg { get; set; }

    public double? Digeraksesuar { get; set; }

    public string? DigerAksesuarAciklama { get; set; }

    public bool? IsAksesuar { get; set; }

    public bool? IsActive { get; set; }

    public int? ModelYili { get; set; }

    public bool? Engelli { get; set; }

    public string? DainiMurtehin { get; set; }

    public int? Banka { get; set; }

    public int? BankaSube { get; set; }

    public int? FinansKurumu { get; set; }

    public bool? OrjinalLpg { get; set; }

    public byte Type { get; set; }

    public string? MotorNo { get; set; }

    public string? SasiNo { get; set; }

    public bool? IsSold { get; set; }

    public int? KoltukSayisi { get; set; }

    public int? AracKullanimSekli { get; set; }

    public int? YakitTipi { get; set; }

    public DateTime? TrafikCikisTarihi { get; set; }

    public DateTime? TrafikTescilTarihi { get; set; }

    public int? CascoVehicleType { get; set; }

    public int? TrafficVehicleType { get; set; }

    public string? IsSoldIptalNedeni { get; set; }

    public DateTime? IsSoldIptalTarihi { get; set; }

    public virtual ICollection<MusteriAraclariMuayeneHistory> MusteriAraclariMuayeneHistory { get; set; } = new List<MusteriAraclariMuayeneHistory>();

    public virtual ICollection<MusteriAraclariUserMapping> MusteriAraclariUserMapping { get; set; } = new List<MusteriAraclariUserMapping>();
}
