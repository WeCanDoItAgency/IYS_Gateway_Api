using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewCurrencies
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Symbol { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<NewCases> NewCases { get; set; } = new List<NewCases>();

    public virtual ICollection<NewInvoices> NewInvoices { get; set; } = new List<NewInvoices>();
}
