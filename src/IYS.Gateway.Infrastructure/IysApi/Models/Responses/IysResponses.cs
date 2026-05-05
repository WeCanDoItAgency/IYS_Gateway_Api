using System.Text.Json.Serialization;

namespace IYS.Gateway.Infrastructure.IysApi.Models.Responses;

// ═══════════════════════════════════════════════════════════════
// Bu dosya SADECE IYS Remote API'ye özgü Infrastructure-level response'ları içerir.
// Consent response modelleri → IYS.Gateway.Application.Models.Consent.ConsentResponses.cs
// Brand response modelleri → IYS.Gateway.Application.Models.Brand.BrandResponses.cs
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// IYS OAuth2 token yanıtı.
/// Token alma: grant_type=password ile username/password gönderilir.
/// Token yenileme: grant_type=refresh_token ile refresh_token gönderilir.
/// Rate Limit: IP başına saatte en fazla 10 istek.
/// </summary>
public class Oauth2Response
{
    /// <summary>API isteklerinde Authorization header'ında kullanılacak erişim jetonu</summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = null!;

    /// <summary>Erişim jetonu süresi dolduğunda yenilemek için kullanılacak jeton</summary>
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = null!;

    /// <summary>Erişim jetonunun geçerlilik süresi (saniye cinsinden). Varsayılan: 7200 (2 saat)</summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    /// <summary>Yenileme jetonunun geçerlilik süresi (saniye cinsinden). Varsayılan: 14400 (4 saat)</summary>
    [JsonPropertyName("refresh_expires_in")]
    public int RefreshExpiresIn { get; set; }

    /// <summary>Jeton tipi. Her zaman "bearer" döner.</summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = "bearer";
}
