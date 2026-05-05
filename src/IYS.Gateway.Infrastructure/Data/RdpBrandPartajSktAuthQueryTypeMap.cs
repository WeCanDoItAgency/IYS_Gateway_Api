using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdpBrandPartajSktAuthQueryTypeMap
{
    public int Id { get; set; }

    public int? SktId { get; set; }

    public int? QueryTypeId { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? RdpBrandPartajSktAuthId { get; set; }

    public bool? TeklifSayfaGizlensinMi { get; set; }

    public bool? TeklifElementGizlensinMi { get; set; }

    public bool? OdemeSayfaGizlensinMi { get; set; }

    public bool? OdemeElementGizlensinMi { get; set; }

    public bool? UretimSayfaGosterilsinMi { get; set; }

    public bool? UretimElementGosterilsinMi { get; set; }

    public bool? TeklifSayfaGosterilsinMi { get; set; }

    public bool? TeklifElementGosterilsinMi { get; set; }

    public bool? OdemeSayfaGosterilsinMi { get; set; }

    public bool? OdemeElementGosterilsinMi { get; set; }

    public bool? ZeyilSayfaGosterilsinMi { get; set; }

    public bool? ZeyilElementGosterilsinMi { get; set; }

    public bool? HasarSayfaGosterilsinMi { get; set; }

    public bool? HasarElementGosterilsinMi { get; set; }

    public virtual NewQueryTypes? QueryType { get; set; }

    public virtual RdpBrandPartajSktAuthMap? RdpBrandPartajSktAuth { get; set; }

    public virtual Subeler? Skt { get; set; }
}
