using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SecurePaymentTokenHistories
{
    public int Id { get; set; }

    public string Token { get; set; } = null!;

    public int DetailId { get; set; }

    public string QueryType { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public short Status { get; set; }

    public string FirmToken { get; set; } = null!;
}
