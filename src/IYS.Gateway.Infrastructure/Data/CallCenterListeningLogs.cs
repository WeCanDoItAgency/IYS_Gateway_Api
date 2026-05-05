using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterListeningLogs
{
    public int Id { get; set; }

    public int? ListenUserId { get; set; }

    public DateTime? ListenDatetime { get; set; }

    public int? ExpertiseRequestStatusLogId { get; set; }
}
