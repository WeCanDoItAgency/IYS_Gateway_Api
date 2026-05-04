using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Models.Consent;
using IYS.Gateway.Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace IYS.Gateway.Api.Controllers;

/// <summary>
/// İzin Yönetimi Controller'ı.
/// IYS'ye izin ekleme, sorgulama, geçmiş ve push bildirim işlemlerini yönetir.
/// Tüm endpoint'ler X-Firm-Guid header'ı gerektirir.
/// 
/// Otomatik çözümlenen parametreler:
/// - iysCode: FirmGuid → NewFirmsMongo.IysCustomerCode
/// - brandCode: IYS API /brands endpoint'inden firma adı ile eşleştirilir (24h cache)
/// - token: OAuth2 access_token (otomatik yönetim: get/refresh/cache)
/// </summary>
[Tags("İzin Yönetimi")]
public class ConsentController : IysBaseController
{
    private readonly IConsentService _consentService;

    public ConsentController(
        IIysFirmResolver firmResolver,
        IConsentService consentService,
        ILogger<ConsentController> logger) : base(firmResolver, logger)
    {
        _consentService = consentService;
    }

    // ═══════════════════════════════════════════════════════════════
    // 1. TEKİL İZİN EKLEME
    // ═══════════════════════════════════════════════════════════════

    /// <summary>
    /// Tekil izin ekleme. Tek bir alıcı için izin kaydı oluşturur.
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** POST /sps/{iysCode}/brands/{brandCode}/consents
    /// 
    /// **Rate Limit:** Dakikada 50 istek
    /// 
    /// **Kısıtlar:**
    /// - İlk izin kaydında status RET olamaz
    /// - consentDate 3 iş gününden eski olamaz
    /// - Telefon formatı: +905XXXXXXXXX
    /// 
    /// **Otomatik çözümlenen:** iysCode, brandCode, token
    /// 
    /// **Örnek İstek:**
    /// ```json
    /// {
    ///   "type": "MESAJ",
    ///   "recipient": "+905001234567",
    ///   "recipientType": "BIREYSEL",
    ///   "status": "ONAY",
    ///   "consentDate": "2024-01-15 10:30:00",
    ///   "source": "HS_WEB"
    /// }
    /// ```
    /// </remarks>
    /// <param name="request">İzin bilgileri</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("consent")]
    public async Task<IActionResult> AddSingleConsent([FromBody] AddSingleConsentRequest request, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        Logger.LogInformation("Tekil izin ekleme başlatıldı. Firma: {FirmGuid}, Alıcı: {Recipient}", firmGuid, request.Recipient);
        var result = await _consentService.AddSingleConsentAsync(firmGuid, request);
        return Ok(result);
    }

    /// <summary>
    /// Tekil izin ekleme (v2). Geliştirilmiş response formatı.
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** POST /v2/sps/{iysCode}/brands/{brandCode}/consents
    /// 
    /// **Rate Limit:** Dakikada 50 istek
    /// 
    /// Parametreler v1 ile aynıdır. Response formatı geliştirilmiştir.
    /// </remarks>
    /// <param name="request">İzin bilgileri</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("consent/v2")]
    public async Task<IActionResult> AddSingleConsentV2([FromBody] AddSingleConsentRequest request, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        Logger.LogInformation("Tekil izin ekleme (v2) başlatıldı. Firma: {FirmGuid}", firmGuid);
        var result = await _consentService.AddSingleConsentV2Async(firmGuid, request);
        return Ok(result);
    }

    // ═══════════════════════════════════════════════════════════════
    // 2. TOPLU İZİN EKLEME
    // ═══════════════════════════════════════════════════════════════

    /// <summary>
    /// Toplu izin ekleme. Asenkron işlem başlatır, requestId döner.
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** POST /sps/{iysCode}/brands/{brandCode}/consents/request
    /// 
    /// **Rate Limit:** Dakikada 2 istek, maksimum 10.000 kayıt/istek
    /// 
    /// **Örnek İstek:**
    /// ```json
    /// {
    ///   "consents": [
    ///     {
    ///       "type": "MESAJ",
    ///       "recipient": "+905001234567",
    ///       "recipientType": "BIREYSEL",
    ///       "status": "ONAY",
    ///       "consentDate": "2024-01-15 10:30:00",
    ///       "source": "HS_WEB"
    ///     }
    ///   ]
    /// }
    /// ```
    /// </remarks>
    /// <param name="request">Toplu izin listesi</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("consent/batch")]
    public async Task<IActionResult> AddBatchConsent([FromBody] AddBatchConsentRequest request, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        Logger.LogInformation("Toplu izin ekleme başlatıldı. Firma: {FirmGuid}, Kayıt Sayısı: {Count}", firmGuid, request.Consents?.Count ?? 0);
        var result = await _consentService.AddBatchConsentAsync(firmGuid, request);
        return Ok(result);
    }

