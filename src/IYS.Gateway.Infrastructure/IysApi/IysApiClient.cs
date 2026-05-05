using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using IYS.Gateway.Application.Common;
using IYS.Gateway.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace IYS.Gateway.Infrastructure.IysApi;

/// <summary>
/// IYS API ile tüm HTTP iletişimini yöneten typed HttpClient.
/// Polly resiliency pipeline ile sarılır (retry + circuit breaker).
/// System.Text.Json ile serialize/deserialize yapar.
/// </summary>
public class IysApiClient : IIysApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<IysApiClient> _logger;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    public IysApiClient(HttpClient httpClient, ILogger<IysApiClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<TResponse?> GetAsync<TResponse>(
        IysFirmContext context, string endpoint, Dictionary<string, string>? queryParams = null)
    {
        var url = BuildUrl(endpoint, queryParams);
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

        return await SendAsync<TResponse>(request, context);
    }

    /// <inheritdoc/>
    public async Task<TResponse?> PostAsync<TRequest, TResponse>(
        IysFirmContext context, string endpoint, TRequest body)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
        request.Content = new StringContent(
            JsonSerializer.Serialize(body, JsonOptions),
            Encoding.UTF8,
            "application/json");

        return await SendAsync<TResponse>(request, context);
    }

    /// <inheritdoc/>
    public async Task<TResponse?> DeleteAsync<TResponse>(IysFirmContext context, string endpoint)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, endpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

        return await SendAsync<TResponse>(request, context);
    }

    /// <inheritdoc/>
    public async Task<TResponse?> PostFormAsync<TResponse>(string endpoint, Dictionary<string, string> formData)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        request.Content = new FormUrlEncodedContent(formData);

        return await SendAsync<TResponse>(request, firmContext: null);
    }

    /// <summary>
    /// HTTP isteğini gönderir ve yanıtı deserialize eder.
    /// 429 (rate limit) ve 5xx (sunucu hatası) durumlarını özel olarak handle eder.
    /// </summary>
    private async Task<TResponse?> SendAsync<TResponse>(HttpRequestMessage request, IysFirmContext? firmContext)
    {
        var firmLog = firmContext != null ? $"[{firmContext.FirmId} - {firmContext.FirmName}]" : "[TOKEN]";

        try
        {
            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            _logger.LogDebug("{FirmLog} IYS API {Method} {Url} → {StatusCode}",
                firmLog, request.Method, request.RequestUri, (int)response.StatusCode);

            if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                int? retryAfter = null;
                if (response.Headers.RetryAfter?.Delta.HasValue == true)
                    retryAfter = (int)response.Headers.RetryAfter.Delta.Value.TotalSeconds;

                _logger.LogWarning("{FirmLog} IYS Rate Limit aşıldı. RetryAfter: {RetryAfter}s",
                    firmLog, retryAfter);

                throw new IysRateLimitException(
                    $"IYS API rate limit aşıldı. Endpoint: {request.RequestUri}", retryAfter);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                if (firmContext == null)
                {
                    // Token endpoint 401 → credential hatası (username/password yanlış)
                    _logger.LogError("IYS OAuth2 credential hatası! Endpoint: {Url}, Response: {Content}",
                        request.RequestUri, content);
                    throw new IysApiException(
                        $"IYS OAuth2 kimlik doğrulama başarısız. Firma credential'ları kontrol edilmeli. Response: {content}", 401);
                }

                // Normal API endpoint 401 → token süresi dolmuş
                _logger.LogWarning("{FirmLog} IYS Token geçersiz veya süresi dolmuş.", firmLog);
                throw new IysTokenExpiredException("IYS token geçersiz veya süresi dolmuş.");
            }

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("{FirmLog} IYS API hata: {StatusCode} - {Content}",
                    firmLog, (int)response.StatusCode, content);

                // IYS iş mantığı hatası (4xx) — response body'yi TResponse olarak deserialize et.
                // Böylece caller'daki tracking (TrackAddConsentResultAsync) çalışabilir.
                if (!string.IsNullOrWhiteSpace(content))
                {
                    try
                    {
                        var errorResult = JsonSerializer.Deserialize<TResponse>(content, JsonOptions);
                        if (errorResult != null)
                            return errorResult;
                    }
                    catch (JsonException)
                    {
                        // Deserialize edilemezse aşağıda exception fırlatılır
                    }
                }

                throw new IysApiException(
                    $"IYS API hatası: {content}",
                    (int)response.StatusCode);
            }

            if (string.IsNullOrWhiteSpace(content))
                return default;

            return JsonSerializer.Deserialize<TResponse>(content, JsonOptions);
        }
        catch (IysApiException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{FirmLog} IYS API iletişim hatası: {Url}", firmLog, request.RequestUri);
            throw new IysApiException($"IYS API iletişim hatası: {ex.Message}", 0);
        }
    }

    /// <summary>
    /// URL'ye query string parametreleri ekler.
    /// </summary>
    private static string BuildUrl(string endpoint, Dictionary<string, string>? queryParams)
    {
        if (queryParams == null || queryParams.Count == 0)
            return endpoint;

        var query = string.Join("&", queryParams
            .Where(kv => !string.IsNullOrEmpty(kv.Value))
            .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));

        return $"{endpoint}?{query}";
    }
}
