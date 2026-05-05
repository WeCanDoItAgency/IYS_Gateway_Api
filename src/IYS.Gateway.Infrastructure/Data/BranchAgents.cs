using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BranchAgents
{
    public int Id { get; set; }

    public int? BranchId { get; set; }

    public int? InsuranceId { get; set; }

    public string? AgentCode { get; set; }

    public string? AgentUsr { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool? IsActive { get; set; }
}
