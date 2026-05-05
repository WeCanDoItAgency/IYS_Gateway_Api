using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SktPaketDegisiklikLoglari
{
    public int Id { get; set; }

    public int? SktId { get; set; }

    public int? GroupId { get; set; }

    public int? AttributeId { get; set; }

    public int? OldValueId { get; set; }

    public int? ValueId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }
}
