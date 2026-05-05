using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimLogsOld
{
    public int Id { get; set; }

    public int SigortaId { get; set; }

    public string? AlertCode { get; set; }

    public string? AlertText { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime CreateDate { get; set; }

    public int? JobId { get; set; }

    public bool IsException { get; set; }

    public bool IsActive { get; set; }

    public virtual UretimPolicyCount? Job { get; set; }
}
