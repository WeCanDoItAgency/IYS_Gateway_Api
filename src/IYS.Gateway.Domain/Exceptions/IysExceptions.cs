namespace IYS.Gateway.Domain.Exceptions;

/// <summary>
/// IYS API'den dönen hata yanıtları için temel exception sınıfı.
/// HTTP status code, hata kodu ve açıklama bilgilerini taşır.
/// </summary>
public class IysApiException : Exception
{
    /// <summary>IYS API'den dönen HTTP durum kodu</summary>
    public int StatusCode { get; }

    /// <summary>IYS hata kodu (ör: H001, H015, H085)</summary>
    public string? ErrorCode { get; }

    public IysApiException(string message, int statusCode, string? errorCode = null)
        : base(message)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
}

/// <summary>
/// Token süresi dolmuş ve yenileme de başarısız olduğunda fırlatılır.
/// </summary>
public class IysTokenExpiredException : IysApiException
{
    public IysTokenExpiredException(string message)
        : base(message, 401, "TOKEN_EXPIRED")
    {
    }
}

/// <summary>
/// IYS API rate limit aşıldığında fırlatılır.
/// HTTP 429 - Too Many Requests.
/// Token alma servisi: IP başına saatte 10 istek.
/// Diğer servisler: Endpoint'e göre değişir (dakikada 2-100 istek).
/// </summary>
public class IysRateLimitException : IysApiException
{
    /// <summary>Yeniden deneme için beklenilmesi gereken süre (saniye)</summary>
    public int? RetryAfterSeconds { get; }

    public IysRateLimitException(string message, int? retryAfterSeconds = null)
        : base(message, 429, "RATE_LIMIT_EXCEEDED")
    {
        RetryAfterSeconds = retryAfterSeconds;
    }
}

/// <summary>
/// FirmGuid ile firma bulunamadığında veya IYS entegrasyonu aktif olmadığında fırlatılır.
/// </summary>
public class FirmNotFoundException : Exception
{
    public Guid FirmGuid { get; }

    public FirmNotFoundException(Guid firmGuid)
        : base($"FirmGuid '{firmGuid}' ile firma bulunamadı veya IYS entegrasyonu aktif değil.")
    {
        FirmGuid = firmGuid;
    }
}

/// <summary>
/// Firma için brandCode resolve edilemediğinde fırlatılır.
/// </summary>
public class BrandNotFoundException : Exception
{
    public int IysCode { get; }
    public string BrandName { get; }

    public BrandNotFoundException(int iysCode, string brandName)
        : base($"IysCode '{iysCode}' için '{brandName}' adlı marka bulunamadı.")
    {
        IysCode = iysCode;
        BrandName = brandName;
    }
}
