using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BinList
{
    public int Bin { get; set; }

    public int? BankaKodu { get; set; }

    public string? BankaAdi { get; set; }

    public string? Type { get; set; }

    public string? SubType { get; set; }

    public string? Virtual { get; set; }

    public string? Prepaid { get; set; }

    public int Id { get; set; }

    public int? BankId { get; set; }

    public bool IsActive { get; set; }

    public virtual NewBanks? Bank { get; set; }

    public virtual ICollection<BrandContractedCreditCards> BrandContractedCreditCards { get; set; } = new List<BrandContractedCreditCards>();
}
