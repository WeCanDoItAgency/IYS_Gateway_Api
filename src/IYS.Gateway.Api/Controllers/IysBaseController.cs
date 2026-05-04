using IYS.Gateway.Api.Middleware;
using IYS.Gateway.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace IYS.Gateway.Api.Controllers;

/// <summary>
/// Tüm IYS Gateway controller'ları için temel sınıf.
/// FirmGuid çözümleme, loglama ve IysFirmContext erişimi sağlar.
/// </summary>
[ApiController]
[Route("api/iys")]
public abstract class IysBaseController : ControllerBase
{
    private readonly IIysFirmResolver _firmResolver;
    protected readonly ILogger Logger;

    protected IysBaseController(IIysFirmResolver firmResolver, ILogger logger)
    {
        _firmResolver = firmResolver;
        Logger = logger;
    }

    /// <summary>
    /// HttpContext'ten FirmGuid'i alır. Middleware tarafından zorunlu olarak kontrol edilmiştir.
    /// </summary>
    protected Guid GetFirmGuid()
    {
        return (Guid)HttpContext.Items[FirmGuidValidationMiddleware.FirmGuidItemKey]!;
    }

    /// <summary>
    /// HttpContext'ten CorrelationId'yi alır.
    /// </summary>
    protected string GetCorrelationId()
    {
        return HttpContext.Items[CorrelationIdMiddleware.ItemKey]?.ToString() ?? "N/A";
    }

    /// <summary>
    /// FirmGuid'den tam IYS firma bağlamını çözer.
    /// Token, iysCode, brandCode otomatik olarak resolve edilir.
    /// </summary>
    protected async Task<IysFirmContext> ResolveFirmContextAsync()
    {
        var firmGuid = GetFirmGuid();
        return await _firmResolver.ResolveAsync(firmGuid);
    }
}
