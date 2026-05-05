using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class DugunSalonlari
{
    public int Id { get; set; }

    public string? SalonAdi { get; set; }

    public string? Il { get; set; }

    public string? Ilce { get; set; }

    public int? Ilkodu { get; set; }

    public int? Ilcekodu { get; set; }
}
