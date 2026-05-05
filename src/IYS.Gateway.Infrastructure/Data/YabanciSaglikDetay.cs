using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class YabanciSaglikDetay
{
    public int Id { get; set; }

    public int? BaslikId { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public int SigortaId { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsPolice { get; set; }

    public string? MusteriNo { get; set; }

    public string? TeklifKodu { get; set; }

    public string? TrackingCode { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public double? Tutar { get; set; }

    public string? WbStatus { get; set; }

    public string? WbDescription { get; set; }

    public bool IsSuccess { get; set; }

    public string? OutputData { get; set; }

    public string? InputData { get; set; }

    public bool? IsMerkeztalep { get; set; }

    public int? PaketId { get; set; }

    public double? Commission { get; set; }

    public int? TaksitSayisi { get; set; }

    public string? EncryptedId { get; set; }

    public bool? IsSecondYear { get; set; }

    public int? ParentDetailId { get; set; }

    public bool IsSendForChange { get; set; }

    public string? ShowBrandAttributeList { get; set; }

    public string? InstallementList { get; set; }

    public int? CampaignId { get; set; }

    public int? CampaignRuleId { get; set; }

    public bool? IsAuthorization { get; set; }

    public int FromPlaceId { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? OfferPdfPath { get; set; }

    public DateTime? MongoSyncDate { get; set; }

    public bool? IsMongoSync { get; set; }

    public string? MongoId { get; set; }

    public Guid DetailGuid { get; set; }

    public string? Visitor { get; set; }

    public int? RdpBrandPartajId { get; set; }

    public string? PartajNo { get; set; }

    public int ZeyilNo { get; set; }

    public int TecditNo { get; set; }

    public bool IsRevize { get; set; }

    public bool? RevizeGordu { get; set; }

    public double? BrutPrim { get; set; }

    public double? NetPrim { get; set; }

    public Guid? PackageGuid { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public string? TeklifHash { get; set; }

    public bool? IsAutoVisitorProcess { get; set; }

    public virtual YabanciSaglikBaslik? Baslik { get; set; }

    public virtual ICollection<YsPoliceler> YsPoliceler { get; set; } = new List<YsPoliceler>();
}
