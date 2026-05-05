using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SmsbotQrSs
{
    public int Id { get; set; }

    public string? BotName { get; set; }

    public string? LastQrSs { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? Phone { get; set; }

    public string? Inv { get; set; }

    public string? AccessToken { get; set; }

    public string? Source { get; set; }

    public int? FromPlace { get; set; }

    public int? FirmId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? Status { get; set; }

    public string? NewRdpPartajAccessToken { get; set; }

    public int? SmsQrType { get; set; }

    public string? ApiKey { get; set; }

    public string? PhoneNumberId { get; set; }

    public string? FaceAccesToken { get; set; }

    public string? WelcomeMessage { get; set; }

    public string? AppSecret { get; set; }

    public string? AppId { get; set; }

    public string? AccountId { get; set; }

    public int? ReplyType { get; set; }

    public bool? IsCanUseWithWebsiteToken { get; set; }

    public bool? EnablePreventionMode { get; set; }

    public bool? OnlyReplyInGroupMention { get; set; }

    public Guid SmsQrGuid { get; set; }

    public bool? IsActive { get; set; }

    public int? OperationStatus { get; set; }

    public string? RedirectPhoneNumber { get; set; }

    public int? PhoneType { get; set; }

    public bool? WpOtomatikIptalTalebiMesajiGonderilsinMi { get; set; }

    public bool? WpOtomatikIptalTalebiCalissinMi { get; set; }

    public bool? WpOtomatikTeklifCalissinMi { get; set; }

    public bool? WpOtomatikTeklifMesajiGonderilsinMi { get; set; }

    public bool? WpOtomatikIptalTalebiOtomatikSistemeGonderilsinMi { get; set; }

    public virtual ICollection<AutoWhatsAppMessageInfo> AutoWhatsAppMessageInfo { get; set; } = new List<AutoWhatsAppMessageInfo>();

    public virtual ICollection<RdpBrandPartajs> RdpBrandPartajs { get; set; } = new List<RdpBrandPartajs>();

    public virtual ICollection<SmsBotQrSsLogs> SmsBotQrSsLogs { get; set; } = new List<SmsBotQrSsLogs>();
}
