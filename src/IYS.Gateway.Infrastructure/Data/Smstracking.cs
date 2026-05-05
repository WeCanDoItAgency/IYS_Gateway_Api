using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Smstracking
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? ExpertiseRequestLogId { get; set; }

    public int? ExpertiseRequestId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? Status { get; set; }

    public string? IdentityNumber { get; set; }

    public string? Plaka { get; set; }

    public string? Phone { get; set; }

    public DateTime? TargetTime { get; set; }

    public DateTime? SendedTime { get; set; }

    public string? Message { get; set; }

    public int? PaymentId { get; set; }

    public string? QueryType { get; set; }

    public int? CampaignId { get; set; }

    public int? CampaignRuleId { get; set; }

    public int? DetailId { get; set; }

    public int? SmsType { get; set; }

    public int? DigitalMarketingId { get; set; }

    public int? UserId { get; set; }

    public int? CurrentCallcenterStatusCode { get; set; }

    public int? FromPlaceId { get; set; }

    public virtual Kullanicilar? User { get; set; }
}
