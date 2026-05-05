using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ScheduleJobsHeader
{
    public int Id { get; set; }

    public int? HeaderId { get; set; }

    public string Querytype { get; set; } = null!;

    public int ScheduleJobsId { get; set; }

    public bool? EmailSent { get; set; }

    public DateTime? EmailSentAt { get; set; }

    public bool? SmsSent { get; set; }

    public DateTime? SmsSentAt { get; set; }

    public bool? CallCenterSent { get; set; }

    public DateTime? CallCenterSentAt { get; set; }

    public bool? SendEmail { get; set; }

    public bool? SendSms { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid HeaderGuid { get; set; }

    public virtual ScheduledJobs ScheduleJobs { get; set; } = null!;
}
