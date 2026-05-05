using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CreditCardViewLogs
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SubeId { get; set; }

    public DateOnly? CreatedData { get; set; }

    public int? UserId { get; set; }

    public string? IpAddress { get; set; }

    public int? Phone { get; set; }

    public int? NationalNumber { get; set; }

    public int Type { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }
}
