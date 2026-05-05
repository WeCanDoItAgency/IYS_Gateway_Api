using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewCariKart
{
    public int Id { get; set; }

    public string? AccountCode { get; set; }

    public string? ParentAccountCode { get; set; }

    public int UserId { get; set; }

    public int SubeId { get; set; }

    public int FirmId { get; set; }

    public string? GuidKod { get; set; }

    public int TipKod { get; set; }

    public string? TcKimlikNo { get; set; }

    public string? VergiKimlikNo { get; set; }

    public string? PassaportNo { get; set; }

    public string? YabanciKimlikNo { get; set; }

    public string? Adi { get; set; }

    public string? Soyadi { get; set; }

    public string? Unvani { get; set; }

    public string? DogumYeri { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? Cinsiyet { get; set; }

    public string? AnneAdi { get; set; }

    public string? BabaAdi { get; set; }

    public int? PrivacyAgrementId { get; set; }

    public int? AdvertisementAggrementId { get; set; }

    public int? OpenDataAggrementId { get; set; }

    public string? UnicoMusterino { get; set; }

    public string? AnadoluMusterino { get; set; }

    public string? BereketMusterino { get; set; }

    public string? RayMusterino { get; set; }

    public string? GulfMusterino { get; set; }

    public string? AnkaraMusterino { get; set; }

    public string? AllianzMusterino { get; set; }

    public string? OrientMusterino { get; set; }

    public string? GroupamaMusterino { get; set; }

    public string? ZurichMusterino { get; set; }

    public string? LogoPath { get; set; }

    public bool? IsEvaluation1Confirmed { get; set; }

    public bool? IsEvaluation2Confirmed { get; set; }

    public bool? IsEvaluationAllConfirmed { get; set; }

    public bool IsControlled { get; set; }

    public byte ControlCount { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsMongoSync { get; set; }

    public DateTime? MongoSyncDate { get; set; }

    public string? MeslekKodu { get; set; }

    public string? Boy { get; set; }

    public string? Kilo { get; set; }

    public virtual ICollection<NewBankAccounts> NewBankAccounts { get; set; } = new List<NewBankAccounts>();

    public virtual ICollection<NewCariAddress> NewCariAddress { get; set; } = new List<NewCariAddress>();

    public virtual ICollection<NewCariMuhasebe> NewCariMuhasebe { get; set; } = new List<NewCariMuhasebe>();

    public virtual ICollection<NewContacts> NewContacts { get; set; } = new List<NewContacts>();

    public virtual ICollection<UserAgreementLogs> UserAgreementLogs { get; set; } = new List<UserAgreementLogs>();
}
