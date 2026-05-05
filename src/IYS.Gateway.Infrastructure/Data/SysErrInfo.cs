using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SysErrInfo
{
    public int Id { get; set; }

    public string? RawUrl { get; set; }

    public string? UrlOriginal { get; set; }

    public string? ReferenceUrl { get; set; }

    public string? HostAddress { get; set; }

    public string? HostName { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? KuserId { get; set; }

    public DateTime CreateDate { get; set; }
}
