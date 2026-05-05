using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdpProductions
{
    public int Id { get; set; }

    public int? ExpertiseRequestStatusLogId { get; set; }

    public int InsuranceFirmId { get; set; }

    public string? PolicyNumber { get; set; }

    public string? PlateNumber { get; set; }

    public string? NationalNumber { get; set; }

    public decimal? GrossPremium { get; set; }

    public decimal? NetPremium { get; set; }

    public int? ZeyilNo { get; set; }

    public int? TecditNo { get; set; }

    public int? Status { get; set; }

    public DateTime? ArrangementDate { get; set; }

    public bool? IsCompanyCard { get; set; }

    public int? PaymentType { get; set; }

    public bool? IsActive { get; set; }

    public string? QueryType { get; set; }

    public int? Sktid { get; set; }

    public int? UserId { get; set; }

    public string? FullName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? PermitNo { get; set; }

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

    public int? IslemSahibiSktid { get; set; }

    public int? IslemSahibiUserId { get; set; }

    public string? Phone { get; set; }

    public string? PartajNo { get; set; }

    public int? RdpBrandPartajId { get; set; }

    public bool IsMatchedWithUretimPolicies { get; set; }

    public string? IsRaiseMatchingErrorMessage { get; set; }

    public bool IsRaiseMatchingError { get; set; }

    public decimal? BranchCommission { get; set; }

    public int? BranchCommissionType { get; set; }

    public int? BranchComissionId { get; set; }

    public decimal? UserCommission { get; set; }

    public int? UserCommissionType { get; set; }

    public int? UserComissionId { get; set; }

    public decimal? IslemSahibiSktcalculatedCommission { get; set; }

    public int? IslemSahibiSktcommissionType { get; set; }

    public int? IslemSahibiSktcommissionId { get; set; }

    public decimal? IslemSahibiUserCalculatedCommission { get; set; }

    public int? IslemSahibiUserCommissionType { get; set; }

    public int? IslemSahibiUserCommissionId { get; set; }

    public int? HeaderId { get; set; }

    public int? DetailId { get; set; }

    public int? PaymentId { get; set; }

    public int? UretimId { get; set; }

    public bool? UretimPolicedeAnaPoliceVarmi { get; set; }

    public string? Iskem { get; set; }

    public bool? ImportedFromAdaCode { get; set; }

    public Guid? DetailGuid { get; set; }
}
