using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TcTelefonSorgulama
{
    public int Id { get; set; }

    public string? NationalNumber { get; set; }

    public string? Telefon { get; set; }

    public DateTime? SorguTarihi { get; set; }
}
