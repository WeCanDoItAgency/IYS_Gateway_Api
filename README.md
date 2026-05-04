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
- 🔗 Correlation ID — her isteğe benzersiz takip kimliği (X-Correlation-Id)
- 📦 Response Compression — Brotli/Gzip sıkıştırma
- 💾 Distributed Cache — MongoDB tabanlı, tüm pod'lar aynı cache'i paylaşır
- ⏹️ CancellationToken — client disconnect'te kaynak israfını önler

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

### Distributed Response Cache (MongoDB)

IYS API yanıtları MONGO_52 üzerinde `IysResponseCache` collection'ında cache'lenir. **Tüm pod'lar aynı cache'i paylaşır** — in-memory cache'den farklı olarak 1000 pod'da bile tek bir cache.

```
Pod A ─ GetBrands() ──▶ MongoDB cache MISS ──▶ IYS API ──▶ Cache WRITE ──▶ response
Pod B ─ GetBrands() ──▶ MongoDB cache HIT ──▶ response (IYS API'ye gitmez)
Pod C ─ GetBrands() ──▶ MongoDB cache HIT ──▶ response (IYS API'ye gitmez)
```

| Endpoint | Cache Süresi | Neden |
|:---------|:------------|:------|
| `brands`, `brand_detail`, `retailers` | 1 saat | Nadiren değişir |
| `sources` | 24 saat | Sabit IYS kaynakları |
| `consent_status` | 30 saniye | Sık değişebilir, ama kısa burst koruması sağlar |
| `via_subscriptions` | 1 saat | Nadiren değişir |

**Index'ler** (startup'ta otomatik oluşturulur):
- `idx_cachekey_unique` — Unique index, aynı key'den 1 kayıt
- `idx_ttl_createdAt` — TTL index, 5 dakika sonra otomatik temizlik
- `idx_firmguid` — Firma bazlı invalidation sorgusu

### MongoDB Index Yönetimi

> ⚠️ **Tüm MongoDB index'leri merkezi olarak `MongoIndexInitializer` (IHostedService) tarafından oluşturulur.**

Dosya: `Infrastructure/Startup/MongoIndexInitializer.cs`

```
Uygulama başlatılıyor
    ↓
MongoIndexInitializer.StartAsync()
    ├─ IysTokenLock: idx_firmguid_unique + idx_createdAt_ttl30s
    └─ IysResponseCache: idx_cachekey_unique + idx_ttl_createdAt + idx_firmguid
    ↓
Uygulama READY
```

**Kurallar:**
- Yeni collection eklendiğinde index tanımı **bu dosyaya** eklenir
- Servis constructor'larında fire-and-forget index oluşturma **yasaktır**
- Tüm index'ler idempotent — varsa sessizce atlar
- Index hatası uygulamayı **durdurmaz** — degraded modda çalışır

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

## Health Check

`GET /health` endpoint'i detaylı JSON yanıt döner:

```json
{
  "status": "Healthy",
  "duration": "42ms",
  "checks": [
    {
      "name": "mongodb",
      "status": "Healthy",
      "description": "Tüm MongoDB sunucuları erişilebilir.",
      "data": {
        "MONGO_52 (Token/Lock)": "OK",
        "MONGO_206 (Firmalar)": "OK"
      }
    },
    {
      "name": "iys-api",
      "status": "Healthy",
      "description": "IYS API erişilebilir.",
      "data": {
        "StatusCode": 401,
        "BaseAddress": "https://api.iys.org.tr/"
      }
    }
  ]
}
```

> ℹ️ IYS API `401` dönmesi **normaldir** — token göndermeden kontrol yapar, erişilebilir olması yeterlidir.

---

## Input Validation

`[IysEnum]` attribute'ü hem Swagger dokümantasyonu hem de **runtime doğrulama** yapar:

```csharp
// Geçersiz enum değeri → 400 BadRequest (IYS API'ye istek gönderilmeden)
POST /api/iys/consent/status
{
  "recipient": "+905001234567",
  "recipientType": "GECERSIZ",  // ❌ 400: "'GECERSIZ' geçersiz bir RecipientType değeridir. Kabul edilen değerler: BIREYSEL, TACIR"
  "type": "MESAJ"
}
```

Validasyon kuralları:
- `[Required]` → Boş/null alanlar 400 döner
- `[IysEnum(typeof(ConsentType))]` → Geçersiz enum değerleri runtime'da yakalanır
- Yeni const eklediğinizde validasyon + Swagger **otomatik güncellenir**

---

## Observability

### Correlation ID
Her istekte `X-Correlation-Id` header'ı otomatik atanır:
- İstemci header gönderirse → aynı ID korunur
- Göndermezse → yeni GUID üretilir
- Response'a otomatik eklenir
- Tüm log'lara scope olarak bağlanır

### Response Compression
- Brotli (öncelikli) + Gzip
- HTTPS dahil tüm JSON yanıtlara uygulanır

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
│   ├── Middleware/            # FirmGuid validation, Global error handler, CorrelationId
│   └── Swagger/               # FirmGuidHeaderFilter, IysEnumSchemaFilter, IysEnumDescriptionFilter
├── IYS.Gateway.Application/
│   ├── Common/                # IysFirmContext, Interface'ler (IIysTokenManager, IIysFirmResolver, IIysApiClient)
│   ├── Models/                # Consent, Via request/response DTO'ları
│   └── Services/              # Service interface'leri
├── IYS.Gateway.Domain/
│   ├── Constants/             # IysEndpoints
│   ├── Enums/                 # ConsentType, ConsentSource, RecipientType, ConsentStatus, IysEnumAttribute (ValidationAttribute)
│   └── Exceptions/            # IysApiException, IysTokenExpiredException, IysRateLimitException
└── IYS.Gateway.Infrastructure/
    ├── HealthChecks/          # MongoHealthCheck, IysApiHealthCheck
    ├── IysApi/                # IysApiClient, IysTokenManager, IysFirmResolver, IysDistributedCache
    ├── Mongo/                 # GenericMongoRepository, ConnectionManager, Entity'ler
    ├── Services/              # ConsentService, BrandService, ViaService
    └── Startup/               # MongoIndexInitializer (IHostedService — merkezi index yönetimi)
```

