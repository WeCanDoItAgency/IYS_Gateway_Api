using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class VwMerkezTeklif
{
    public int Id { get; set; }

    public int BaslikId { get; set; }

    public int SigortaId { get; set; }

    public bool IsTalep { get; set; }

    public DateTime? SorguTarihi { get; set; }
}
