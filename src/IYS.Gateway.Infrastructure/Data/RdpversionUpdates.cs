using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdpversionUpdates
{
    public int Id { get; set; }

    public Guid? VersionGuid { get; set; }

    public string? Version { get; set; }

    public string? TestVersion { get; set; }

    public string? Url { get; set; }

    public string? TestUrl { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool IsProduction { get; set; }
}
