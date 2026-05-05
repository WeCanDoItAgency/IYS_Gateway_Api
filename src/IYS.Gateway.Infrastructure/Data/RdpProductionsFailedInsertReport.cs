using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdpProductionsFailedInsertReport
{
    public int Id { get; set; }

    public int? ExpertiseRequestStatusLogId { get; set; }

    public int InsuranceFirmId { get; set; }

    public string PolicyNumber { get; set; } = null!;

    public string? PlateNumber { get; set; }

    public string? NationalNumber { get; set; }

    public decimal? GrossPremium { get; set; }

    public int? ZeyilNo { get; set; }

    public int? TecditNo { get; set; }

    public int? Status { get; set; }

    public DateTime? ArrangementDate { get; set; }

    public bool? IsCompanyCard { get; set; }

    public int? PaymentType { get; set; }

    public bool? IsActive { get; set; }

    public decimal? NetPremium { get; set; }

    public string? QueryType { get; set; }

    public int? Sktid { get; set; }

    public int? UserId { get; set; }

    public string? FullName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? PermitNo { get; set; }

    public int? FailedReason { get; set; }

    public string? FailedReasonText { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public int? DeletedDate { get; set; }

    public int FromPlaceId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? Installement { get; set; }

    public int? PolicyRecordId { get; set; }

    public string? Email { get; set; }

    public string? UavtNo { get; set; }

    public int? FirmId { get; set; }

    public int? CalisanFirmId { get; set; }

    public int? CalisanBranchId { get; set; }

    public int? CalisanUserId { get; set; }

    public string? Phone { get; set; }
}
