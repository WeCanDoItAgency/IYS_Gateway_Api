using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewAccountancyPlannings
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string? Code { get; set; }

    public string? WholeCode { get; set; }

    public string? Name { get; set; }

    public bool IsDefinition { get; set; }

    public bool? IsDefinitionFirm { get; set; }

    public int? AccountTypeId { get; set; }

    public int? FirmId { get; set; }

    public int? SubeId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual NewAccountPlanAccountTypes? AccountType { get; set; }

    public virtual ICollection<BranchTypes> BranchTypes { get; set; } = new List<BranchTypes>();

    public virtual ICollection<NewAccountancyPlannings> InverseParent { get; set; } = new List<NewAccountancyPlannings>();

    public virtual NewAccountancyPlannings? Parent { get; set; }

    public virtual Subeler? Sube { get; set; }
}
