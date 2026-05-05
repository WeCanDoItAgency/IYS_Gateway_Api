using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class OdemeRaporuRequest
{
    public int Id { get; set; }

    public string? RequestFile { get; set; }

    public int? SigortaId { get; set; }

    public int? FirmId { get; set; }

    public DateTime? AddedDate { get; set; }

    public int? UserId { get; set; }

    public byte? Status { get; set; }

    public string? SigortaName { get; set; }
}
