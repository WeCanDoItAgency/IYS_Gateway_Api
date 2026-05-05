using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AiTutorialSteps
{
    public int Id { get; set; }

    public int TutorialDefinitionId { get; set; }

    public string TargetElement { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Placement { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; }

    public virtual AiTutorialDefinitions TutorialDefinition { get; set; } = null!;
}
