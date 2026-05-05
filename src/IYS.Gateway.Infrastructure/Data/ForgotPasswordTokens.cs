using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ForgotPasswordTokens
{
    public int Id { get; set; }

    public string Token { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ExpiredDate { get; set; }

    public DateTime? UsedDate { get; set; }

    public bool IsUsed { get; set; }

    public string IpAddress { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public int UserId { get; set; }

    public virtual Kullanicilar User { get; set; } = null!;
}
