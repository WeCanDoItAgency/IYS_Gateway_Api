# GenericMongoRepository Documentation

`GenericMongoRepository`, PORTAL_JOB_ORCHESTRATOR projelerinde kullanılan, yüksek performanslı ve MongoDB sunucuları (MONGO_206, MONGO_52, vb.) arası (cross-server) sorgu/join yetenekleri sunan güçlü bir veri erişim katmanıdır.

> [!NOTE]
> Bu doküman güncel `GenericMongoQueryBuilder` mimarisini, "Yazma/Güncelleme/Sayfalama" optimizasyonlarını ve "Geliştirici Güvenlik Kurallarını (Safeguards)" içermektedir.

## 1. Temel Okuma / Filtreleme ve Sayfalama (Pagination)

Aynı veritabanındaki veriler, Expression ağaçları ile kolayca çekilebilir. Çok fazla sütun içeren tablolarda RAM dostu çalışmak için `.SelectOnly` veya `.IgnoreFields` kullanabilirsiniz. Eğer verileri DataGrid/Tablo için sayfalayarak dönecekseniz `.ToPagedListAsync` hayat kurtarır.

```csharp
var repo = new GenericMongoRepository(_connectionManager);

// Klasik Liste Çekme (Sadece 3 Sütun)
var result = await repo.Query<SubelerMongo>()
    .SelectOnly(s => s.Id, s => s.SubeKodu, s => s.Unvan) 
    .Where(s => s.IsActive == true)
    .Skip(10)
    .Take(50)
    .ToListAsync();

// Otomatik Sayfalama (Paralel Count ve Data Çeker)
PagedResult<SubelerMongo> pagedResult = await repo.Query<SubelerMongo>()
    .Where(s => s.IsActive == true)
    .ToPagedListAsync(pageNumber: 1, pageSize: 50);

Console.WriteLine($"Toplam Kayıt: {pagedResult.TotalCount}");
```

> [!WARNING]
> Eğer `LookupCrossServer` veya `Lookup` yapıyorsanız, Join şartında kullandığınız alanı (`localField`) `.SelectOnly()` içerisine eklemeyi UNUTMAYIN! Eğer eklerseniz veri çekilmeyeceği için Join boşa düşer.

---

## 2. Kısmi Güncelleme (Partial Updates)

Tablodaki 100 sütunlu veriyi RAM'e çekip değiştirmek yerine direkt veritabanı seviyesinde işlem yapabilirsiniz.

```csharp
var updateDef = Builders<SubelerMongo>.Update.Set(x => x.IsActive, false);

// ÖRNEK 1: Şarta uyan TEK BİR (İlk) kaydı günceller
var singleResult = await repo.Query<SubelerMongo>()
    .Where(s => s.Id == "5f1b2c3d...")
    .UpdateOneAsync(updateDef);

// ÖRNEK 2: Şarta uyan TÜM kayıtları günceller
var multipleResult = await repo.Query<SubelerMongo>()
    .Where(s => s.FirmaMongoId == "123")
    .UpdateManyAsync(updateDef);
```

> [!CAUTION]
> Update işlemleri sırasında `.Lookup` veya `.LookupCrossServer` **KULLANILAMAZ**. Hata fırlatır.

---

## 3. Upsert ve Atomik Find-and-Modify İşlemleri

### A. UpsertOneAsync — Varsa Güncelle, Yoksa Ekle

Kayıt yoksa oluşturur, varsa günceller. Token cache, konfigürasyon gibi "tek kayıt garantisi" gereken senaryolarda kullanılır.

#### Mekanizma Detayı

`UpsertOneAsync` arka planda MongoDB'nin `UpdateOne` komutunu `IsUpsert: true` seçeneğiyle çalıştırır. İki farklı senaryo vardır:

**Senaryo 1: Kayıt VAR (Where filtresi eşleşti)**
- `Set()` ile belirtilen alanlar güncellenir
- `SetOnInsert()` ile belirtilen alanlar **ATLANIR** (kayıt zaten mevcut olduğu için)
- **Update'te yazılmayan alanlar olduğu gibi kalır, dokunulmaz**
- Mevcut doküman korunur, sadece belirtilen alanlar değişir

**Senaryo 2: Kayıt YOK (Where filtresi eşleşmedi)**
- MongoDB yeni bir doküman oluşturur
- `_id` → otomatik ObjectId üretilir
- `Set()` ile belirtilen alanlar yazılır
- `SetOnInsert()` ile belirtilen alanlar **yazılır** (sadece bu senaryoda aktif!)
- **Update'te yazılmayan alanlar MEVCUT OLMAZ** (null/default kalır)

