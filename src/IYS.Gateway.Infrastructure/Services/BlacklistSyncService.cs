using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Services;
using IYS.Gateway.Infrastructure.Data;
using IYS.Gateway.Infrastructure.Mongo.Entity.IYS;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.Services;

/// <summary>
/// IYS karaliste/beyazliste senkronizasyon servisi.
/// MongoDB'ye HER ZAMAN yazar (MONGO_206 / MongoPortal / BusinessRulesLog).
/// SQL'e ise sadece UseSqlDb=true olduğunda yazar.
///
/// BusinessRuleId=2: Karaliste, BusinessRuleId=3: Beyazliste
/// CreatedUserId > 0: Manuel kayıtlara dokunulmaz.
/// CreatedUserId <= 0: IYS sistem tarafından oluşturulan kayıtlar.
/// </summary>
public class BlacklistSyncService : IBlacklistSyncService
{
    private readonly ILogger<BlacklistSyncService> _logger;
    private readonly IysSyncConfig _config;
    private readonly GenericMongoRepository _repo;

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
        IOptions<IysSyncConfig> config)
    {
        _logger = logger;
        _config = config.Value;
        _repo = new GenericMongoRepository();
    }

    public async Task<bool> SyncBlacklistAsync(string? status, string consentType, string recipient, int firmId)
    {
        if (string.IsNullOrEmpty(status))
            return true;

        try
        {
            var phone = ExtractPhone(recipient);

            // ═══════════════════════════════════════════════════
            // 1) MongoDB — HER ZAMAN çalışır
            // ═══════════════════════════════════════════════════
            await SyncMongoAsync(status, consentType, phone, recipient, firmId);

            // ═══════════════════════════════════════════════════
            // 2) SQL — Sadece UseSqlDb=true ise
            // ═══════════════════════════════════════════════════
            if (_config.UseSqlDb)
            {
                await SyncSqlAsync(status, consentType, phone, recipient, firmId);
            }
            else
            {
                _logger.LogDebug("SQL yazımı devre dışı (UseSqlDb=false) — SQL BlacklistSync atlandı. FirmId={FirmId}", firmId);
            }

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

    // ═══════════════════════════════════════════════════════════════
    // MONGO OPERASYONLARİ — MONGO_206 / MongoPortal / BusinessRulesLog
    // ═══════════════════════════════════════════════════════════════

    private async Task SyncMongoAsync(string status, string consentType, string phone, string recipient, int firmId)
    {
        var collection = _repo.GetCollection<BusinessRulesLogMongo>();

        // Manuel karaliste kontrolü
        if (await HasManualBlacklistMongoAsync(collection, consentType, phone, recipient, firmId))
        {
            _logger.LogDebug("Manuel karaliste mevcut (Mongo) — IYS sync atlandı. FirmId={FirmId}, Recipient={Recipient}", firmId, recipient);
            return;
        }

        // Sistem kayıtları filtresi (CreatedUserId <= 0)
        var systemFilter = Builders<BusinessRulesLogMongo>.Filter.And(
            Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.IsActive, true),
            Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.FirmId, firmId),
            Builders<BusinessRulesLogMongo>.Filter.Lte(x => x.CreatedUserId, 0)
        );

        if (status == StatusApprove)
        {
            await HandleApproveMongoAsync(collection, consentType, phone, recipient, firmId, systemFilter);
        }
        else if (status == StatusReject)
        {
            await HandleRejectMongoAsync(collection, consentType, phone, recipient, firmId, systemFilter);
        }
    }

    private async Task HandleApproveMongoAsync(IMongoCollection<BusinessRulesLogMongo> col, string consentType, string phone, string recipient, int firmId, FilterDefinition<BusinessRulesLogMongo> systemFilter)
    {
        FilterDefinition<BusinessRulesLogMongo> matchFilter;

        if (consentType is "ARAMA" or "MESAJ")
            matchFilter = Builders<BusinessRulesLogMongo>.Filter.And(systemFilter, Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.PhoneNumber, phone), Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.BusinessRuleId, BlacklistRuleId));
        else if (consentType == "EPOSTA")
            matchFilter = Builders<BusinessRulesLogMongo>.Filter.And(systemFilter, Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.Email, recipient), Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.BusinessRuleId, BlacklistRuleId));
        else
            return;

        // Aktif karalisteyi kapat
        var deactivate = Builders<BusinessRulesLogMongo>.Update
            .Set(x => x.IsActive, false)
            .Set(x => x.Description, SyncDescription)
            .Set(x => x.UpdatedDate, DateTime.Now)
            .Set(x => x.UpdatedUserId, 0);

        var result = await col.UpdateManyAsync(matchFilter, deactivate);

        // Kapalanan varsa beyazliste ekle
        if (result.ModifiedCount > 0)
        {
            await col.InsertOneAsync(CreateMongoEntry(WhitelistRuleId,
                phone: consentType is "ARAMA" or "MESAJ" ? phone : null,
                email: consentType == "EPOSTA" ? recipient : null,
                firmId: firmId));
        }
    }

    private async Task HandleRejectMongoAsync(IMongoCollection<BusinessRulesLogMongo> col, string consentType, string phone, string recipient, int firmId, FilterDefinition<BusinessRulesLogMongo> systemFilter)
    {
        FilterDefinition<BusinessRulesLogMongo> whiteFilter;
        FilterDefinition<BusinessRulesLogMongo> blackFilter;

        if (consentType is "ARAMA" or "MESAJ")
        {
            whiteFilter = Builders<BusinessRulesLogMongo>.Filter.And(systemFilter, Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.PhoneNumber, phone), Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.BusinessRuleId, WhitelistRuleId));
            blackFilter = Builders<BusinessRulesLogMongo>.Filter.And(systemFilter, Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.PhoneNumber, phone), Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.BusinessRuleId, BlacklistRuleId));
        }
        else if (consentType == "EPOSTA")
        {
            whiteFilter = Builders<BusinessRulesLogMongo>.Filter.And(systemFilter, Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.Email, recipient), Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.BusinessRuleId, WhitelistRuleId));
            blackFilter = Builders<BusinessRulesLogMongo>.Filter.And(systemFilter, Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.Email, recipient), Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.BusinessRuleId, BlacklistRuleId));
        }
        else
            return;

        // Aktif beyazlisteyi kapat
        var deactivate = Builders<BusinessRulesLogMongo>.Update
            .Set(x => x.IsActive, false)
            .Set(x => x.Description, SyncDescription)
            .Set(x => x.UpdatedDate, DateTime.Now)
            .Set(x => x.UpdatedUserId, 0);
        await col.UpdateManyAsync(whiteFilter, deactivate);

        // Karaliste yoksa ekle
        var existingBlacklist = await col.Find(blackFilter).FirstOrDefaultAsync();
        if (existingBlacklist == null)
        {
            await col.InsertOneAsync(CreateMongoEntry(BlacklistRuleId,
                phone: consentType is "ARAMA" or "MESAJ" ? phone : null,
                email: consentType == "EPOSTA" ? recipient : null,
                firmId: firmId));
        }
    }

    private async Task<bool> HasManualBlacklistMongoAsync(IMongoCollection<BusinessRulesLogMongo> col, string consentType, string phone, string recipient, int firmId)
    {
        var manualFilter = Builders<BusinessRulesLogMongo>.Filter.And(
            Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.FirmId, firmId),
            Builders<BusinessRulesLogMongo>.Filter.Gt(x => x.CreatedUserId, 0),
            Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.IsActive, true),
            Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.BusinessRuleId, BlacklistRuleId)
        );

        if (consentType is "ARAMA" or "MESAJ")
            manualFilter = Builders<BusinessRulesLogMongo>.Filter.And(manualFilter, Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.PhoneNumber, phone));
        else if (consentType == "EPOSTA")
            manualFilter = Builders<BusinessRulesLogMongo>.Filter.And(manualFilter, Builders<BusinessRulesLogMongo>.Filter.Eq(x => x.Email, recipient));
        else
            return false;

        return await col.Find(manualFilter).AnyAsync();
    }

    private static BusinessRulesLogMongo CreateMongoEntry(int ruleId, string? phone = null, string? email = null, int firmId = 0)
    {
        return new BusinessRulesLogMongo
        {
            PhoneNumber = phone,
            Email = email,
            FirmId = firmId,
            IsActive = true,
            BusinessRuleId = ruleId,
            CreatedDate = DateTime.Now,
            CreatedUserId = 0,
            Description = SyncDescription
        };
    }

    // ═══════════════════════════════════════════════════════════════
    // SQL OPERASYONLARİ — Sadece UseSqlDb=true ise
    // ═══════════════════════════════════════════════════════════════

    private async Task SyncSqlAsync(string status, string consentType, string phone, string recipient, int firmId)
    {
        using var db = new ACENTE365Context();

        // Manuel karaliste kontrolü
        if (await HasManualBlacklistSqlAsync(db, consentType, phone, recipient, firmId))
        {
            _logger.LogDebug("Manuel karaliste mevcut (SQL) — IYS sync atlandı. FirmId={FirmId}, Recipient={Recipient}", firmId, recipient);
            return;
        }

        var systemRecordsQuery = db.BusinessRulesLog
            .Where(x => x.IsActive == true && x.FirmId == firmId && x.CreatedUserId <= 0);

        if (status == StatusApprove)
        {
            await HandleApproveSqlAsync(db, consentType, phone, recipient, firmId, systemRecordsQuery);
        }
        else if (status == StatusReject)
        {
            await HandleRejectSqlAsync(db, consentType, phone, recipient, firmId, systemRecordsQuery);
        }

        await db.SaveChangesAsync();
    }

    private async Task HandleApproveSqlAsync(ACENTE365Context db, string consentType, string phone, string recipient, int firmId, IQueryable<BusinessRulesLog> systemQuery)
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
                db.BusinessRulesLog.Add(CreateSqlEntry(WhitelistRuleId, phone: phone, firmId: firmId));
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
                db.BusinessRulesLog.Add(CreateSqlEntry(WhitelistRuleId, email: recipient, firmId: firmId));
        }
    }

    private async Task HandleRejectSqlAsync(ACENTE365Context db, string consentType, string phone, string recipient, int firmId, IQueryable<BusinessRulesLog> systemQuery)
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
                db.BusinessRulesLog.Add(CreateSqlEntry(BlacklistRuleId, phone: phone, firmId: firmId));
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
                db.BusinessRulesLog.Add(CreateSqlEntry(BlacklistRuleId, email: recipient, firmId: firmId));
        }
    }

    private async Task<bool> HasManualBlacklistSqlAsync(ACENTE365Context db, string consentType, string phone, string recipient, int firmId)
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

    // ═══════════════════════════════════════════════════════════════
    // YARDIMCI METODLAR
    // ═══════════════════════════════════════════════════════════════

    /// <summary>+90 prefix'ini kaldırır — BusinessRulesLog.PhoneNumber formatına çevirir.</summary>
    private static string ExtractPhone(string recipient)
    {
        return recipient.StartsWith("+90") ? recipient[3..] : recipient;
    }

    private static BusinessRulesLog CreateSqlEntry(int ruleId, string? phone = null, string? email = null, int firmId = 0)
    {
        return new BusinessRulesLog
        {
            PhoneNumber = phone,
            Email = email,
            FirmId = firmId,
            IsActive = true,
            BusinessRuleId = ruleId,
            CreatedDate = DateTime.Now,
            CreatedUserId = 0,
            Description = SyncDescription
        };
    }
}
