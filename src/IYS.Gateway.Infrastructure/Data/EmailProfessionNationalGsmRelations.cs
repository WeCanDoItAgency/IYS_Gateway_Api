using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class EmailProfessionNationalGsmRelations
{
    public int Id { get; set; }

    public string NationalNumber { get; set; } = null!;

    public string Gsm { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? TrafficProfessionCode { get; set; }

    public string? AdditiveProfessionCode { get; set; }
}
