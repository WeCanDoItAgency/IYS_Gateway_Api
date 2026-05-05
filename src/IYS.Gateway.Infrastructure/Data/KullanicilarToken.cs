using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class KullanicilarToken
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public string Token { get; set; } = null!;

    public byte TokenType { get; set; }

    public DateTime? ExpiredDate { get; set; }

    public string IpAddress { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public bool? IsActive { get; set; }

    public string? DeviceName { get; set; }

    public string? Platform { get; set; }

    public string? CreatedByToken { get; set; }

    public int FromPlace { get; set; }

    public bool IsSiteToken { get; set; }

    public virtual Kullanicilar User { get; set; } = null!;
}
