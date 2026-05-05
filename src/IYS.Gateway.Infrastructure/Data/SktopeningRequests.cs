using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SktopeningRequests
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SktId { get; set; }

    public int? BranchId { get; set; }

    public string? NationalNumber { get; set; }

    public string? TaxNumber { get; set; }

    public string? PassportNumber { get; set; }

    public string? OperationalName { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? MarketerId { get; set; }

    public int? RepresentativeId { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public int? CountyId { get; set; }

    public bool? IsPrepaidSales { get; set; }

    public int? PrepaidCurrency { get; set; }

    public string? PrepaidValue { get; set; }

    public bool? CanOpenSubBranch { get; set; }

    public int? CreditCardType { get; set; }

    public string? CreditCardNo { get; set; }

    public string? CreditCardOwnerName { get; set; }

    public string? CreditCardOwnerSurname { get; set; }

    public string? CreditCardSktmonth { get; set; }

    public string? CreditCardSktyear { get; set; }

    public string? CreditCardCvv { get; set; }

    public int? Status { get; set; }

    public bool? IsConfirmed { get; set; }

    public bool? IsCorporate { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool? IysKontroluOlacakmi { get; set; }

    public bool? IsHaveUseCampaingPermission { get; set; }

    public bool? IsHaveUseSmsServicePermission { get; set; }

    public bool? SendWhatsApp { get; set; }

    public bool? IsSendNotificationEmail { get; set; }

    public bool? IsSendNotificationSms { get; set; }

    public bool? SendNotification { get; set; }

    public bool? IsHaveUseRdppermission { get; set; }
}
