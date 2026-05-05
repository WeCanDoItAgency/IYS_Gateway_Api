using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewExpenseItems
{
    public int Id { get; set; }

    public int ExpenseId { get; set; }

    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

    public int UomId { get; set; }

    public int CurrencyId { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
