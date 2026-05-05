using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterEvaluationCriteries
{
    public int Id { get; set; }

    public string? QualityCriterion { get; set; }

    public int? ExpectedScore { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUser { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUser { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<CallCenterEvaluationResults> CallCenterEvaluationResults { get; set; } = new List<CallCenterEvaluationResults>();
}
