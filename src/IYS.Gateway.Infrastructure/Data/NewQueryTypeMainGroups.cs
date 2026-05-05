using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewQueryTypeMainGroups
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? DeleteUserId { get; set; }

    public bool? IsActive { get; set; }

    public Guid Guid { get; set; }

    public virtual ICollection<NewQueryTypes> NewQueryTypes { get; set; } = new List<NewQueryTypes>();
}
