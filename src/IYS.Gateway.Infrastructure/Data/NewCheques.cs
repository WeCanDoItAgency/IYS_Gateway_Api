using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewCheques
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public string Code { get; set; } = null!;

    public int TypeId { get; set; }

    public string? ChequeNo { get; set; }

    public int? BankId { get; set; }

    public int? BankBranchId { get; set; }

    public int? BankAccountId { get; set; }

    public string? Description { get; set; }

    public string? AccountPlanCode { get; set; }

    public decimal Amount { get; set; }

    public int CurrencyId { get; set; }

    public DateTime ValidationDate { get; set; }

    public DateTime GivenDate { get; set; }

    public DateTime? ReminderDate { get; set; }

    public string? ChequeDescription { get; set; }

    public string? ChequeNote { get; set; }

    public int? WebNotificationId { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
