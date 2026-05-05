using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewGeneralTransactions
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int? ExchangeTypeId { get; set; }

    public int? TransactionTahsilatTediyeTipId { get; set; }

    public int? TransactionTypeId { get; set; }

    public int? DocumentTypeId { get; set; }

    public DateTime? Date { get; set; }

    public string? Note { get; set; }

    public bool? IsTransferAmountIncluded { get; set; }

    public decimal? TransferAmount { get; set; }

    public int? TransferAmountCurrencyId { get; set; }

    public int? TransferAmountVatId { get; set; }

    public decimal? TransferAmountVatAmount { get; set; }

    public decimal? TransferAmountTotalAmount { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