    /// <summary>
    /// Toplu izin ekleme (v2). Geliştirilmiş response formatı.
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** POST /v2/sps/{iysCode}/brands/{brandCode}/consents/request
    /// 
    /// **Rate Limit:** Dakikada 2 istek, maksimum 10.000 kayıt/istek
    /// </remarks>
    /// <param name="request">Toplu izin listesi</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("consent/batch/v2")]
    public async Task<IActionResult> AddBatchConsentV2([FromBody] AddBatchConsentRequest request, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        Logger.LogInformation("Toplu izin ekleme (v2) başlatıldı. Firma: {FirmGuid}", firmGuid);
        var result = await _consentService.AddBatchConsentV2Async(firmGuid, request);
        return Ok(result);
    }

    // ═══════════════════════════════════════════════════════════════
    // 3. TOPLU İZİN SONUÇ SORGULAMA
    // ═══════════════════════════════════════════════════════════════

    /// <summary>
    /// Toplu izin sonucunu sorgulama. requestId ile asenkron işlem sonucunu döner.
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** GET /sps/{iysCode}/brands/{brandCode}/consents/request/{requestId}
    /// 
    /// **Rate Limit:** Dakikada 20 istek
    /// </remarks>
    /// <param name="requestId">Toplu izin isteğinin requestId değeri</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpGet("consent/batch/{requestId}")]
    public async Task<IActionResult> GetBatchConsentStatus(string requestId, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        var result = await _consentService.GetBatchConsentStatusAsync(firmGuid, requestId);
        return Ok(result);
    }

    /// <summary>
    /// Toplu izin sonucunu sorgulama (v2).
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** GET /v2/sps/{iysCode}/brands/{brandCode}/consents/request/{requestId}
    /// 
    /// **Rate Limit:** Dakikada 20 istek
    /// </remarks>
    /// <param name="requestId">Toplu izin isteğinin requestId değeri</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpGet("consent/batch/v2/{requestId}")]
    public async Task<IActionResult> GetBatchConsentStatusV2(string requestId, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        var result = await _consentService.GetBatchConsentStatusV2Async(firmGuid, requestId);
        return Ok(result);
    }

    // ═══════════════════════════════════════════════════════════════
    // 4. TEKİL İZİN DURUM SORGULAMA
    // ═══════════════════════════════════════════════════════════════

    /// <summary>
    /// Tekil izin durum sorgulama. Belirli bir alıcının mevcut izin durumunu döner.
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** POST /sps/{iysCode}/brands/{brandCode}/consents/status
    /// 
    /// **Rate Limit:** Dakikada 100 istek
    /// 
    /// **Örnek İstek:**
    /// ```json
    /// {
    ///   "recipient": "+905001234567",
    ///   "recipientType": "BIREYSEL",
    ///   "type": "MESAJ"
    /// }
    /// ```
    /// </remarks>
    /// <param name="request">Sorgulanacak alıcı bilgileri</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("consent/status")]
    public async Task<IActionResult> GetSingleConsentStatus([FromBody] GetConsentStatusRequest request, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        var result = await _consentService.GetSingleConsentStatusAsync(firmGuid, request);
        return Ok(result);
    }

    // ═══════════════════════════════════════════════════════════════
    // 5. ÇOKLU İZİN DURUM SORGULAMA
    // ═══════════════════════════════════════════════════════════════

    /// <summary>
    /// Çoklu izin durum sorgulama. Birden fazla alıcının izin durumunu toplu sorgular.
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** POST /sps/{iysCode}/brands/{brandCode}/consents/{recipientType}/status/{type}
    /// 
    /// **Rate Limit:** Dakikada 10 istek, maksimum 1.000 alıcı/istek
    /// 
    /// **Örnek İstek:**
    /// ```json
    /// {
    ///   "recipients": ["+905001234567", "+905009876543"]
    /// }
    /// ```
    /// </remarks>
    /// <param name="recipientType">Alıcı tipi: BIREYSEL | TACIR</param>
    /// <param name="type">İzin türü: ARAMA | MESAJ | EPOSTA</param>
    /// <param name="request">Alıcı listesi</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("consent/status/{recipientType}/{type}")]
    public async Task<IActionResult> GetMultipleConsentStatus(string recipientType, string type, [FromBody] GetMultipleConsentStatusRequest request, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        var result = await _consentService.GetMultipleConsentStatusAsync(firmGuid, recipientType, type, request);
        return Ok(result);
    }

