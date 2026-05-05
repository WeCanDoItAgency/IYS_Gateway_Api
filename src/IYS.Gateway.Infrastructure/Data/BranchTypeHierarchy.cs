using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BranchTypeHierarchy
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public int? ChildId { get; set; }

    public bool? IsActive { get; set; }
}
