using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FirmApiAdresses
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public string? ApiName { get; set; }

    public string? BaseUrl { get; set; }

    public string? DebugUrl { get; set; }

    public string? TestUrl { get; set; }

    public string? OtherUrl { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public bool? UseDefaultApi { get; set; }

    public int? InsuranceId { get; set; }

    public byte? ApiType { get; set; }

    public int? ShareFirmId { get; set; }

    public int? ShareApiNameId { get; set; }

    public virtual NewFirms? Firm { get; set; }

    public virtual NewSubBrands? Insurance { get; set; }
}
