using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class EmailQueues
{
    public long Id { get; set; }

    public string EncryptedId { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? ProcessDate { get; set; }

    public string QueryType { get; set; } = null!;

    public short Status { get; set; }
}
