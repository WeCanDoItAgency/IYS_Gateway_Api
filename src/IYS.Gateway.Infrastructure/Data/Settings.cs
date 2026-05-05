using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Settings
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? IpAddress { get; set; }

    public int? PortId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? FileAbsolutePath { get; set; }
}
