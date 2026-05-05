using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewAccountTransactions
{
    public int Id { get; set; }

    public string? AccountPlanCode { get; set; }

    public int FirmId { get; set; }

    public string? Note { get; set; }

    public DateTime Date { get; set; }

    public int? CreditCardId { get; set; }

    public int TransactionTypeId { get; set; }

    public int? SenderCariKartId { get; set; }

    public int? ReceiverCariKartId { get; set; }

    public int? SenderBankAccountId { get; set; }

    public int? ReceiverBankAccountId { get; set; }

    public int? SenderCaseId { get; set; }

    public int? ReceiverCaseId { get; set; }

    public decimal BorcAmount { get; set; }

    public decimal? AlacakAmount { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? AccountTransactionExchangeTypeId { get; set; }

    public int AmountCurrencyId { get; set; }

    public int StatusId { get; set; }

    public string? DocumentNo { get; set; }

    public int? DocumentTypeId { get; set; }

    public string? SourceOutTransferAccountNumber { get; set; }

    public string? SourceOutTransferIban { get; set; }

    public string? DestinationOutTransferAccountNumber { get; set; }

    public string? DestinationOutTransferIban { get; set; }

    public string? SourceOutTransferCreditCard { get; set; }

    public string? SourceOutTransferCcownerName { get; set; }

    public string? SourceOutTransferCcownerTc { get; set; }

    public int? SourceOutTransferCcstatus { get; set; }

    public int? SourceOutTransferCctype { get; set; }

    public string? SourceOutTransferCcmonth { get; set; }

    public string? SourceOutTransferCcyear { get; set; }

    public string? SourceOutTransferCccvv { get; set; }

    public string? DestinationOutTransferCreditCard { get; set; }

    public string? DestinationOutTransferCcownerName { get; set; }

    public string? DestinationOutTransferCcownerTc { get; set; }

    public int? DestinationOutTransferCcstatus { get; set; }

    public int? DestinationOutTransferCctype { get; set; }

    public string? DestinationOutTransferCcmonth { get; set; }

    public string? DestinationOutTransferCcyear { get; set; }

    public string? DestinationOutTransferCccvv { get; set; }

    public int? SenderChequeId { get; set; }

    public int? ReceiverChequeId { get; set; }

    public int? ReceiverChequeBankId { get; set; }

    public int? ReceiverChequeBankBranchId { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }
}
