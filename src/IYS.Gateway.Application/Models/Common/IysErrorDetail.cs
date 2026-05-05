using System.Text.Json.Serialization;

namespace IYS.Gateway.Application.Models.Common;

/// <summary>
/// IYS API hata detay modeli. Hem API response hem MongoDB entity'de kullanılır.
/// OpenAPI: InvalidError — { code, message, location, value }
/// MongoDB: BsonIgnoreExtraElements ile uyumlu (MongoDB driver JsonPropertyName'leri dikkate almaz).
/// </summary>
public class IysErrorDetail
{
    /// <summary>Batch istek içindeki sıra numarası (0-based)</summary>
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    /// <summary>Hata kodu (ör: H121, H120, H111)</summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>Hata mesajı</summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>Hatalı alan yolu (ör: ["type"], ["consentDate"])</summary>
    [JsonPropertyName("location")]
    public List<string>? Location { get; set; }

    /// <summary>Hatalı değer</summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
