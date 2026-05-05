using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class FirmCreditCardInfos
{
    public int Id { get; set; }

    public int FirmId { get; set; }

    public string EncCreditCardNumber { get; set; } = null!;

    public string EncCreditCardExpiryDate { get; set; } = null!;

    public string EncCreditCardMonth { get; set; } = null!;

    public string EncCreditCardYear { get; set; } = null!;

    public string EncCreditCardCvv { get; set; } = null!;

    public string SaltGuid { get; set; } = null!;

    public string CardOwnerName { get; set; } = null!;

    public string CardOwnerSurname { get; set; } = null!;

    public string? Aciklama { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedUserId { get; set; }

    public bool IsActive { get; set; }
}
