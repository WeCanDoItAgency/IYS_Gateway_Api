using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UniversiteBolum
{
    public int BolumId { get; set; }

    public int? FakulteId { get; set; }

    public int? UniversiteId { get; set; }

    public string? Name { get; set; }

    public byte Status { get; set; }
}
