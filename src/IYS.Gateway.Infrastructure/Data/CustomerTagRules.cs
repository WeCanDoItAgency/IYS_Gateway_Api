using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CustomerTagRules
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int ActionType { get; set; }

    public int Puan { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public int Limit { get; set; }

    public virtual NewFirms Firm { get; set; } = null!;
}
