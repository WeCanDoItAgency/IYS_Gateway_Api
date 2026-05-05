using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UserAgreement
{
    public int Id { get; set; }

    public string SmallCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public int? UserId { get; set; }
}
