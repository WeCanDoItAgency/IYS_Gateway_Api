using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class LoginDeviceLogs
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Source { get; set; }

    public string? PlayerId { get; set; }

    public string? Device { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public int? FromPlace { get; set; }

    public int? SktId { get; set; }

    public int? FirmId { get; set; }
}
