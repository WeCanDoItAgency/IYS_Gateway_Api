using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ProxyCredential
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? SubeId { get; set; }

    public int? FirmId { get; set; }

    public string? ProxyUrl { get; set; }

    public string? ProxyPort { get; set; }

    public string? ProxyUsername { get; set; }

    public string? ProxyPassword { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public int? SigortaId { get; set; }

    public bool? IsSystemProxy { get; set; }

    public bool? IsActive { get; set; }
}
