using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class OfferInstallmentPrices
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int UserId { get; set; }

    public Guid DetailGuid { get; set; }

    public string QueryType { get; set; } = null!;

    public int BrandId { get; set; }

    public int SubbrandId { get; set; }

    public decimal GrossPremium { get; set; }

    public decimal? NetPremium { get; set; }

    public decimal? Commission { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public int InstallmentCount { get; set; }

    public string? InstallmentDescription { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? FromPlace { get; set; }

    public bool? IsActive { get; set; }
}
