using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewAccountingProductionPeriodOpenClose
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int No { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime FinishDate { get; set; }

    public int StatusId { get; set; }

    public int CurrencyId { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public int ClosingOrderStatus { get; set; }

    public virtual ICollection<Mutabakat> Mutabakat { get; set; } = new List<Mutabakat>();
}
