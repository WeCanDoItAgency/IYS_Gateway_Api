using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmsmobileBackground
{
    public int Id { get; set; }

    public int Type { get; set; }

    public int Location { get; set; }

    public string? VideoPath { get; set; }

    public int? SiteId { get; set; }

    public int? FirmId { get; set; }

    public int? SktId { get; set; }

    public bool? IsActive { get; set; }
}
