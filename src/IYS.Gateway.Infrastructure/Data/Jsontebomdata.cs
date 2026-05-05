using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Jsontebomdata
{
    public int Id { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? BranchName { get; set; }

    public string? AuthorizedNameSurname { get; set; }

    public string? UserNameSurname { get; set; }

    public string? Phone { get; set; }

    public string? Plate { get; set; }

    public string? PersonalityType { get; set; }

    public string? TaxIdentityNumber { get; set; }

    public string? VehicleOwner { get; set; }

    public string? PlaceOfBirth { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? UavtAdressCode { get; set; }

    public string? CityDistrictName { get; set; }

    public string? LicenseSerialNumber { get; set; }

    public string? VehicleKindName { get; set; }

    public string? VehicleKindCode { get; set; }

    public string? VehicleSubKind { get; set; }

    public string? VehicleCode { get; set; }

    public string? VehicleBrandCode { get; set; }

    public string? VehicleBrandName { get; set; }

    public string? VehicleModelCode { get; set; }

    public string? VehicleModelName { get; set; }

    public int? ModelYear { get; set; }

    public string? CascoValuation { get; set; }

    public DateTime? RegistirationDate { get; set; }

    public string? EngineNumber { get; set; }

    public string? ChassisNumber { get; set; }

    public string? FuelType { get; set; }

    public int? SeatingCapacity { get; set; }

    public bool? PreviousTrafikUsePoliciy { get; set; }

    public string? PreviousTrafficInsuranceCode { get; set; }

    public string? PreviousTrafficInsuranceName { get; set; }

    public string? PreviousTrafficAgencyCode { get; set; }

    public string? PreviousTrafficAgencyName { get; set; }

    public string? PreviousTrafficPolicyCode { get; set; }

    public int? PreviousTrafficRegenerationNumber { get; set; }

    public DateTime? TrafficPolicyStartDate { get; set; }

    public DateTime? TrafficPolicyFinishDate { get; set; }

    public string? TrafficLevel { get; set; }

    public string? TrafficPoliceTaxIdentityNumber { get; set; }

    public bool? PreviousCascoUsePoliciy { get; set; }

    public string? PreviousCascoInsuranceCode { get; set; }

    public string? PreviousCascoInsuranceName { get; set; }

    public string? PreviousCascoAgencyCode { get; set; }

    public string? PreviousCascoAgencyName { get; set; }

    public string? PreviousCascoPolicyCode { get; set; }

    public int? PreviousCascoRegenerationNumber { get; set; }

    public DateTime? CascoStartDate { get; set; }

    public DateTime? CascoFinishDate { get; set; }

    public string? CascoLevel { get; set; }

    public int? JsonId { get; set; }

    public string? Query { get; set; }
}
