using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SignatureLogs
{
    public int Id { get; set; }

    public long ImzaId { get; set; }

    public int OdemeId { get; set; }

    public int BaslikId { get; set; }

    public int DetayId { get; set; }

    public int SigortaId { get; set; }

    public string TypeCode { get; set; } = null!;

    public string? AlertText { get; set; }

    public short Status { get; set; }

    public string? OutFileName { get; set; }

    public DateTime Cdate { get; set; }

    public int UserId { get; set; }

    public bool IsError { get; set; }
}
