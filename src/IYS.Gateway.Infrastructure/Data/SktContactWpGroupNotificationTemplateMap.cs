using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SktContactWpGroupNotificationTemplateMap
{
    public int Id { get; set; }

    public int SktContactInfoId { get; set; }

    public string WpGroupId { get; set; } = null!;

    public int NotificationTemplateId { get; set; }

    public bool IsActive { get; set; }

    public virtual NotificationTemplates NotificationTemplate { get; set; } = null!;

    public virtual SktContactInfos SktContactInfo { get; set; } = null!;
}
