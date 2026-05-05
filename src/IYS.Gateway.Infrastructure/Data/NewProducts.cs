using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewProducts
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public string Name { get; set; } = null!;

    public int? ProductFamilyId { get; set; }

    public int? ProductGroupId { get; set; }

    public int? ProductSubGroupId { get; set; }

    public int UomId { get; set; }

    public int TypeId { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    public int? ModelId { get; set; }

    public string? MenseiCompanyName { get; set; }

    public int? MenseiCountryId { get; set; }

    public decimal? VolumeM3 { get; set; }

    public decimal? WeightKg { get; set; }

    public int? CabTypeId { get; set; }

    public int? CabVolume { get; set; }

    public decimal? BuyingPrice { get; set; }

    public int? BuyingPriceCurrencyId { get; set; }

    public decimal? SellingPrice { get; set; }

    public int? SellingPriceCurrencyId { get; set; }

    public decimal? TaxRatio { get; set; }

    public decimal? MinimumStock { get; set; }

    public int? WarrantyInMonth { get; set; }

    public string? ProductImagePath { get; set; }

    public string? AccountPlanCode { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
