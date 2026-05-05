using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Duyurular
{
    public int Id { get; set; }

    public int? GonderenId { get; set; }

    public string? Baslik { get; set; }

    public string? Icerik { get; set; }

    public int? Durum { get; set; }

    public int? Banner { get; set; }

    public int? Kayan { get; set; }

    public int? Login { get; set; }

    public int? Siteici { get; set; }

    public DateTime? Tarih { get; set; }

    public string? Resim { get; set; }

    public int? AlanId { get; set; }

    public int? Type { get; set; }
}
