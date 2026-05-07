using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using IYS.Gateway.Infrastructure.Mongo.Entity;

using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
namespace IYS.Gateway.Infrastructure.Mongo.Entity.MongoPortal;

[BsonCollection("NewFirms")]
[BsonIgnoreExtraElements]
public class NewFirmsMongo : MongoDbEntity
{

    public int MssqlId { get; set; }

    public string? FullName { get; set; }

    public string? Title { get; set; }

    public string? TaxOffice { get; set; }

    public string? NationalNumber { get; set; }

    public string? TaxNumber { get; set; }

    public string? Email { get; set; }

    public string? AuthorizedName { get; set; }

    public string? AuthorizedSurname { get; set; }

    public string? ProxyAddress { get; set; }

    public string? ProxyPort { get; set; }

    public string? ProxyUsername { get; set; }

    public string? ProxyPassword { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public int? CountyId { get; set; }

    public string? AddressDetail { get; set; }

    public string? LogoPath { get; set; }

    public int StatusId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? WorkPhone { get; set; }

    public string? RegistrationNo { get; set; }

    public string? MersisNo { get; set; }

    public string? KepAddress { get; set; }

    public bool? CanOpenSubbranch { get; set; }

    public string? IpAddress { get; set; }

    public bool? IsBlackList { get; set; }

    public bool? IsRdp { get; set; }

    public string? SignatureImageName { get; set; }

    public string? ApiBaseUrl { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? DeleteUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? IsActive { get; set; }

    public string? ProductionProcessName { get; set; }

    public string? FirmEmailExtension { get; set; }

    public bool? CanUseBot { get; set; }

    public Guid FirmGuid { get; set; }


    public string? FirmGuidStr { get; set; }

    public bool? KomisyonGizlensinMi { get; set; }

    public bool? SmpSorgudanBeslensinMi { get; set; }

    public bool? EmailRastgeleMi { get; set; }

    public string? RastgeleEmailDomain { get; set; }

    public bool? IsAutoWorker { get; set; }

    public bool? CanUseVirtualSign { get; set; }

    public string? VirtualSignLogoPath { get; set; }

    public bool? IsSendWhatsappNotificationPerm { get; set; }

    public bool? CagriMerkeziGorebilirMi { get; set; }

    public string? IysUsername { get; set; }

    public string? IysPassword { get; set; }

    public string? IysBrand { get; set; }

    public string? IysCustomerCode { get; set; }

    public bool? IsIysSystemActive { get; set; }

    public bool? ZeyilKullanabilirMi { get; set; }

    public string? FirmSiteUrl { get; set; }

    public string? ShortLinkDomainUrl { get; set; }

    public bool? WhatsappOtpGonderilecekMi { get; set; }

    public bool IsSeeChatBot { get; set; }

    public string? SunucuAdi { get; set; }

    public string? SunucuIp { get; set; }

    public bool? AltFirmaMi { get; set; }

    public int? UstFirmId { get; set; }

    public string? WpGroupId { get; set; }

    public bool? DemoMod { get; set; }

    // --- Mongo Reference Fields ---
    [BsonRepresentation(BsonType.ObjectId)]
    public string? CreatedUserMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? DeleteUserMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? UpdateUserMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? UstFirmMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? CityMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? CountyMongoId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? CountryMongoId { get; set; }

}
