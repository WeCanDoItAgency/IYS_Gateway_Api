using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class VwSupportMessages
{
    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateTime CreateDate { get; set; }

    public string Message { get; set; } = null!;

    public string? Attachment { get; set; }

    public string? ProfilePicture { get; set; }

    public int RequestId { get; set; }

    public bool Manager { get; set; }
}
