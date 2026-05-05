using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewSmsSettings
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Originator { get; set; }
}
