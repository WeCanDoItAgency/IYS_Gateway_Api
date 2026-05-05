using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrowserFiles
{
    public int Id { get; set; }

    public int KuserId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? Extention { get; set; }

    public byte[]? Basefile { get; set; }

    public string? IpAddress { get; set; }
}
