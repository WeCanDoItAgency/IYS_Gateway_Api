# GenericMongoRepository — Geliştirici Referans Kılavuzu

`GenericMongoRepository`, PORTAL_JOB_ORCHESTRATOR projelerinde kullanılan; MongoDB sunucuları arası (MONGO_206, MONGO_52, MONGO_53 vb.) cross-server join, server-side grid loading, auto-healing index ve bulk operasyon yetenekleri sunan yüksek performanslı veri erişim katmanıdır.

> [!NOTE]
> Her metot için 2-3 gerçek kullanım örneği mevcuttur. Geliştirici herhangi bir senaryoyu anahtar kelimeyle arayıp bulabilmelidir.

---

## İçindekiler

1. [Filtreleme ve Temel Okuma](#1-filtreleme-ve-temel-okuma)
2. [Sıralama (OrderBy / OrderByDescending)](#2-sıralama)
3. [Sayfalama (Skip / Take / ToPagedListAsync)](#3-sayfalama)
4. [Projeksiyon (SelectOnly / IgnoreFields)](#4-projeksiyon)
5. [Terminal — Veri Okuma (ToListAsync / FirstOrDefault / Count / Any)](#5-terminal--veri-okuma)
6. [Kısmi Güncelleme (UpdateOne / UpdateMany)](#6-kısmi-güncelleme)
7. [Upsert (UpsertOneAsync)](#7-upsert)
8. [Atomik İşlemler (FindOneAndUpdate / FindOneAndDelete)](#8-atomik-i̇şlemler)
9. [Aynı Sunucu Join (Lookup)](#9-aynı-sunucu-join-lookup)
10. [Cross-Server Join (LookupCrossServer)](#10-cross-server-join-lookupcrossserver)
11. [Cross-Server Filtreleme (WhereCrossServer)](#11-cross-server-filtreleme-wherecrossserver)
12. [Ekleme / Silme (Insert / Delete)](#12-ekleme--silme)
13. [Toplu İşlemler (BulkWriteAsync)](#13-toplu-i̇şlemler-bulkwriteasync)
14. [Transaction / Session](#14-transaction--session)
15. [Server-Side Grid Loading (LoadServerSideAsync)](#15-server-side-grid-loading)
16. [Direct Repository CRUD](#16-direct-repository-crud)
17. [Auto-Healing Index Engine](#17-auto-healing-index-engine)
18. [Geliştirici Kısıtlamaları ve Hatalar](#18-geliştirici-kısıtlamaları-ve-hatalar)
19. [Kurulum ve DI Kullanımı](#19-kurulum-ve-di-kullanımı)

---

## 1. Filtreleme ve Temel Okuma

`Where()` birden fazla çağrıda **AND** ile birleştirilir. Lambda expression veya `FilterDefinition<T>` kabul eder.

```csharp
// ÖRNEK 1 — Tek koşul
var aktifSubeler = await _repo.Query<SubelerMongo>()
    .Where(s => s.IsActive == true)
    .ToListAsync();

// ÖRNEK 2 — Çok koşullu (AND zinciri)
var sonuclar = await _repo.Query<IysRequestConsentMongo>(OurMongosServer.MONGO_52, "acente365")
    .Where(x => x.FirmId == 27)
    .Where(x => x.Status == "APPROVED")
    .Where(x => x.ConsentDate >= DateTime.Today.AddDays(-30))
    .ToListAsync();

// ÖRNEK 3 — Native FilterDefinition ile (karmaşık OR sorgusu)
var filter = Builders<SubelerMongo>.Filter.Or(
    Builders<SubelerMongo>.Filter.Eq(x => x.SubeKodu, 100),
    Builders<SubelerMongo>.Filter.Eq(x => x.SubeKodu, 200)
);
var vip = await _repo.Query<SubelerMongo>()
    .Where(filter)
    .ToListAsync();
```

> [!WARNING]
> `Where()` null gelirse `ArgumentNullException` fırlatır. Koşullu filtre için `if` bloğu kullanın:
> ```csharp
> var q = _repo.Query<SubelerMongo>();
> if (firmId.HasValue) q = q.Where(x => x.FirmaMongoId == firmId.ToString());
> var list = await q.ToListAsync();
> ```

---

## 2. Sıralama

`OrderBy` ve `OrderByDescending` zincirlenerek çok alanlı sıralama yapılabilir.

```csharp
// ÖRNEK 1 — Tek alan artan
var liste = await _repo.Query<SubelerMongo>()
    .Where(s => s.IsActive == true)
    .OrderBy(s => s.Unvan)
    .ToListAsync();

// ÖRNEK 2 — Çok alanlı (önce tarih azalan, sonra ad artan)
var liste2 = await _repo.Query<IysRequestConsentMongo>(OurMongosServer.MONGO_52, "acente365")
    .Where(x => x.FirmId == 27)
    .OrderByDescending(x => x.ConsentDate)
    .OrderBy(x => x.PhoneNumber)
    .ToListAsync();

// ÖRNEK 3 — FindOneAndDelete ile birlikte FIFO sıra
var enEskiGorev = await _repo.Query<PendingTaskMongo>()
    .Where(t => t.Status == "READY")
    .OrderBy(t => t.CreatedAt)
    .FindOneAndDeleteAsync();
```

---

## 3. Sayfalama

### Skip / Take (Manuel)

```csharp
// ÖRNEK 1 — Sayfa 3, 20'şerlik (skip=40, take=20)
var sayfa3 = await _repo.Query<SubelerMongo>()
    .Where(s => s.IsActive == true)
    .OrderBy(s => s.Unvan)
    .Skip(40)
    .Take(20)
    .ToListAsync();

// ÖRNEK 2 — Güvenlik limiti: maksimum 100 kayıt
var guvenli = await _repo.Query<LogMongo>()
    .Where(l => l.Level == "ERROR")
    .OrderByDescending(l => l.CreatedAt)
    .Take(100)
    .ToListAsync();
```

> [!TIP]
> `Skip()` negatif değeri otomatik **0** yapar. `Take(0)` veya negatif yok sayılır.

### ToPagedListAsync (Otomatik — Paralel Count + Data)

```csharp
// ÖRNEK 1 — Grid için sayfalı sonuç
PagedResult<SubelerMongo> sayfa = await _repo.Query<SubelerMongo>()
    .Where(s => s.IsActive == true)
    .OrderBy(s => s.SubeKodu)
    .ToPagedListAsync(pageNumber: 2, pageSize: 25);

Console.WriteLine($"Toplam: {sayfa.TotalCount}, Bu sayfada: {sayfa.Data.Count}");

// ÖRNEK 2 — HTTP API response mapping
var result = await _repo.Query<IysRequestConsentMongo>(OurMongosServer.MONGO_52, "acente365")
    .Where(x => x.FirmId == firmId)
    .OrderByDescending(x => x.ConsentDate)
    .ToPagedListAsync(pageNumber, pageSize);

return Ok(new { total = result.TotalCount, data = result.Data });
```

> [!NOTE]
> `TotalCount` ve `Data` paralel olarak çekilir — iki ayrı MongoDB sorgusu eşzamanlı çalışır. `PagedResult<T>` immutable'dır, constructor sonrası değiştirilemez.

---

## 4. Projeksiyon

### SelectOnly — Sadece Belirtilen Alanlar

```csharp
// ÖRNEK 1 — Sadece 3 alan (RAM tasarrufu)
var kodlar = await _repo.Query<SubelerMongo>()
    .SelectOnly(s => s.Id, s => s.SubeKodu, s => s.Unvan)
    .Where(s => s.IsActive == true)
    .ToListAsync();

// ÖRNEK 2 — Join'de localField mutlaka SelectOnly'ye dahil edilmeli
var liste = await _repo.Query<KullanicilarMongo>()
    .SelectOnly(k => k.Id, k => k.Ad, k => k.SubeMongoId) // SubeMongoId join için şart!
    .LookupCrossServer<SubelerMongo>(
        OurMongosServer.MONGO_206, "MongoPortal",
        k => k.SubeMongoId, s => s.Id, "SubeBilgisi")
    .ToListAsync();

// ÖRNEK 3 — Dropdown için sadece id + label
var dropdown = await _repo.Query<SubelerMongo>()
    .SelectOnly(s => s.Id, s => s.Unvan)
    .Where(s => s.IsActive == true)
    .OrderBy(s => s.Unvan)
    .ToListAsync();
```

### IgnoreFields — Belirtilen Alanları Gizle

```csharp
// ÖRNEK 1 — Büyük binary alanı atla
var liste = await _repo.Query<BelgeMongo>()
    .IgnoreFields(b => b.RawPdfBytes, b => b.ThumbnailBytes)
    .Where(b => b.FirmId == 27)
    .ToListAsync();

// ÖRNEK 2 — Log tablosunda payload gizle
var loglar = await _repo.Query<ApiLogMongo>()
    .IgnoreFields(l => l.RequestBody, l => l.ResponseBody)
    .Where(l => l.StatusCode >= 500)
    .OrderByDescending(l => l.CreatedAt)
    .Take(50)
    .ToListAsync();
```

> [!WARNING]
> `SelectOnly` ve `IgnoreFields` aynı sorguda birlikte kullanılmamalıdır — MongoDB driver çakışma yaratır.

> [!TIP]
> `ExtraElements` alanını manuel olarak `IgnoreFields(x => x.ExtraElements)` ile hariç tutmaya **gerek yoktur**.
> Repository tüm okuma metodlarında (`ToListAsync`, `ToPagedListAsync`, `FirstOrDefaultAsync`,
> `FindOneAndUpdateAsync`, `FindOneAndDeleteAsync`, `LoadServerSideAsync`) bunu **otomatik olarak** yapar.

---

### ExtraElements Otomatik Hariç Tutma

v2+ itibarıyla tüm sorgu sonuçlarından `ExtraElements` **varsayılan olarak çıkarılır**. Grid'lere, listelere ya da API response'larına karışmaz.

| Sorgu Tipi | ExtraElements Davranışı |
|---|---|
| Normal sorgu (join yok) | ❌ Otomatik hariç tutulur |
| `LookupCrossServer` (cross-server join) | ❌ MongoDB'den hariç, C#'ta in-memory doldurulur |
| `Lookup` (aynı sunucu `$lookup`) | ✅ Korunur — join datası burada yaşar |

```csharp
// ✅ ExtraElements otomatik hariç — ek kod gerekmez
var subeler = await _repo.Query<SubelerMongo>()
    .Where(s => s.IsActive)
    .ToListAsync();

// ✅ Cross-server join — ExtraElements MongoDB'den gelmez, C#'ta doldurulur
var subeler = await _repo.Query<SubelerMongo>()
    .LookupCrossServer<CariKartlarMongo>(
        OurMongosServer.Mongo52, "acente365",
        s => s.CariKartId, c => c.Id,
        "CariKartDetay")
    .ToListAsync();
// s.ExtraElements["CariKartDetay"] erişilebilir ✅

// ✅ Aynı sunucu Lookup — ExtraElements korunur (join datası için şart)
var subeler = await _repo.Query<SubelerMongo>()
    .Lookup<FirmaMongo>(s => s.FirmaId, f => f.Id, "FirmaBilgisi")
    .ToListAsync();
```

---

## 5. Terminal — Veri Okuma

### ToListAsync

```csharp
// ÖRNEK 1 — Basit liste
var tumSubeler = await _repo.Query<SubelerMongo>().ToListAsync();

// ÖRNEK 2 — CancellationToken ile (HTTP request iptalinde)
var liste = await _repo.Query<SubelerMongo>()
    .Where(s => s.IsActive == true)
    .ToListAsync(cancellationToken);
```

### FirstOrDefaultAsync

```csharp
// ÖRNEK 1 — Tek kayıt bul (null kontrolü şart)
var sube = await _repo.Query<SubelerMongo>()
    .Where(s => s.SubeKodu == 100)
    .FirstOrDefaultAsync();

if (sube == null) throw new NotFoundException("Şube bulunamadı");

// ÖRNEK 2 — En son log kaydı
var sonHata = await _repo.Query<ApiLogMongo>()
    .Where(l => l.StatusCode >= 500)
    .OrderByDescending(l => l.CreatedAt)
    .FirstOrDefaultAsync();

// ÖRNEK 3 — Token cache kontrolü
var token = await _repo.Query<IysTokenCacheMongo>(OurMongosServer.MONGO_52, "tokenDb")
    .Where(t => t.FirmGuid == firmGuid.ToString())
    .FirstOrDefaultAsync();
var accessToken = token?.AccessToken ?? throw new UnauthorizedException();
```

### CountAsync

```csharp
// ÖRNEK 1 — Toplam aktif şube sayısı
long aktifSayi = await _repo.Query<SubelerMongo>()
    .Where(s => s.IsActive == true)
    .CountAsync();

// ÖRNEK 2 — Bugün onaylanan kayıt sayısı
long bugunOnaylanan = await _repo.Query<IysRequestConsentMongo>(OurMongosServer.MONGO_52, "acente365")
    .Where(x => x.ConsentDate >= DateTime.Today)
    .Where(x => x.Status == "APPROVED")
    .CountAsync();
```

### AnyAsync

```csharp
// ÖRNEK 1 — Kayıt var mı kontrolü
bool varMi = await _repo.Query<IysTokenCacheMongo>(OurMongosServer.MONGO_52, "tokenDb")
    .Where(t => t.FirmGuid == firmGuid.ToString())
    .AnyAsync();

if (!varMi) await CreateTokenAsync(firmGuid);

// ÖRNEK 2 — Duplicate kontrolü (insert öncesi)
bool duplicate = await _repo.Query<SubelerMongo>()
    .Where(s => s.SubeKodu == yeniSube.SubeKodu)
    .AnyAsync();

if (duplicate) throw new ConflictException($"SubeKodu {yeniSube.SubeKodu} zaten mevcut.");
```

> [!TIP]
> `AnyAsync`, dahili olarak `CountDocumentsAsync` ile `Limit(1)` kullanır — tüm koleksiyonu saymaz, çok hızlıdır.

---

## 6. Kısmi Güncelleme

### UpdateOneAsync — İlk Eşleşen Kayıt

```csharp
// ÖRNEK 1 — Tek alan güncelle
var update = Builders<SubelerMongo>.Update.Set(x => x.IsActive, false);
var result = await _repo.Query<SubelerMongo>()
    .Where(s => s.Id == "6633b4...id...")
    .UpdateOneAsync(update);
// result.ModifiedCount == 1 ise başarılı

// ÖRNEK 2 — Birden fazla alan
var multiUpdate = Builders<IysRequestConsentMongo>.Update
    .Set(x => x.Status, "CANCELLED")
    .Set(x => x.UpdatedAt, DateTime.Now)
    .Set(x => x.UpdatedBy, "system");

await _repo.Query<IysRequestConsentMongo>(OurMongosServer.MONGO_52, "acente365")
    .Where(x => x.TransactionId == transactionId)
    .UpdateOneAsync(multiUpdate);
```

### UpdateManyAsync — Tüm Eşleşen Kayıtlar

```csharp
// ÖRNEK 1 — Toplu deaktivasyon
var update = Builders<SubelerMongo>.Update.Set(x => x.IsActive, false);
var result = await _repo.Query<SubelerMongo>()
    .Where(s => s.FirmaMongoId == firmaId)
    .UpdateManyAsync(update);
Console.WriteLine($"{result.ModifiedCount} şube deaktive edildi.");

// ÖRNEK 2 — Toplu alan güncelleme + array push
var logUpdate = Builders<SyncJobMongo>.Update
    .Set(x => x.Status, "COMPLETED")
    .Set(x => x.CompletedAt, DateTime.Now)
    .Inc(x => x.RetryCount, 1);

await _repo.Query<SyncJobMongo>()
    .Where(j => j.BatchId == batchId && j.Status == "RUNNING")
    .UpdateManyAsync(logUpdate);

// ÖRNEK 3 — Null alanları temizle (unset)
var unsetUpdate = Builders<ApiLogMongo>.Update.Unset(x => x.TempData);
await _repo.Query<ApiLogMongo>()
    .Where(l => l.CreatedAt < DateTime.Today.AddDays(-90))
    .UpdateManyAsync(unsetUpdate);
```

> [!CAUTION]
> `UpdateOneAsync` / `UpdateManyAsync` ile birlikte `.Lookup()` veya `.LookupCrossServer()` **KULLANILAMAZ**. `NotSupportedException` fırlatır.

---

## 7. Upsert

**Varsa güncelle, yoksa ekle.** Token cache, konfigürasyon, distributed lock gibi "tek kayıt garantisi" senaryolarında kullanılır.

```csharp
// ÖRNEK 1 — Token cache upsert
var update = Builders<IysTokenCacheMongo>.Update
    .Set(x => x.AccessToken, response.AccessToken)
    .Set(x => x.RefreshToken, response.RefreshToken)
    .Set(x => x.ExpiresAt, DateTime.Now.AddHours(1))
    .Set(x => x.UpdatedAt, DateTime.Now)
    .SetOnInsert(x => x.CreatedAt, DateTime.Now); // sadece ilk insert'te!

await _repo.Query<IysTokenCacheMongo>(OurMongosServer.MONGO_52, "tokenDb")
    .Where(x => x.FirmGuid == firmGuid.ToString())
    .UpsertOneAsync(update);

// ÖRNEK 2 — Konfigürasyon upsert
var configUpdate = Builders<AppConfigMongo>.Update
    .Set(x => x.Value, yeniDeger)
    .Set(x => x.UpdatedAt, DateTime.Now)
    .SetOnInsert(x => x.CreatedAt, DateTime.Now)
    .SetOnInsert(x => x.Key, configKey);

await _repo.Query<AppConfigMongo>()
    .Where(x => x.Key == configKey)
    .UpsertOneAsync(configUpdate);

// ÖRNEK 3 — Distributed lock alma
var lockUpdate = Builders<DistributedLockMongo>.Update
    .Set(x => x.LockedBy, Environment.MachineName)
    .Set(x => x.LockedAt, DateTime.Now)
    .SetOnInsert(x => x.Resource, resourceName);

await _repo.Query<DistributedLockMongo>(OurMongosServer.MONGO_52, "locks")
    .Where(x => x.Resource == resourceName && x.LockedBy == null)
    .UpsertOneAsync(lockUpdate);
```

> [!WARNING]
> `SetOnInsert()` sadece **yeni kayıt oluşturulurken** çalışır. Mevcut kayıt güncellenirken bu alanlar atlanır. Tüm zorunlu alanları `Set()` içine alın.

---

## 8. Atomik İşlemler

### FindOneAndUpdateAsync — Güncelle ve Döndür

```csharp
// ÖRNEK 1 — Sayacı artır, güncel değeri al (returnAfter: true varsayılan)
var incUpdate = Builders<SubelerMongo>.Update.Inc(x => x.RequestCount, 1);
var updated = await _repo.Query<SubelerMongo>()
    .Where(s => s.SubeKodu == 100)
    .FindOneAndUpdateAsync(incUpdate);
Console.WriteLine($"Yeni sayaç: {updated?.RequestCount}");

// ÖRNEK 2 — Güncelleme öncesi değeri al
var before = await _repo.Query<SubelerMongo>()
    .Where(s => s.SubeKodu == 100)
    .FindOneAndUpdateAsync(incUpdate, returnAfter: false);
Console.WriteLine($"Eski değer: {before?.RequestCount}"); // +1 öncesi

// ÖRNEK 3 — Status geçişi + timestamp (atomic state machine)
var statusUpdate = Builders<SyncJobMongo>.Update
    .Set(x => x.Status, "PROCESSING")
    .Set(x => x.StartedAt, DateTime.Now)
    .Set(x => x.ProcessedBy, Environment.MachineName);

var job = await _repo.Query<SyncJobMongo>()
    .Where(j => j.Status == "PENDING")
    .OrderBy(j => j.CreatedAt)
    .FindOneAndUpdateAsync(statusUpdate);

if (job == null) return; // Alınacak iş yok
```

### FindOneAndDeleteAsync — Sil ve Döndür

```csharp
// ÖRNEK 1 — FIFO kuyruk: en eski görevi al ve sil
var task = await _repo.Query<PendingTaskMongo>()
    .Where(t => t.Status == "READY")
    .OrderBy(t => t.CreatedAt)
    .FindOneAndDeleteAsync();

if (task != null)
    await ProcessTaskAsync(task);

// ÖRNEK 2 — Distributed lock bırak
var released = await _repo.Query<DistributedLockMongo>(OurMongosServer.MONGO_52, "locks")
    .Where(x => x.Resource == resourceName && x.LockedBy == Environment.MachineName)
    .FindOneAndDeleteAsync();

// ÖRNEK 3 — Tek kullanımlık OTP/Token sil
var otp = await _repo.Query<OtpTokenMongo>()
    .Where(o => o.Code == givenCode && o.PhoneNumber == phone && o.ExpiresAt > DateTime.Now)
    .FindOneAndDeleteAsync();

if (otp == null) throw new InvalidOperationException("Geçersiz veya süresi dolmuş OTP.");
```

> [!TIP]
> | Metot | Kayıt Yoksa | Sonuç | Kullanım |
> |:------|:-----------|:------|:---------|
> | `UpdateOneAsync` | Hiçbir şey yapmaz | `UpdateResult` | Normal güncelleme |
> | `UpsertOneAsync` | Yeni kayıt oluşturur | `UpdateResult` | Cache, config |
> | `FindOneAndUpdateAsync` | `null` döner | Güncel doküman | Sayaç, state machine |
> | `FindOneAndDeleteAsync` | `null` döner | Silinen doküman | Kuyruk, OTP |

---

## 9. Aynı Sunucu Join (Lookup)

Aynı MongoDB sunucusu/veritabanı içinde `$lookup` (LEFT JOIN) yapar.

```csharp
// ÖRNEK 1 — Kullanıcıya şube bilgisini ekle
var kullanicilar = await _repo.Query<KullanicilarMongo>()
    .SelectOnly(k => k.Id, k => k.Ad, k => k.SubeMongoId) // localField şart!
    .Lookup<SubelerMongo>(
        localField: k => k.SubeMongoId,
        foreignField: s => s.Id,
        @as: "SubeBilgisi")
    .Where(k => k.IsActive == true)
    .ToListAsync();

// SubeBilgisi'ne erişim:
// k.ExtraElements["SubeBilgisi"] as BsonArray

// ÖRNEK 2 — Çoklu join (aynı sunucu)
var teklifler = await _repo.Query<TeklifMongo>()
    .SelectOnly(t => t.Id, t => t.SubeMongoId, t => t.MusteriMongoId, t => t.Tutar)
    .Lookup<SubelerMongo>(
        localField: t => t.SubeMongoId,
        foreignField: s => s.Id,
        @as: "Sube")
    .Lookup<MusteriMongo>(
        localField: t => t.MusteriMongoId,
        foreignField: m => m.Id,
        @as: "Musteri")
    .Where(t => t.Tutar > 1000)
    .ToListAsync();
```

> [!WARNING]
> `localField` olarak kullandığınız alanı `SelectOnly()` içine **mutlaka** ekleyin. Aksi hâlde join boşa düşer.
> Aynı `@as` alias'ı iki kez kullanırsanız `InvalidOperationException` fırlatılır.

---

## 10. Cross-Server Join (LookupCrossServer)

Farklı MongoDB sunucusundaki koleksiyonla in-memory join. Lokal ID'ler toplanır → foreign sunucuya batch sorgu → bellekte eşleştirilir.

> [!TIP]
> **Otomatik Chunking:** 10.000'lik paketler halinde çeker. MongoDB 16MB BSON limitine takılmaz.

```csharp
// ÖRNEK 1 — Şubeye CariKart bilgisi ekle (206 → 52)
var subeler = await _repo.Query<SubelerMongo>()
    .SelectOnly(s => s.Id, s => s.Unvan, s => s.CariKartMongoId)
    .LookupCrossServer<CariKartlar>(
        server: OurMongosServer.MONGO_52,
        database: "acente365",
        localField: s => s.CariKartMongoId,
        foreignField: c => c.Id,
        @as: "CariKartDetay")
    .Where(s => s.IsActive == true)
    .ToListAsync();

// CariKartDetay'a erişim:
// s.ExtraElements["CariKartDetay"] as BsonArray

// ÖRNEK 2 — Çoklu cross-server join (206 + 52 + 53)
var kayitlar = await _repo.Query<NewDocumentsMongo>()
    .SelectOnly(d => d.Id, d => d.CariKartMongoId, d => d.OfferId, d => d.Tutar)
    .LookupCrossServer<CariKartlar>(
        OurMongosServer.MONGO_52, "acente365",
        d => d.CariKartMongoId, c => c.Id, "CariKart")
    .LookupCrossServer<OffersMongo>(
        OurMongosServer.MONGO_53, "offers",
        d => d.OfferId, o => o.Id, "Teklif")
    .Where(d => d.IsActive == true)
    .ToListAsync();

// ÖRNEK 3 — Aynı sunucu + cross-server karma join
var result = await _repo.Query<KullanicilarMongo>()
    .SelectOnly(k => k.Id, k => k.Ad, k => k.SubeMongoId, k => k.FirmaMongoId)
    .Lookup<SubelerMongo>(                     // aynı sunucu ($lookup)
        k => k.SubeMongoId, s => s.Id, "Sube")
    .LookupCrossServer<CariKartlar>(           // farklı sunucu (in-memory)
        OurMongosServer.MONGO_52, "acente365",
        k => k.FirmaMongoId, c => c.Id, "Firma")
    .Where(k => k.IsActive == true)
    .ToListAsync();
```

> [!WARNING]
> Array/List tipindeki alanlar `localField` veya `foreignField` olarak kullanılamaz. Sadece tekil (1-1) eşleşmeler desteklenir.

---

## 11. Cross-Server Filtreleme (WhereCrossServer)

Foreign sunucuya **önce filtre uygulanır**, eşleşen ID'ler ana sorguya `IN` olarak eklenir. Hem filtreleme hem join tek çağrıda yapılır.

```csharp
// ÖRNEK 1 — "Ahmet" unvanlı carikartların şubelerini getir
var subeler = await _repo.Query<SubelerMongo>()
    .WhereCrossServer<CariKartlar>(
        server: OurMongosServer.MONGO_52,
        database: "acente365",
        localField: s => s.CariKartMongoId,
        foreignField: c => c.Id,
        foreignFilter: c => c.Unvan.Contains("Ahmet"),
        @as: "CariKart")
    .Where(s => s.IsActive == true)
    .ToListAsync();

// ÖRNEK 2 — Belirli teklif tipindeki şubeleri getir
var sonuclar = await _repo.Query<SubelerMongo>()
    .WhereCrossServer<OffersMongo>(
        OurMongosServer.MONGO_53, "offers",
        s => s.Id, o => o.SubeMongoId,
        o => o.OfferType == "KASKO" && o.Status == "ACTIVE",
        @as: "KaskoTeklifler")
    .Where(s => s.IsActive == true)
    .OrderBy(s => s.Unvan)
    .ToListAsync();

// ÖRNEK 3 — WhereCrossServer + LookupCrossServer birlikte
var list = await _repo.Query<SubelerMongo>()
    .WhereCrossServer<CariKartlar>(        // önce 52'de filtrele
        OurMongosServer.MONGO_52, "acente365",
        s => s.CariKartMongoId, c => c.Id,
        c => c.Il == "İstanbul",
        @as: "CariKart")
    .LookupCrossServer<OffersMongo>(       // sonra 53'ten join yap
        OurMongosServer.MONGO_53, "offers",
        s => s.Id, o => o.SubeMongoId,
        @as: "Teklifler")
    .Where(s => s.IsActive == true)
    .ToListAsync();
```

> [!NOTE]
> `WhereCrossServer` sonucu `ExtraElements["@as"]` içinde de döner — hem filtre hem join tek seferde.

---

## 12. Ekleme / Silme (Insert / Delete)

### InsertOneAsync (Query Builder — hedefli server/db)

```csharp
// ÖRNEK 1 — Belirli server/db'ye ekle
var lockDoc = new DistributedLockMongo
{
    Resource = "iys-sync",
    LockedBy = Environment.MachineName,
    CreatedAt = DateTime.Now
};
await _repo.Query<DistributedLockMongo>(OurMongosServer.MONGO_52, "locks")
    .InsertOneAsync(lockDoc);

// ÖRNEK 2 — Log kaydı ekle
await _repo.Query<ApiLogMongo>()
    .InsertOneAsync(new ApiLogMongo
    {
        Endpoint = "/api/iys/sync",
        StatusCode = 200,
        DurationMs = elapsed,
        CreatedAt = DateTime.Now
    });
```

### DeleteOneAsync (Query Builder — filtreyle sil)

```csharp
// ÖRNEK 1 — Distributed lock bırak
var result = await _repo.Query<DistributedLockMongo>(OurMongosServer.MONGO_52, "locks")
    .Where(x => x.Resource == "iys-sync" && x.LockedBy == Environment.MachineName)
    .DeleteOneAsync();

if (result.DeletedCount == 0)
    _logger.LogWarning("Lock zaten bırakılmış veya başkası tarafından alınmış.");

// ÖRNEK 2 — Süresi dolmuş cache sil
await _repo.Query<IysTokenCacheMongo>(OurMongosServer.MONGO_52, "tokenDb")
    .Where(t => t.ExpiresAt < DateTime.Now)
    .DeleteOneAsync();
```

> [!TIP]
> | Metot | Seviye | Server/DB Hedefli | Açıklama |
> |:------|:-------|:-----------------|:---------|
> | `InsertAsync` | Repository | Varsayılan | Genel ekleme |
> | `InsertManyAsync` | Repository | Varsayılan | Toplu ekleme |
> | `InsertOneAsync` | QueryBuilder | ✅ `.Query<T>(server, db)` | Hedefli server'a ekleme |
> | `DeleteAsync` | Repository | Varsayılan | ID ile sil |
> | `DeleteManyAsync` | Repository | Varsayılan | Filtre ile toplu sil |
> | `DeleteOneAsync` | QueryBuilder | ✅ `.Where().DeleteOneAsync()` | Filtreyle ilk kaydı sil |

---

## 13. Toplu İşlemler (BulkWriteAsync)

Binlerce kaydı tek ağ paketinde gönderir. `IsOrdered = false` ile paralel çalışır.

```csharp
// ÖRNEK 1 — 10.000 kayıt güncelleme
var requests = new List<WriteModel<SubelerMongo>>();
foreach (var item in buyukListe)
{
    var filter = Builders<SubelerMongo>.Filter.Eq(x => x.MssqlId, item.MssqlId);
    var update = Builders<SubelerMongo>.Update
        .Set(x => x.Unvan, item.Unvan)
        .Set(x => x.UpdatedAt, DateTime.Now);
    requests.Add(new UpdateOneModel<SubelerMongo>(filter, update));
}
var bulkResult = await _repo.BulkWriteAsync(requests);
Console.WriteLine($"Güncellenen: {bulkResult.ModifiedCount}");

// ÖRNEK 2 — Upsert ile sync işlemi (varsa güncelle, yoksa ekle)
var upsertRequests = new List<WriteModel<IysRequestConsentMongo>>();
foreach (var consent in gelenKayitlar)
{
    var filter = Builders<IysRequestConsentMongo>.Filter.Eq(x => x.TransactionId, consent.TransactionId);
    var update = Builders<IysRequestConsentMongo>.Update
        .Set(x => x.Status, consent.Status)
        .Set(x => x.UpdatedAt, DateTime.Now)
        .SetOnInsert(x => x.CreatedAt, DateTime.Now);
    upsertRequests.Add(new UpdateOneModel<IysRequestConsentMongo>(filter, update) { IsUpsert = true });
}
await _repo.BulkWriteAsync<IysRequestConsentMongo>(
    upsertRequests, OurMongosServer.MONGO_52, "acente365");

// ÖRNEK 3 — Karma (insert + update + delete)
var karmaRequests = new List<WriteModel<LogMongo>>();
karmaRequests.Add(new InsertOneModel<LogMongo>(yeniLog));
karmaRequests.Add(new UpdateOneModel<LogMongo>(
    Builders<LogMongo>.Filter.Eq(x => x.Id, eskiId),
    Builders<LogMongo>.Update.Set(x => x.Archived, true)));
karmaRequests.Add(new DeleteOneModel<LogMongo>(
    Builders<LogMongo>.Filter.Lt(x => x.CreatedAt, DateTime.Today.AddYears(-1))));
await _repo.BulkWriteAsync(karmaRequests);
```

---

## 14. Transaction / Session

Birden fazla koleksiyonu etkileyen ACID işlemleri için.

> [!WARNING]
> Transaction'lar **sadece Replica Set kurulumlu** MongoDB'lerde çalışır. Standalone'da hata fırlatır.

```csharp
// ÖRNEK 1 — Temel transaction
using var session = await _repo.StartSessionAsync();
session.StartTransaction();
try
{
    // İşlemler (session parametresi ileride desteklenecek)
    await session.CommitTransactionAsync();
}
catch (Exception ex)
{
    await session.AbortTransactionAsync();
    _logger.LogError(ex, "Transaction rollback yapıldı.");
    throw;
}

// ÖRNEK 2 — Farklı sunucu session'ı
using var session52 = await _repo.StartSessionAsync(OurMongosServer.MONGO_52);
session52.StartTransaction();
try
{
    // MONGO_52 üzerinde işlemler
    await session52.CommitTransactionAsync();
}
catch
{
    await session52.AbortTransactionAsync();
    throw;
}
```

---

## 15. Server-Side Grid Loading

`LoadServerSideAsync`, DevExtreme DataGrid'den gelen **tüm** grid parametrelerini (filter, sort, paging, headerFilter) native MongoDB sorgusuna çevirir.

> [!IMPORTANT]
> Bu metot **DevExtreme paketine bağımlı DEĞİLDİR**. Orchestrator projesinde doğrudan kullanılabilir.
> WebUI tarafında `DataSourceLoadOptionsBase` → `ServerSideLoadOptions` dönüşümü extension method ile yapılır.

### A. Basit Kullanım — Tam Server-Side

```csharp
// ÖRNEK 1 — Controller
public async Task<object> GetConsentRecords(ServerSideLoadOptions gridOptions, int firmId)
{
    return await _repo.Query<IysRequestConsentMongo>(OurMongosServer.MONGO_52, "acente365")
        .Where(x => x.FirmId == firmId)
        .LoadServerSideAsync(gridOptions);
}

// ÖRNEK 2 — Lookup ile birlikte
public async Task<object> GetSubeler(ServerSideLoadOptions gridOptions)
{
    return await _repo.Query<SubelerMongo>()
        .LookupCrossServer<CariKartlar>(
            OurMongosServer.MONGO_52, "acente365",
            s => s.CariKartMongoId, c => c.Id, "CariKart")
        .Where(s => s.IsActive == true)
        .LoadServerSideAsync(gridOptions);
}
```

### B. Hibrit — Bazı Alanlar Client-Side

```csharp
// Hesaplanmış alanlar MongoDB'de yok → client-side işlensin
var result = await _repo.Query<IysRequestConsentMongo>(OurMongosServer.MONGO_52, "acente365")
    .Where(x => x.FirmId == firmId)
    .LoadServerSideAsync(new ServerSideLoadOptions
    {
        Filter = rawFilter,
        Sort = sortArray,
        Skip = skip,
        Take = take,
        ClientSideProperties = new HashSet<string> { "ToplamPrim", "HesaplananKomisyon" }
    });
```

### C. Tamamı Client-Side (Fallback)

```csharp
var result = await _repo.Query<KucukKoleksiyonMongo>()
    .LoadServerSideAsync(new ServerSideLoadOptions
    {
        ServerSideFiltering = false,
        ServerSideSorting   = false,
        ServerSidePaging    = false,
        Filter = rawFilter,
        Skip = 0, Take = 50
    });
```

### D. HeaderFilter (Distinct Değerler)

Grid kolon başlığındaki filtre listesi `$group` aggregation ile otomatik çekilir. `Group` parametresi dolu geldiğinde `LoadServerSideAsync` kendisi distinct sorgusu çalıştırır:

```
Dönüş: { data: [{key: "APPROVED"}, {key: "PENDING"}], groupCount: 2 }
```

### E. Desteklenen Operatörler

| DevExtreme | MongoDB | Açıklama |
|:-----------|:--------|:---------|
| `=` | `$eq` | Eşitlik |
| `<>` / `!=` | `$ne` | Eşit değil |
| `>` | `$gt` | Büyüktür |
| `>=` | `$gte` | Büyük eşit |
| `<` | `$lt` | Küçüktür |
| `<=` | `$lte` | Küçük eşit |
| `contains` | `$regex` (i) | İçerir |
| `notcontains` | `$not` + `$regex` | İçermez |
| `startswith` | `$regex` (`^val`) | İle başlar |
| `endswith` | `$regex` (`val$`) | İle biter |

### F. Server/Client-Side Seçenekleri

| Property | Varsayılan | Açıklama |
|:---------|:-----------|:---------|
| `ServerSideFiltering` | `true` | Filtreleme MongoDB'de |
| `ServerSideSorting` | `true` | Sıralama MongoDB'de |
| `ServerSidePaging` | `true` | Skip/Take MongoDB'de |
| `ClientSideProperties` | `null` | Property bazlı client-side hariç tut |

> [!CAUTION]
> `LoadServerSideAsync` builder'ın internal state'ini (`_filter`, `_sort`, `_skip`, `_take`) değiştirir.
> Her grid isteği için yeni `Query<T>()` çağrısı yapın — aynı instance'ı yeniden kullanmayın.

---

## 16. Direct Repository CRUD

Query Builder kullanmadan doğrudan CRUD işlemleri.

```csharp
// GetByIdAsync
var sube = await _repo.GetByIdAsync<SubelerMongo>("6633b4...id...");

// InsertAsync
var yeniSube = new SubelerMongo { SubeKodu = 999, Unvan = "Test" };
await _repo.InsertAsync(yeniSube);

// InsertManyAsync
var liste = new List<SubelerMongo> { /* ... */ };
await _repo.InsertManyAsync(liste);

// UpdateAsync (tam replace)
sube.Unvan = "Güncel İsim";
await _repo.UpdateAsync(sube.Id, sube);

// DeleteAsync (ID ile)
await _repo.DeleteAsync<SubelerMongo>("6633b4...id...");

// DeleteManyAsync (filtre ile)
long silinenSayi = await _repo.DeleteManyAsync<SubelerMongo>(
    x => x.IsActive == false && x.UpdatedAt < DateTime.Today.AddYears(-1));
Console.WriteLine($"{silinenSayi} kayıt silindi.");
```

> [!NOTE]
> `GetByIdAsync`, `InsertAsync`, `UpdateAsync`, `DeleteAsync` metodlarına `null` id veya entity verilirse `ArgumentNullException` fırlatılır.

---

## 17. Auto-Healing Index Engine

Yavaş sorgular tespit edildiğinde arka planda otomatik index önerisi/oluşturma yapar.

**Davranış:**
1. Herhangi bir sorgu **60 saniyeyi** aşarsa tetiklenir
2. MongoDB'ye gönderilen filtre ağacındaki alanlar analiz edilir
3. İlgili koleksiyona `AUTO_HEAL_idx_Alan1_Alan2` adıyla compound index oluşturulur
4. Hata olursa sessizce loglanır, asıl uygulama etkilenmez

```
// Otomatik oluşturulan index adı örneği:
AUTO_HEAL_idx_FirmId_Status_ConsentDate
```

> [!TIP]
> Debug modunda `[AUTO-HEAL]` prefix'li log mesajları oluşturulur. Production'da bu loglar `Debug.WriteLine` ile çıkar — monitoring sisteminize yönlendirin.

---

## 18. Geliştirici Kısıtlamaları ve Hatalar

### A. Alias Çakışma Koruması
```csharp
// ❌ HATA: Aynı alias iki kez kullanılamaz
query.Lookup<SubelerMongo>(x => x.SubeId, s => s.Id, @as: "Sube")
     .Lookup<SubelerMongo>(x => x.SubeId, s => s.Id, @as: "Sube"); // InvalidOperationException!

// ✅ DOĞRU: Benzersiz alias kullan
query.Lookup<SubelerMongo>(x => x.SubeId, s => s.Id, @as: "SubeBilgisi")
     .Lookup<MusteriMongo>(x => x.MusteriId, m => m.Id, @as: "MusteriBilgisi");
```

### B. Array/List Alanlarla Join Yapılamaz
```csharp
// ❌ HATA: List<string> tipinde alan kullanılamaz
.LookupCrossServer<X>(server, db, s => s.TargetIds, ...); // NotSupportedException!

// ✅ DOĞRU: Tekil (1-1) eşleşme alanı kullan
.LookupCrossServer<X>(server, db, s => s.TargetId, ...);
```

### C. Update + Lookup Birlikte Kullanılamaz
```csharp
// ❌ HATA
await query.Lookup<X>(...).UpdateOneAsync(update); // NotSupportedException!

// ✅ DOĞRU: Lookup'suz güncelleme
await query.Where(x => x.Id == id).UpdateOneAsync(update);
```

### D. BsonCollectionAttribute Zorunluluğu
```csharp
// ✅ Her entity'de attribute tanımlı olmalı
[BsonCollection("subeler")]
public class SubelerMongo : MongoDbEntity { }

// Attribute yoksa sınıf adı (SubelerMongo) koleksiyon adı olarak kullanılır
```

### E. Nested Join Desteklenmez
```csharp
// ❌ DESTEKLENMIYOR: Çekilen Şube'nin alanından 3. tabloya join
// (Root entity'den dışarıya join atılabilir, zincirleme nested join yapılamaz)
```

---

## 19. Kurulum ve DI Kullanımı

### Program.cs / Startup.cs

```csharp
// Connection Manager — uygulama boyunca tek instance
builder.Services.AddSingleton<GenericMongoConnectionManager>(
    _ => GenericMongoConnectionManager.Instance);

// Repository — her istekte yeni instance
builder.Services.AddScoped<IGenericMongoRepository, GenericMongoRepository>();
```

### Constructor Injection

```csharp
// ÖRNEK 1 — Varsayılan server (MONGO_206 / MongoPortal)
public class SubeService
{
    private readonly IGenericMongoRepository _repo;

    public SubeService(IGenericMongoRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<SubelerMongo>> GetAktifSubelerAsync()
        => await _repo.Query<SubelerMongo>()
            .Where(s => s.IsActive == true)
            .OrderBy(s => s.Unvan)
            .ToListAsync();
}

// ÖRNEK 2 — Farklı server/db hedefli
public class IysService
{
    private readonly IGenericMongoRepository _repo;

    public IysService(IGenericMongoRepository repo) => _repo = repo;

    public async Task<IysRequestConsentMongo?> GetConsentAsync(string transactionId)
        => await _repo.Query<IysRequestConsentMongo>(OurMongosServer.MONGO_52, "acente365")
            .Where(x => x.TransactionId == transactionId)
            .FirstOrDefaultAsync();
}
```

### BsonCollectionAttribute Kullanımı

```csharp
// Her entity'de koleksiyon adı tanımlanmalı
[BsonCollection("subeler")]
[BsonIgnoreExtraElements]
public class SubelerMongo : MongoDbEntity
{
    public int SubeKodu { get; set; }
    public string Unvan { get; set; }
    public bool IsActive { get; set; }
    public string? CariKartMongoId { get; set; }
}
```

### ObjectId ve String Dönüşümleri

Repository mimarisi `ObjectId` tipine manuel dönüştürme zahmetinden kurtarır:

```csharp
// Manuel dönüşüme GEREK YOK
var sube = await _repo.GetByIdAsync<SubelerMongo>("6633b4...id...");

// MongoDbEntity base class'ta Id tanımı:
// [BsonId]
// [BsonRepresentation(BsonType.ObjectId)]
// public string Id { get; set; }
```

---

> [!NOTE]
> **Performans Özeti:**
> - Collection name'ler `ConcurrentDictionary` ile cache'lenir — her sorguda `ListCollectionNames()` çağrılmaz
> - Reflection sonuçları (`PropertyInfo`, MongoDB field adları) cache'lenir — tekrar eden filtre/sort çağrılarında maliyet sıfıra yakın
> - `AnyAsync` → `Limit(1)` kullanır — tüm koleksiyonu saymaz
> - `ToPagedListAsync` → Count ve Data paralel çekilir
> - Auto-heal → fire-and-forget, asıl iş akışını bloklamaz

