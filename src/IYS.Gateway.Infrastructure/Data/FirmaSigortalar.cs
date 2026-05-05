using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FirmaSigortalar
{
    public int Id { get; set; }

    public int FirmaId { get; set; }

    public int SigortaId { get; set; }

    public string? Adi { get; set; }

    public int SigortaKodu { get; set; }
}