> [!WARNING]
> **Senaryo 2'de dikkat:** Yeni doküman oluşturulurken sadece `Set()` ve `SetOnInsert()` içinde belirttiğiniz alanlar yazılır. Belirtmediğiniz alanlar doküman'da **hiç olmaz**. Bu yüzden upsert kullanırken tüm zorunlu alanları `Set()` içine eklediğinizden emin olun.

#### Örnek: Token Cache Upsert

```csharp
var update = Builders<IysTokenCacheMongo>.Update
    .Set(x => x.FirmGuid, firmGuid.ToString())     // Her zaman yazılır
    .Set(x => x.AccessToken, response.AccessToken)  // Her zaman yazılır
    .Set(x => x.RefreshToken, response.RefreshToken) // Her zaman yazılır
    .Set(x => x.UpdatedAt, DateTime.Now)             // Her zaman yazılır
    .SetOnInsert(x => x.CreatedAt, DateTime.Now);    // Sadece ilk insert'te!

await repo.Query<IysTokenCacheMongo>(OurMongosServer.MONGO_52, "tokenDb")
    .Where(x => x.FirmGuid == firmGuidStr)
    .UpsertOneAsync(update);
```

**İlk çağrı (kayıt yok):** Tüm alanlar yazılır + `CreatedAt` set edilir.
**Sonraki çağrılar (kayıt var):** Token güncellenir, `CreatedAt` korunur, `CachedBrandCode` gibi diğer alanlar **dokunulmaz**.

#### Örnek: Konfigürasyon Ayarı (Tek Kayıt Garantisi)

```csharp
var update = Builders<AppConfigMongo>.Update
    .Set(x => x.Key, "MaxRetryCount")
    .Set(x => x.Value, "5")
    .Set(x => x.UpdatedAt, DateTime.Now)
    .SetOnInsert(x => x.CreatedAt, DateTime.Now);

await repo.Query<AppConfigMongo>()
    .Where(x => x.Key == "MaxRetryCount")
    .UpsertOneAsync(update);
// İlk seferde kayıt oluşturur, sonrakilerde sadece Value güncellenir
```

---

### B. FindOneAndUpdateAsync — Güncelle ve Güncel Dokümanı Dön

Atomic olarak günceller ve güncellenmiş (veya önceki) dokümanı döner. Concurrent ortamlarda race condition önler.

#### Mekanizma Detayı

- Güncelleme ve okuma **tek bir atomic operasyondur** — arada başka thread araya giremez
- `returnAfter: true` (varsayılan): **Güncelleme SONRASI** dokümanı döner
- `returnAfter: false`: **Güncelleme ÖNCESİ** dokümanı döner
- Filtre eşleşmezse `null` döner

#### Ne Zaman Kullanılır?
- Concurrent sayaçlar (ör. request counter)
- Distributed lock mekanizmaları
- "Güncelle ve sonucu hemen kullan" senaryoları

```csharp
// Sayacı artır ve güncel değeri al
var update = Builders<SubelerMongo>.Update.Inc(x => x.RequestCount, 1);

var updated = await repo.Query<SubelerMongo>()
    .Where(s => s.SubeKodu == 100)
    .FindOneAndUpdateAsync(update);
// updated.RequestCount → güncelleme sonrası değer (ör: 43)

// Güncelleme öncesi değeri al (eski değer lazımsa)
var before = await repo.Query<SubelerMongo>()
    .Where(s => s.SubeKodu == 100)
    .FindOneAndUpdateAsync(update, returnAfter: false);
// before.RequestCount → güncelleme öncesi değer (ör: 43, güncelleme sonrası aslında 44)
```

---

### C. FindOneAndDeleteAsync — Sil ve Silinen Dokümanı Dön

Queue-like pattern'lerde veya "al ve sil" senaryolarında kullanılır.

#### Mekanizma Detayı

- Silme ve okuma **tek bir atomic operasyondur**
- Filtre eşleşmezse `null` döner
- `.OrderBy()` ile sıralama yapılabilir — bu sayede "en eski görevi al ve sil" gibi FIFO kuyruk pattern'leri kurulabilir

