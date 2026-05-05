using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewAuthorizations
{
    public int Id { get; set; }

    public int? TypeId { get; set; }

    public string? ValueId { get; set; }

    public bool? IsAuth { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? DeleteUserId { get; set; }

    public bool? IsActive { get; set; }

    public virtual NewAuthorizationTypes? Type { get; set; }
}
