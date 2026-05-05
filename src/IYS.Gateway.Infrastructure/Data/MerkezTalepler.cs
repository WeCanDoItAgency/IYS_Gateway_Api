using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class MerkezTalepler
{
    public int Id { get; set; }

    public string QueryType { get; set; } = null!;

    public int IslemId { get; set; }

    public Guid? DetailGuid { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public int SigortaId { get; set; }

    public string? PoliceNo { get; set; }

    public bool IsClosed { get; set; }

    public DateTime? SorguDate { get; set; }

    public double Tutar { get; set; }

    public string? Aciklama { get; set; }

    public int Durumu { get; set; }

    public int? TuserId { get; set; }

    public int? TbranchId { get; set; }

    public int? PoliceId { get; set; }

    public int? RequestType { get; set; }

    public int? TakenOnUserId { get; set; }

    public DateTime? TakenOnDate { get; set; }

    public string? ErrorMessage { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public string? BotErrorMessage { get; set; }

    public DateTime? BotTakenOnDate { get; set; }

    public int? BotTakenOnUserId { get; set; }

    public DateTime? BotSorguDate { get; set; }

    public int? IvrResponseId { get; set; }

    public string? ExpertiseGuid { get; set; }

    public int? RefCenterWaitingId { get; set; }

    public string? MusteriAdi { get; set; }

    public string? KimlikNo { get; set; }

    public string? Plaka { get; set; }

    public int? CenterWaitingType { get; set; }

    public int? ChatLastStatus { get; set; }

    public bool IsManuelClosed { get; set; }

    public int? TakenOnForCreatePolicyUserId { get; set; }

    public string? TeklifNo { get; set; }

    public bool IsCanceled { get; set; }

    public int? CancelledUserId { get; set; }

    public DateTime? CanceledDate { get; set; }

    public string? CanceledNote { get; set; }

    public int? CarAge { get; set; }

    public bool? IsAuthorization { get; set; }

    public int? FromPlaceId { get; set; }

    public Guid? HeaderGuid { get; set; }

    public Guid? PackageGuid { get; set; }

    public bool? SubbrandIsWebService { get; set; }

    public double? BrutPrim { get; set; }

    public double? NetPrim { get; set; }

    public int? RetrySendToBotCount { get; set; }

    public int? IstakipTalepId { get; set; }

    public bool? AutoSystemProcessing { get; set; }

    public bool? IsChangedForSync { get; set; }

    public virtual ICollection<CenterWaitingFiles> CenterWaitingFiles { get; set; } = new List<CenterWaitingFiles>();

    public virtual ICollection<CenterWaitingMessages> CenterWaitingMessages { get; set; } = new List<CenterWaitingMessages>();

    public virtual ICollection<CenterWaitingModifiedAttributeValues> CenterWaitingModifiedAttributeValues { get; set; } = new List<CenterWaitingModifiedAttributeValues>();
}
