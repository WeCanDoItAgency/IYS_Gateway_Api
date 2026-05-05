using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UretimCekmeEmirleri
{
    public int Id { get; set; }

    public int? SubbrandId { get; set; }

    public string? ApiName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? PolicyCount { get; set; }

    public DateTime? FetchStartDate { get; set; }

    public DateTime? FetchEndDate { get; set; }

    public int? CompletedCount { get; set; }

    public int IsProcess { get; set; }

    public int ProcessType { get; set; }

    public DateTime? ProcessStartTime { get; set; }

    public DateTime? ProcessEndTime { get; set; }

    public bool? IsSendtoBot { get; set; }

    public bool? IsRespondedFromBot { get; set; }

    public bool? IsSuccessFromBot { get; set; }

    public string? SavedFilePath { get; set; }

    public bool? IsSendWithMail { get; set; }

    public bool? IsRespondedFromMail { get; set; }

    public bool? IsWebService { get; set; }

    public int? FetchUserId { get; set; }

    public int? FetchBranchId { get; set; }

    public int? FetchFirmId { get; set; }

    public bool IsManuelTransfer { get; set; }

    public bool IsAdaFile { get; set; }

    public bool IsWithAdaCode { get; set; }

    public bool IsReportRequest { get; set; }

    public bool IsSendtoQueue { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }
}
