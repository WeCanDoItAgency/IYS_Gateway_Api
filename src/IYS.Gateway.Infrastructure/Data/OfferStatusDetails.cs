using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class OfferStatusDetails
{
    public long Id { get; set; }

    public string QueryType { get; set; } = null!;

    public int HeaderId { get; set; }

    public int DetailId { get; set; }

    public short Status { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}
