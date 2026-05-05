using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MfaverificationCodesOut
{
    public int Id { get; set; }

    public string VerificationCode { get; set; } = null!;

    public string Firm { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public bool? IsUsed { get; set; }

    public int? BotId { get; set; }

    public int? FirmId { get; set; }

    public int? ForSktId { get; set; }

    public int? ForUserId { get; set; }

    public int? CreatedUserId { get; set; }

    public int? RdpPartajId { get; set; }
}
