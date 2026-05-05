using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlinePoliceiiptal
{
    public int Id { get; set; }

    public string? MusteriTcknVkn { get; set; }

    public string? PoliceTuru { get; set; }

    public int? FirmaId { get; set; }

    public string? PoliceFile { get; set; }

    public int? CreateUser { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool? IsActive { get; set; }

    public string? Plaka { get; set; }

    public string? PolicyNo { get; set; }

    public string? Notes { get; set; }
}
