using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Talepler
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? BranchId { get; set; }

    public int? UserId { get; set; }

    public int? ManualAssignedUserId { get; set; }

    public DateTime? ManualAssigmentDate { get; set; }

    public int? AssignedUserId { get; set; }

    public int? QueryId { get; set; }

    public int? DepartmentId { get; set; }

    public int? RequestType { get; set; }

    public bool? Status { get; set; }

    public int? TalepStatusId { get; set; }

    public long? UretimPoliceId { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public string? DamageFileNo { get; set; }

    public decimal? MuallakAmount { get; set; }

    public decimal? PaidAmount { get; set; }

    public DateTime? PaidAmountDate { get; set; }

    public string? UploadFile { get; set; }

    public string? UploadFilePath { get; set; }

    public string? FilePath { get; set; }

    public int? OperationStatus { get; set; }

    public int? PriorityStatus { get; set; }

    public string? VehiclePlate { get; set; }

    public string? PolicyNo { get; set; }

    public int? InsuranceId { get; set; }

    public string? NationalNumber { get; set; }

    public string? NameSurname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? LicencePermitNumber { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool? IsActive { get; set; }

    public string? ExpertiseGuid { get; set; }

    public int? ParentId { get; set; }

    public int? HeaderId { get; set; }

    public int? DetailId { get; set; }

    public int? ContactGroup { get; set; }

    public int? Location { get; set; }

    public int? PaymentId { get; set; }

    public int? Il { get; set; }

    public int? Ilce { get; set; }

    public string? NoterAdi { get; set; }

    public string? NoterNumarasi { get; set; }

    public DateTime? SatisTarihi { get; set; }

    public int? FromplaceId { get; set; }

    public int? SmsQrId { get; set; }

    public Guid TalepGuid { get; set; }

    public string? ConversationId { get; set; }

    public string? CarQueryResponseId { get; set; }

    public bool? IsIptalControl { get; set; }

    public string? CenterWaitingMongoId { get; set; }

    public Guid? HeaderGuid { get; set; }

    public Guid? DetailGuid { get; set; }

    public Guid? PaymentGuid { get; set; }

    public int? AutoSystemRetryCount { get; set; }

    public int? AddendumStatusType { get; set; }

    public virtual Departments? Department { get; set; }

    public virtual ICollection<Talepler> InverseParent { get; set; } = new List<Talepler>();

    public virtual Talepler? Parent { get; set; }

    public virtual ICollection<TalepDetay> TalepDetay { get; set; } = new List<TalepDetay>();
}
