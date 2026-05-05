using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimPolicyCount
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public string? FirmName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? PolicyCount { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? CompletedCount { get; set; }

    public int IsProcess { get; set; }

    public int ProcessType { get; set; }

    public DateTime? ProcessStartTime { get; set; }

    public DateTime? ProcessEndTime { get; set; }

    public bool? IsSendtoBot { get; set; }

    public bool? IsRespondedFromBot { get; set; }

    public bool? IsSuccessFromBot { get; set; }

    public string? FilePath { get; set; }

    public bool? IsSendWithMail { get; set; }

    public bool? IsRespondedFromMail { get; set; }

    public bool? IsWebService { get; set; }

    public int? CreatedUserId { get; set; }

    public int? CreatedBranchId { get; set; }

    public int? CreatedFirmId { get; set; }

    public bool IsManuelTransfer { get; set; }

    public bool IsAdaFile { get; set; }

    public bool IsWithAdaCode { get; set; }

    public bool IsReportRequest { get; set; }

    public bool IsSendtoQueue { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public virtual Kullanicilar? CreatedUser { get; set; }

    public virtual Kullanicilar? UpdatedUser { get; set; }

    public virtual ICollection<UretimLogsOld> UretimLogsOld { get; set; } = new List<UretimLogsOld>();
}
