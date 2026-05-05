using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class GenericVerifyCode
{
    public int Id { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EmailAdress { get; set; }

    public string ReferenceCode { get; set; } = null!;

    public string VerifyCode { get; set; } = null!;

    public bool Verified { get; set; }

    public DateTime? VerifyDate { get; set; }

    public bool IsSent { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public int FirmId { get; set; }

    public string? IpAddress { get; set; }

    public int FromPlace { get; set; }

    public int VerificationCodeTypeEnum { get; set; }

    public virtual Kullanicilar? CreatedUser { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;
}
