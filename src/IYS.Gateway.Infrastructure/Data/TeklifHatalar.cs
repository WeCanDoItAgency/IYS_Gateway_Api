using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TeklifHatalar
{
    public int Id { get; set; }

    public int TeklifId { get; set; }

    public string? HataAdi { get; set; }
}
