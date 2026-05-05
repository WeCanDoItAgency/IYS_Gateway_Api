using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CariReports
{
    public int Id { get; set; }

    public DateTime CDate { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public bool IsPortal { get; set; }

    public int IslemTipi { get; set; }

    public int? SigortaId { get; set; }

    public int? BransId { get; set; }

    public int? TakipNo { get; set; }

    public string? PoliceNo { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public int? VadeGun { get; set; }

    public bool IsClosed { get; set; }

    public int? NewId { get; set; }

    public DateTime? NewVadeBaslangic { get; set; }

    public DateTime? NewVadeBitis { get; set; }

    public string? NewPoliceNo { get; set; }

    public int? NewSigortaId { get; set; }

    public string? Notlar { get; set; }

    public int? NotEkleyenId { get; set; }
}
