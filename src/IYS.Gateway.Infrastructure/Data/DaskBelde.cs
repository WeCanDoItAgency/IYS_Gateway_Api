using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class DaskBelde
{
    public int Id { get; set; }

    public string Il { get; set; } = null!;

    public string Ilce { get; set; } = null!;

    public string Belde { get; set; } = null!;

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public Guid Guid { get; set; }
}
