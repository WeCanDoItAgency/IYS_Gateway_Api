using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewMailSettings
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public string? MailAddress { get; set; }

    public string? MailPassword { get; set; }

    public string? Host { get; set; }

    public int? Port { get; set; }

    public bool? EnableSsl { get; set; }
}
