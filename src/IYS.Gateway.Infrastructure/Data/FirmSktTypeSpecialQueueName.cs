using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FirmSktTypeSpecialQueueName
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int SktTypeId { get; set; }

    public string? SpecialName { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }
}
