using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TrainingsTrainer
{
    public int Id { get; set; }

    public int TrainerId { get; set; }

    public int TrainingId { get; set; }

    public virtual Kullanicilar Trainer { get; set; } = null!;

    public virtual Trainings Training { get; set; } = null!;
}
