using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BranchTypeChanges
{
    public int Id { get; set; }

    public int? BranchId { get; set; }

    public int? BranchTypeId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public virtual Subeler? Branch { get; set; }
}
