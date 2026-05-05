using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AiFaqSearchLogs
{
    public int Id { get; set; }

    public Guid UserGuid { get; set; }

    public Guid FirmGuid { get; set; }

    public Guid SktGuid { get; set; }

    public string? SearchTerm { get; set; }

    public string? IpAddress { get; set; }

    public string? Browser { get; set; }

    public string? OperatingSystem { get; set; }

    public string? SourceUrl { get; set; }

    public DateTime ActionDate { get; set; }
}
