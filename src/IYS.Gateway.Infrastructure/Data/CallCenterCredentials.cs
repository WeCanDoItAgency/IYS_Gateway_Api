using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class CallCenterCredentials
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public bool IsActive { get; set; }

    public string? MantisApiKey { get; set; }

    public int AddedUserId { get; set; }

    public DateTime AddedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string MantisApiUrl { get; set; } = null!;

    public string? FromPhone { get; set; }

    public bool IsDefault { get; set; }

    public string? MantisUrl { get; set; }

    public virtual Kullanicilar AddedUser { get; set; } = null!;

    public virtual ICollection<CallCenterStatuses> CallCenterStatuses { get; set; } = new List<CallCenterStatuses>();

    public virtual Kullanicilar? UpdatedUser { get; set; }
}
