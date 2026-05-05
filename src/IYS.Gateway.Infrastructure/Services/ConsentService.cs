using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Models.Consent;
using IYS.Gateway.Application.Models.Common;
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

    public async Task<ConsentResponse?> AddSingleConsentAsync(Guid firmGuid, AddSingleConsentRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<ConsentResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddSingleConsent, ctx.IysCode, ctx.BrandCode);
            var result = await _apiClient.PostAsync<AddSingleConsentRequest, ConsentResponse>(ctx, endpoint, request);

            // Consent Tracking — MongoDB'ye kaydet + karaliste senkronizasyonu
            await TrackAddConsentResultAsync(ctx, request, result);

            return result;
        });
    }

    public async Task<ConsentResponse?> AddSingleConsentV2Async(Guid firmGuid, AddSingleConsentRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<ConsentResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddSingleConsentV2, ctx.IysCode, ctx.BrandCode);
            var result = await _apiClient.PostAsync<AddSingleConsentRequest, ConsentResponse>(ctx, endpoint, request);

            // Consent Tracking — MongoDB'ye kaydet + karaliste senkronizasyonu
            await TrackAddConsentResultAsync(ctx, request, result);

            return result;
        });
    }

    public async Task<BatchConsentResponse?> AddBatchConsentAsync(Guid firmGuid, AddBatchConsentRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<BatchConsentResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddBatchConsent, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<AddBatchConsentRequest, BatchConsentResponse>(ctx, endpoint, request);
        });
    }

    public async Task<BatchConsentResponse?> AddBatchConsentV2Async(Guid firmGuid, AddBatchConsentRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<BatchConsentResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.AddBatchConsentV2, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<AddBatchConsentRequest, BatchConsentResponse>(ctx, endpoint, request);
        });
    }

    public async Task<List<BatchConsentStatusItem>?> GetBatchConsentStatusAsync(Guid firmGuid, string requestId)
    {
        return await _firmResolver.ExecuteWithRetryAsync<List<BatchConsentStatusItem>>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetBatchConsentStatus, ctx.IysCode, ctx.BrandCode, requestId);
            return await _apiClient.GetAsync<List<BatchConsentStatusItem>>(ctx, endpoint);
        });
    }

    public async Task<List<BatchConsentStatusItem>?> GetBatchConsentStatusV2Async(Guid firmGuid, string requestId)
    {
        return await _firmResolver.ExecuteWithRetryAsync<List<BatchConsentStatusItem>>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetBatchConsentStatusV2, ctx.IysCode, ctx.BrandCode, requestId);
            return await _apiClient.GetAsync<List<BatchConsentStatusItem>>(ctx, endpoint);
        });
    }

    public async Task<ConsentStatusResponse?> GetSingleConsentStatusAsync(Guid firmGuid, GetConsentStatusRequest request)
    {
        var firmGuidStr = firmGuid.ToString();

        // Cache kontrolü — aynı firma + aynı parametreler için 30sn cache
        var cached = await _cache.GetAsync<ConsentStatusResponse>(firmGuidStr, "consent_status", request);
        if (cached != null) return cached;

        var result = await _firmResolver.ExecuteWithRetryAsync<ConsentStatusResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetSingleConsentStatus, ctx.IysCode, ctx.BrandCode);
            var apiResult = await _apiClient.PostAsync<GetConsentStatusRequest, ConsentStatusResponse>(ctx, endpoint, request);

            // Consent Status Tracking — MongoDB'de mevcut kaydı güncelle + karaliste senkronizasyonu
            await TrackStatusQueryResultAsync(ctx, request, apiResult);

            return apiResult;
        });

        if (result != null)
            await _cache.SetAsync(firmGuidStr, "consent_status", result, ConsentStatusCacheTtlSeconds, request);

        return result;
    }

    public async Task<MultipleConsentStatusResponse?> GetMultipleConsentStatusAsync(Guid firmGuid, string recipientType, string type, GetMultipleConsentStatusRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<MultipleConsentStatusResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetMultipleConsentStatus, ctx.IysCode, ctx.BrandCode, recipientType, type);
            return await _apiClient.PostAsync<GetMultipleConsentStatusRequest, MultipleConsentStatusResponse>(ctx, endpoint, request);
        });
    }

    public async Task<ConsentHistoryResponse?> GetConsentHistoryAsync(Guid firmGuid, GetConsentHistoryRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<ConsentHistoryResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetConsentHistory, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<GetConsentHistoryRequest, ConsentHistoryResponse>(ctx, endpoint, request);
        });
    }

    public async Task<ConsentChangesResponse?> GetConsentChangesAsync(Guid firmGuid, Dictionary<string, string>? queryParams)
    {
        return await _firmResolver.ExecuteWithRetryAsync<ConsentChangesResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.GetConsentChanges, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.GetAsync<ConsentChangesResponse>(ctx, endpoint, queryParams);
        });
    }

    public async Task<ConsentChangesResponse?> GetDailyChangeFileAsync(Guid firmGuid, string reportDate)
    {
        return await _firmResolver.ExecuteWithRetryAsync<ConsentChangesResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.DailyChangeFile, ctx.IysCode, ctx.BrandCode, reportDate);
            return await _apiClient.GetAsync<ConsentChangesResponse>(ctx, endpoint);
        });
    }

    /// <summary>
    /// Worker'dan gelen tekil izin durum güncelleme isteği.
    /// MongoDB IysRequestConsent kaydını günceller ve karaliste senkronizasyonu yapar.
    /// </summary>
    public async Task SyncConsentStatusAsync(Guid firmGuid, SyncConsentStatusRequest request)
    {
        var ctx = await _firmResolver.ResolveAsync(firmGuid);

        await _tracker.UpdateConsentStatusAsync(
            firmId: ctx.FirmId,
            recipient: request.Recipient,
            type: request.Type,
            status: request.Status,
            source: request.Source,
            transactionId: request.TransactionId,
            consentDate: request.ConsentDate);
    }

    public async Task<IysErrorResponse?> RegisterPushAsync(Guid firmGuid, RegisterPushRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<IysErrorResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.PushRegistration, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<RegisterPushRequest, IysErrorResponse>(ctx, endpoint, request);
        });
    }

    public async Task<IysErrorResponse?> GetPushStatusAsync(Guid firmGuid)
    {
        return await _firmResolver.ExecuteWithRetryAsync<IysErrorResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.PushRegistration, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.GetAsync<IysErrorResponse>(ctx, endpoint);
        });
    }

    public async Task<IysErrorResponse?> UnregisterPushAsync(Guid firmGuid, UnregisterPushRequest request)
    {
        return await _firmResolver.ExecuteWithRetryAsync<IysErrorResponse>(firmGuid, async ctx =>
        {
            var endpoint = string.Format(IysEndpoints.PushUnregistration, ctx.IysCode, ctx.BrandCode);
            return await _apiClient.PostAsync<UnregisterPushRequest, IysErrorResponse>(ctx, endpoint, request);
        });
    }

    // ═══════════════════════════════════════════════════════════════
    // TRACKING HELPER METHODS
    // ═══════════════════════════════════════════════════════════════

    /// <summary>
    /// İzin ekleme sonrası IYS API yanıtını parse edip MongoDB tracking kaydı oluşturur.
    /// SADECE başarılı yanıtlarda (transactionId döndüğünde) tracking yapılır.
    /// </summary>
    private async Task TrackAddConsentResultAsync(IysFirmContext ctx, AddSingleConsentRequest request, ConsentResponse? result)
    {
        try
        {
            if (result == null) return;

            DateTime? iysCreationDate = null;
            if (!string.IsNullOrEmpty(result.CreationDate))
                iysCreationDate = Convert.ToDateTime(result.CreationDate);

            // Errors → IysErrorFull mapping
            List<IysErrorFull>? errors = null;
            if (result.Errors is { Count: > 0 })
            {
                errors = result.Errors.Select(e => new IysErrorFull
                {
                    Code = e.Code,
                    Message = e.Message,
                    Index = e.Index,
                    Location = e.Location,
                    Value = e.Value
                }).ToList();
            }

            // Başarılı (transactionId var) → tam upsert
            // Başarısız (transactionId yok, errors var) → sadece errors + lastQueryDate güncelle
            await _tracker.UpsertConsentRecordAsync(
                firmId: ctx.FirmId,
                recipient: request.Recipient,
                type: request.Type,
                recipientType: request.RecipientType,
                source: request.Source,
                consentDate: request.ConsentDate,
                transactionId: result.TransactionId,
                status: !string.IsNullOrEmpty(result.TransactionId) ? request.Status : null,
                iysCreationDate: iysCreationDate,
                errors: errors);
        }
        catch
        {
            // Tracking hatası ana akışı etkilememeli
        }
    }

    /// <summary>
    /// İzin durum sorgulama sonrası IYS API yanıtını parse edip MongoDB kaydını günceller.
    /// </summary>
    private async Task TrackStatusQueryResultAsync(IysFirmContext ctx, GetConsentStatusRequest request, ConsentStatusResponse? result)
    {
        try
        {
            if (result == null) return;

            if (!string.IsNullOrEmpty(result.Status))
            {
                await _tracker.UpdateConsentStatusAsync(
                    firmId: ctx.FirmId,
                    recipient: request.Recipient,
                    type: request.Type,
                    status: result.Status,
                    source: result.Source,
                    transactionId: result.TransactionId,
                    consentDate: result.ConsentDate);
            }
        }
        catch
        {
            // Tracking hatası ana akışı etkilememeli
        }
    }
}
