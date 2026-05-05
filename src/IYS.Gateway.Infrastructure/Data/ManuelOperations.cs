using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ManuelOperations
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int UserId { get; set; }

    public int CalisilanFirmId { get; set; }

    public int CalisilanBranchId { get; set; }

    public int CalisilanUserId { get; set; }

    public string? PolicyNumber { get; set; }

    public string? QueryType { get; set; }

    public string? NationalNumber { get; set; }

    public string? PlateNumber { get; set; }

    public string? PermitNumber { get; set; }

    public string? UavtNo { get; set; }

    public DateTime? ArrangementDate { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int SubBrandId { get; set; }

    public double? GrossPremium { get; set; }

    public double? NetPremium { get; set; }

    public int? Installement { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? PaymentId { get; set; }

    public int? HeaderId { get; set; }

    public int? DetailId { get; set; }

    public bool IsCanceled { get; set; }

    public int? CancelledUserId { get; set; }

    public DateTime? CanceledDate { get; set; }

    public string? CanceledNote { get; set; }

    public int? CountryId { get; set; }

    public Guid? HeaderGuid { get; set; }

    public Guid? DetailGuid { get; set; }

    public string? MotorNo { get; set; }

    public string? SasiNo { get; set; }

    public bool IsVerified { get; set; }

    public string? NonApprovalReason { get; set; }

    public int? VerifiedUserId { get; set; }

    public DateTime? VerifiedDate { get; set; }

    public string? PolicyFilePath { get; set; }

    public string? ReceiptFilePath { get; set; }

    public int FromPlaceId { get; set; }

    public int? MerkezeSorId { get; set; }

    public string? MerkezeSorAciklama { get; set; }

    public bool? IsChangedToUnverified { get; set; }

    public int? Status { get; set; }

    public bool? OnaylanmadiAmaOlustu { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public string? CenterWaitingMongoId { get; set; }

    public bool? SirketKartiMi { get; set; }

    public int? FirmCreditCardInfoId { get; set; }
}
