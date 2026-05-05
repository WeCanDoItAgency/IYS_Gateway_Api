using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class PolicyInformationFiles
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public int QueryTypeId { get; set; }

    public string? FilePath { get; set; }

    public string? FileName { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }
}
