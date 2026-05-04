using System.Net;
using System.Text.Json;
using IYS.Gateway.Domain.Exceptions;

namespace IYS.Gateway.Api.Middleware;

/// <summary>
/// Global hata yakalama middleware'i.
/// IYS API exception'larını, firma bulunamadı hatalarını ve beklenmeyen hataları
/// yapısal JSON yanıtlarına dönüştürür.
/// </summary>
public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (FirmNotFoundException ex)
        {
            _logger.LogWarning("Firma bulunamadı: {FirmGuid}", ex.FirmGuid);
            await WriteErrorResponse(context, HttpStatusCode.NotFound, ex.Message, "FIRM_NOT_FOUND");
        }
        catch (BrandNotFoundException ex)
        {
            _logger.LogWarning("Marka bulunamadı: IysCode={IysCode}, Brand={Brand}", ex.IysCode, ex.BrandName);
            await WriteErrorResponse(context, HttpStatusCode.NotFound, ex.Message, "BRAND_NOT_FOUND");
        }
        catch (IysRateLimitException ex)
        {
            _logger.LogWarning("IYS Rate Limit: {Message}, RetryAfter={RetryAfter}s", ex.Message, ex.RetryAfterSeconds);
            if (ex.RetryAfterSeconds.HasValue)
                context.Response.Headers["Retry-After"] = ex.RetryAfterSeconds.Value.ToString();
            await WriteErrorResponse(context, HttpStatusCode.TooManyRequests, ex.Message, "RATE_LIMIT_EXCEEDED");
        }
        catch (IysTokenExpiredException ex)
        {
            _logger.LogWarning("IYS Token süresi dolmuş: {Message}", ex.Message);
            await WriteErrorResponse(context, HttpStatusCode.Unauthorized, ex.Message, "TOKEN_EXPIRED");
        }
        catch (IysApiException ex)
        {
            _logger.LogError("IYS API hatası: StatusCode={StatusCode}, Message={Message}", ex.StatusCode, ex.Message);
            await WriteErrorResponse(context, (HttpStatusCode)ex.StatusCode, ex.Message, ex.ErrorCode);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Beklenmeyen hata oluştu.");
            await WriteErrorResponse(context, HttpStatusCode.InternalServerError,
                "Beklenmeyen bir sunucu hatası oluştu.", "INTERNAL_ERROR");
        }
    }

    private static async Task WriteErrorResponse(HttpContext context, HttpStatusCode statusCode, string message, string? errorCode)
    {
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        var error = new
        {
            error = errorCode ?? "UNKNOWN_ERROR",
            message,
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(error, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }));
    }
}

public static class GlobalExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}
