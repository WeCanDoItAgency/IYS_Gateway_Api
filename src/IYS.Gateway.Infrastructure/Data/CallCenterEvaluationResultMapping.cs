using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterEvaluationResultMapping
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? DepartmentId { get; set; }

    public int? UserId { get; set; }

    public string? CallId { get; set; }

    public int? ExpertiseRequestId { get; set; }

    public int? CallRequestId { get; set; }

    public int? VerimorId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
