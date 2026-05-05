using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PaymentParameterFromOffer
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Sktid { get; set; }

    public int FirmId { get; set; }

    public int? DetailId { get; set; }

    public Guid DetailGuid { get; set; }

    public string QueryType { get; set; } = null!;

    public string? TeklifHash { get; set; }

    public string? AracMotorNo { get; set; }

    public string? SasiNo { get; set; }

    public string? TescilSeriKod { get; set; }

    public string? TescilSeriNo { get; set; }
}
