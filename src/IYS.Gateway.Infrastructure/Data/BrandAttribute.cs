using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class BrandAttribute
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public int BrandId { get; set; }

    public int ControlTypeId { get; set; }

    public int DisplayOrder { get; set; }

    public string? ApiName { get; set; }

    public string? BotApiName { get; set; }

    public string? QueryType { get; set; }

    public int? VehicleType { get; set; }

    public int? UserId { get; set; }

    public bool? PolicyDetailVisible { get; set; }

    public bool? CompareVisible { get; set; }

    public bool? DescriptionVisible { get; set; }

    public bool DontSendApi { get; set; }

    public bool IsSendBot { get; set; }

    public string? DescriptionForRequest { get; set; }

    public int? SyncReferenceAttributeId { get; set; }

    public int? CreatedUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? ShowInAcente { get; set; }

    public bool? ShowInDijipol { get; set; }

    public bool? ShowInCenterWaiting { get; set; }

    public bool? ShowInFilter { get; set; }

    public bool? IsMandatory { get; set; }

    public bool? IsActive { get; set; }

    public bool? ReWorkIfInstallmentChanges { get; set; }

    public int? BrandAttributeType { get; set; }

    public string? BotEqualsName { get; set; }

    public string? ServicePropertyName { get; set; }

    public virtual ICollection<BrandAttibuteGroupTypeIsShowCwmap> BrandAttibuteGroupTypeIsShowCwmap { get; set; } = new List<BrandAttibuteGroupTypeIsShowCwmap>();

    public virtual ICollection<BrandAttributeGroupValues> BrandAttributeGroupValues { get; set; } = new List<BrandAttributeGroupValues>();

    public virtual ICollection<BrandAttributeValue> BrandAttributeValue { get; set; } = new List<BrandAttributeValue>();
}
