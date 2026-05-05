using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandContractedCreditCards
{
    public int Id { get; set; }

    public int? BrandId { get; set; }

    public int? QueryTypeId { get; set; }

    public int? BankId { get; set; }

    public int? BinId { get; set; }

    public string? BankName { get; set; }

    public string? BankLogoUrl { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public virtual NewBanks? Bank { get; set; }

    public virtual BinList? Bin { get; set; }
}
