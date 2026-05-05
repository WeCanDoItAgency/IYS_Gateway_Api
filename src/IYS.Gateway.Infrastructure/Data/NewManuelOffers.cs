using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewManuelOffers
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? UserId { get; set; }

    public DateTime? OfferDate { get; set; }

    public string? NationalNumber { get; set; }

    public string? LicencePlateNumber { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public bool? IsRenewal { get; set; }

    public bool? HaveAddition { get; set; }

    public int? QueryTypeId { get; set; }

    public int? QueryTypeProductId { get; set; }

    public int? SubBrandId { get; set; }

    public int? InsurancesOfferCount { get; set; }

    public string? OfferNumber { get; set; }

    public double? GrossPremium { get; set; }

    public double? NetPremium { get; set; }

    public string? Description { get; set; }

    public bool? IsPolice { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? DeleteUserId { get; set; }

    public virtual Subeler? Branch { get; set; }

    public virtual NewFirms? Firm { get; set; }

    public virtual ICollection<NewManuelPolicies> NewManuelPolicies { get; set; } = new List<NewManuelPolicies>();

    public virtual NewQueryTypes? QueryType { get; set; }

    public virtual NewSubBrands? SubBrand { get; set; }
}
