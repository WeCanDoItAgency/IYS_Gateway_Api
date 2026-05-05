using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SmsBotQrSsLogs
{
    public int Id { get; set; }

    public int SmsQrBotSsId { get; set; }

    public string? AndroidId { get; set; }

    public int? BatteryLevel { get; set; }

    public string? Board { get; set; }

    public string? Brand { get; set; }

    public string? CpuAbI { get; set; }

    public string? Hardware { get; set; }

    public string? IpAddress { get; set; }

    public string? Locale { get; set; }

    public string? Manufacturer { get; set; }

    public string? Model { get; set; }

    public string? NetworkType { get; set; }

    public string? Release { get; set; }

    public int? SdkInt { get; set; }

    public string? SsId { get; set; }

    public string? TimeZone { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual SmsbotQrSs SmsQrBotSs { get; set; } = null!;
}
