using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimBranslar
{
    public int Id { get; set; }

    public int SigortaId { get; set; }

    public string? Brans { get; set; }

    public int QueryId { get; set; }

    public string? Name { get; set; }

    public bool IsDefault { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }
}
