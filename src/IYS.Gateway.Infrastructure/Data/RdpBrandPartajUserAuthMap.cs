using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class RdpBrandPartajUserAuthMap
{
    public int Id { get; set; }

    public int? RdpBrandPartajId { get; set; }

    public int? UserId { get; set; }

    public bool? IsAuth { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual NewRdpBrandPartajs? RdpBrandPartaj { get; set; }

    public virtual ICollection<RdpBrandPartajUserQueryTypeAuthMap> RdpBrandPartajUserQueryTypeAuthMap { get; set; } = new List<RdpBrandPartajUserQueryTypeAuthMap>();
}
