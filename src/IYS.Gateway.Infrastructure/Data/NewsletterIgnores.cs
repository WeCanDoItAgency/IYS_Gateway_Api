using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewsletterIgnores
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public DateTime CreateDate { get; set; }
}
