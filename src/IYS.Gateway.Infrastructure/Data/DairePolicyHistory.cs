using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class DairePolicyHistory
{
    public int Id { get; set; }

    public DateTime? PoliceBaslangic { get; set; }

    public DateTime? PoliceBitis { get; set; }

    public string? SirketNo { get; set; }

    public string? SirketAdi { get; set; }

    public string? YenilemeNo { get; set; }

    public string? AcenteNo { get; set; }

    public string? PoliceNo { get; set; }

    public string? Email { get; set; }

    public string? Telefon { get; set; }

    public string? TcKimlik { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public int ScheduleJobId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Uavt { get; set; }

    public string? AddressNum { get; set; }

    public string? ApartmentUsageTypeCode { get; set; }

    public string? ApartmentusagetypeExplanationText { get; set; }

    public string? BankNameText { get; set; }

    public string? ConstructionTypeCode { get; set; }

    public string? ConstructiondamagestatusExplanationText { get; set; }

    public string? ConstructiondateExplanationText { get; set; }

    public string? ConstructiontypeExplanationText { get; set; }

    public string? NumberofstoreyCode { get; set; }

    public string? NumberofstoreyExplanationText { get; set; }

    public string? MernisNum { get; set; }

    public string? RiskBuildingCode { get; set; }

    public int? RiskCityCode { get; set; }

    public int? RiskDistrictCode { get; set; }

    public string? RiskDistrictNameText { get; set; }

    public string? RiskFlatNum { get; set; }

    public string? RiskLot { get; set; }

    public string? RiskQuarterCode { get; set; }

    public string? RiskStreetCode { get; set; }

    public string? RiskVillageCode { get; set; }

    public string? RiskVillageNameText { get; set; }

    public string? TariffExplanationText { get; set; }
}
