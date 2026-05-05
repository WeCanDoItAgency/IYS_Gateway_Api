using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MusteriAraclariMuayeneHistory
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime MuayeneTarihi { get; set; }

    public Guid MusteriAraclariGuid { get; set; }

    public virtual MusteriAraclari MusteriAraclari { get; set; } = null!;
}
