using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterStatuses
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int MainGroupId { get; set; }

    public int? Code { get; set; }

    public string Name { get; set; } = null!;

    public int TypeId { get; set; }

    public int? SymbolId { get; set; }

    public int? CallAfterXminute { get; set; }

    public bool? TriggerCallCenter { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool IsAppointment { get; set; }

    public int? SendSmsafterXminute { get; set; }

    public bool? TriggerSms { get; set; }

    public int? PriorityDate { get; set; }

    public bool? IsSendSurvey { get; set; }

    public bool? IsApplicationDownloadSms { get; set; }

    public bool? IsGoogleAds { get; set; }

    public bool? IsSendNotification { get; set; }

    public bool? IsSendToScheduledJob { get; set; }

    public bool? IsSendToScheduledJobAuto { get; set; }

    public bool? SendWhatsApp { get; set; }

    public int? SendWhatsappAfterXminute { get; set; }

    public int? CallcenterCredentialId { get; set; }

    public virtual CallCenterCredentials? CallcenterCredential { get; set; }

    public virtual CallCenterStatusesMainGroup MainGroup { get; set; } = null!;
}
