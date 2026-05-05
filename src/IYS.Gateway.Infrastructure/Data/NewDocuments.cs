using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewDocuments
{
    public int Id { get; set; }

    public int? BranchId { get; set; }

    public int? FirmId { get; set; }

    public int? UserId { get; set; }

    public int? CariKartId { get; set; }

    public int? QueryTypeId { get; set; }

    public int? Type { get; set; }

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    public string? FolderName { get; set; }

    public int? EntityId { get; set; }

    public string? TableName { get; set; }

    public int? TableId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? CenterWaitingMongoId { get; set; }

    public virtual DocumentTypes? TypeNavigation { get; set; }
}
