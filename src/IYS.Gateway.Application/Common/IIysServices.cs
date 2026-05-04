namespace IYS.Gateway.Application.Common;

/// <summary>
/// IYS token yönetimi interface'i.
/// Multi-pod ortamda MongoDB-based distributed token cache kullanır.
/// Token lifecycle: aktif → refresh → yeni al
/// </summary>
public interface IIysTokenManager
{
    /// <summary>
    /// Firma için geçerli bir access token döner.
    /// Aktif token varsa kullanır, refresh edilebilirse refresh eder, yoksa yeni alır.
    /// </summary>
    /// <param name="firmGuid">Firmanın benzersiz tanımlayıcısı</param>
    /// <returns>Geçerli access token string'i</returns>
    Task<string> GetValidTokenAsync(Guid firmGuid);
}

/// <summary>
/// FirmGuid'den IYS credentials ve brandCode çözümleyen interface.
/// MongoDB'den firma bilgilerini okur ve brandCode'u cache'ler.
/// </summary>
public interface IIysFirmResolver
{
    /// <summary>
    /// FirmGuid'den tam firma bağlamını (credentials + brandCode + token) çözer.
    /// </summary>
    /// <param name="firmGuid">Firmanın benzersiz tanımlayıcısı</param>
    /// <returns>Tüm auto-resolved parametreleri içeren IysFirmContext</returns>
    Task<IysFirmContext> ResolveAsync(Guid firmGuid);
}

/// <summary>
/// IYS API çağrıları için typed HTTP client interface'i.
/// Tüm IYS endpoint'lerini proxy eder.
/// </summary>
public interface IIysApiClient
{
    /// <summary>
    /// IYS API'ye GET isteği gönderir.
    /// </summary>
    /// <typeparam name="TResponse">Beklenen response tipi</typeparam>
    /// <param name="context">Firma bağlamı (token, iysCode, brandCode)</param>
    /// <param name="endpoint">IYS API endpoint yolu (format edilmiş)</param>
    /// <param name="queryParams">Opsiyonel query string parametreleri</param>
    Task<TResponse?> GetAsync<TResponse>(IysFirmContext context, string endpoint, Dictionary<string, string>? queryParams = null);

    /// <summary>
    /// IYS API'ye POST isteği gönderir.
    /// </summary>
    /// <typeparam name="TRequest">Request body tipi</typeparam>
    /// <typeparam name="TResponse">Beklenen response tipi</typeparam>
    /// <param name="context">Firma bağlamı (token, iysCode, brandCode)</param>
    /// <param name="endpoint">IYS API endpoint yolu (format edilmiş)</param>
    /// <param name="body">Request body nesnesi</param>
    Task<TResponse?> PostAsync<TRequest, TResponse>(IysFirmContext context, string endpoint, TRequest body);

    /// <summary>
    /// IYS API'ye DELETE isteği gönderir.
    /// </summary>
    /// <typeparam name="TResponse">Beklenen response tipi</typeparam>
    /// <param name="context">Firma bağlamı (token, iysCode, brandCode)</param>
    /// <param name="endpoint">IYS API endpoint yolu (format edilmiş)</param>
    Task<TResponse?> DeleteAsync<TResponse>(IysFirmContext context, string endpoint);

    /// <summary>
    /// IYS API'ye form-urlencoded POST isteği gönderir (OAuth2 token alma için).
    /// </summary>
    /// <typeparam name="TResponse">Beklenen response tipi</typeparam>
    /// <param name="endpoint">IYS API endpoint yolu</param>
    /// <param name="formData">Form verileri</param>
    Task<TResponse?> PostFormAsync<TResponse>(string endpoint, Dictionary<string, string> formData);
}
