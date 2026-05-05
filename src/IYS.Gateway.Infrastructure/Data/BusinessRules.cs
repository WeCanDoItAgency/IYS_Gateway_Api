using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BusinessRules
{
    public int Id { get; set; }

    public string RuleName { get; set; } = null!;

    public string? Description { get; set; }

    public int? FromWhere { get; set; }

    public bool IsActive { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? FirmId { get; set; }

    public bool? IsByQueryTypeRule { get; set; }

    public virtual ICollection<BusinessRulesLog> BusinessRulesLog { get; set; } = new List<BusinessRulesLog>();
}
