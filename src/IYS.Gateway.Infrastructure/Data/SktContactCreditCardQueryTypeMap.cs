using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SktContactCreditCardQueryTypeMap
{
    public int Id { get; set; }

    public int SktContactInfosId { get; set; }

    public int QueryTypeId { get; set; }

    public string QueryType { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public virtual SktContactInfos SktContactInfos { get; set; } = null!;
}
