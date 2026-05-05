using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PackagesExceptCities
{
    public int Id { get; set; }

    public int? PackageId { get; set; }

    public int? CityCode { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public virtual UavtIl? CityCodeNavigation { get; set; }

    public virtual Kullanicilar? CreatedUser { get; set; }

    public virtual BrandAttributeGroup? Package { get; set; }

    public virtual Kullanicilar? UpdatedUser { get; set; }
}
