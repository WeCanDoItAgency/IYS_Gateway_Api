using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Services;
using IYS.Gateway.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IYS.Gateway.Infrastructure.Services;

/// <summary>
/// IYS karaliste/beyazliste senkronizasyon servisi.
/// SyncHelper.KaralisteEkleGuncelle mantığının birebir taşınmış hali.
/// Config ile SQL yazımı kapatılabilir.
/// 
/// BusinessRuleId=2: Karaliste, BusinessRuleId=3: Beyazliste
/// CreatedUserId > 0: Manuel kayıtlara dokunulmaz.
/// CreatedUserId <= 0: IYS sistem tarafından oluşturulan kayıtlar.
/// </summary>
public class BlacklistSyncService : IBlacklistSyncService
{
    private readonly ILogger<BlacklistSyncService> _logger;
    private readonly BlacklistSyncConfig _config;

    /// <summary>Karaliste BusinessRuleId değeri</summary>
    private const int BlacklistRuleId = 2;

    /// <summary>Beyazliste BusinessRuleId değeri</summary>
    private const int WhitelistRuleId = 3;

    /// <summary>IYS senkronizasyon açıklama etiketi</summary>
    private const string SyncDescription = "IysSync";

    /// <summary>IYS izin durumu: Onay</summary>
    private const string StatusApprove = "ONAY";

    /// <summary>IYS izin durumu: Ret</summary>
    private const string StatusReject = "RET";

    public BlacklistSyncService(
        ILogger<BlacklistSyncService> logger,
        IOptions<BlacklistSyncConfig> config)
    {
        _logger = logger;
        _config = config.Value;
    }

