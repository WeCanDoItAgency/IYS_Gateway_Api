using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Teminatparams
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public int SigortaId { get; set; }

    public string? Code { get; set; }

    public int? Kademe { get; set; }

    public string? Aciklama { get; set; }
}
