using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TrainingAttenders
{
    public int Id { get; set; }

    public int TrainingAttender { get; set; }

    public int TrainingId { get; set; }

    public virtual Trainings Training { get; set; } = null!;

    public virtual Kullanicilar TrainingAttenderNavigation { get; set; } = null!;
}
