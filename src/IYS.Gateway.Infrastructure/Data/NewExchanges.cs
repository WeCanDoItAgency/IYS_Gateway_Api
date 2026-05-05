using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewExchanges
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int TypeId { get; set; }

    public decimal Amount { get; set; }

    public int CurrencyId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }
}
