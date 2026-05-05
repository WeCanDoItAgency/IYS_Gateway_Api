using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MerkezTalepCreditCardInfo
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? IvrResponseId { get; set; }

    public string? CreditCardOwnerName { get; set; }

    public string? CreditCardOwnerSurname { get; set; }

    public string? Installement { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public int Status { get; set; }

    public int? MerkezTalepId { get; set; }

    public string? SaltGuid { get; set; }

    public string? EncCreditCardNo { get; set; }

    public string? EncCardExpiry { get; set; }

    public string? EncCardMonth { get; set; }

    public string? EncCardYear { get; set; }

    public string? EncCardCvv { get; set; }

    public string? NationalNumber { get; set; }

    public int? CampaignId { get; set; }

    public int? RuleId { get; set; }

    public string? Phone { get; set; }

    public string? EncDetailId { get; set; }

    public Guid? DetailGuid { get; set; }

    public string? QueryType { get; set; }

    public bool IsCreatedFrom3D { get; set; }

    public bool IsConfirmed3D { get; set; }

    public string? CenterWaitingMongoId { get; set; }
}
