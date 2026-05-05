using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NotificationParameters
{
    public int Id { get; set; }

    public string ParameterName { get; set; } = null!;

    public bool? UseInNotification { get; set; }

    public bool? UseInSms { get; set; }

    public bool? UseInEmail { get; set; }

    public bool? UseInWhatsApp { get; set; }

    public int? QueryTypeId { get; set; }

    public bool? IsActive { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int NotificationTypeId { get; set; }

    public virtual NotificationTypes NotificationType { get; set; } = null!;
}
