using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class DublicateLogin
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string OldIpAddress { get; set; } = null!;

    public string NewIpAddress { get; set; } = null!;

    public DateTime TokenOldCreatedDate { get; set; }

    public DateTime CreatedDate { get; set; }
}
