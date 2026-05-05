using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewAccountingTransactions
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public decimal BorcAmount { get; set; }

    public decimal AlacakAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public int CurrencyId { get; set; }

    public int? ExchangeCurrencyId { get; set; }

    public decimal? BorcAmountExchange { get; set; }

    public decimal? AlacakAmountExchange { get; set; }

    public decimal? TotalAmountExchange { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
