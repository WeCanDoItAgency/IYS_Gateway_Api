using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TrainingsInsurances
{
    public int Id { get; set; }

    public int SigortaId { get; set; }

    public int TrainingId { get; set; }

    public virtual NewSubBrands Sigorta { get; set; } = null!;

    public virtual Trainings Training { get; set; } = null!;
}
