using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AcikPortfoyOrtakTablo
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int BranchId { get; set; }

    public int KuserId { get; set; }

    public bool IsPolice { get; set; }

    public string? PoliceNo { get; set; }

    public DateTime CreateDate { get; set; }

    public string? MusteriAdi { get; set; }

    public string? MusteriSoyadi { get; set; }

    public string? MobilPhone { get; set; }

    public string? AracPlaka { get; set; }

    public string? AracRuhsatNo { get; set; }

    public string? MusteriVknNo { get; set; }

    public string? PasaportNo { get; set; }

    public string? Adres { get; set; }

    public string? UavtKodu { get; set; }

    public string? AracMotorNo { get; set; }

    public string? Marka { get; set; }

    public string? Model { get; set; }

    public int? SigortaId { get; set; }

    public string? QueryType { get; set; }

    public string? Email { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public DateTime? TanzimTarihi { get; set; }

    public DateTime? VadeBaslangic { get; set; }

    public DateTime? VadeBitis { get; set; }

    public int? Calisilanfirma { get; set; }

    public int? Calisilansube { get; set; }

    public int? Calisilanuser { get; set; }

    public bool? ZeyilGordu { get; set; }

    public int? FromPlaceId { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public Guid HeaderGuid { get; set; }

    public bool? TelefonSorgulandi { get; set; }

    public int? FirstUserId { get; set; }

    public int? FirstBranchId { get; set; }

    public int? FirstFirmId { get; set; }

    public DateTime? CallcenterSentDate { get; set; }

    public int? CallCenterSentUserId { get; set; }

    public string? SompoCompanyName { get; set; }

    public string? SompoRowData { get; set; }

    public string? SompoName { get; set; }

    public string? SompoSurname { get; set; }

    public string? SompoAdress { get; set; }

    public string? SompoPhoneNumber { get; set; }

    public bool? IsUpdated { get; set; }

    public string? AllianzPhoneNumber { get; set; }

    public bool? IsProcessCallcenterQue { get; set; }

    public virtual ICollection<AcikPortfoySendCallCenterLogs> AcikPortfoySendCallCenterLogs { get; set; } = new List<AcikPortfoySendCallCenterLogs>();
}
