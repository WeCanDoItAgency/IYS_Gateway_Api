using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ExpertiseRequestStatusLogs
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? UserId { get; set; }

    public long? CallRequestId { get; set; }

    public int? RequestNumber { get; set; }

    public int? Status { get; set; }

    public string? Notes { get; set; }

    public DateTime? FutureCallDate { get; set; }

    public string? UploadedFileName { get; set; }

    public decimal? TargetAmount { get; set; }

    public int? TargetAmountCurrencyId { get; set; }

    public string? QueryTypeId { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CallRecordedPath { get; set; }

    public bool IsCallCenterSend { get; set; }

    public bool IsProcessed { get; set; }

    public string? EncDetailId { get; set; }

    public string? NationalNumber { get; set; }

    public string? Phone { get; set; }

    public int? FromPlaceId { get; set; }

    public DateTime? StartCallDate { get; set; }

    public DateTime? FinishCallDate { get; set; }

    public Guid? HeaderGuid { get; set; }

    public Guid? DetailGuid { get; set; }

    public bool? OncekiPolicesiBizdenMi { get; set; }

    public Guid ExpertiseLogGuid { get; set; }

    public string? Visitor { get; set; }

    public string? UtmCampaign { get; set; }

    public string? UtmMedium { get; set; }

    public string? UtmSource { get; set; }

    public string? FromPhone { get; set; }

    public string? MantisCustomerId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? RespondByUserId { get; set; }

    public string? LicensePlateNumber { get; set; }

    public Guid? ParentExpertiseLogGuid { get; set; }

    public int? CallTimeSec { get; set; }

    public string? UtmTerm { get; set; }

    public string? GadSource { get; set; }

    public string? UtmGclid { get; set; }

    public string? UtmGraid { get; set; }

    public string? UtmKeyword { get; set; }

    public string? UtmMatchtype { get; set; }

    public string? UtmDevice { get; set; }

    public string? UtmCreative { get; set; }

    public string? UtmTargetid { get; set; }

    public bool? ToolsOtomatikTeklifBasariliMi { get; set; }

    public int? ScheduleJobsId { get; set; }

    public virtual CallRequests? CallRequest { get; set; }
}
