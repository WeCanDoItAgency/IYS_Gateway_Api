using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PaymentEmailQueue
{
    public int Id { get; set; }

    public int? PaymentId { get; set; }

    public int? HeaderId { get; set; }

    public int? DetailId { get; set; }

    public string? QueryType { get; set; }

    public string? AccessToken { get; set; }

    public string? EncryptedDetailId { get; set; }

    public string? Email { get; set; }

    public string? Source { get; set; }

    public string? Language { get; set; }

    public int? Status { get; set; }

    public int? PrintType { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public int? FirmId { get; set; }

    public int? FromPlace { get; set; }

    public string? IpAddress { get; set; }

    public string? DetailGuid { get; set; }
}
