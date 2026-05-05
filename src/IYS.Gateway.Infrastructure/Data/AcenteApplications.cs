using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcenteApplications
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public string? CompanyName { get; set; }

    public string? RespName { get; set; }

    public string? RespSurname { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? RespCitizenId { get; set; }

    public string? Tin { get; set; }

    public string? Email { get; set; }

    public int? Status { get; set; }

    public string? Note { get; set; }

    public string? SeoKeywords { get; set; }

    public string? Title { get; set; }

    public string? TitleClass { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
