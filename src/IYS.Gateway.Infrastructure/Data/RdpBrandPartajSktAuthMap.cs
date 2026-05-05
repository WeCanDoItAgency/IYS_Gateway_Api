using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdpBrandPartajSktAuthMap
{
    public int Id { get; set; }

    public int RdpBrandPartajId { get; set; }

    public int SktId { get; set; }

    public bool? IsAuth { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsForeignCompany { get; set; }

    public virtual NewRdpBrandPartajs RdpBrandPartaj { get; set; } = null!;

    public virtual ICollection<RdpBrandPartajSktAuthQueryTypeMap> RdpBrandPartajSktAuthQueryTypeMap { get; set; } = new List<RdpBrandPartajSktAuthQueryTypeMap>();

    public virtual Subeler Skt { get; set; } = null!;
}
