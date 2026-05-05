using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class VsignProcess
{
    public long Id { get; set; }

    public int OdemeId { get; set; }

    public int BaslikId { get; set; }

    public int DetayId { get; set; }

    public int SigortaId { get; set; }

    public string TypeCode { get; set; } = null!;

    public int ProcessTypeId { get; set; }

    public int UserId { get; set; }

    public string? FileName { get; set; }

    public bool IsSigning { get; set; }

    public bool IsClosed { get; set; }

    public int NumberOfWork { get; set; }

    public string? OutFileName { get; set; }

    public bool IsVirtualSigning { get; set; }

    public DateTime? CreateDate { get; set; }
}
