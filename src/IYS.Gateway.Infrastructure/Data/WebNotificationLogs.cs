using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class WebNotificationLogs
{
    public int Id { get; set; }

    public int? SenderUserId { get; set; }

    public int? ReceivedUserId { get; set; }

    public int? NotificationId { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? SeenDateTime { get; set; }

    public int? NotificationType { get; set; }

    public string? SmsReceivedCode { get; set; }
}
