using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BotStatuss
{
    public int Id { get; set; }

    public int BotType { get; set; }

    public DateTime LastHeartBeat { get; set; }
}
