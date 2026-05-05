using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class OfferRequestQueues
{
    public int Id { get; set; }

    public string EncryptedHeaderId { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Status { get; set; }

    public string QueryType { get; set; } = null!;

    public string? ResultJson { get; set; }

    public string? SentResult { get; set; }

    public string? CallbackUrl { get; set; }

    public bool? SendEmail { get; set; }

    public bool? PostCallback { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ProcessStart { get; set; }

    public DateTime? ResponseDate { get; set; }

    public string? AccessToken { get; set; }

    public string? Source { get; set; }
}
