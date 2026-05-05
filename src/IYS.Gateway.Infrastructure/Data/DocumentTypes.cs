using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class DocumentTypes
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? OldTableName { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<NewDocuments> NewDocuments { get; set; } = new List<NewDocuments>();
}
