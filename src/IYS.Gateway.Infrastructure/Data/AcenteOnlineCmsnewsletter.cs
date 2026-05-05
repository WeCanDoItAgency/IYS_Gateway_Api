using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteOnlineCmsnewsletter
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? IpAddress { get; set; }

    public string? BrowserAgent { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsCancel { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? SiteId { get; set; }

    public int? SktId { get; set; }

    public int? FirmId { get; set; }
}
