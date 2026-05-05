using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BusinessRulesLog
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? PhoneNumber { get; set; }

    public string? IdentityNumber { get; set; }

    public int? IdentityNumberType { get; set; }

    public string? Email { get; set; }

    public string? IpAddress { get; set; }

    public string? QueryType { get; set; }

    public int? EntityId { get; set; }

    public Guid? HeaderGuid { get; set; }

    public int? ExpertiseStatusLogId { get; set; }

    public int? BusinessRuleId { get; set; }

    public int? FirmId { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int CountOfAttempts { get; set; }

    public virtual BusinessRules? BusinessRule { get; set; }

    public virtual ICollection<BusinessRulesAttempts> BusinessRulesAttempts { get; set; } = new List<BusinessRulesAttempts>();
}
