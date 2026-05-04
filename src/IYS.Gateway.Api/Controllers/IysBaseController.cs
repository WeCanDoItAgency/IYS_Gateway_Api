using IYS.Gateway.Api.Middleware;
using IYS.Gateway.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace IYS.Gateway.Api.Controllers;

/// <summary>
/// Tüm IYS Gateway controller'ları için temel sınıf.
/// FirmGuid çözümleme ve IysFirmContext erişimi sağlar.
/// </summary>
[ApiController]
[Route("api/iys")]
public abstract class IysBaseController : ControllerBase
{
    private readonly IIysFirmResolver _firmResolver;

    protected IysBaseController(IIysFirmResolver firmResolver)
    {
        _firmResolver = firmResolver;
    }

    /// <summary>
    /// HttpContext'ten FirmGuid'i alır. Middleware tarafından zorunlu olarak kontrol edilmiştir.
    /// </summary>
    protected Guid GetFirmGuid()
    {
        return (Guid)HttpContext.Items[FirmGuidValidationMiddleware.FirmGuidItemKey]!;
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
