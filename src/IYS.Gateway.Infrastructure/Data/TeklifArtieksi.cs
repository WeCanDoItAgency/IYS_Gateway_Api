using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TeklifArtieksi
{
    public int Id { get; set; }

    public int TeklifId { get; set; }

    public int HesapId { get; set; }

    public string? Ad { get; set; }

    public string? ArtiEksi { get; set; }

    public string? Kod { get; set; }

    public double? Oran { get; set; }
}
