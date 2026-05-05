using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BaslikAracInfo
{
    public int Id { get; set; }

    public bool? IsActive { get; set; }

    public int? BaslikId { get; set; }

    public string? Plaka { get; set; }

    public string? Phone { get; set; }

    public int? FirmId { get; set; }

    public string? Source { get; set; }

    public string? ExpertiseGuid { get; set; }

    public string? MotorNo { get; set; }

    public string? SasiNo { get; set; }

    public string? BelgeSeri { get; set; }

    public string? TcKimlik { get; set; }

    public string? MarkaKodu { get; set; }

    public string? ModelKodu { get; set; }

    public string? MarkaModelFull { get; set; }

    public string? QueryType { get; set; }

    public string? OncekiSirketKodu { get; set; }

    public string? OncekiAcenteNo { get; set; }

    public string? OncekiYenilemeNo { get; set; }

    public string? OncekiPoliceNo { get; set; }

    public DateTime? OpoliceBaslangic { get; set; }

    public DateTime? OpoliceBitis { get; set; }

    public DateTime? FutureCallDate { get; set; }

    public string? Note { get; set; }

    public string? KoncekiSirketKodu { get; set; }

    public string? KoncekiAcenteNo { get; set; }

    public string? KoncekiYenilemeNo { get; set; }

    public string? KoncekiPoliceNo { get; set; }

    public DateTime? KopoliceBaslangic { get; set; }

    public DateTime? KopoliceBitis { get; set; }

    public bool? KoncekiPoliceIptal { get; set; }

    public string? ToncekiSirketKodu { get; set; }

    public string? ToncekiAcenteNo { get; set; }

    public string? ToncekiYenilemeNo { get; set; }

    public string? ToncekiPoliceNo { get; set; }

    public DateTime? TopoliceBaslangic { get; set; }

    public DateTime? TopoliceBitis { get; set; }

    public bool? ToncekiPoliceIptal { get; set; }

    public int? ProcessStatus { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? ThasarSayisi { get; set; }

    public string? KhasarSayisi { get; set; }

    public string? ThasarsizlikKademesi { get; set; }

    public string? KhasarsizlikKademesi { get; set; }

    public int? ModelYili { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public decimal? AracBedeli { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public Guid? HeaderGuid { get; set; }
}
