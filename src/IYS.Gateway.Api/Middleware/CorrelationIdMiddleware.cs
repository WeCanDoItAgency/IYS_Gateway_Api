using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace IYS.Gateway.Api.Middleware;

/// <summary>
/// İstek takibi middleware'i.
/// Her isteğe benzersiz bir CorrelationId atar ve tüm loglara scope olarak bağlar.
/// İstemci X-Correlation-Id header'ı gönderirse onu kullanır, yoksa yeni üretir.
/// Response'a da X-Correlation-Id header'ı eklenir — hata takibi için.
/// </summary>
public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CorrelationIdMiddleware> _logger;
    public const string HeaderName = "X-Correlation-Id";
    public const string ItemKey = "CorrelationId";

    public CorrelationIdMiddleware(RequestDelegate next, ILogger<CorrelationIdMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var correlationId = context.Request.Headers[HeaderName].FirstOrDefault()
                            ?? Guid.NewGuid().ToString("N");

        context.Items[ItemKey] = correlationId;
        context.Response.OnStarting(() =>
        {
            context.Response.Headers[HeaderName] = correlationId;
            return Task.CompletedTask;
        });

        using (_logger.BeginScope(new Dictionary<string, object> { [ItemKey] = correlationId }))
        {
            await _next(context);
        }
    }
}

/// <summary>
/// CorrelationId middleware extension metodu.
/// </summary>
public static class CorrelationIdMiddlewareExtensions
{
    public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CorrelationIdMiddleware>();
    }
}
