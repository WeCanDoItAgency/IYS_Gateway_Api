using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CampaignMessages
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? CampaignId { get; set; }

    public int? MessageType { get; set; }

    public string? MessageText { get; set; }

    public string? Name { get; set; }

    public int? QueryTypeId { get; set; }

    public int? DiscountType { get; set; }

    public int? CallCenterStatus { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public int? FirmNsid { get; set; }

    public bool? IsSurvey { get; set; }

    public bool? UisActive { get; set; }

    public string? UmessageText { get; set; }

    public int? UfirmNsid { get; set; }

    public int? NotificationFirmNsid { get; set; }

    public string? NotificationMessageText { get; set; }

    public bool? NotificationIsActive { get; set; }

    public string? WhatsAppMessageText { get; set; }

    public bool? WhatsAppIsActive { get; set; }

    public bool? WhatsAppSendPolicyInfo { get; set; }

    public int? WhatsAppSmsQrId { get; set; }

    public string? WhatsAppTemplateId { get; set; }

    public virtual Campaigns? Campaign { get; set; }

    public virtual CampaignRefundTypes? DiscountTypeNavigation { get; set; }

    public virtual NewQueryTypes? QueryType { get; set; }
}
