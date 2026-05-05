using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AiUserWhatsAppGlobalPreferences
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? AllowedPhones { get; set; }

    public bool GlobalWhatsAppNotificationsEnabled { get; set; }

    public virtual Kullanicilar User { get; set; } = null!;
}
