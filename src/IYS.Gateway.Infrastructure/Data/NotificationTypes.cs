using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NotificationTypes
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public string? Description { get; set; }

    public bool DependedQueryType { get; set; }

    public bool? IsActive { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<NotificationParameters> NotificationParameters { get; set; } = new List<NotificationParameters>();

    public virtual ICollection<NotificationTemplates> NotificationTemplates { get; set; } = new List<NotificationTemplates>();
}
