using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class IvrResponses
{
    public int Id { get; set; }

    public int? IvrRequestId { get; set; }

    public string? ExpertiseGuid { get; set; }

    public string? SaltGuid { get; set; }

    public string? EncCreditCardNo { get; set; }

    public string? EncCardExpiry { get; set; }

    public string? EncCardMonth { get; set; }

    public string? EncCardYear { get; set; }

    public string? EncCardCvv { get; set; }

    public string? Installement { get; set; }

    public string? CardOwner { get; set; }

    public string? EncDetailId { get; set; }

    public string? QueryType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public int Status { get; set; }

    public bool IsJustCvv { get; set; }

    public string? Column20Guid { get; set; }

    public string? Note { get; set; }
}
