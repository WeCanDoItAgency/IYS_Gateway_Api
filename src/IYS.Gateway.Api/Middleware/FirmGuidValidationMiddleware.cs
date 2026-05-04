using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace IYS.Gateway.Api.Middleware;

/// <summary>
/// FirmGuid zorunluluk middleware'i.
/// Her API isteğinde X-Firm-Guid header'ını kontrol eder.
/// Yoksa veya geçersiz formattaysa 400 BadRequest döner.
/// Health check ve Swagger endpoint'leri hariç tutulur.
/// </summary>
public class FirmGuidValidationMiddleware
{
    private readonly RequestDelegate _next;
    public const string FirmGuidHeaderName = "X-Firm-Guid";
    public const string FirmGuidItemKey = "FirmGuid";

    /// <summary>FirmGuid kontrolü uygulanmayacak path'ler</summary>
    private static readonly string[] ExcludedPaths =
    [
        "/health",
        "/swagger",
        "/favicon.ico"
    ];

    public FirmGuidValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value?.ToLowerInvariant() ?? "";

        // Hariç tutulan path'ler
        if (ExcludedPaths.Any(p => path.StartsWith(p)))
        {
            await _next(context);
            return;
        }

        // /api/ ile başlamayan istekleri atla
        if (!path.StartsWith("/api/"))
        {
            await _next(context);
            return;
        }

        // X-Firm-Guid header kontrolü
        if (!context.Request.Headers.TryGetValue(FirmGuidHeaderName, out var firmGuidHeader) ||
            string.IsNullOrWhiteSpace(firmGuidHeader))
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var error = new { error = $"{FirmGuidHeaderName} header'ı zorunludur." };
            await context.Response.WriteAsync(JsonSerializer.Serialize(error));
            return;
        }

        if (!Guid.TryParse(firmGuidHeader, out var firmGuid))
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var error = new { error = $"{FirmGuidHeaderName} geçerli bir GUID formatında olmalıdır." };
            await context.Response.WriteAsync(JsonSerializer.Serialize(error));
            return;
        }

        // FirmGuid'i HttpContext'e ekle — controller'larda kullanılır
        context.Items[FirmGuidItemKey] = firmGuid;

        await _next(context);
    }
}

/// <summary>
/// FirmGuid middleware extension metodu.
/// </summary>
public static class FirmGuidValidationMiddlewareExtensions
{
    public static IApplicationBuilder UseFirmGuidValidation(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<FirmGuidValidationMiddleware>();
    }
}
