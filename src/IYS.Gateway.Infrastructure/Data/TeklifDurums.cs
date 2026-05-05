using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TeklifDurums
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? Sktid { get; set; }

    public int? UserId { get; set; }

    public int BaslikId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? YvadeBaslangic { get; set; }

    public DateTime? YvadeBitis { get; set; }

    public string? YSirketKodu { get; set; }

    public string? YAcenteNo { get; set; }

    public string? YPoliceNo { get; set; }

    public string? YYenilemeNo { get; set; }

    public bool IsPolice { get; set; }

    public bool IsClosed { get; set; }

    public double? Comission { get; set; }

    public bool IsScheduled { get; set; }

    public string? Querytype { get; set; }

    public bool? BaslikStatus { get; set; }

    public bool? BizdenmiPolicelesti { get; set; }

    public string? BaslikLicensePlateNumber { get; set; }

    public string? BaslikLicensePermitNumber { get; set; }

    public string? BaslikNationalNumber { get; set; }

    public int? BaslikCalisilanfirma { get; set; }

    public int? BaslikCalisilansube { get; set; }

    public int? BaslikCalisilanuser { get; set; }

    public string? BaslikChasisNumber { get; set; }

    public string? BaslikEngineNumber { get; set; }

    public string? BaslikName { get; set; }

    public string? BaslikSurname { get; set; }

    public int? BaslikBranchId { get; set; }

    public string? BaslikEmail { get; set; }

    public string? BaslikPhone { get; set; }

    public DateTime? BaslikBirthdate { get; set; }

    public DateTime? DigerYvadeBaslangic { get; set; }

    public DateTime? DigerYvadeBitis { get; set; }

    public string? DigerYSirketKodu { get; set; }

    public string? DigerYAcenteNo { get; set; }

    public string? DigerYPoliceNo { get; set; }

    public string? DigerYYenilemeNo { get; set; }

    public bool DigerIsPolice { get; set; }

    public bool? IsSold { get; set; }

    public string? BaslikUavt { get; set; }

    public string? BaslikMusteriAdi { get; set; }

    public string? BaslikMusteriSoyadi { get; set; }

    public string? BaslikHeaderGuid { get; set; }

    public string? BaslikEskiPolice { get; set; }

    public int? BaslikMeslek { get; set; }

    public DateTime? SoldDate { get; set; }
}
