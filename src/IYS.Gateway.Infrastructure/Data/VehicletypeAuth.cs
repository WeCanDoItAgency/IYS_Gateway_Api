using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class VehicletypeAuth
{
    public int Id { get; set; }

    public int SigortaId { get; set; }

    public string Querytype { get; set; } = null!;

    public int GroupId { get; set; }

    public int AractipiId { get; set; }

    public bool IsAuth { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public bool? IsActive { get; set; }
}
