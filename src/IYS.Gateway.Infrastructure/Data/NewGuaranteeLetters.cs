using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewGuaranteeLetters
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int BankAccountId { get; set; }

    public string Code { get; set; } = null!;

    public string? No { get; set; }

    public int? TypeId { get; set; }

    public DateTime Date { get; set; }

    public DateTime? ValidationDate { get; set; }

    public DateTime? RemainderDate { get; set; }

    public int? WebNotificationId { get; set; }

    public bool? IsLimited { get; set; }

    public decimal Amount { get; set; }

    public int CurrencyId { get; set; }

    public string ReceivedResponsiblePersonName { get; set; } = null!;

    public string SenderResponsiblePersonName { get; set; } = null!;

    public string? Description { get; set; }

    public string? AccountPlanCode { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
