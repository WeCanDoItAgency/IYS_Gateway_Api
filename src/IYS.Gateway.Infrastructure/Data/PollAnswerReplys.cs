using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PollAnswerReplys
{
    public int Id { get; set; }

    public int AnswerId { get; set; }

    public int HeaderId { get; set; }

    public int? UserId { get; set; }

    public DateTime CreateDate { get; set; }

    public string UserAgent { get; set; } = null!;

    public string Ipaddress { get; set; } = null!;

    public string? QueryType { get; set; }
}
