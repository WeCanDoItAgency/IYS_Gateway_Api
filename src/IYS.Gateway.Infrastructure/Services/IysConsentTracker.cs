using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Models.Consent;
using IYS.Gateway.Application.Services;
using IYS.Gateway.Infrastructure.Mongo.Entity.IYS;
using IYS.Gateway.Infrastructure.Mongo.Repository.Generic;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.Services;

/// <summary>
/// IYS izin takip servisi implementasyonu.
/// Her izin ekleme/sorgulama sonrası MongoDB IysRequestConsentMongo kaydını upsert eder.
/// Config ile MongoDB tracking kapatılabilir.
/// </summary>
public class IysConsentTracker : IIysConsentTracker
{
    private readonly GenericMongoRepository _repo;
    private readonly IBlacklistSyncService _blacklistSync;
    private readonly ILogger<IysConsentTracker> _logger;
    private readonly BlacklistSyncConfig _config;
    private readonly string _database;

    public IysConsentTracker(
        IBlacklistSyncService blacklistSync,
        ILogger<IysConsentTracker> logger,
        IOptions<BlacklistSyncConfig> config)
    {
        _repo = new GenericMongoRepository();
        _blacklistSync = blacklistSync;
        _logger = logger;
        _config = config.Value;
        _database = GlobalAppSettings.Instance.Get<string>("GlobalAdresses:MongoDbSettings52Database");
    }

    public async Task UpsertConsentRecordAsync(
        int firmId,
        string recipient,
        string type,
        string recipientType,
        string? source,
        string? consentDate,
        string? transactionId,
        string? status,
        DateTime? iysCreationDate = null,
        List<IysErrorDetail>? errors = null)
    {
        if (!_config.EnableMongoTracking)
            return;

        try
        {
            var collection = _repo.GetCollection<IysRequestConsentMongo>(OurMongosServer.MONGO_52, _database);

            var filter = Builders<IysRequestConsentMongo>.Filter.And(
                Builders<IysRequestConsentMongo>.Filter.Eq(x => x.FirmId, firmId),
                Builders<IysRequestConsentMongo>.Filter.Eq(x => x.Recipient, recipient),
                Builders<IysRequestConsentMongo>.Filter.Eq(x => x.Type, type)
            );

            var update = Builders<IysRequestConsentMongo>.Update
                .Set(x => x.FirmId, firmId)
                .Set(x => x.Recipient, recipient)
                .Set(x => x.Type, type)
                .Set(x => x.RecipientType, recipientType)
                .Set(x => x.Source, source)
                .Set(x => x.ConsentDate, consentDate)
                .Set(x => x.TransactionId, transactionId)
                .Set(x => x.Status, status)
                .Set(x => x.IysCreationDate, iysCreationDate)
                .Set(x => x.Errors, errors)
                .Set(x => x.LastQueryDate, DateTime.Now);

            await collection.UpdateManyAsync(filter, update);

            _logger.LogInformation(
                "IYS Consent tracked: FirmId={FirmId}, Recipient={Recipient}, Type={Type}, Status={Status}, TransactionId={TransactionId}",
                firmId, recipient, type, status, transactionId);

            // Karaliste senkronizasyonu
            if (!string.IsNullOrEmpty(status))
            {
                await _blacklistSync.SyncBlacklistAsync(status, type, recipient, firmId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "IYS Consent tracking hatası: FirmId={FirmId}, Recipient={Recipient}, Type={Type}",
                firmId, recipient, type);
        }
    }

    public async Task UpdateConsentStatusAsync(
        int firmId,
        string recipient,
        string type,
        string? status,
        string? source = null,
        string? transactionId = null,
        string? consentDate = null)
    {
        if (!_config.EnableMongoTracking)
            return;

        try
        {
            var collection = _repo.GetCollection<IysRequestConsentMongo>(OurMongosServer.MONGO_52, _database);

            var filter = Builders<IysRequestConsentMongo>.Filter.And(
                Builders<IysRequestConsentMongo>.Filter.Eq(x => x.FirmId, firmId),
                Builders<IysRequestConsentMongo>.Filter.Eq(x => x.Recipient, recipient),
                Builders<IysRequestConsentMongo>.Filter.Eq(x => x.Type, type)
            );

            var updateDef = Builders<IysRequestConsentMongo>.Update
                .Set(x => x.Status, status)
                .Set(x => x.Source, source)
                .Set(x => x.TransactionId, transactionId)
                .Set(x => x.ConsentDate, consentDate)
                .Set(x => x.LastQueryDate, DateTime.Now);

            await collection.UpdateManyAsync(filter, updateDef);

            _logger.LogInformation(
                "IYS Consent status updated: FirmId={FirmId}, Recipient={Recipient}, Type={Type}, Status={Status}",
                firmId, recipient, type, status);

            // Karaliste senkronizasyonu
            if (!string.IsNullOrEmpty(status))
            {
                await _blacklistSync.SyncBlacklistAsync(status, type, recipient, firmId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "IYS Consent status güncelleme hatası: FirmId={FirmId}, Recipient={Recipient}, Type={Type}",
                firmId, recipient, type);
        }
    }
}
