using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UserTutorialLogs
{
    public int Id { get; set; }

    public Guid UserGuid { get; set; }

    public Guid FirmGuid { get; set; }

    public Guid SktGuid { get; set; }

    public string? TutorialCode { get; set; }

    public bool IsCompleted { get; set; }

    public int ViewCount { get; set; }

    public string? IpAddress { get; set; }

    public string? Browser { get; set; }

    public string? OperatingSystem { get; set; }

    public string? SourceUrl { get; set; }

    public DateTime? LastViewDate { get; set; }

    public DateTime CreateDate { get; set; }
}
