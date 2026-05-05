using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Usersloger
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int SubeId { get; set; }

    public int UserId { get; set; }

    public bool IsWbsrc { get; set; }

    public bool IsDesktop { get; set; }

    public int AgentId { get; set; }

    public DateTime CDate { get; set; }
}
