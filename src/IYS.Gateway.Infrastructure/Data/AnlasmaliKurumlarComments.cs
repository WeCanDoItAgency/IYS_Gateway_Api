using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AnlasmaliKurumlarComments
{
    public int Id { get; set; }

    public string? CommentContent { get; set; }

    public double? Point { get; set; }

    public int UserId { get; set; }

    public int AnlasmaliKurumId { get; set; }

    public bool IsApproved { get; set; }

    public bool IsActive { get; set; }

    public virtual Kullanicilar User { get; set; } = null!;
}
