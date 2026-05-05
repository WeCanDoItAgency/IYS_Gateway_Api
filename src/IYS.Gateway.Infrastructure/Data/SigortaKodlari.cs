using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SigortaKodlari
{
    public int Id { get; set; }

    public int SigortaId { get; set; }

    public int TypeId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }
}
