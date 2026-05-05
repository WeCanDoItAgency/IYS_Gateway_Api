using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewGeneralTransactionMappings
{
    public int Id { get; set; }

    public int? AccountingTransactionId { get; set; }

    public int? GeneralTransactionId { get; set; }

    public int? SenderCaseId { get; set; }

    public int? ReceiverCaseId { get; set; }

    public int? ReceiverBankId { get; set; }

    public bool IsActive { get; set; }
}
