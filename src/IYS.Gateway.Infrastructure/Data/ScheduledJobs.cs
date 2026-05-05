using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ScheduledJobs
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SktId { get; set; }

    public int? UserId { get; set; }

    public int OfferStatusId { get; set; }

    public int OldHeaderId { get; set; }

    public int? HeaderId { get; set; }

    public Guid? OldHeaderGuid { get; set; }

    public Guid? HeaderGuid { get; set; }

    public int? ExpertiseRequestId { get; set; }

    public DateTime CreateDate { get; set; }

    public string QueryType { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateTime? Birthdate { get; set; }

    public string? Uavt { get; set; }

    public string NationalNumber { get; set; } = null!;

    public string? LicensePlateNumber { get; set; }

    public string? LicensePermitNumber { get; set; }

    public string? EngineNumber { get; set; }

    public string? ChasisNumber { get; set; }

    public bool EmailSent { get; set; }

    public DateTime? EmailSentAt { get; set; }

    public bool SmsSent { get; set; }

    public DateTime? SmsSentAt { get; set; }

    public bool CallCenterSent { get; set; }

    public DateTime? CallCenterSentAt { get; set; }

    public bool? SendEmail { get; set; }

    public bool? SendSms { get; set; }

    public string? Source { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool IsRenew { get; set; }

    public bool IsQueried { get; set; }

    public DateTime? QueryDate { get; set; }

    public bool IsSold { get; set; }

    public DateTime? SoldDate { get; set; }

    public DateTime? TrafikSonKontrol { get; set; }

    public DateTime? ImmSonKontrol { get; set; }

    public DateTime? KaskoSonKontrol { get; set; }

    public DateTime? KaskoWorkDate { get; set; }

    public DateTime? TrafikWorkDate { get; set; }

    public DateTime? ImmWorkDate { get; set; }

    public bool? KaskoOffersGenerated { get; set; }

    public DateTime? KaskoOffersGeneratedAt { get; set; }

    public bool? TrafikOffersGenerated { get; set; }

    public DateTime? TrafikOffersGeneratedAt { get; set; }

    public string? HeaderLogMessage { get; set; }

    public int? BusinessRuleLogId { get; set; }

    public DateTime? TamamlayiciSonKontrol { get; set; }

    public DateTime? TamamlayiciWorkDate { get; set; }

    public bool? TamamlayiciOffersGenerated { get; set; }

    public DateTime? TamamlayiciOffersGeneratedAt { get; set; }

    public DateTime? KonutSonKontrol { get; set; }

    public DateTime? KonutWorkDate { get; set; }

    public bool? KonutOffersGenerated { get; set; }

    public DateTime? KonutOffersGeneratedAt { get; set; }

    public DateTime? DaskSonKontrol { get; set; }

    public DateTime? DaskWorkDate { get; set; }

    public bool? DaskOffersGenerated { get; set; }

    public DateTime? DaskOffersGeneratedAt { get; set; }

    public DateTime? BireyselSonKontrol { get; set; }

    public DateTime? BireyselWorkDate { get; set; }

    public bool? BireyselOffersGenerated { get; set; }

    public DateTime? BireyselOffersGeneratedAt { get; set; }

    public DateTime? OutgoingSonKontrol { get; set; }

    public DateTime? OutgoingWorkDate { get; set; }

    public bool? OutgoingOffersGenerated { get; set; }

    public DateTime? OutgoingOffersGeneratedAt { get; set; }

    public DateTime? PetSonKontrol { get; set; }

    public DateTime? PetWorkDate { get; set; }

    public bool? PetOffersGenerated { get; set; }

    public DateTime? PetOffersGeneratedAt { get; set; }

    public DateTime? YssonKontrol { get; set; }

    public DateTime? YsworkDate { get; set; }

    public bool? YsoffersGenerated { get; set; }

    public DateTime? YsoffersGeneratedAt { get; set; }

    public DateTime? CepSonKontrol { get; set; }

    public DateTime? CepWorkDate { get; set; }

    public bool? CepOffersGenerated { get; set; }

    public DateTime? CepOffersGeneratedAt { get; set; }

    public bool? BizdenmiPolicelestiTrafik { get; set; }

    public bool? BizdenmiPolicelestiKasko { get; set; }

    public DateTime? MonthlyScanDate { get; set; }

    public DateTime? OngoingPolicyTraffic { get; set; }

    public DateTime? OngoingPolicyImm { get; set; }

    public DateTime? OngoingPolicyKasko { get; set; }

    public DateTime? OngoingPolicyTamamlayici { get; set; }

    public DateTime? OngoingPolicyKonut { get; set; }

    public DateTime? CallcenterSentDate { get; set; }

    public int? CallCenterSentUserId { get; set; }

    public bool? BizdenmiPolicelestiDs { get; set; }

    public bool? IsEgmsorun { get; set; }

    public string? Egmmessage { get; set; }

    public DateTime? OngoingPolicyDask { get; set; }

    public bool? IsSendControl { get; set; }

    public DateTime? SendControlDate { get; set; }

    public DateTime? CommonWorkDate { get; set; }

    public bool? BizdenMiPolicelestiGenel { get; set; }

    public DateTime? OngoingPolicyDiger { get; set; }

    public bool? IsPolicyDiger { get; set; }

    public bool? IsPolicyKasko { get; set; }

    public bool? IsPolicyTrafik { get; set; }

    public bool? IsProcessCallcenterQue { get; set; }

    public bool? ControledReportTrafik { get; set; }

    public bool? ControledReportKasko { get; set; }

    public bool? ControledReportDiger { get; set; }

    public int? ModelYear { get; set; }

    public DateTime? Mantis { get; set; }

    public int? CalisilanUser { get; set; }

    public int? CalisilanSube { get; set; }

    public int? CalisilanFirma { get; set; }

    public string? BaslikEskiPolice { get; set; }

    public int? BaslikMeslek { get; set; }

    public bool? EgmdenGecmedi { get; set; }

    public bool? OldHeaderScheduleJobsOldHeaderMapTasindi { get; set; }

    public virtual ICollection<AracPoliceHistory> AracPoliceHistory { get; set; } = new List<AracPoliceHistory>();

    public virtual ICollection<ScheduleJobsHeader> ScheduleJobsHeader { get; set; } = new List<ScheduleJobsHeader>();
}
