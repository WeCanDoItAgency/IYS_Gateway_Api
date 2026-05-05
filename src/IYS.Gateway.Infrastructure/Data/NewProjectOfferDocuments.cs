using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewProjectOfferDocuments
{
    public int Id { get; set; }

    public int? FirmId { get; set; }

    public int? SubeId { get; set; }

    public int? UserId { get; set; }

    public int? ProjectOfferId { get; set; }

    public string? DocumentName { get; set; }

    public string? FileUrl { get; set; }

    public string? Description { get; set; }

    public string? Token { get; set; }

    public int? TokenType { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsNew { get; set; }
}
