using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CenterWaitingModifiedAttributeValues
{
    public int Id { get; set; }

    public int? AttributeId { get; set; }

    public int? ValueId { get; set; }

    public int? CreatedUserId { get; set; }

    public int? CenterWaitingId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? EncrytedDetailId { get; set; }

    public string? QueryType { get; set; }

    public Guid? DetailGuid { get; set; }

    public virtual MerkezTalepler? CenterWaiting { get; set; }
}
