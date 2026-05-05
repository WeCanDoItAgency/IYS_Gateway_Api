using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SupportTicketMessages
{
    public long Id { get; set; }

    public int RequestId { get; set; }

    public DateTime CreateDate { get; set; }

    public int UserId { get; set; }

    public string Message { get; set; } = null!;

    public string? Attachment { get; set; }
}
