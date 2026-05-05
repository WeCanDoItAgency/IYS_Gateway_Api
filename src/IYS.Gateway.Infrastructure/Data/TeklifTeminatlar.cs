using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TeklifTeminatlar
{
    public int Id { get; set; }

    public int TeklifId { get; set; }

    public string? Kod { get; set; }

    public string? TeminatAdi { get; set; }

    public double? Bedel { get; set; }

    public double? Fiyat { get; set; }

    public double? HesaplananPrim { get; set; }

    public double? Prim { get; set; }

    public double? KullaniciPrim { get; set; }
}
