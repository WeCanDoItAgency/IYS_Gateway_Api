using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class OfferExtraProductMapping
{
    public int Id { get; set; }

    public int MainQueryTypeId { get; set; }

    public Guid? MainDetailGuid { get; set; }

    public int ExtraQueryTypeId { get; set; }

    public Guid? ExtraDetailGuid { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid MainHeaderGuid { get; set; }

    public Guid ExtraHeaderGuid { get; set; }

    public Guid? MainPolicyGuid { get; set; }

    public Guid? ExtraPolicyGuid { get; set; }

    public bool IsRequired { get; set; }
}
