using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallRequests
{
    public long Id { get; set; }

    public int? CariKartId { get; set; }

    public int? RespondByUserId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Plate { get; set; }

    public int? FirmId { get; set; }

    public string? QueryType { get; set; }

    public string? EncryptedId { get; set; }

    public string? EncryptedHeaderId { get; set; }

    public string? Gsm { get; set; }

    public DateTime? CallDate { get; set; }

    public int? CityCode { get; set; }

    public int? CountyCode { get; set; }

    public int Status { get; set; }

    public string? Notes { get; set; }

    public string? NationalNumber { get; set; }

    public string? LicencePermitNumber { get; set; }

    public string? EngineNo { get; set; }

    public string? FrameNo { get; set; }

    public string? Source { get; set; }

    public string? CustomName { get; set; }

    public string? FromAccessToken { get; set; }

    public int? ClonedExpertiseRequestId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? Guid { get; set; }

    public string? CallRecordPath { get; set; }

    public virtual ICollection<ExpertiseRequestStatusLogs> ExpertiseRequestStatusLogs { get; set; } = new List<ExpertiseRequestStatusLogs>();
}
