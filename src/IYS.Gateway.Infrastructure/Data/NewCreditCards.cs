using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewCreditCards
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int? StatusId { get; set; }

    public int? CariKartId { get; set; }

    public int? TypeId { get; set; }

    public string? OwnerTc { get; set; }

    public string OwnerFirstName { get; set; } = null!;

    public string OwnerLastName { get; set; } = null!;

    public string CreditCardNumber { get; set; } = null!;

    public string Month { get; set; } = null!;

    public string Year { get; set; } = null!;

    public string Cvv { get; set; } = null!;

    public string? AccountPlanCode { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
