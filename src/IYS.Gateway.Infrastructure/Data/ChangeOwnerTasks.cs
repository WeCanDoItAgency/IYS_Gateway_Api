using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ChangeOwnerTasks
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? SourceBranchId { get; set; }

    public int? TargetBranchId { get; set; }

    public int? SourceUserId { get; set; }

    public int? TargetUserId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }
}
