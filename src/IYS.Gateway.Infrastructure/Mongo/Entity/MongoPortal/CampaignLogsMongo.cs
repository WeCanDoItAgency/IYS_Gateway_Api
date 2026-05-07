using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

[BsonCollection("CampaignLogs")]
[BsonIgnoreExtraElements]
public class CampaignLogsMongo : MongoDbEntity
{
    public int MssqlId { get; set; }

    public int? FirmId { get; set; }

    public int? UserId { get; set; }

    public int? BranchId { get; set; }

    public int CampaignId { get; set; }

    public int? ExistRuleId { get; set; }

    public int? RuleId { get; set; }

    public int QueryTypeId { get; set; }

    public int HeaderId { get; set; }

    public int? DetailId { get; set; }

    public int? PaymentId { get; set; }

    public bool IsPolicy { get; set; }

    public DateTime? UseDate { get; set; }

    public DateTime? AppliedDate { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsFraud { get; set; }

    public string? IdentityNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerSurname { get; set; }

    public decimal? NetPrim { get; set; }

    public decimal? BrutPrim { get; set; }

    public decimal? Hakedis { get; set; }

    public bool IsApproved { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public string? ApprovedMessage { get; set; }

    public int? CodeSharedBy { get; set; }

    public DateTime? CodeSharedDate { get; set; }

    public decimal? CustomDiscount { get; set; }

    public bool MtLog { get; set; }

    public bool IsMtRequestApprove { get; set; }

    public int? MtRequestApprovedBy { get; set; }

    public DateTime? MtRequestApprovedDate { get; set; }

    public string? MtRequestApproveMessage { get; set; }

    public int? SigortaId { get; set; }

    public int? CodeId { get; set; }

    public bool? IsNotApproved { get; set; }

    public string? NotApprovedReason { get; set; }

    public int? NotApprovedBy { get; set; }

    public DateTime? NotApprovedDate { get; set; }

    public string? ReferansCode { get; set; }

    public string? PolicyNo { get; set; }

    public bool? IsApprovedManuel { get; set; }

    public Guid? HeaderGuid { get; set; }

    public string? HeaderGuidStr { get; set; }

    public Guid? DetailGuid { get; set; }

    public string? DetailGuidStr { get; set; }

    public Guid? PaymentGuid { get; set; }

    public string? PaymentGuidStr { get; set; }

    // --- Mongo Reference Fields ---
    [BsonRepresentation(BsonType.ObjectId)]
    public string? FirmMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? UserMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? BranchMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? QueryTypeMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? CreatedUserMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? UpdatedUserMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? SigortaMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? CampaignMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? ExistRuleMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? RuleMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? ApprovedByMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? CodeSharedByMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? MtRequestApprovedByMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? NotApprovedByMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? CodeMongoId { get; set; }

}
