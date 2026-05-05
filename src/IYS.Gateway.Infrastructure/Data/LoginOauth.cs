using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class LoginOauth
{
    public int Id { get; set; }

    public string Guid { get; set; } = null!;

    public int UserId { get; set; }

    public bool IsUsed { get; set; }

    public DateTime CreateDatetime { get; set; }

    public DateTime? UsedDatetime { get; set; }
}
