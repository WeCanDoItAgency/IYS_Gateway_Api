using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UserRoles
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public int? Priority { get; set; }

    public string? Description { get; set; }
}
