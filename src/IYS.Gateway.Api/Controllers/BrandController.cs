using IYS.Gateway.Application.Common;
using IYS.Gateway.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IYS.Gateway.Api.Controllers;

/// <summary>
/// Marka, Bayi, Mutabakat ve Bilgi Controller'ı.
/// Tüm endpoint'ler X-Firm-Guid header'ı gerektirir.
/// </summary>
[Tags("Marka & Bayi & Mutabakat")]
public class BrandController : IysBaseController
{
    private readonly IBrandService _brandService;

    public BrandController(IIysFirmResolver firmResolver, IBrandService brandService) : base(firmResolver)
    {
        _brandService = brandService;
    }

    /// <summary>Marka listesi sorgulama.</summary>
    /// <remarks>**IYS Remote API:** GET /sps/{iysCode}/brands | **Rate Limit:** Dakikada 100 istek</remarks>
    [HttpGet("brands")]
    public async Task<IActionResult> GetBrands()
    {
        var result = await _brandService.GetBrandsAsync(GetFirmGuid());
        return Ok(result);
    }

    /// <summary>Marka detayı sorgulama.</summary>
    /// <remarks>**IYS Remote API:** GET /sps/{iysCode}/brands/{brandCode} | **Rate Limit:** Dakikada 100 istek</remarks>
    [HttpGet("brands/detail")]
    public async Task<IActionResult> GetBrandDetail()
    {
        var result = await _brandService.GetBrandDetailAsync(GetFirmGuid());
        return Ok(result);
    }

    /// <summary>Bayi listesi sorgulama.</summary>
    /// <remarks>**IYS Remote API:** GET /sps/{iysCode}/brands/{brandCode}/retailers | **Rate Limit:** Dakikada 100 istek</remarks>
    [HttpGet("retailers")]
    public async Task<IActionResult> GetRetailers()
    {
        var result = await _brandService.GetRetailersAsync(GetFirmGuid());
        return Ok(result);
    }

    /// <summary>Bayi detayı sorgulama.</summary>
    /// <remarks>**IYS Remote API:** GET /sps/{iysCode}/brands/{brandCode}/retailers/{retailerCode} | **Rate Limit:** Dakikada 100 istek</remarks>
    [HttpGet("retailers/{retailerCode:int}")]
    public async Task<IActionResult> GetRetailerDetail(int retailerCode)
    {
        var result = await _brandService.GetRetailerDetailAsync(GetFirmGuid(), retailerCode);
        return Ok(result);
    }

    /// <summary>İzin sayısı mutabakat raporu.</summary>
    /// <remarks>**IYS Remote API:** GET /sps/{iysCode}/brands/{brandCode}/consents/count | **Rate Limit:** Dakikada 50 istek</remarks>
    [HttpGet("reconciliation/count")]
    public async Task<IActionResult> GetConsentCount([FromQuery] string? date)
    {
        var queryParams = date != null ? new Dictionary<string, string> { ["date"] = date } : null;
        var result = await _brandService.GetConsentCountAsync(GetFirmGuid(), queryParams);
        return Ok(result);
    }

    /// <summary>IYS iletişim kaynakları listesi.</summary>
    /// <remarks>**IYS Remote API:** GET /sps/sources | **Rate Limit:** Dakikada 100 istek</remarks>
    [HttpGet("sources")]
    public async Task<IActionResult> GetSources()
    {
        var result = await _brandService.GetSourcesAsync(GetFirmGuid());
        return Ok(result);
    }
}
