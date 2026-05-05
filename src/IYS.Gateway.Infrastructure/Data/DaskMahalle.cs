using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class DaskMahalle
{
    public int Id { get; set; }

    public long BeldeId { get; set; }

    public string? Adi { get; set; }
}
