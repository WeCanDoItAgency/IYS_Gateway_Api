using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class LiveSupportRequests
{
    public long Id { get; set; }

    public int FromUser { get; set; }

    public int? AnsweredUser { get; set; }

    public string OfferQuery { get; set; } = null!;

    public string? AnswerQuery { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Answered { get; set; }

    public DateTime? Ended { get; set; }

    public int? EntityId { get; set; }

    public string? QueryType { get; set; }
}
