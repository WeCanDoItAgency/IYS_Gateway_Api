using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ScheduledJobsLog
{
    public int Id { get; set; }

    public string? Message { get; set; }

    public int? ScheduleJobId { get; set; }

    public DateTime? CreatedDate { get; set; }
}
