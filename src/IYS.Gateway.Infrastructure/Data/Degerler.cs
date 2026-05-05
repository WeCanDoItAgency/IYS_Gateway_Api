using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Degerler
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int SigortaId { get; set; }

    public int ListId { get; set; }

    public string ValueId { get; set; } = null!;

    public string? TipId { get; set; }

    public string? OzelKod { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool? IsActive { get; set; }
}
