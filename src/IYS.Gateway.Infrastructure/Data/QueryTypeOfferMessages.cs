using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class QueryTypeOfferMessages
{
    public int Id { get; set; }

    public int? QueryTypeId { get; set; }

    public string? Message { get; set; }

    public int? DisplayOrder { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }
}
