# IYS Gateway API

> İleti Yönetim Sistemi (IYS) ile entegrasyon sağlayan merkezi gateway servisi.

---

## Genel Bakış

IYS Gateway API, Türkiye İleti Yönetim Sistemi'nin tüm API endpoint'lerini tek bir proxy üzerinden sunar. Multi-tenant mimaride her firmanın kendi IYS credential'ları ile çalışır.

**Temel Özellikler:**
- 🔐 Firma bazlı OAuth2 token yönetimi (otomatik cache, refresh, yenileme)
- ⚡ Stampede koruması — binlerce paralel istekte bile tek token isteği
- 🔄 401 auto-retry — token expire olursa otomatik yenileme + retry
- 🛡️ Polly ile retry + circuit breaker
- 📋 Swagger UI ile otomatik enum dokümantasyonu

---

## Mimari

```
┌─────────────────┐     ┌──────────────────┐     ┌─────────────────┐
│   WebUI / API   │────▶│  IYS Gateway API │────▶│   IYS API v3    │
│   Tüketiciler   │     │   (.NET 10)      │     │ api.iys.org.tr  │
└─────────────────┘     └──────┬───────────┘     └─────────────────┘
                               │
                    ┌──────────┼──────────┐
                    ▼          ▼          ▼
              ┌──────────┐ ┌───────┐ ┌───────┐
              │ Mongo 206│ │Mongo52│ │Mongo53│
              │  Firmalar│ │ Token │ │ Data  │
              └──────────┘ └───────┘ └───────┘
```

| Katman | Proje | Sorumluluk |
|:-------|:------|:-----------|
| API | `IYS.Gateway.Api` | Controller'lar, Swagger, Middleware |
| Application | `IYS.Gateway.Application` | Service interface'leri, DTO'lar, Enum attribute'leri |
| Domain | `IYS.Gateway.Domain` | Exception'lar, Constant'lar, Enum sabitleri |
| Infrastructure | `IYS.Gateway.Infrastructure` | IYS API client, Token yönetimi, MongoDB, Polly |

---

## Başlangıç

