using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RoleWidgetSettings
{
    public int Id { get; set; }

    public int UserRoleId { get; set; }

    public string WidgetKey { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }
}
