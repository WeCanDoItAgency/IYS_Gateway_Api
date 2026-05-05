using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Payment3Drequests
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? UserId { get; set; }

    public string? QueryType { get; set; }

    public int? DetailId { get; set; }

    public string? EncDetailId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ApiResponse { get; set; }

    public string? MsuSessionToken { get; set; }

    public string? SaltGuid { get; set; }

    public string? EncCreditCardNo { get; set; }

    public string? EncCardExpiry { get; set; }

    public string? EncCardMonth { get; set; }

    public string? EncCardYear { get; set; }

    public string? EncCardCvv { get; set; }

    public int? SavedCreditCardId { get; set; }

    public int? CampaignId { get; set; }

    public int? CampaignRuleId { get; set; }

    public bool? FromBalance { get; set; }

    public string? NationalNumber { get; set; }

    public string? Phone { get; set; }

    public string? CreditCardOwnerName { get; set; }

    public string? CreditCardOwnerSurname { get; set; }

    public string? Installement { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Visitor { get; set; }

    public int? FromPlace { get; set; }

    public string? Source { get; set; }

    public string? Email { get; set; }

    public string? UserAccessToken { get; set; }

    public Guid? DetailGuid { get; set; }

    public string? ApiResponseSession { get; set; }

    public string? ApiResponse3Dhtml { get; set; }

    public double? GrossPremium { get; set; }

    public bool? IsSuccessful { get; set; }

    public string? ApiResponse3DhtmlErrorMessage { get; set; }

    public Guid? PolicyGuid { get; set; }

    public Guid? Payment3DrequestsGuid { get; set; }

    public string? PaytenCardToken { get; set; }
}
