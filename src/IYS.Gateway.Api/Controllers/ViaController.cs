using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Models.Via;
using IYS.Gateway.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IYS.Gateway.Api.Controllers;

/// <summary>
/// ViA, KVK, ViaPass ve ViaFrame Controller'ı.
/// IYS'nin gelişmiş izin yönetimi araçlarını kapsar.
/// Tüm endpoint'ler X-Firm-Guid header'ı gerektirir.
/// </summary>
[Tags("ViA & KVK & ViaPass & ViaFrame")]
public class ViaController : IysBaseController
{
    private readonly IViaService _viaService;

    public ViaController(IIysFirmResolver firmResolver, IViaService viaService, ILogger<ViaController> logger)
        : base(firmResolver, logger)
    {
        _viaService = viaService;
    }

    /// <summary>ViA abonelik listesi.</summary>
    /// <remarks>**IYS Remote API:** GET /sps/{iysCode}/brands/{brandCode}/via/subscriptions | **Rate Limit:** Dakikada 50 istek</remarks>
    [HttpGet("via/subscriptions")]
    public async Task<IActionResult> GetViaSubscriptions(CancellationToken ct)
    {
        var result = await _viaService.GetViaSubscriptionsAsync(GetFirmGuid());
        return Ok(result);
    }

    /// <summary>ViA abonelik detayı.</summary>
    /// <remarks>**IYS Remote API:** GET /sps/{iysCode}/brands/{brandCode}/via/subscriptions/{subscriptionCode} | **Rate Limit:** Dakikada 50 istek</remarks>
    /// <param name="subscriptionCode">Abonelik kodu</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpGet("via/subscriptions/{subscriptionCode}")]
    public async Task<IActionResult> GetViaSubscriptionDetail(string subscriptionCode, CancellationToken ct)
    {
        var result = await _viaService.GetViaSubscriptionDetailAsync(GetFirmGuid(), subscriptionCode);
        return Ok(result);
    }

    /// <summary>KVK onay durumu sorgulama.</summary>
    /// <remarks>
    /// **IYS Remote API:** POST /sps/{iysCode}/brands/{brandCode}/kvk/consents/status | **Rate Limit:** Dakikada 100 istek
    /// 
    /// **Örnek İstek:**
    /// ```json
    /// {
    ///   "recipient": "+905001234567",
    ///   "recipientType": "BIREYSEL"
    /// }
    /// ```
    /// </remarks>
    /// <param name="request">Sorgulanacak alıcı bilgileri</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("kvk/status")]
    public async Task<IActionResult> GetKvkConsentStatus([FromBody] GetKvkConsentStatusRequest request, CancellationToken ct)
    {
        var result = await _viaService.GetKvkConsentStatusAsync(GetFirmGuid(), request);
        return Ok(result);
    }

    /// <summary>KVK izin ekleme.</summary>
    /// <remarks>
    /// **IYS Remote API:** POST /sps/{iysCode}/brands/{brandCode}/kvk/consents | **Rate Limit:** Dakikada 50 istek
    /// 
    /// **Örnek İstek:**
    /// ```json
    /// {
    ///   "recipient": "+905001234567",
    ///   "recipientType": "BIREYSEL",
    ///   "status": "ONAY",
    ///   "consentDate": "2024-01-15 10:30:00"
    /// }
    /// ```
    /// </remarks>
    /// <param name="request">KVK izin bilgileri</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("kvk/consent")]
    public async Task<IActionResult> AddKvkConsent([FromBody] AddKvkConsentRequest request, CancellationToken ct)
    {
        var firmGuid = GetFirmGuid();
        Logger.LogInformation("KVK izin ekleme başlatıldı. Firma: {FirmGuid}", firmGuid);
        var result = await _viaService.AddKvkConsentAsync(firmGuid, request);
        return Ok(result);
    }

    /// <summary>ViaPass kod gönderme. Alıcıya SMS ile doğrulama kodu gönderir.</summary>
    /// <remarks>**IYS Remote API:** POST /sps/{iysCode}/brands/{brandCode}/viapass/send | **Rate Limit:** Dakikada 50 istek</remarks>
    /// <param name="request">Telefon numarası</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("viapass/send")]
    public async Task<IActionResult> SendViaPass([FromBody] SendViaPassRequest request, CancellationToken ct)
    {
        var result = await _viaService.SendViaPassAsync(GetFirmGuid(), request);
        return Ok(result);
    }

    /// <summary>ViaPass kod doğrulama. Gönderilen kodu doğrular.</summary>
    /// <remarks>**IYS Remote API:** POST /sps/{iysCode}/brands/{brandCode}/viapass/verify | **Rate Limit:** Dakikada 50 istek</remarks>
    /// <param name="request">Doğrulama kodu ve telefon</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("viapass/verify")]
    public async Task<IActionResult> VerifyViaPass([FromBody] VerifyViaPassRequest request, CancellationToken ct)
    {
        var result = await _viaService.VerifyViaPassAsync(GetFirmGuid(), request);
        return Ok(result);
    }

    /// <summary>ViaFrame URL üretme. Web sayfalarına gömülebilir izin formu URL'si oluşturur.</summary>
    /// <remarks>
    /// **IYS Remote API:** POST /sps/{iysCode}/brands/{brandCode}/viaframe/url | **Rate Limit:** Dakikada 50 istek
    /// 
    /// Oluşan URL bir iframe içinde web sayfasına gömülebilir.
    /// </remarks>
    /// <param name="request">Return URL ve form tipi</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpPost("viaframe/url")]
    public async Task<IActionResult> GenerateViaFrameUrl([FromBody] GenerateViaFrameUrlRequest request, CancellationToken ct)
    {
        var result = await _viaService.GenerateViaFrameUrlAsync(GetFirmGuid(), request);
        return Ok(result);
    }

    /// <summary>ViaFrame sonuç sorgulama. Form tamamlandıktan sonra sonucu sorgular.</summary>
    /// <remarks>**IYS Remote API:** GET /sps/{iysCode}/brands/{brandCode}/viaframe/result/{token} | **Rate Limit:** Dakikada 50 istek</remarks>
    /// <param name="token">ViaFrame işlem token'ı</param>
    /// <param name="ct">İptal token'ı</param>
    [HttpGet("viaframe/result/{token}")]
    public async Task<IActionResult> GetViaFrameResult(string token, CancellationToken ct)
    {
        var result = await _viaService.GetViaFrameResultAsync(GetFirmGuid(), token);
        return Ok(result);
    }
}
