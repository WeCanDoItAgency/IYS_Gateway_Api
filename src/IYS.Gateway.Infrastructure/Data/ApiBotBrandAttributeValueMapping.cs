using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class ApiBotBrandAttributeValueMapping
{
    public int Id { get; set; }

    public int BotAttributeValueId { get; set; }

    public int ApiAttributeValueId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }
}
