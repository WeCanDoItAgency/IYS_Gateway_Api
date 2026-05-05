using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class QueryRules
{
    public int Id { get; set; }

    public int? SktId { get; set; }

    public int? SktTypeId { get; set; }

    public int? SubBrandId { get; set; }

    public int QueryTypeId { get; set; }

    public int? FirmId { get; set; }

    public int QueryRulesActionTypeId { get; set; }

    public string? QueryRulesName { get; set; }

    public int Limit { get; set; }

    public bool IsActive { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual NewFirms? Firm { get; set; }

    public virtual Subeler? Skt { get; set; }

    public virtual BranchTypes? SktType { get; set; }

    public virtual NewSubBrands? SubBrand { get; set; }

    public virtual ICollection<SubQueryRules> SubQueryRules { get; set; } = new List<SubQueryRules>();
}
