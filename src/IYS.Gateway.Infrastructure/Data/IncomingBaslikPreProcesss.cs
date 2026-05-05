using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class IncomingBaslikPreProcesss
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? PasaportNo { get; set; }

    public string? Adi { get; set; }

    public string? Soyadi { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? Cinsiyet { get; set; }

    public string? AlanKodu { get; set; }

    public string? Telefon { get; set; }

    public string? UlkeKodu { get; set; }

    public DateTime? PoliceBaslangic { get; set; }

    public bool IsPolice { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? PoliceBitis { get; set; }

    public int? SigortaId { get; set; }

    public string? PoliceNo { get; set; }

    public string? TckimlikNo { get; set; }

    public string? BabaAdi { get; set; }

    public string? AnneAdi { get; set; }

    public bool? FromCredit { get; set; }

    public string? HolderName { get; set; }

    public string? HolderSurname { get; set; }

    public string? CardNumber { get; set; }

    public string? CardCvc { get; set; }

    public string? CardMonth { get; set; }

    public string? CardYear { get; set; }

    public int? Status { get; set; }

    public string? SessionToken { get; set; }

    public string? SessionUserId { get; set; }

    public int? TakipNo { get; set; }

    public int? DetayNo { get; set; }

    public string? Mesaj { get; set; }

    public double? Tutar { get; set; }

    public string? VatandaslikUlke { get; set; }

    public int PsureId { get; set; }
}