    public async Task<bool> SyncBlacklistAsync(string? status, string consentType, string recipient, int firmId)
    {
        if (!_config.EnableSqlSync)
        {
            _logger.LogDebug("SQL senkronizasyonu devre dışı — BlacklistSync atlandı. FirmId={FirmId}, Recipient={Recipient}", firmId, recipient);
            return true;
        }

        if (string.IsNullOrEmpty(status))
            return true;

        try
        {
            using var db = new ACENTE365Context();
            var phone = ExtractPhone(recipient);

            // Manuel karaliste kontrolü — CreatedUserId > 0 olan kayıtlara DOKUNMA
            if (await HasManualBlacklistAsync(db, consentType, phone, recipient, firmId))
            {
                _logger.LogDebug("Manuel karaliste mevcut — IYS sync atlandı. FirmId={FirmId}, Recipient={Recipient}", firmId, recipient);
                return true;
            }

            // Sistem kayıtları sorgusu (CreatedUserId <= 0)
            var systemRecordsQuery = db.BusinessRulesLog
                .Where(x => x.IsActive == true && x.FirmId == firmId && x.CreatedUserId <= 0);

            if (status == StatusApprove)
            {
                await HandleApproveAsync(db, consentType, phone, recipient, firmId, systemRecordsQuery);
            }
            else if (status == StatusReject)
            {
                await HandleRejectAsync(db, consentType, phone, recipient, firmId, systemRecordsQuery);
            }

            await db.SaveChangesAsync();

            _logger.LogInformation(
                "Karaliste senkronizasyonu tamamlandı: FirmId={FirmId}, Status={Status}, Type={Type}, Recipient={Recipient}",
                firmId, status, consentType, recipient);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Karaliste senkronizasyonu hatası: FirmId={FirmId}, Status={Status}, Type={Type}, Recipient={Recipient}",
                firmId, status, consentType, recipient);
            return false;
        }
    }

    /// <summary>
    /// ONAY durumu: Aktif karalisteyi kapat, beyazliste ekle.
    /// </summary>
    private async Task HandleApproveAsync(ACENTE365Context db, string consentType, string phone, string recipient, int firmId, IQueryable<BusinessRulesLog> systemQuery)
    {
        if (consentType is "ARAMA" or "MESAJ")
        {
            var activeBlacklist = await systemQuery
                .Where(x => x.PhoneNumber == phone && x.BusinessRuleId == BlacklistRuleId)
                .ToListAsync();

            foreach (var item in activeBlacklist)
            {
                item.Description = SyncDescription;
                item.IsActive = false;
                item.UpdatedDate = DateTime.Now;
                item.UpdatedUserId = 0;
            }

            if (activeBlacklist.Count > 0)
            {
                db.BusinessRulesLog.Add(CreateWhitelistEntry(phone: phone, firmId: firmId));
            }
        }
        else if (consentType == "EPOSTA")
        {
            var activeBlacklist = await systemQuery
                .Where(x => x.Email == recipient && x.BusinessRuleId == BlacklistRuleId)
                .ToListAsync();

            foreach (var item in activeBlacklist)
            {
                item.Description = SyncDescription;
                item.IsActive = false;
                item.UpdatedDate = DateTime.Now;
                item.UpdatedUserId = 0;
            }

            if (activeBlacklist.Count > 0)
            {
                db.BusinessRulesLog.Add(CreateWhitelistEntry(email: recipient, firmId: firmId));
            }
        }
    }

    /// <summary>
    /// RET durumu: Aktif beyazlisteyi kapat, karaliste ekle (yoksa).
    /// </summary>
    private async Task HandleRejectAsync(ACENTE365Context db, string consentType, string phone, string recipient, int firmId, IQueryable<BusinessRulesLog> systemQuery)
    {
        if (consentType is "ARAMA" or "MESAJ")
        {
            var activeWhitelist = await systemQuery
                .Where(x => x.PhoneNumber == phone && x.BusinessRuleId == WhitelistRuleId)
                .ToListAsync();

            foreach (var item in activeWhitelist)
            {
                item.Description = SyncDescription;
                item.IsActive = false;
                item.UpdatedDate = DateTime.Now;
                item.UpdatedUserId = 0;
            }

            var existingBlacklist = await systemQuery
                .FirstOrDefaultAsync(x => x.PhoneNumber == phone && x.BusinessRuleId == BlacklistRuleId);

            if (existingBlacklist == null)
            {
                db.BusinessRulesLog.Add(CreateBlacklistEntry(phone: phone, firmId: firmId));
            }
        }
        else if (consentType == "EPOSTA")
        {
            var activeWhitelist = await systemQuery
                .Where(x => x.Email == recipient && x.BusinessRuleId == WhitelistRuleId)
                .ToListAsync();

            foreach (var item in activeWhitelist)
            {
                item.Description = SyncDescription;
                item.IsActive = false;
                item.UpdatedDate = DateTime.Now;
                item.UpdatedUserId = 0;
            }

            var existingBlacklist = await systemQuery
                .FirstOrDefaultAsync(x => x.Email == recipient && x.BusinessRuleId == BlacklistRuleId);

            if (existingBlacklist == null)
            {
                db.BusinessRulesLog.Add(CreateBlacklistEntry(email: recipient, firmId: firmId));
            }
        }
    }

    /// <summary>
    /// Manuel karaliste kontrolü — CreatedUserId > 0 olan kayıtlar IYS tarafından override edilmez.
    /// </summary>
    private async Task<bool> HasManualBlacklistAsync(ACENTE365Context db, string consentType, string phone, string recipient, int firmId)
    {
        if (consentType is "ARAMA" or "MESAJ")
        {
            return await db.BusinessRulesLog.AsNoTracking().AnyAsync(x =>
                x.FirmId == firmId &&
                x.CreatedUserId > 0 &&
                x.IsActive == true &&
                x.BusinessRuleId == BlacklistRuleId &&
                !string.IsNullOrEmpty(x.PhoneNumber) &&
                x.PhoneNumber == phone);
        }

        if (consentType == "EPOSTA")
        {
            return await db.BusinessRulesLog.AsNoTracking().AnyAsync(x =>
                x.FirmId == firmId &&
                x.CreatedUserId > 0 &&
                x.IsActive == true &&
                x.BusinessRuleId == BlacklistRuleId &&
                !string.IsNullOrEmpty(x.Email) &&
                x.Email!.ToLower() == recipient.ToLower());
        }

        return false;
    }

    /// <summary>+90 prefix'ini kaldırır — BusinessRulesLog.PhoneNumber formatına çevirir.</summary>
    private static string ExtractPhone(string recipient)
    {
        return recipient.StartsWith("+90") ? recipient[3..] : recipient;
    }

    private static BusinessRulesLog CreateBlacklistEntry(string? phone = null, string? email = null, int firmId = 0)
    {
        return new BusinessRulesLog
        {
            PhoneNumber = phone,
            Email = email,
            FirmId = firmId,
            IsActive = true,
            BusinessRuleId = BlacklistRuleId,
            CreatedDate = DateTime.Now,
            CreatedUserId = 0,
            Description = SyncDescription
        };
    }

    private static BusinessRulesLog CreateWhitelistEntry(string? phone = null, string? email = null, int firmId = 0)
    {
        return new BusinessRulesLog
        {
            PhoneNumber = phone,
            Email = email,
            FirmId = firmId,
            IsActive = true,
            BusinessRuleId = WhitelistRuleId,
            CreatedDate = DateTime.Now,
            CreatedUserId = 0,
            Description = SyncDescription
        };
    }
}