```csharp
// FIFO kuyruk: en eski hazır görevi al ve sil
var deleted = await repo.Query<PendingTaskMongo>()
    .Where(t => t.Status == "ready")
    .OrderBy(t => t.CreatedAt)
    .FindOneAndDeleteAsync();

if (deleted != null)
{
    Console.WriteLine($"İşlenen görev: {deleted.Id}");
    // deleted → silinen dokümanın tüm verisi burada
}
```

> [!CAUTION]
> Find-and-Modify işlemleri sırasında `.Lookup` veya `.LookupCrossServer` **KULLANILAMAZ**. Hata fırlatır.

> [!TIP]
> **UpdateOneAsync vs UpsertOneAsync vs FindOneAndUpdateAsync — Hangisini Seçmeliyim?**
>
> | Metot | Kayıt Yoksa | Sonuç Döner mi? | Kullanım |
> |:------|:-----------|:----------------|:---------|
> | `UpdateOneAsync` | Hiçbir şey yapmaz | ❌ Sadece `UpdateResult` | Normal güncelleme |
> | `UpsertOneAsync` | Yeni kayıt oluşturur | ❌ Sadece `UpdateResult` | Cache, config, tek kayıt garantisi |
> | `FindOneAndUpdateAsync` | `null` döner | ✅ Güncel dokümanı döner | Sayaç, lock, "güncelle ve kullan" |

---

## 4. Toplu İşlemler (Bulk Write)

Binlerce kaydı tek seferde MongoDB'ye göndermek isterseniz (Performans için):

```csharp
var requests = new List<WriteModel<SubelerMongo>>();

foreach(var item in binkayitlikListe) {
    var filter = Builders<SubelerMongo>.Filter.Eq(x => x.Id, item.Id);
    var update = Builders<SubelerMongo>.Update.Set(x => x.GuncellenmeTarihi, DateTime.Now);
    requests.Add(new UpdateOneModel<SubelerMongo>(filter, update));
}

// 10.000 kaydı tek bir ağ paketiyle gönder
await repo.BulkWriteAsync(requests);
```

---

## 5. Transaction / Session Yönetimi

Kritik finansal veya birden çok tabloyu etkileyen işlemlerde tutarlılık (ACID) sağlamak için:

> [!WARNING]
> Transaction'lar **sadece Replica Set kurulumu olan MongoDB sunucularında çalışır**. Standalone MongoDB'ler hata fırlatır!

```csharp
using var session = await repo.StartSessionAsync();
session.StartTransaction();

try {
    // İşlemler buraya (session parametresi ile)
    await session.CommitTransactionAsync();
} 
catch {
    await session.AbortTransactionAsync();
}
```

---

## 6. Cross-Server Join İşlemleri (Farklı Sunucular Arası)

Eğer Subeler koleksiyonu `MONGO_206` üzerinde, CariKartlar koleksiyonu ise `MONGO_52` üzerindeyse, `LookupCrossServer` kullanılır. 

> [!TIP]
> **Batching/Chunking:** `LookupCrossServer` büyük verilerde performans sorunu yaşanmaması ve MongoDB'nin 16MB BSON limitine takılmaması için **verileri arka planda 10.000'lik paketler (Chunk) halinde çeker** ve bellekte birleştirir.

```csharp
var result = await repo.Query<NewDocumentsMongo>() // Default 206
    .LookupCrossServer<CariKartlar>(
        server: OurMongosServer.MONGO_52, 
        database: "acente365", 
        localField: d => d.CariKartMongoId,
        foreignField: c => c.Id,
        @as: "CariKartDetaylari" // Zorunlu parametre!
    )
    .Where(d => d.IsActive == true)
    .ToListAsync();
```

### Multiple Join (Çoklu Join) ve Fluent Yapı

Mimarimizi **"Fluent (Akıcı)"** bir düzende kurduğumuz için arka arkaya dilediğiniz kadar `.Lookup()` veya `.LookupCrossServer()` ekleyebilirsiniz. 

```csharp
var kullanicilar = await repo.Query<KullanicilarMongo>()
    // 1. Join: Aynı veritabanındaki Şube'yi çek (Örn: MONGO_206)
    .Lookup<SubelerMongo>(
        localField: k => k.SubeMongoId, 
        foreignField: s => s.Id, 
        @as: "SubeBilgisi"
    )
    // 2. Join: Farklı veritabanındaki Firma'yı çek (Örn: MONGO_52 CariKartlar)
    .LookupCrossServer<CariKartlar>(
        server: OurMongosServer.MONGO_52,
        database: "acente365",
        localField: k => k.FirmaMongoId,
        foreignField: c => c.Id,
        @as: "FirmaBilgisi"
    )
    .Where(k => k.IsActive == true)
    .ToListAsync();
```

