using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ExpertiseRequests
{
    public int Id { get; set; }

    public int? CariKartId { get; set; }

    public int? RespondByUserId { get; set; }

    public string? FromPlace { get; set; }

    public string? RequestNumber { get; set; }

    public string? EncryptedHeaderId { get; set; }

    public string? EncryptedId { get; set; }

    public string? FromAccessToken { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? UserId { get; set; }

    public string? LicensePlateNumber { get; set; }

    public string? NationalNumber { get; set; }

    public string? DocSerialNumber { get; set; }

    public int? ModelYear { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string Phone { get; set; } = null!;

    public int? CityId { get; set; }

    public string? CityName { get; set; }

    public int? CountyId { get; set; }

    public string? CountyName { get; set; }

    public int? Job { get; set; }

    public string? Gender { get; set; }

    public string? MaritalStatus { get; set; }

    public DateTime? DateofBirth { get; set; }

    public int? Status { get; set; }

    public string? AutomobileInsuranceReqNumber { get; set; }

    public string? TrafficInsuranceReqNumber { get; set; }

    public string? ResidenceReqNumber { get; set; }

    public string? DaskReqNumber { get; set; }

    public string? ForeignHealthyReqNumber { get; set; }

    public string? IndividualReqNumber { get; set; }

    public string? TssreqNumber { get; set; }

    public string? TravelHealthReqNumber { get; set; }

    public string? IncomingReqNumber { get; set; }

    public string? NurseReqNumber { get; set; }

    public string? PetReqNumber { get; set; }

    public string? TransportationReqNumber { get; set; }

    public string? PersonalAccidentReqNumber { get; set; }

    public string? UsedWarrantyReqNumber { get; set; }

    public bool IsSave { get; set; }

    public string? Notes { get; set; }

    public string? Tag { get; set; }

    public string? BrandCodeFull { get; set; }

    public DateTime? OperationStartDate { get; set; }

    public DateTime? OperationEndDate { get; set; }

    public DateTime? OperationDate { get; set; }

    public string? ApprovedQuery { get; set; }

    public string? ReqQueryType { get; set; }

    public int? OperationStatus { get; set; }

    public string? GeneratedId { get; set; }

    public string? AttachedFiles { get; set; }

    public string? Topic { get; set; }

    public string? VicinityCode { get; set; }

    public string? NeighborhoodCode { get; set; }

    public string? StreetCode { get; set; }

    public string? TownCode { get; set; }

    public string? FlatNo { get; set; }

    public string? CallbackUrl { get; set; }

    public string? SicilNo { get; set; }

    public string? CardNumber { get; set; }

    public string? CardName { get; set; }

    public string? CardSurname { get; set; }

    public string? CardMonth { get; set; }

    public string? CardYear { get; set; }

    public string? CardCvv { get; set; }

    public string? Guid { get; set; }

    public string? CallRecordPath { get; set; }

    public bool? IsCallRequest { get; set; }

    public bool? IsSentToCallCenter { get; set; }

    public string? EngineNo { get; set; }

    public string? FrameNo { get; set; }

    public string? Source { get; set; }

    public DateTime? CallDate { get; set; }

    public string? CustomName { get; set; }

    public int? CreatedUserId { get; set; }

    public int? CallRequestTypeId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual CallRequestTypes? CallRequestType { get; set; }
}
