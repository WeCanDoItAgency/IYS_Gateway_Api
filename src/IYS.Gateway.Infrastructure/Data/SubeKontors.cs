using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SubeKontors
{
    public int Id { get; set; }

    public int SubeId { get; set; }

    public int YukleyenSubeId { get; set; }

    public int YukleyenUserId { get; set; }

    public double YuklenenKontor { get; set; }

    public DateTime CreateDate { get; set; }
}
