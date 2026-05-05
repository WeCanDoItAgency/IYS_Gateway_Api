using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewCases
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public string? Name { get; set; }

    public string? Note { get; set; }

    public int CurrencyId { get; set; }

    public string? AccountPlanCode { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual NewCurrencies Currency { get; set; } = null!;

    public virtual NewFirms Firm { get; set; } = null!;
}
