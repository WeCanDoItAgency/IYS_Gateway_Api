using System.Text.Json;
using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Models.Consent;
using IYS.Gateway.Application.Services;
using IYS.Gateway.Domain.Constants;
using IYS.Gateway.Infrastructure.IysApi;

namespace IYS.Gateway.Infrastructure.Services;

/// <summary>
/// İzin yönetimi servis implementasyonu.
/// FirmGuid ile IysFirmResolver → IysApiClient zincirini çalıştırır.
/// Tüm API çağrıları ExecuteWithRetryAsync ile sarılır → 401 auto-retry aktif.
/// Tekil durum sorgulamaları distributed cache ile korunur (30sn).
/// 
/// İzin ekleme ve durum sorgulama sonuçları IysConsentTracker ile MongoDB'ye kaydedilir
/// ve BlacklistSyncService ile karaliste/beyazliste senkronizasyonu yapılır.
/// </summary>
public class ConsentService : IConsentService
{
    private readonly IIysFirmResolver _firmResolver;
    private readonly IIysApiClient _apiClient;
    private readonly IIysDistributedCache _cache;
    private readonly IIysConsentTracker _tracker;

    /// <summary>Consent status cache süresi — 30 saniye (sık değişebilir)</summary>
    private const int ConsentStatusCacheTtlSeconds = 30;

    public ConsentService(IIysFirmResolver firmResolver, IIysApiClient apiClient, IIysDistributedCache cache, IIysConsentTracker tracker)
    {
        _firmResolver = firmResolver;
        _apiClient = apiClient;
        _cache = cache;
        _tracker = tracker;
    }

    public async Task<object?> AddSingleConsentAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddSingleConsent, ctx.IysCode, ctx.BrandCode);
            var result = await _apiClient.PostAsync<object, object>(ctx, endpoint, body);

            // Consent Tracking — MongoDB'ye kaydet + karaliste senkronizasyonu
            await TrackAddConsentResultAsync(ctx, body, result);

            return result;
        });
    }

    public async Task<object?> AddSingleConsentV2Async(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddSingleConsentV2, ctx.IysCode, ctx.BrandCode);
            var result = await _apiClient.PostAsync<object, object>(ctx, endpoint, body);

            // Consent Tracking — MongoDB'ye kaydet + karaliste senkronizasyonu
            await TrackAddConsentResultAsync(ctx, body, result);

            return result;
        });
    }

    public async Task<object?> AddBatchConsentAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddBatchConsent, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> AddBatchConsentV2Async(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddBatchConsentV2, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> GetBatchConsentStatusAsync(Guid firmGuid, string requestId)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetBatchConsentStatus, ctx.IysCode, ctx.BrandCode, requestId);
            return await _apiClient.GetAsync<object>(ctx, endpoint);
        });
    }

    public async Task<object?> GetBatchConsentStatusV2Async(Guid firmGuid, string requestId)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetBatchConsentStatusV2, ctx.IysCode, ctx.BrandCode, requestId);
            return await _apiClient.GetAsync<object>(ctx, endpoint);
        });
    }

    public async Task<object?> GetSingleConsentStatusAsync(Guid firmGuid, object body)
    {
        var firmGuidStr = firmGuid.ToString();

        // Cache kontrolü — aynı firma + aynı parametreler için 30sn cache
        var cached = await _cache.GetAsync<object>(firmGuidStr, "consent_status", body);
        if (cached != null) return cached;

        var result = await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetSingleConsentStatus, ctx.IysCode, ctx.BrandCode);
            var apiResult = await _apiClient.PostAsync<object, object>(ctx, endpoint, body);

            // Consent Status Tracking — MongoDB'de mevcut kaydı güncelle + karaliste senkronizasyonu
            await TrackStatusQueryResultAsync(ctx, body, apiResult);

            return apiResult;
        });

        if (result != null)
            await _cache.SetAsync(firmGuidStr, "consent_status", result, ConsentStatusCacheTtlSeconds, body);

        return result;
    }

    public async Task<object?> GetMultipleConsentStatusAsync(Guid firmGuid, string recipientType, string type, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetMultipleConsentStatus, ctx.IysCode, ctx.BrandCode, recipientType, type);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> GetConsentHistoryAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetConsentHistory, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> GetConsentChangesAsync(Guid firmGuid, Dictionary<string, string>? queryParams)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetConsentChanges, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.GetAsync<object>(ctx, endpoint, queryParams);
        });
    }

    public async Task<object?> RegisterPushAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.PushRegistration, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    public async Task<object?> GetPushStatusAsync(Guid firmGuid)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.PushRegistration, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.GetAsync<object>(ctx, endpoint);
        });
    }

    public async Task<object?> UnregisterPushAsync(Guid firmGuid, object body)
    {
        return await _firmResolver.ExecuteWithRetryAsync<object>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.PushUnregistration, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<object, object>(ctx, endpoint, body);
        });
    }

    // ═══════════════════════════════════════════════════════════════
    // TRACKING HELPER METHODS
    // ═══════════════════════════════════════════════════════════════

    /// <summary>
    /// İzin ekleme sonrası IYS API yanıtını parse edip MongoDB tracking kaydı oluşturur.
    /// SADECE başarılı yanıtlarda (transactionId döndüğünde) tracking yapılır.
    /// </summary>
    private async Task TrackAddConsentResultAsync(IysFirmContext ctx, object body, object? result)
    {
        try
        {
            if (body is not AddSingleConsentRequest request) return;
            if (result == null) return;

            var json = JsonSerializer.Serialize(result);
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            // TransactionId yoksa başarısız — tracking yapma
            if (!root.TryGetProperty("transactionId", out var tid) || string.IsNullOrEmpty(tid.GetString()))
                return;

            var transactionId = tid.GetString();

            DateTime? iysCreationDate = null;
            if (root.TryGetProperty("creationDate", out var cd) && cd.GetString() is string cdStr)
                iysCreationDate = Convert.ToDateTime(cdStr);

            await _tracker.UpsertConsentRecordAsync(
                firmId: ctx.FirmId,
                recipient: request.Recipient,
                type: request.Type,
                recipientType: request.RecipientType,
                source: request.Source,
                consentDate: request.ConsentDate,
                transactionId: transactionId,
                status: request.Status,
                iysCreationDate: iysCreationDate);
        }
        catch
        {
            // Tracking hatası ana akışı etkilememeli
        }
    }

    /// <summary>
    /// İzin durum sorgulama sonrası IYS API yanıtını parse edip MongoDB kaydını günceller.
    /// </summary>
    private async Task TrackStatusQueryResultAsync(IysFirmContext ctx, object body, object? result)
    {
        try
        {
            if (body is not GetConsentStatusRequest request) return;
            if (result == null) return;

            var json = JsonSerializer.Serialize(result);
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            string? status = null;
            string? source = null;
            string? transactionId = null;
            string? consentDate = null;

            if (root.TryGetProperty("status", out var s))
                status = s.GetString();

            if (root.TryGetProperty("source", out var src))
                source = src.GetString();

            if (root.TryGetProperty("transactionId", out var tid))
                transactionId = tid.GetString();

            if (root.TryGetProperty("consentDate", out var cd))
                consentDate = cd.GetString();

            if (!string.IsNullOrEmpty(status))
            {
                await _tracker.UpdateConsentStatusAsync(
                    firmId: ctx.FirmId,
                    recipient: request.Recipient,
                    type: request.Type,
                    status: status,
                    source: source,
                    transactionId: transactionId,
                    consentDate: consentDate);
            }
        }
        catch
        {
            // Tracking hatası ana akışı etkilememeli
        }
    }
}
