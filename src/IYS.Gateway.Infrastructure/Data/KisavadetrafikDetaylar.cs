using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class KisavadetrafikDetaylar
{
    public int Id { get; set; }

    public int BaslikId { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public int SigortaId { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsSorgu { get; set; }

    public DateTime? SorguDate { get; set; }

    public bool IsTeklif { get; set; }

    public DateTime? TeklifDate { get; set; }

    public bool IsPolice { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public string? TeklifKodu { get; set; }

    public double? BrutPrim { get; set; }

    public double? NetPrim { get; set; }

    public string? MusteriKod { get; set; }

    public string? WbStatus { get; set; }

    public bool IsSuccess { get; set; }

    public bool IsMerkeztalep { get; set; }

    public int? PaketId { get; set; }

    public string? TaksitSayisi { get; set; }

    public double? Commission { get; set; }

    public string? TeklifHash { get; set; }

    public string? EncryptedId { get; set; }

    public int? ParentDetailId { get; set; }

    public bool IsSendForChange { get; set; }

    public int? CampaignId { get; set; }

    public int? CampaignRuleId { get; set; }

    public string? InputData { get; set; }

    public string? OutputData { get; set; }

    public bool? IsAuthorization { get; set; }

    public int FromPlaceId { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? MongoSyncDate { get; set; }

    public bool? IsMongoSync { get; set; }

    public string? MongoId { get; set; }

    public Guid DetailGuid { get; set; }

    public string? Visitor { get; set; }

    public int? RdpBrandPartajId { get; set; }

    public string? PartajNo { get; set; }

    public int ZeyilNo { get; set; }

    public int TecditNo { get; set; }

    public bool RevizeGordu { get; set; }

    public string? TrackingCode { get; set; }

    public Guid? PackageGuid { get; set; }

    public string? WbDescription { get; set; }

    public string? OfferPdfPath { get; set; }

    public string? ShowBrandAttributeList { get; set; }

    public string? InstallementList { get; set; }

    public bool? IsAutoVisitorProcess { get; set; }

    public virtual KisavadetrafikBasliklar Baslik { get; set; } = null!;

    public virtual ICollection<KisavadetrafikPoliceler> KisavadetrafikPoliceler { get; set; } = new List<KisavadetrafikPoliceler>();
}
