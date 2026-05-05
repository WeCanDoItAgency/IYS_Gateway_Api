using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class UserSeeAuths
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? QueryType { get; set; }

    public bool? IsAuth { get; set; }

    public string? Type { get; set; }
}