> [!WARNING]
> **Desteklenmeyen Tek Senaryo (Deep/Nested Join):** Şu anki yapıda her zaman en baştaki "Ana Tablo'dan (Root Entity)" dışarıya paralel join atabilirsiniz. Çektiğiniz bir Şube'nin içindeki alanı kullanıp 3. bir tabloya zincirleme join (Nested Lookup) **yapılamaz**.

---

## 7. Cross-Server Filtreleme (WhereCrossServer / Reverse Query)

Cross-Server işlemlerde asıl performans sorunu "Alt tabloya göre filtrelemektir". Eğer alt tablodan gelen bir şarta göre ana tablodaki verileri filtrelemek istiyorsanız `WhereCrossServer` kullanmalısınız.

```csharp
var result = await repo.Query<SubelerMongo>() // 206 Sunucusu
    .WhereCrossServer<CariKartlar>(
        server: OurMongosServer.MONGO_52,
        database: "acente365",
        localField: s => s.CariKartMongoId,
        foreignField: c => c.Id,
        foreignFilter: c => c.Unvan.Contains("Ahmet"), // Önce 52'de Ahmet'leri bul!
        @as: "CariKartlar"
    )
    .Where(s => s.IsActive == true)
    .ToListAsync();
```

---

## 8. Kendi Kendini İyileştiren İndeksleme (Auto-Healing Query Engine)

`GenericMongoQueryBuilder` veritabanındaki yavaş sorguları algılar ve optimize eder.

Eğer herhangi bir sorgu (Ana `_filter`, `LookupCrossServer`, `WhereCrossServer` veya `UpdateMany`) **60 saniyeden uzun sürerse**:
1. Arka planda (`Task.Run` ile sessizce) bir iyileştirme süreci başlar.
2. MongoDB'ye gönderilen filtre ağacı (BsonDocument) ayrıştırılır ve içerisindeki sahalar tespit edilir.
3. İlgili koleksiyona **otomatik Compound Index** (Birleşik İndeks) oluşturulur.
4. İndeks isimleri her zaman `AUTO_HEAL_idx_Alan1_Alan2` şeklinde başlar.

---

## 9. Geliştirici Kısıtlamaları ve Hatalar (Developer Safeguards)

### A. Alias (@as) Çakışma Koruması
Aynı query builder'da `Lookup` veya `LookupCrossServer` üzerinden aynı `@as` ismi iki kez verilirse `InvalidOperationException` fırlatılır.

### B. Array / Liste Üzerinden Join Atılamaz (NotSupportedException)
`LookupCrossServer` ve `WhereCrossServer` işlemleri şu anda sadece tekil string/ObjectId gibi alanları desteklemektedir. 
**Neden Desteklemiyoruz?** Eğer ana tablonuzdaki eşleşme alanı bir `List<string>` (örn: `TargetIds`) olsaydı, on binlerce kaydın içindeki yüz binlerce ID'yi düzleştirip (flatten) karşı sunucuya sormamız gerekecekti. Dönen on binlerce sonucu ise tekrar orijinal nesnelerin içindeki dizilerle tek tek eşleştirmek (In-Memory Intersection) **O(N*M)** yani Kartezyen Çarpım benzeri devasa bir işlem karmaşası yaratacaktı. Bu işlem CPU ve RAM'i felç edeceği için, performansın tahmin edilebilir kalması adına şu an sadece 1-1 (Tekil) eşleşmelere izin veriyoruz. 

### C. UpdateMany Sırasında Join Atılamaz
Veritabanı bazında kısmi güncelleme yapan `UpdateManyAsync` çağrılarında Cross-Server eşleşme yapılamaz, sistem izin vermez.

---

## 10. Diğer Terminal Komutları

Veriyi listeye çekmek (`ToListAsync()`) ve PagedList dışında kullanabileceğiniz bitirici komutlar:

```csharp
// 1. FirstOrDefaultAsync: Şarta uyan ilk kaydı getirir.
var firstItem = await repo.Query<SubelerMongo>()
    .Where(s => s.SubeKodu == 100)
    .FirstOrDefaultAsync();

// 2. CountAsync: Şarta uyan kayıt sayısını döndürür. (RAM'e veri çekmez, süper hızlıdır).
var totalActive = await repo.Query<SubelerMongo>()
    .Where(s => s.IsActive == true)
    .CountAsync();

// 3. AnyAsync: Şarta uyan kayıt var mı yok mu kontrol eder.
bool hasRecords = await repo.Query<SubelerMongo>()
    .Where(s => s.FirmaMongoId == "123")
    .AnyAsync();
```

