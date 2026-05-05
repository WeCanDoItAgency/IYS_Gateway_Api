using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UavtIl
{
    public int Kodu { get; set; }

    public string? Adi { get; set; }

    public int? CountryId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public Guid Guid { get; set; }

    public virtual ICollection<PackagesExceptCities> PackagesExceptCities { get; set; } = new List<PackagesExceptCities>();

    public virtual ICollection<Subeler> Subeler { get; set; } = new List<Subeler>();

    public virtual ICollection<UavtKoyler> UavtKoyler { get; set; } = new List<UavtKoyler>();
}
