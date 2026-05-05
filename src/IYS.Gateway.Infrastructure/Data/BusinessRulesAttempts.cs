using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BusinessRulesAttempts
{
    public int Id { get; set; }

    public string? QueryType { get; set; }

    public string? AccessToken { get; set; }

    public int? FirmId { get; set; }

    public string? Source { get; set; }

    public string? IdentityNumber { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public DateTime? CreateDate { get; set; }

    public int BusinessRulesLogId { get; set; }

    public virtual BusinessRulesLog BusinessRulesLog { get; set; } = null!;
}
