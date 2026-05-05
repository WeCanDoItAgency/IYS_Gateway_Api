using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class Goals
{
    public int Id { get; set; }

    public string? GoalName { get; set; }

    public string? GoalGuid { get; set; }

    public int GoalType { get; set; }

    public int FirmId { get; set; }

    public int? SktId { get; set; }

    public int? QueryTypeId { get; set; }

    public int? UserId { get; set; }

    public int? InsuranceFirmId { get; set; }

    public int? ExpectedTargetPiece { get; set; }

    public decimal? ExpectedTargetAmount { get; set; }

    public double? PremiumLessThan60PercentAmountPercentage { get; set; }

    public double? PremiumBetween60and80PercentAmountPercentage { get; set; }

    public double? PremiumBetween80and100PercentAmountPercentage { get; set; }

    public double? PremiumCompleted100PercentAmountPercentage { get; set; }

    public double? PremiumLessThan60PercentPiecePercentage { get; set; }

    public double? PremiumBetween60and80PercentPiecePercentage { get; set; }

    public double? PremiumBetween80and100PercentPiecePercentage { get; set; }

    public double? PremiumCompleted100PercentPiecePercentage { get; set; }

    public DateTime GoalStartDate { get; set; }

    public DateTime GoalEndDate { get; set; }

    public bool IsActive { get; set; }

    public int CreateUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? ApprovedByUserId { get; set; }

    public DateTime? ApproveDate { get; set; }

    public bool IsApproved { get; set; }

    public double? PremiumCompleted130PercentAmountPercentage { get; set; }

    public double? PremiumCompleted160PercentAmountPercentage { get; set; }

    public double? PremiumCompleted130PercentPiecePercentage { get; set; }

    public double? PremiumCompleted160PercentPiecePercentage { get; set; }

    public virtual Kullanicilar? ApprovedByUser { get; set; }

    public virtual Kullanicilar CreateUser { get; set; } = null!;

    public virtual NewFirms Firm { get; set; } = null!;

    public virtual NewSubBrands? InsuranceFirm { get; set; }

    public virtual NewQueryTypes? QueryType { get; set; }

    public virtual Subeler? Skt { get; set; }

    public virtual Kullanicilar? UpdateUser { get; set; }

    public virtual Kullanicilar? User { get; set; }
}
