using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewBankAccounts
{
    public int Id { get; set; }

    public int? CariKartId { get; set; }

    public int FirmId { get; set; }

    public int? BankId { get; set; }

    public int? BankBranchId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? IbanNo { get; set; }

    public string? HesapNumarasi { get; set; }

    public string? Note { get; set; }

    public int? CurrencyId { get; set; }

    public int? AccountTypeId { get; set; }

    public string? AccountPlanCode { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsMongoSync { get; set; }

    public DateTime? MongoSyncDate { get; set; }

    public virtual NewCariKart? CariKart { get; set; }
}
