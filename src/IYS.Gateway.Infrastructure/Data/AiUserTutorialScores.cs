using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AiUserTutorialScores
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TotalScore { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual Kullanicilar User { get; set; } = null!;
}
