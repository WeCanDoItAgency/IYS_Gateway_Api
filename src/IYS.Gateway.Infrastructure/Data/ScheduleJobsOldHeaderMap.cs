using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ScheduleJobsOldHeaderMap
{
    public int Id { get; set; }

    public string QueryType { get; set; } = null!;

    public Guid OldHeaderGuid { get; set; }

    public int ScheduleJobId { get; set; }

    public DateTime CreatedDate { get; set; }
}
