using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FirmVisibleAuths
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public string? QueryType { get; set; }

    public bool? ShowPrice { get; set; }

    public bool? ShowCertificate { get; set; }

    public bool? ShowPolicy { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }
}
