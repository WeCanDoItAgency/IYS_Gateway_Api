using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Trainings
{
    public int Id { get; set; }

    public string EgitimAdi { get; set; } = null!;

    public string EgitimKonusu { get; set; } = null!;

    public DateTime BaslangicTarihi { get; set; }

    public DateTime BitisTarihi { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<TrainingAttenders> TrainingAttenders { get; set; } = new List<TrainingAttenders>();

    public virtual ICollection<TrainingsInsurances> TrainingsInsurances { get; set; } = new List<TrainingsInsurances>();

    public virtual ICollection<TrainingsTrainer> TrainingsTrainer { get; set; } = new List<TrainingsTrainer>();
}
