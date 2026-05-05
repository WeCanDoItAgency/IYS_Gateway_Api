using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TypeCodes
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public int AgentId { get; set; }

    public int CodeId { get; set; }

    public int? ParentId { get; set; }

    public string? NameValue { get; set; }
}
