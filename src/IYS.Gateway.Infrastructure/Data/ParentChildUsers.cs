using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ParentChildUsers
{
    public int Id { get; set; }

    public int ParentUserId { get; set; }

    public int ChildUserId { get; set; }

    public DateTime? CreateDate { get; set; }
}
