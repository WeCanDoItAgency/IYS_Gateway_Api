using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdpPartajBranchAuths
{
    public int Id { get; set; }

    public int? RdpPartajId { get; set; }

    public int? BranchId { get; set; }

    public bool? IsAuth { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public virtual Subeler? Branch { get; set; }

    public virtual RdpBrandPartajs? RdpPartaj { get; set; }
}
