using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AppUpdates
{
    public int Id { get; set; }

    public string? ApplicationName { get; set; }

    public string? FileName { get; set; }

    public string? FileType { get; set; }

    public string? Version { get; set; }

    public byte[]? FileUpLoad { get; set; }
}
