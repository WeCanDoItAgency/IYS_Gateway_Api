using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Sorgular
{
    public int Id { get; set; }

    public int Sigortaid { get; set; }

    public string Sigortatanim { get; set; } = null!;

    public string Sigortatip { get; set; } = null!;

    public string Islem { get; set; } = null!;

    public DateTime Tarih { get; set; }

    public decimal Tutar { get; set; }

    public int Durum { get; set; }

    public string Tcvergino { get; set; } = null!;

    public string Plaka { get; set; } = null!;

    public string Ruhsat { get; set; } = null!;

    public string? Hatamesaj { get; set; }

    public string? Inputdata { get; set; }

    public string? Outputdata { get; set; }

    public string? Inputdatatype { get; set; }

    public string? Outputdatatype { get; set; }
}