    // ═══════════════════════════════════════════════════════════════
    // 6. İZİN GEÇMİŞİ
    // ═══════════════════════════════════════════════════════════════

    /// <summary>
    /// İzin geçmişi sorgulama. Belirli bir alıcının tüm izin değişiklik geçmişini döner.
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** POST /sps/{iysCode}/brands/{brandCode}/consents/history
    /// 
    /// **Rate Limit:** Dakikada 100 istek
    /// 
    /// **Örnek İstek:**
    /// ```json
    /// {
    ///   "recipient": "+905001234567",
    ///   "recipientType": "BIREYSEL",
    ///   "type": "MESAJ"
    /// }
    /// ```
    /// </remarks>
    /// <param name="request">Geçmiş sorgulanacak alıcı bilgileri</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("consent/history")]
    public async Task<IActionResult> GetConsentHistory([FromBody] GetConsentHistoryRequest request, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        var result = await _consentService.GetConsentHistoryAsync(firmGuid, request);
        return Ok(result);
    }

    // ═══════════════════════════════════════════════════════════════
    // 7. İZİN DEĞİŞİKLİKLERİ
    // ═══════════════════════════════════════════════════════════════

    /// <summary>
    /// İzin değişiklikleri sorgulama. Belirli bir tarihten sonraki tüm izin hareketlerini döner.
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** GET /sps/{iysCode}/brands/{brandCode}/consents/changes
    /// 
    /// **Rate Limit:** Dakikada 50 istek, varsayılan limit 500
    /// </remarks>
    /// <param name="after">Son alınan kayıdın cursor değeri</param>
    /// <param name="limit">Sayfa başı kayıt sayısı (varsayılan: 500)</param>
    /// <param name="source">Kaynak filtresi (opsiyonel)</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpGet("consent/changes")]
    public async Task<IActionResult> GetConsentChanges([FromQuery] string? after, [FromQuery] int? limit, [FromQuery] string? source, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        var queryParams = new Dictionary<string, string>();
        if (!string.IsNullOrEmpty(after)) queryParams["after"] = after;
        if (limit.HasValue) queryParams["limit"] = limit.Value.ToString();
        if (!string.IsNullOrEmpty(source)) queryParams["source"] = source;

        var result = await _consentService.GetConsentChangesAsync(firmGuid, queryParams.Count > 0 ? queryParams : null);
        return Ok(result);
    }

    // ═══════════════════════════════════════════════════════════════
    // 8. PUSH BİLDİRİM
    // ═══════════════════════════════════════════════════════════════

    /// <summary>
    /// Push bildirim kaydı oluşturma. İzin hareketlerinin anlık iletileceği URL kaydeder.
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** POST /sps/{iysCode}/brands/{brandCode}/push/registration
    /// 
    /// **Rate Limit:** Dakikada 5 istek
    /// 
    /// **Örnek İstek:**
    /// ```json
    /// {
    ///   "url": "https://example.com/iys/webhook",
    ///   "type": "CONSENT_CHANGE"
    /// }
    /// ```
    /// </remarks>
    /// <param name="request">Push bildirim kayıt bilgileri</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("consent/push/register")]
    public async Task<IActionResult> RegisterPush([FromBody] RegisterPushRequest request, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        Logger.LogInformation("Push bildirim kaydı oluşturuluyor. Firma: {FirmGuid}", firmGuid);
        var result = await _consentService.RegisterPushAsync(firmGuid, request);
        return Ok(result);
    }

    /// <summary>
    /// Push bildirim durumu sorgulama.
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** GET /sps/{iysCode}/brands/{brandCode}/push/registration
    /// 
    /// **Rate Limit:** Dakikada 5 istek
    /// </remarks>
    /// <param name="ct">İptal token'ı</param>
    [HttpGet("consent/push/status")]
    public async Task<IActionResult> GetPushStatus(CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        var result = await _consentService.GetPushStatusAsync(firmGuid);
        return Ok(result);
    }

    /// <summary>
    /// Push bildirim kaydını silme.
    /// </summary>
    /// <remarks>
    /// **IYS Remote API:** POST /sps/{iysCode}/brands/{brandCode}/push/unregistration
    /// 
    /// **Rate Limit:** Dakikada 5 istek
    /// </remarks>
    /// <param name="request">Silinecek push bildirim tipi</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("consent/push/unregister")]
    public async Task<IActionResult> UnregisterPush([FromBody] UnregisterPushRequest request, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        Logger.LogInformation("Push bildirim kaydı siliniyor. Firma: {FirmGuid}", firmGuid);
        var result = await _consentService.UnregisterPushAsync(firmGuid, request);
        return Ok(result);
    }
}
