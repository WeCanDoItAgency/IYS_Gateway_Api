using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TrainingWatchLogs
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreateDate { get; set; }
}
