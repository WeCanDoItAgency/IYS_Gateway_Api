using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class EimzaLogs
{
    public int Id { get; set; }

    public int OdemeId { get; set; }

    public int BaslikId { get; set; }

    public int DetayId { get; set; }

    public int SigortaId { get; set; }

    public string TypCode { get; set; } = null!;

    public string? AlertText { get; set; }

    public short Status { get; set; }

    public string? Outgoing { get; set; }

    public DateTime CreateDate { get; set; }

    public int KuserId { get; set; }
}
