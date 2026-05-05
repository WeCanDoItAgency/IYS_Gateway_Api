using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UsrBrowsers
{
    public int Id { get; set; }

    public int UsrId { get; set; }

    public DateTime LoginDate { get; set; }

    public DateTime? LogoutDate { get; set; }

    public string? IpAddr { get; set; }

    public string? BrowserType { get; set; }

    public string? BrowserName { get; set; }

    public string? PlatForm { get; set; }

    public bool IsmobileDevice { get; set; }

    public bool IsOffline { get; set; }
}
