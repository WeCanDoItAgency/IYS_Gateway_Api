using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewAccountingMappings
{
    public int Id { get; set; }

    public int? CreditCardId { get; set; }

    public int? GuaranteeLetterId { get; set; }

    public int? ChequeId { get; set; }

    public int? BankAccountId { get; set; }

    public int? CaseId { get; set; }

    public int? InvoiceId { get; set; }

    public int? UretimPoliceId { get; set; }

    public int? ManuelPoliceId { get; set; }

    public int? CariKartId { get; set; }

    public int? AccountTransactionId { get; set; }

    public bool IsActive { get; set; }
}
