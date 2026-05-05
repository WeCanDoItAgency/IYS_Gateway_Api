using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandQueryTypeRdpBrowserAuth
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public string? FirmName { get; set; }

    public string? BlockedPath { get; set; }

    public int? BlockedFindType { get; set; }

    public string? ClickElementPath { get; set; }

    public int? ElementFindType { get; set; }

    public string? Script { get; set; }

    public string? Url { get; set; }

    public int? BlockedType { get; set; }

    public int? QueryType { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public int? ProcessType { get; set; }

    public virtual NewBrands Brand { get; set; } = null!;
}
