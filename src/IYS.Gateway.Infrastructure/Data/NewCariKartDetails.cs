using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewCariKartDetails
{
    public int Id { get; set; }

    public int CariId { get; set; }

    public bool IsPortal { get; set; }

    public int? IslemTipi { get; set; }

    public int? SigortaId { get; set; }

    public int? BransId { get; set; }

    public int? TakipNo { get; set; }

    public string? PoliceNo { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public int FirmId { get; set; }

    public int SubeId { get; set; }

    public int UserKod { get; set; }

    public int OwnFirmId { get; set; }

    public double? BrutTutar { get; set; }

    /// <summary>
    /// acente komisyon
    /// </summary>
    public double? AkomTutar { get; set; }

    /// <summary>
    /// sube komisyon
    /// </summary>
    public double? SkomTutar { get; set; }
}