### Gereksinimler
- .NET 10 SDK
- Azure Key Vault erişimi (credential'lar)
- MongoDB bağlantısı (MONGO_52, MONGO_206)

### Çalıştırma
```bash
cd src/IYS.Gateway.Api
dotnet run
```

Swagger UI: `http://localhost:5062/swagger`

### Yapılandırma
`appsettings.json` içinde:
```json
{
  "IysApi": {
    "UseProduction": true,
    "ProductionBaseUrl": "https://api.iys.org.tr/"
  }
}
```

> ⚠️ Sandbox ortamı mevcut değildir. `UseProduction: true` zorunludur.

---

## API Kullanımı

Her istek `X-Firm-Guid` header'ı gerektirir:

```bash
curl -X POST http://localhost:5062/api/iys/consent/status \
  -H "X-Firm-Guid: 3fa85f64-5717-4562-b3fc-2c963f66afa6" \
  -H "Content-Type: application/json" \
  -d '{"recipient": "+905001234567", "recipientType": "BIREYSEL", "type": "MESAJ"}'
```

### Endpoint Kategorileri

| Kategori | Prefix | Açıklama |
|:---------|:-------|:---------|
| İzin Yönetimi | `/api/iys/consent/*` | Tekil/toplu izin ekleme, durum sorgulama, geçmiş |
| Marka & Bayi | `/api/iys/brands/*` | Marka/bayi listesi ve detay |
| Mutabakat | `/api/iys/reconciliation/*` | İzin sayısı raporu |
| Push Bildirim | `/api/iys/consent/push/*` | Webhook kayıt/silme |
| ViA & KVK | `/api/iys/kvk/*`, `/api/iys/via/*` | KVK onay, ViA abonelik |
| ViaPass | `/api/iys/viapass/*` | SMS doğrulama |
| ViaFrame | `/api/iys/viaframe/*` | Embed form URL üretme |

---

## Resiliency Stack

### Token Stampede Koruması (2 Katman)

**Layer 1 — In-Process (SemaphoreSlim):** Aynı pod içindeki paralel istekleri sıralar.

**Layer 2 — Distributed Lock (MongoDB):** Podlar arası koordinasyon sağlar.

```
Pod A ─ İstek 1 ──▶ SemaphoreSlim ──▶ MongoDB Lock (INSERT) ──▶ Token al ──▶ Lock sil
Pod A ─ İstek 2 ──▶ SemaphoreSlim ──▶ [bekle] ──▶ cache'den oku
Pod B ─ İstek 3 ──▶ SemaphoreSlim ──▶ MongoDB Lock (DUPLICATE KEY) ──▶ [bekle] ──▶ cache'den oku
Pod C ─ İstek 4 ──▶ SemaphoreSlim ──▶ MongoDB Lock (DUPLICATE KEY) ──▶ [bekle] ──▶ cache'den oku
```

1000 pod açılsa bile aynı firma için **tek bir OAuth2 token isteği** gider:
- Layer 1: Pod içinde SemaphoreSlim ile sadece 1 thread MongoDB'ye lock isteği gönderir
- Layer 2: MongoDB unique index ile sadece 1 pod lock alır, diğerleri bekler
- TTL index: 30 saniye sonra ölü lock'lar otomatik temizlenir

### 401 Auto-Retry
API çağrısı sırasında token expire olursa:
1. `IysTokenExpiredException` yakalanır
2. `ForceRefreshTokenAsync` ile yeni token alınır
3. Aynı istek yeni token ile otomatik tekrar edilir
4. Kullanıcı hiç hata görmez

### Polly Policies
| Policy | Tetik | Davranış |
|:-------|:------|:---------|
| Retry | 429, 5xx | 3 deneme, exponential backoff (2s, 4s, 8s) |
| Circuit Breaker | 5 ardışık hata | 30s devre açık, sonra half-open test |

---

## Swagger Enum Otomasyonu

IYS enum değerleri (ConsentType, ConsentSource, RecipientType, ConsentStatus) Swagger UI'da otomatik gösterilir.

### Nasıl Çalışır
1. Domain constant'larında değer tanımla:
```csharp
// Domain/Enums/ConsentType.cs
public static class ConsentType
{
    public const string ARAMA = "ARAMA";
    public const string MESAJ = "MESAJ";
    public const string EPOSTA = "EPOSTA";
}
```

2. Model'de `[IysEnum]` attribute'ü kullan:
```csharp
[IysEnum(typeof(ConsentType))]
public string Type { get; set; }
```

3. Yeni değer ekleme → hiçbir model dosyasına dokunmadan Swagger otomatik güncellenir.

### Swagger UI Görünümü
- **Schema sekmesi:** Enum dropdown
- **Description:** "Kabul edilen değerler: ARAMA, EPOSTA, MESAJ"
- **Endpoint üstü:** Tablo formatında tüm enum değerler

---

## Hata Yönetimi

Tüm hatalar yapısal JSON yanıta dönüştürülür:

```json
{
  "error": "RATE_LIMIT_EXCEEDED",
  "message": "IYS API rate limit aşıldı.",
  "timestamp": "2026-05-05 00:15:00"
}
```

| Error Code | HTTP | Açıklama |
|:-----------|:-----|:---------|
| `FIRM_NOT_FOUND` | 404 | FirmGuid ile firma bulunamadı |
| `BRAND_NOT_FOUND` | 404 | Firma için marka eşleşmedi |
| `TOKEN_EXPIRED` | 401 | Token süresi dolmuş (auto-retry sonrası) |
| `RATE_LIMIT_EXCEEDED` | 429 | IYS rate limit aşıldı |
| `INTERNAL_ERROR` | 500 | Beklenmeyen sunucu hatası |

---

## IYS Bilinen Kısıtlar

- Telefon formatı: `+905XXXXXXXXX` (zorunlu)
- İlk izin kaydında status `RET` olamaz
- 3 iş günü öncesinde alınan izinler kaydedilemez
- Token süresi: access 2 saat, refresh 4 saat
- Rate limit: IP başına saatte 10 token isteği

---

## Proje Yapısı

```
src/
├── IYS.Gateway.Api/
│   ├── Controllers/          # Consent, Brand, Via controller'ları
│   ├── Middleware/            # FirmGuid validation, Global error handler
│   └── Swagger/               # FirmGuidHeaderFilter, IysEnumSchemaFilter, IysEnumDescriptionFilter
├── IYS.Gateway.Application/
│   ├── Common/                # IysFirmContext, Interface'ler (IIysTokenManager, IIysFirmResolver, IIysApiClient)
│   ├── Models/                # Consent, Via request/response DTO'ları
│   └── Services/              # Service interface'leri
├── IYS.Gateway.Domain/
│   ├── Constants/             # IysEndpoints
│   ├── Enums/                 # ConsentType, ConsentSource, RecipientType, ConsentStatus, IysEnumAttribute
│   └── Exceptions/            # IysApiException, IysTokenExpiredException, IysRateLimitException
└── IYS.Gateway.Infrastructure/
    ├── IysApi/                # IysApiClient, IysTokenManager, IysFirmResolver
    ├── Mongo/                 # GenericMongoRepository, ConnectionManager, Entity'ler
    └── Services/              # ConsentService, BrandService, ViaService
```
