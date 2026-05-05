using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class OldPolicyQueryLogs
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? IpAddress { get; set; }

    public string? PolicyNumber { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? CityNameText { get; set; }

    public string? CityCode { get; set; }

    public string? DistrictNameText { get; set; }

    public string? DistrictCode { get; set; }

    public string? QuarterCode { get; set; }

    public string? QuarterNameText { get; set; }

    public string? StreetCode { get; set; }

    public string? BuildingCode { get; set; }

    public string? CitizenshipNumber { get; set; }

    public string? RiskAddressCode { get; set; }

    public string? PostalNum { get; set; }

    public string? VillageNameText { get; set; }

    public string? VillageCode { get; set; }

    public string? MobileNum { get; set; }

    public string? UsageTypeString { get; set; }

    public string? UsageType { get; set; }

    public string? Lot { get; set; }

    public string? LossPayeeType { get; set; }

    public string? LossPayeeFinancial { get; set; }

    public string? LossPayeeBranch { get; set; }

    public string? LossPayeeBank { get; set; }

    public string? LandSheet { get; set; }

    public string? GrossAreaM2 { get; set; }

    public string? FinancialInstitution { get; set; }

    public string? BuildYearString { get; set; }

    public string? BuildYear { get; set; }

    public string? BuildType { get; set; }

    public string? BuildTypeString { get; set; }

    public string? Block { get; set; }

    public string? BankBranch { get; set; }

    public string? Bank { get; set; }

    public string? AnteriorDamage { get; set; }

    public string? FlatNum { get; set; }

    public string? TotalFloorString { get; set; }

    public string? TotalFloor { get; set; }

    public string? CompanyNameText { get; set; }

    public string? BankNameText { get; set; }

    public DateTime? EndDate { get; set; }
}
