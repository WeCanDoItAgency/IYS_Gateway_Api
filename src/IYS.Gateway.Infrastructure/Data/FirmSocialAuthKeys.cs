using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FirmSocialAuthKeys
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public bool IsActive { get; set; }

    public string? SecretKey { get; set; }

    public string? ApiKey { get; set; }

    public int AuthType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public int? SmsQrId { get; set; }

    public string? Token { get; set; }
}
