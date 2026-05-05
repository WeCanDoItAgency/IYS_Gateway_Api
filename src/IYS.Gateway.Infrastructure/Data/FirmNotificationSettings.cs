using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FirmNotificationSettings
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public string? Baslik { get; set; }

    public string? TokenKey { get; set; }

    public int? SettingType { get; set; }

    public string? Description { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? CaprazFromEmailAddress { get; set; }

    public string? CaprazSenderName { get; set; }

    public string? CaprazDomainName { get; set; }

    public string? DuyuruFromEmailAddress { get; set; }

    public string? DuyuruSenderName { get; set; }

    public string? DuyuruDomainName { get; set; }

    public int? FromPlace { get; set; }

    public bool? WhatsappGonderilsinMi { get; set; }

    public int? SmsQrId { get; set; }

    public int? OtpWpType { get; set; }
}
