using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CenterWaitingMessages
{
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public int CenterWaitingId { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool Seen { get; set; }

    public virtual MerkezTalepler CenterWaiting { get; set; } = null!;

    public virtual Kullanicilar CreatedUser { get; set; } = null!;
}
