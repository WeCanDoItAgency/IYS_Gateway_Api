using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BotQueueNames
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int? SktId { get; set; }

    public int SubbrandId { get; set; }

    public string? QueuePrefix { get; set; }

    public int QueryTypeId { get; set; }

    public bool IsActive { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? ReplicaNumber { get; set; }

    public int? ReplicaMin { get; set; }

    public int? ReplicaMax { get; set; }

    public string? Namespace { get; set; }

    public virtual NewSubBrands Subbrand { get; set; } = null!;
}
