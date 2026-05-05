using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Processing
{
    public int Id { get; set; }

    public int? DetayId { get; set; }

    public string? TypeCode { get; set; }

    public string? CodeOwner { get; set; }

    public string? CodeCvv { get; set; }

    public string? CodeNumber { get; set; }

    public string? CodeMonth { get; set; }

    public string? CodeYear { get; set; }

    public int? UserId { get; set; }

    public string? CardType { get; set; }

    public string? Installment { get; set; }
}
