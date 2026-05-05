using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcikPortfoySendCallCenterLogs
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SubeId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UserId { get; set; }

    public string? IpAddress { get; set; }

    public string? Phone { get; set; }

    public string? NationalNumber { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? AcikPortfoyOrtakTabloId { get; set; }

    public string? SendPhoneNumber { get; set; }

    public virtual AcikPortfoyOrtakTablo? AcikPortfoyOrtakTablo { get; set; }
}
