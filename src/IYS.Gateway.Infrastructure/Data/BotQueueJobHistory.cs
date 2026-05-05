using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BotQueueJobHistory
{
    public int Id { get; set; }

    public string Request { get; set; } = null!;

    public string? Response { get; set; }

    public int RequestUserId { get; set; }

    public DateTime RequestCreateDate { get; set; }

    public DateTime? ResponseCreateDate { get; set; }

    public bool? ReQueue { get; set; }

    public bool? IsResponded { get; set; }

    public string Firm { get; set; } = null!;

    public string QueryType { get; set; } = null!;
}
