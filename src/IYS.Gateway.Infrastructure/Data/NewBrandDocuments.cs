using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewBrandDocuments
{
    public int Id { get; set; }

    public int? QueryTypeId { get; set; }

    public int? BrandId { get; set; }

    public string? DocumentName { get; set; }

    public string? DocumentPath { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? DeleteUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsNew { get; set; }

    public virtual NewBrands? Brand { get; set; }

    public virtual NewQueryTypes? QueryType { get; set; }
}
