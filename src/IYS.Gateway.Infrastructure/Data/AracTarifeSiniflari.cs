using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AracTarifeSiniflari
{
    public int Id { get; set; }

    public int Spid { get; set; }

    public int Code { get; set; }

    public string TarifeAdi { get; set; } = null!;
}
