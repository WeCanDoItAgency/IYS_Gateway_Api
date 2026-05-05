using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterEvaluationResults
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? DepartmentId { get; set; }

    public string? CallId { get; set; }

    public int? ExpertiseRequestId { get; set; }

    public int? CallRequestId { get; set; }

    public int? CriteryMappingId { get; set; }

    public int? CriteriaId { get; set; }

    public int? UserId { get; set; }

    public int? EvaluatedUserId { get; set; }

    public int? Score { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Subeler? Branch { get; set; }

    public virtual CallCenterEvaluationCriteries? CriteryMapping { get; set; }

    public virtual NewFirms? Firm { get; set; }

    public virtual Kullanicilar? User { get; set; }
}
