using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BranchQuerytypeAuth
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? QueryTypeId { get; set; }

    public bool? IsAuth { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? SktRequestId { get; set; }

    public virtual Subeler? Branch { get; set; }

    public virtual NewFirms? Firm { get; set; }

    public virtual NewQueryTypes? QueryType { get; set; }
}
