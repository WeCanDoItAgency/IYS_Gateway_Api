using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class IncomingUlkeler
{
    public int Id { get; set; }

    public string? UlkeKodu { get; set; }

    public string? UlkeAdi { get; set; }

    public string? KisaKod { get; set; }

    public string? MrzKod { get; set; }
}
