using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewExecutionProceedings
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? IcraOffice { get; set; }

    public string? FileNo { get; set; }

    public DateTime? Date { get; set; }

    public int? FirmId { get; set; }

    public int? SubeId { get; set; }

    public int? UserId { get; set; }

    public decimal? PersonelSalaryAmount { get; set; }

    public int? PersonelSalaryAmountCurrencyId { get; set; }

    public decimal? IcraAmount { get; set; }

    public int? IcraAmountCurrencyId { get; set; }

    public decimal? CutRate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? CreditorIban { get; set; }
}
