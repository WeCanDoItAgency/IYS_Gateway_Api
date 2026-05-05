using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AiTutorialDefinitions
{
    public int Id { get; set; }

    public string TutorialCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual ICollection<AiTutorialSteps> AiTutorialSteps { get; set; } = new List<AiTutorialSteps>();
}
