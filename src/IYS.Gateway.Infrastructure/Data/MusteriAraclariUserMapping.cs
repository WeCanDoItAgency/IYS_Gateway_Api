using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MusteriAraclariUserMapping
{
    public int Id { get; set; }

    public Guid MusteriAraclariGuid { get; set; }

    public int UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual MusteriAraclari MusteriAraclari { get; set; } = null!;

    public virtual Kullanicilar User { get; set; } = null!;
}
