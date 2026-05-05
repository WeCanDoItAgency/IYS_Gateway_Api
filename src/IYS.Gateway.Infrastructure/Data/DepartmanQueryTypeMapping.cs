using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class DepartmanQueryTypeMapping
{
    public int Id { get; set; }

    public int? DepartmanId { get; set; }

    public int? QueryTypeId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Departments? Departman { get; set; }

    public virtual NewQueryTypes? QueryType { get; set; }
}
