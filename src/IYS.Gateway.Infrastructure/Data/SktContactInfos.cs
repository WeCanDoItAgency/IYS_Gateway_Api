using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class SktContactInfos
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public int SktId { get; set; }

    public int? UserId { get; set; }

    public string? Email { get; set; }

    public string? WpGroupId { get; set; }

    public string? CardName { get; set; }

    public string? CardSurname { get; set; }

    public string? CardNumber { get; set; }

    public string? CardExpiryDate { get; set; }

    public string? CardCvv { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool? IsActive { get; set; }

    public int ContactType { get; set; }

    public Guid FirmGuid { get; set; }

    public Guid SktGuid { get; set; }

    public Guid? UserGuid { get; set; }

    public string? TcVkn { get; set; }

    public string? SaltGuid { get; set; }

    public int? FirmCreditCardId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public virtual ICollection<SktContactCreditCardQueryTypeMap> SktContactCreditCardQueryTypeMap { get; set; } = new List<SktContactCreditCardQueryTypeMap>();

    public virtual ICollection<SktContactWpGroupNotificationTemplateMap> SktContactWpGroupNotificationTemplateMap { get; set; } = new List<SktContactWpGroupNotificationTemplateMap>();
}
