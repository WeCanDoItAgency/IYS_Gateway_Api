using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewProjectOffers
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int? TypeId { get; set; }

    public bool? IsProjectCompleted { get; set; }

    public int? KullanicilarTokenId { get; set; }

    public int? SelectedFirmId { get; set; }

    public int? SelectedSubeId { get; set; }

    public int? SelectedUserId { get; set; }

    public string? CompanyName { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string Description { get; set; } = null!;

    public string Note { get; set; } = null!;

    public DateTime? ValidDate { get; set; }

    public bool? IsSendEmail { get; set; }

    public DateTime? ProjectCompletionDate { get; set; }

    public bool? IsServicesSent { get; set; }

    public DateTime? ServiceSentDate { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }
}
