using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class GsmRequestHistorys
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? UserId { get; set; }

    public string? NationalNumber { get; set; }

    public string? TaxNumber { get; set; }

    public string? PassportNumber { get; set; }

    public string? LicensePlateNumber { get; set; }

    public string? AsbisNumber { get; set; }

    public string? Email { get; set; }

    public string? Gsm { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? SmsActivationCode { get; set; }

    public bool SmsApproved { get; set; }

    public DateTime? SmsApproveDate { get; set; }

    public string? QueryType { get; set; }

    public string? ReferenceNumber { get; set; }

    public bool? IsConfirmOpenData { get; set; }

    public bool? IsConfirmPrivacy { get; set; }

    public bool? IsConfirmAdvertisement { get; set; }

    public string? IpAddress { get; set; }

    public bool? IsAddGsmLimitCount { get; set; }

    public bool? IsAddedWithoutSms { get; set; }

    public string? Visitor { get; set; }

    public string? PlayerId { get; set; }

    public string? Device { get; set; }

    public int? FromPlace { get; set; }

    public string? DeviceModel { get; set; }

    public string? BuildNumber { get; set; }

    public string? UtmCampaign { get; set; }

    public string? UtmMedium { get; set; }

    public string? UtmSource { get; set; }

    public string? UtmTerm { get; set; }

    public DateTime? Birthdate { get; set; }

    public bool? IsUsed { get; set; }
}