---

## 11. Kurulum ve Dependency Injection (DI) Kullanımı

Mimarideki `GenericMongoRepository` sınıfı, `IMongoConnectionManager`'a bağımlıdır. Bir mikroservise veya Job projelerinize eklemek için `Program.cs` veya `Startup.cs` içerisinde IoC konteynerine kaydetmeniz gerekir.

### A. Servis Kayıtları (Program.cs)

```csharp
// 1. Connection Manager (Uygulama boyunca 1 kez yaratılır)
builder.Services.AddSingleton<IMongoConnectionManager, MongoConnectionManager>();

// 2. Generic Repository (Her istekte yeni bir kopya yaratılması daha sağlıklıdır)
builder.Services.AddScoped<IGenericMongoRepository, GenericMongoRepository>();
```

### B. Constructor Injection (Kullanım)

Herhangi bir Service, Handler veya Background Worker içerisinde constructor'dan isteyerek kullanabilirsiniz:

```csharp
public class TeklifHesaplamaService
{
    private readonly IGenericMongoRepository _mongoRepo;

    public TeklifHesaplamaService(IGenericMongoRepository mongoRepo)
    {
        _mongoRepo = mongoRepo;
    }

    public async Task IslemYap()
    {
        var aktifKullanici = await _mongoRepo.Query<KullanicilarMongo>()
            .Where(k => k.IsActive == true)
            .FirstOrDefaultAsync();
    }
}
```

---

## 12. ObjectId ve String Dönüşümleri (BsonRepresentation)

Repository mimarisi, geliştiriciyi `ObjectId` tipine manuel dönüştürme zahmetinden kurtarmak üzere tasarlanmıştır.

`GetByIdAsync` veya `Where` ile ID tabanlı sorgular yaparken MongoDB `_id` değerini `string` olarak (Örn: `"6633b4..."`) göndermeniz yeterlidir:

```csharp
// ÖRNEK: Manuel tip dönüşümü YAPMANIZA GEREK YOKTUR
var sube = await _mongoRepo.GetByIdAsync<SubelerMongo>("6633b4...id...");
```

**Nasıl Çalışıyor?**
Base class olan `MongoDbEntity` sınıfımızda Id alanı şu etiketle (attribute) tanımlanmıştır:
```csharp
[BsonId]
[BsonRepresentation(BsonType.ObjectId)] 
public string Id { get; set; }
```
Bu attribut sayesinde C# MongoDB Sürücüsü, sorgu atarken string ifadenizi arka planda otomatik olarak `ObjectId` tipine çevirir. Veritabanından okurken de `ObjectId`'yi tekrar C# `string`'ine çevirerek size teslim eder. Kısacası hiçbir zaman `new ObjectId("...")` yapmanıza gerek kalmaz.

---

## 13. Veri Ekleme ve Silme İşlemleri (Insert / Delete)

Query Builder (okuma ve kısmi güncelleme) dışında `IGenericMongoRepository` direkt olarak temel CRUD yeteneklerine sahiptir. Yeni veri oluşturmak veya silmek için doğrudan repository metotlarını kullanabilirsiniz.

### A. Veri Ekleme (Insert)
```csharp
var yeniSube = new SubelerMongo 
{ 
    SubeKodu = 999, 
    Unvan = "Yeni Şube", 
    IsActive = true 
};

// Tekli Ekleme
await _mongoRepo.InsertAsync(yeniSube);

// Çoklu Ekleme (Performanslı)
var subeListesi = new List<SubelerMongo> { /* ... */ };
await _mongoRepo.InsertManyAsync(subeListesi);
```

### B. Veri Silme (Delete)
```csharp
// 1. Direkt ID ile Tekli Silme
await _mongoRepo.DeleteAsync<SubelerMongo>("6633b4...id...");

// 2. Şarta Göre Toplu Silme (DeleteMany)
// Pasif olan ve MssqlId'si 100'den küçük olan tüm kayıtları sil
await _mongoRepo.DeleteManyAsync<SubelerMongo>(x => x.IsActive == false && x.MssqlId < 100);
```
