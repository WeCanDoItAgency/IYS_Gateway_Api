using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class NewManuelPolicies
{
    public int Id { get; set; }

    public int? ManuelOfferId { get; set; }

    public int? SellingType { get; set; }

    public DateTime? ArrangementDate { get; set; }

    public string? PolicyNumber { get; set; }

    public string? Description { get; set; }

    public bool? Status { get; set; }

    public int? InstallementCount { get; set; }

    public int? ZeyilNo { get; set; }

    public int? TecditNo { get; set; }

    public bool? IsMailOrder { get; set; }

    public string? CreditCardNo { get; set; }

    public string? CreaditCardOwnerName { get; set; }

    public string? CreditCardOwnerSurname { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreatedUserId { get; set; }

    public virtual NewManuelOffers? ManuelOffer { get; set; }

    public virtual ICollection<NewManuelPolicyPaymentDetails> NewManuelPolicyPaymentDetails { get; set; } = new List<NewManuelPolicyPaymentDetails>();
}
