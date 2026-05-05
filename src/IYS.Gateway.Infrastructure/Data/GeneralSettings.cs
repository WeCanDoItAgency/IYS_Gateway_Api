using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class GeneralSettings
{
    public int Id { get; set; }

    public string? SettingsName { get; set; }

    public string? SettingsValue { get; set; }
}
