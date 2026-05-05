using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class EgmqueryHistory
{
    public int Id { get; set; }

    public string? NationalNumber { get; set; }

    public string? LicencePermitNumber { get; set; }

    public string? LicensePlateNumber { get; set; }

    public int? UserId { get; set; }

    public int? SubeId { get; set; }

    public string? PriceIdentityCode { get; set; }

    public decimal? Price { get; set; }

    public DateTime? QueryDate { get; set; }

    public bool? IsEgm { get; set; }

    public bool? IsKm { get; set; }

    public bool? IsParca { get; set; }

    public bool? IsHasar { get; set; }

    public bool? IsTramer { get; set; }

    public byte? IsEgmbotStatus { get; set; }

    public byte? IsKmBotStatus { get; set; }

    public byte? IsParcaBotStatus { get; set; }

    public byte? IsHasarBotStatus { get; set; }

    public byte? IsTramerBotStatus { get; set; }

    public long? AracId { get; set; }

    public virtual AracKartlar? Arac { get; set; }

    public virtual ICollection<AracDegisenParca> AracDegisenParca { get; set; } = new List<AracDegisenParca>();

    public virtual ICollection<AracHasarBilgisi> AracHasarBilgisi { get; set; } = new List<AracHasarBilgisi>();

    public virtual ICollection<AracKaskosuzDonem> AracKaskosuzDonem { get; set; } = new List<AracKaskosuzDonem>();

    public virtual ICollection<AracKm> AracKm { get; set; } = new List<AracKm>();
}
