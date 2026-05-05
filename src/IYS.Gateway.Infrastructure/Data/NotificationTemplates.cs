using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NotificationTemplates
{
    public int Id { get; set; }

    public int NotificationTypeId { get; set; }

    public int? FirmId { get; set; }

    public int? SktId { get; set; }

    public int? QueryTypeId { get; set; }

    public string? Logo { get; set; }

    public string? NotificationTitle { get; set; }

    public string? NotificationContent { get; set; }

    public string? SmsContent { get; set; }

    public string? MailSubject { get; set; }

    public string? MailContent { get; set; }

    public string? WhatsAppContent { get; set; }

    public bool? SendNotification { get; set; }

    public bool? SendSms { get; set; }

    public bool? SendEmail { get; set; }

    public bool? SendWhatsApp { get; set; }

    public int? WhatsAppSmsQrId { get; set; }

    public bool? IsActive { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? WhatsAppMessageTemplatesMongoId { get; set; }

    public virtual NotificationTypes NotificationType { get; set; } = null!;

    public virtual ICollection<SktContactWpGroupNotificationTemplateMap> SktContactWpGroupNotificationTemplateMap { get; set; } = new List<SktContactWpGroupNotificationTemplateMap>();
}
