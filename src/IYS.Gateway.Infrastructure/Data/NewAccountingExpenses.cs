using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewAccountingExpenses
{
    public int Id { get; set; }

    public decimal? BankAccountId { get; set; }

    public decimal NetAmount { get; set; }

    public int VatRatioId { get; set; }

    public decimal VatAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public int? CurrencyId { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
