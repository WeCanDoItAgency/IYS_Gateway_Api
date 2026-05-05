using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AnlasmaliServislerDirectionLog
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int AnlasmaliKurumId { get; set; }

    public string? IpAddress { get; set; }

    public string? BrowserAgent { get; set; }

    public virtual AnlasmaliKurumlar AnlasmaliKurum { get; set; } = null!;

    public virtual Kullanicilar? User { get; set; }
}
