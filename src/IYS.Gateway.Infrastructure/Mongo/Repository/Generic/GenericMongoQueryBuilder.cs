using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using IYS.Gateway.Infrastructure.Mongo.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.Mongo.Repository.Generic
{
    /// <summary>
    /// MongoDB sorgu pipeline'ı oluşturmak için fluent builder implementasyonu.
    /// <see cref="IGenericMongoQueryBuilder{T}"/> arayüzünü gerçekler.
    /// 
    /// <para><b>Yaşam döngüsü:</b> Her instance tek kullanımlıktır. Terminal metot çağrıldıktan sonra
    /// internal state (_filter, _sort, _skip, _take) değişmiş olacağından yeniden kullanılmamalıdır.</para>
    /// 
    /// <para><b>Auto-Healing:</b> Yavaş sorgular tespit edildiğinde (>{@value AUTO_HEAL_THRESHOLD_SECONDS}s)
    /// otomatik index önerisi/oluşturma mekanizması devreye girer.</para>
    /// </summary>
    /// <typeparam name="T">Hedef MongoDB entity tipi.</typeparam>
    public class GenericMongoQueryBuilder<T> : IGenericMongoQueryBuilder<T> where T : MongoDbEntity
    {
        private readonly IMongoCollection<T> _collection;
        private readonly IGenericMongoRepository _repository;
        private FilterDefinition<T> _filter = Builders<T>.Filter.Empty;
        private SortDefinition<T>? _sort;
        private ProjectionDefinition<T>? _projection;
        private int? _skip;
        private int? _take;
        private readonly List<BsonDocument> _lookupStages = new();
        private readonly List<Func<List<T>, CancellationToken, Task>> _crossServerLookups = new();
        private readonly List<Func<CancellationToken, Task>> _reverseLookups = new();
        private readonly HashSet<string> _usedAliases = new();

        /// <summary>
        /// Reflection sonuçlarını cache'ler. Key: "TypeName:PropertyName" → Value: PropertyInfo.
        /// Her sort/filter çağrısında tekrarlanan GetProperty() maliyetini önler.
        /// </summary>
        private static readonly ConcurrentDictionary<string, PropertyInfo?> _propertyCache = new();
        
        /// <summary>Yavaş sorgu algılama eşiği (saniye). Bu süreyi aşan sorgular auto-heal tetikler.</summary>
        private const int AUTO_HEAL_THRESHOLD_SECONDS = 60;

        /// <summary>
        /// Yeni bir query builder oluşturur.
        /// </summary>
        /// <param name="collection">Hedef MongoDB koleksiyonu.</param>
        /// <param name="repository">Cross-server sorguları için repository referansı.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> veya <paramref name="repository"/> null ise.</exception>
        public GenericMongoQueryBuilder(IMongoCollection<T> collection, IGenericMongoRepository repository)
        {
            _collection = collection ?? throw new ArgumentNullException(nameof(collection));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> Where(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            _filter = Builders<T>.Filter.And(_filter, Builders<T>.Filter.Where(predicate));
            return this;
        }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> Where(FilterDefinition<T> filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            _filter = Builders<T>.Filter.And(_filter, filter);
            return this;
        }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> OrderBy(Expression<Func<T, object>> field)
        {
            if (field == null) throw new ArgumentNullException(nameof(field));
            _sort = _sort == null 
                ? Builders<T>.Sort.Ascending(field) 
                : Builders<T>.Sort.Combine(_sort, Builders<T>.Sort.Ascending(field));
            return this;
        }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> OrderByDescending(Expression<Func<T, object>> field)
        {
            if (field == null) throw new ArgumentNullException(nameof(field));
            _sort = _sort == null 
                ? Builders<T>.Sort.Descending(field) 
                : Builders<T>.Sort.Combine(_sort, Builders<T>.Sort.Descending(field));
            return this;
        }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> Skip(int count) { _skip = Math.Max(0, count); return this; }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> Take(int count) { if (count > 0) _take = count; return this; }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> SelectOnly(params Expression<Func<T, object>>[] fields)
        {
            if (fields == null || fields.Length == 0) return this;
            var builder = Builders<T>.Projection;
            foreach (var field in fields)
            {
                if (field == null) continue;
                _projection = _projection == null ? builder.Include(field) : _projection.Include(field);
            }
            return this;
        }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> IgnoreFields(params Expression<Func<T, object>>[] fields)
        {
            if (fields == null || fields.Length == 0) return this;
            var builder = Builders<T>.Projection;
            foreach (var field in fields)
            {
                if (field == null) continue;
                _projection = _projection == null ? builder.Exclude(field) : _projection.Exclude(field);
            }
            return this;
        }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> Lookup<TForeign>(
            Expression<Func<T, object>> localField,
            Expression<Func<TForeign, object>> foreignField,
            string @as) where TForeign : MongoDbEntity
        {
            if (!_usedAliases.Add(@as))
            {
                throw new InvalidOperationException($"'{@as}' takma adı (alias) bu sorguda zaten kullanılıyor. Lütfen benzersiz bir alias belirleyin.");
            }

            var localFieldName = GetMongoFieldName(localField);
            var foreignFieldName = GetMongoFieldName(foreignField);
            var foreignCollectionName = GetCollectionName<TForeign>();

            _lookupStages.Add(new BsonDocument("$lookup", new BsonDocument
            {
                { "from", foreignCollectionName },
                { "localField", localFieldName },
                { "foreignField", foreignFieldName },
                { "as", @as }
            }));
            
            return this;
        }

        private void EnsureNotArray(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType != typeof(string) && typeof(System.Collections.IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
            {
                throw new NotSupportedException("Cross-Server join işlemlerinde Array/List tipindeki alanlar (1-N) henüz desteklenmemektedir. Lütfen tekil (1-1) bir eşleşme property'si kullanın.");
            }
        }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> WhereCrossServer<TForeign>(
            OurMongosServer server,
            string database,
            Expression<Func<T, object>> localField,
            Expression<Func<TForeign, object>> foreignField,
            Expression<Func<TForeign, bool>> foreignFilter,
            string @as) where TForeign : MongoDbEntity
        {
            if (!_usedAliases.Add(@as))
                throw new InvalidOperationException($"'{@as}' takma adı (alias) bu sorguda zaten kullanılıyor. Lütfen benzersiz bir alias belirleyin.");

            var localPropInfo = GetPropertyInfo(localField);
            EnsureNotArray(localPropInfo);
            var foreignPropInfo = GetPropertyInfo(foreignField);
            var foreignMongoFieldName = GetMongoFieldName(foreignField);

            _reverseLookups.Add(async (ct) =>
            {
                var foreignCollection = _repository.GetCollection<TForeign>(server, database);
                var sw = Stopwatch.StartNew();
                var cursor = await foreignCollection.FindAsync(foreignFilter, cancellationToken: ct);
                var foreignResults = await cursor.ToListAsync(ct);
                sw.Stop();
                CheckAndHealIndexes(sw, foreignCollection, foreignFilter, foreignMongoFieldName);

                if (foreignResults.Count == 0)
                {
                    // Eğer foreign tabloda hiç sonuç yoksa, ana tablonun sorgusu da boş dönmelidir.
                    // Bu yüzden filter'a eşleşmeyecek geçersiz bir şart ekliyoruz.
                    _filter = Builders<T>.Filter.And(_filter, Builders<T>.Filter.Eq("_id", ObjectId.Empty));
                    return;
                }

                var foreignIds = new HashSet<object>();
                var localType = localPropInfo.PropertyType;

                foreach (var fItem in foreignResults)
                {
                    var val = foreignPropInfo.GetValue(fItem);
                    if (val != null)
                    {
                        try
                        {
                            var convertedVal = localType == typeof(string) 
                                ? val.ToString() 
                                : Convert.ChangeType(val, localType);
                                
                            if (convertedVal != null)
                            {
                                foreignIds.Add(convertedVal);
                            }
                        }
                        catch { }
                    }
                }

                // Ana sorgunun içine IN filtresini yerleştir.
                _filter = Builders<T>.Filter.And(_filter, Builders<T>.Filter.In(localField, foreignIds));

                // Join (Haritalama) işlemini yapmak için normal listeye (crossServerLookups) ekle
                // Böylece veritabanından veri çekilmez, elimizdeki (foreignResults) memory'den maplenir.
                _crossServerLookups.Add(async (localResults, innerCt) =>
                {
                    var foreignLookup = foreignResults.GroupBy(x => foreignPropInfo.GetValue(x)?.ToString())
                                                      .ToDictionary(g => g.Key ?? string.Empty, g => g.ToList());

                    foreach (var item in localResults)
                    {
                        var val = localPropInfo.GetValue(item)?.ToString();
                        var matchedList = (!string.IsNullOrEmpty(val) && foreignLookup.TryGetValue(val, out var matched)) 
                            ? matched 
                            : new List<TForeign>();

                        if (matchedList.Count > 0)
                        {
                            var bsonArray = new BsonArray();
                            foreach (var fItem in matchedList)
                            {
                                bsonArray.Add(fItem.ToBsonDocument());
                            }

                            if (bsonArray.Count > 0)
                            {
                                var extraElementsProp = typeof(T).GetProperty("ExtraElements");
                                if (extraElementsProp != null)
                                {
                                    var extraElements = extraElementsProp.GetValue(item) as Dictionary<string, object>;
                                    if (extraElements == null)
                                    {
                                        extraElements = new Dictionary<string, object>();
                                        if (extraElementsProp.CanWrite)
                                        {
                                            extraElementsProp.SetValue(item, extraElements);
                                        }
                                    }
                                    extraElements[@as] = bsonArray;
                                }
                            }
                        }
                    }
                    await Task.CompletedTask;
                });
            });

            return this;
        }

        /// <inheritdoc />
        public IGenericMongoQueryBuilder<T> LookupCrossServer<TForeign>(
            OurMongosServer server,
            string database,
            Expression<Func<T, object>> localField,
            Expression<Func<TForeign, object>> foreignField,
            string @as) where TForeign : MongoDbEntity
        {
            if (!_usedAliases.Add(@as))
                throw new InvalidOperationException($"'{@as}' takma adı (alias) bu sorguda zaten kullanılıyor. Lütfen benzersiz bir alias belirleyin.");

            var localPropInfo = GetPropertyInfo(localField);
            EnsureNotArray(localPropInfo);

            var foreignPropInfo = GetPropertyInfo(foreignField);

            // Task listesine in-memory join işlemini ekle
            _crossServerLookups.Add(async (localResults, ct) =>
            {
                if (localResults == null || localResults.Count == 0) return;

                // 1. Local entity'lerden aranacak id'leri topla
                var localIds = new HashSet<object>();
                var foreignType = foreignPropInfo.PropertyType;
                
                foreach (var item in localResults)
                {
                    var val = localPropInfo.GetValue(item);
                    if (val != null)
                    {
                        try
                        {
                            var convertedVal = foreignType == typeof(string) 
                                ? val.ToString() 
                                : Convert.ChangeType(val, foreignType);
                                
                            if (convertedVal != null)
                            {
                                localIds.Add(convertedVal);
                            }
                        }
                        catch { }
                    }
                }

                if (localIds.Count == 0) return;

                // 2. Cross server'a bağlanıp verileri BATCH halinde çek
                var foreignCollection = _repository.GetCollection<TForeign>(server, database);
                var foreignResults = new List<TForeign>();
                var localIdsList = localIds.ToList();
                const int chunkSize = 10000;
                var tasks = new List<Task<List<TForeign>>>();

                for (int i = 0; i < localIdsList.Count; i += chunkSize)
                {
                    var chunk = localIdsList.Skip(i).Take(chunkSize).ToList();
                    var filter = Builders<TForeign>.Filter.In(foreignField, chunk);
                    
                    tasks.Add(Task.Run(async () => {
                        var sw = Stopwatch.StartNew();
                        var cursor = await foreignCollection.FindAsync(filter, cancellationToken: ct);
                        var chunkRes = await cursor.ToListAsync(ct);
                        sw.Stop();
                        CheckAndHealIndexes(sw, foreignCollection, filter, GetMongoFieldName(foreignField));
                        return chunkRes;
                    }, ct));
                }

                var chunkResults = await Task.WhenAll(tasks);
                foreach (var chunk in chunkResults)
                {
                    foreignResults.AddRange(chunk);
                }

                if (foreignResults.Count == 0) return;

                // 3. Eşleştirmeyi memory üzerinde yap
                var foreignLookup = foreignResults.GroupBy(x => foreignPropInfo.GetValue(x)?.ToString())
                                                  .ToDictionary(g => g.Key ?? string.Empty, g => g.ToList());

                foreach (var item in localResults)
                {
                    var val = localPropInfo.GetValue(item)?.ToString();
                    var matchedList = (!string.IsNullOrEmpty(val) && foreignLookup.TryGetValue(val, out var matched)) 
                        ? matched 
                        : new List<TForeign>();

                    if (matchedList.Count > 0)
                    {
                        var bsonArray = new BsonArray();
                        foreach (var fItem in matchedList)
                        {
                            bsonArray.Add(fItem.ToBsonDocument());
                        }

                        if (bsonArray.Count > 0)
                        {
                            var extraElementsProp = typeof(T).GetProperty("ExtraElements");
                            if (extraElementsProp != null)
                            {
                                var extraElements = extraElementsProp.GetValue(item) as Dictionary<string, object>;
                                if (extraElements == null)
                                {
                                    extraElements = new Dictionary<string, object>();
                                    if (extraElementsProp.CanWrite)
                                    {
                                        extraElementsProp.SetValue(item, extraElements);
                                    }
                                }
                                extraElements[@as] = bsonArray;
                            }
                        }
                    }
                }
            });

            return this;
        }

        /// <inheritdoc />
        public async Task<List<T>> ToListAsync(CancellationToken ct = default)
        {
            // Ana sorgu atılmadan ÖNCE reverse-lookup (filtreleme için) işlemleri çalıştırılmalı.
            if (_reverseLookups.Count > 0)
            {
                foreach (var reverseLookup in _reverseLookups)
                {
                    await reverseLookup(ct);
                }
            }

            List<T> results;

            if (_lookupStages.Count > 0)
            {
                results = await ExecuteAggregationAsync(ct);
            }
            else
            {
                var options = new FindOptions<T>();
                if (_sort != null) options.Sort = _sort;
                if (_skip.HasValue) options.Skip = _skip;
                if (_take.HasValue) options.Limit = _take;
                if (_projection != null) options.Projection = _projection;

                var sw = Stopwatch.StartNew();
                var cursor = await _collection.FindAsync(_filter, options, ct);
                results = await cursor.ToListAsync(ct);
                sw.Stop();
                CheckAndHealIndexes(sw, _collection, _filter);
            }

            // Execute cross-server lookups
            if (_crossServerLookups.Count > 0 && results.Count > 0)
            {
                foreach (var crossServerAction in _crossServerLookups)
                {
                    await crossServerAction(results, ct);
                }
            }

            return results;
        }

        /// <inheritdoc />
        public async Task<T?> FirstOrDefaultAsync(CancellationToken ct = default)
        {
            var oldTake = _take;
            _take = 1;
            var results = await ToListAsync(ct);
            _take = oldTake;
            return results.FirstOrDefault();
        }

        /// <inheritdoc />
        public async Task<long> CountAsync(CancellationToken ct = default)
        {
            if (_reverseLookups.Count > 0)
            {
                foreach (var reverseLookup in _reverseLookups)
                {
                    await reverseLookup(ct);
                }
            }
            var sw = Stopwatch.StartNew();
            var count = await _collection.CountDocumentsAsync(_filter, cancellationToken: ct);
            sw.Stop();
            CheckAndHealIndexes(sw, _collection, _filter);
            return count;
        }

        /// <inheritdoc />
        public async Task<bool> AnyAsync(CancellationToken ct = default)
        {
            // Reverse lookup'lar varsa önce çalıştır (filtreyi güncelleyebilirler)
            if (_reverseLookups.Count > 0)
            {
                foreach (var reverseLookup in _reverseLookups)
                {
                    await reverseLookup(ct);
                }
            }

            // CountAsync tüm koleksiyonu sayar — AnyAsync için Limit(1) yeterli
            var sw = Stopwatch.StartNew();
            var options = new CountOptions { Limit = 1 };
            var count = await _collection.CountDocumentsAsync(_filter, options, ct);
            sw.Stop();
            CheckAndHealIndexes(sw, _collection, _filter);
            return count > 0;
        }

        /// <inheritdoc />
        public async Task<PagedResult<T>> ToPagedListAsync(int pageNumber, int pageSize, CancellationToken ct = default)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            var countTask = CountAsync(ct);

            // Set skip and take for pagination
            _skip = (pageNumber - 1) * pageSize;
            _take = pageSize;

            var dataTask = ToListAsync(ct);

            await Task.WhenAll(countTask, dataTask);

            return new PagedResult<T>(countTask.Result, dataTask.Result);
        }

        /// <inheritdoc />
        public async Task<UpdateResult> UpdateOneAsync(UpdateDefinition<T> update, CancellationToken ct = default)
        {
            if (_lookupStages.Count > 0 || _reverseLookups.Count > 0)
            {
                throw new NotSupportedException("Update operations do not support cross-server or local Lookups.");
            }

            var sw = Stopwatch.StartNew();
            var result = await _collection.UpdateOneAsync(_filter, update, cancellationToken: ct);
            sw.Stop();
            CheckAndHealIndexes(sw, _collection, _filter);

            return result;
        }

        /// <inheritdoc />
        public async Task<UpdateResult> UpdateManyAsync(UpdateDefinition<T> update, CancellationToken ct = default)
        {
            if (_lookupStages.Count > 0 || _reverseLookups.Count > 0)
            {
                throw new NotSupportedException("Update operations do not support cross-server or local Lookups.");
            }

            var sw = Stopwatch.StartNew();
            var result = await _collection.UpdateManyAsync(_filter, update, cancellationToken: ct);
            sw.Stop();
            CheckAndHealIndexes(sw, _collection, _filter);

            return result;
        }

        /// <inheritdoc />
        public async Task<UpdateResult> UpsertOneAsync(UpdateDefinition<T> update, CancellationToken ct = default)
        {
            if (_lookupStages.Count > 0 || _reverseLookups.Count > 0)
            {
                throw new NotSupportedException("Upsert operations do not support cross-server or local Lookups.");
            }

            var sw = Stopwatch.StartNew();
            var options = new UpdateOptions { IsUpsert = true };
            var result = await _collection.UpdateOneAsync(_filter, update, options, ct);
            sw.Stop();
            CheckAndHealIndexes(sw, _collection, _filter);

            return result;
        }

        /// <inheritdoc />
        public async Task<T?> FindOneAndUpdateAsync(UpdateDefinition<T> update, bool returnAfter = true, CancellationToken ct = default)
        {
            if (_lookupStages.Count > 0 || _reverseLookups.Count > 0)
            {
                throw new NotSupportedException("FindOneAndUpdate operations do not support cross-server or local Lookups.");
            }

            var sw = Stopwatch.StartNew();
            var options = new FindOneAndUpdateOptions<T>
            {
                ReturnDocument = returnAfter ? ReturnDocument.After : ReturnDocument.Before
            };
            var result = await _collection.FindOneAndUpdateAsync(_filter, update, options, ct);
            sw.Stop();
            CheckAndHealIndexes(sw, _collection, _filter);

            return result;
        }

        /// <inheritdoc />
        public async Task<T?> FindOneAndDeleteAsync(CancellationToken ct = default)
        {
            if (_lookupStages.Count > 0 || _reverseLookups.Count > 0)
            {
                throw new NotSupportedException("FindOneAndDelete operations do not support cross-server or local Lookups.");
            }

            var sw = Stopwatch.StartNew();
            var result = await _collection.FindOneAndDeleteAsync(_filter, cancellationToken: ct);
            sw.Stop();
            CheckAndHealIndexes(sw, _collection, _filter);

            return result;
        }

        /// <inheritdoc />
        public async Task InsertOneAsync(T document, CancellationToken ct = default)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            await _collection.InsertOneAsync(document, cancellationToken: ct);
        }

        /// <inheritdoc />
        public async Task<DeleteResult> DeleteOneAsync(CancellationToken ct = default)
        {
            var sw = Stopwatch.StartNew();
            var result = await _collection.DeleteOneAsync(_filter, ct);
            sw.Stop();
            CheckAndHealIndexes(sw, _collection, _filter);
            return result;
        }

        // ═══════════════════════════════════════════════════════════════
        // SERVER-SIDE GRID LOADING (DevExtreme Uyumlu)
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// DevExtreme grid'den gelen tüm parametreleri (filter/sort/paging/group) işler.
        /// Varsayılan: Hepsi MongoDB'de çalışır (ServerSide*=true).
        /// Opsiyonel: Property bazlı veya toplu client-side'a düşürülebilir.
        /// 
        /// Kullanım (basit — tek satır):
        ///   return await query.LoadServerSideAsync(options);
        /// 
        /// Kullanım (hibrit — bazı alanlar client-side):
        ///   options.ClientSideProperties = new HashSet&lt;string&gt; { "ComputedField" };
        ///   return await query.LoadServerSideAsync(options);
        /// 
        /// Kullanım (tamamı client-side — eski davranış):
        ///   options.ServerSideFiltering = false;
        ///   options.ServerSideSorting = false;
        ///   options.ServerSidePaging = false;
        ///   return await query.LoadServerSideAsync(options);
        /// </summary>
        public async Task<ServerSideLoadResult> LoadServerSideAsync(ServerSideLoadOptions options, CancellationToken ct = default)
        {
            if (options == null)
                options = new ServerSideLoadOptions();

            // ── 1. FILTER İŞLEME ──────────────────────────────────────
            if (options.Filter != null && options.Filter.Count > 0 && options.ServerSideFiltering)
            {
                if (options.ClientSideProperties != null && options.ClientSideProperties.Count > 0)
                {
                    // Hibrit mod: Server-side ve client-side filtreleri ayır
                    var splitResult = DevExtremeMongoAdapter.SplitFilter<T>(
                        options.Filter, options.ClientSideProperties);

                    // Server-side filtreleri MongoDB'ye uygula
                    if (splitResult.ServerSideFilter != null &&
                        splitResult.ServerSideFilter != Builders<T>.Filter.Empty)
                    {
                        _filter = Builders<T>.Filter.And(_filter, splitResult.ServerSideFilter);
                    }

                    // Client-side filtreler varsa, sonra bellekte uygulanacak
                    // (aşağıda ApplyClientSideFilter ile)
                }
                else
                {
                    // Tam server-side: Tüm filtreleri MongoDB'ye gönder
                    var parsedFilter = DevExtremeMongoAdapter.ParseFilter<T>(options.Filter);
                    if (parsedFilter != null && parsedFilter != Builders<T>.Filter.Empty)
                    {
                        _filter = Builders<T>.Filter.And(_filter, parsedFilter);
                    }
                }
            }

            // ── 2. GROUP / HEADERFILTER ───────────────────────────────
            if (options.Group != null && options.Group.Length > 0)
            {
                return await ExecuteGroupQueryAsync(options, ct);
            }

            // ── 3. SORT İŞLEME ───────────────────────────────────────
            if (options.Sort != null && options.Sort.Length > 0 && options.ServerSideSorting)
            {
                var parsedSort = DevExtremeMongoAdapter.ParseSort<T>(options.Sort);
                if (parsedSort != null)
                {
                    // Grid kullanıcısının sort'u öncelikli — mevcut sort'u override et
                    _sort = parsedSort;
                }
            }

            // ── 4. PAGING İŞLEME ─────────────────────────────────────
            if (options.ServerSidePaging)
            {
                _skip = options.Skip;
                if (options.Take > 0) _take = options.Take;
            }

            // ── 5. VERİ ÇEKME ─────────────────────────────────────────
            long totalCount = -1;
            List<T> data;

            if (options.RequireTotalCount)
            {
                // Reverse lookup'ları bir kez çalıştır
                if (_reverseLookups.Count > 0)
                {
                    foreach (var reverseLookup in _reverseLookups)
                    {
                        await reverseLookup(ct);
                    }
                }

                // Count (skip/take uygulanmadan — toplam kayıt sayısı)
                var countTask = _collection.CountDocumentsAsync(_filter, cancellationToken: ct);

                // Data çekimi — Lookup varsa aggregation, yoksa find
                List<T> rawData;
                if (_lookupStages.Count > 0)
                {
                    rawData = await ExecuteAggregationAsync(ct);
                }
                else
                {
                    var findOptions = new FindOptions<T>();
                    if (_sort != null) findOptions.Sort = _sort;
                    if (_skip.HasValue) findOptions.Skip = _skip;
                    if (_take.HasValue) findOptions.Limit = _take;
                    if (_projection != null) findOptions.Projection = _projection;

                    var sw = Stopwatch.StartNew();
                    var cursor = await _collection.FindAsync(_filter, findOptions, ct);
                    rawData = await cursor.ToListAsync(ct);
                    sw.Stop();
                    CheckAndHealIndexes(sw, _collection, _filter);
                }

                // Cross-server lookups (memory join)
                if (_crossServerLookups.Count > 0 && rawData.Count > 0)
                {
                    foreach (var crossServerAction in _crossServerLookups)
                    {
                        await crossServerAction(rawData, ct);
                    }
                }

                totalCount = await countTask;
                data = rawData;
            }
            else
            {
                data = await ToListAsync(ct);
            }

            // ── 6. CLIENT-SIDE POST-PROCESSING ───────────────────────
            // Eğer bazı operasyonlar client-side ise bellekte uygula
            data = ApplyClientSideOperations(data, options);

            return new ServerSideLoadResult
            {
                Data = data,
                TotalCount = totalCount
            };
        }

        /// <summary>
        /// Client-side olarak işaretlenmiş operasyonları bellekte uygular.
        /// Server-side aktifse bu metot hiçbir şey yapmaz (pass-through).
        /// </summary>
        private List<T> ApplyClientSideOperations(List<T> data, ServerSideLoadOptions options)
        {
            if (data == null || data.Count == 0) return data;

            // Client-side sorting
            if (!options.ServerSideSorting && options.Sort != null && options.Sort.Length > 0)
            {
                data = ApplyClientSideSort(data, options.Sort);
            }

            // Client-side paging
            if (!options.ServerSidePaging)
            {
                if (options.Skip > 0)
                    data = data.Skip(options.Skip).ToList();
                if (options.Take > 0)
                    data = data.Take(options.Take).ToList();
            }

            return data;
        }

        /// <summary>
        /// Bellekte sıralama uygular. Reflection ile property değerine erişir.
        /// </summary>
        private List<T> ApplyClientSideSort(List<T> data, ServerSideSortInfo[] sortInfos)
        {
            if (sortInfos == null || sortInfos.Length == 0) return data;

            IOrderedEnumerable<T> ordered = null;

            for (int i = 0; i < sortInfos.Length; i++)
            {
                var info = sortInfos[i];
                if (info == null || string.IsNullOrWhiteSpace(info.Selector)) continue;

                // Reflection sonucu cache'lenir — aynı T + Selector için tekrar aranmaz
                var cacheKey = $"{typeof(T).FullName}:{info.Selector}";
                var propInfo = _propertyCache.GetOrAdd(cacheKey, _ =>
                    typeof(T).GetProperty(info.Selector,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase));

                if (propInfo == null) continue;

                if (i == 0)
                {
                    ordered = info.Desc
                        ? data.OrderByDescending(x => propInfo.GetValue(x))
                        : data.OrderBy(x => propInfo.GetValue(x));
                }
                else if (ordered != null)
                {
                    ordered = info.Desc
                        ? ordered.ThenByDescending(x => propInfo.GetValue(x))
                        : ordered.ThenBy(x => propInfo.GetValue(x));
                }
            }

            return ordered?.ToList() ?? data;
        }

        /// <summary>
        /// HeaderFilter için grup (distinct) sorgusu çalıştırır.
        /// MongoDB $group aggregation ile benzersiz değerleri çeker.
        /// </summary>
        private async Task<ServerSideLoadResult> ExecuteGroupQueryAsync(ServerSideLoadOptions options, CancellationToken ct)
        {
            var groupField = options.Group[0].Selector;
            if (string.IsNullOrWhiteSpace(groupField))
            {
                return new ServerSideLoadResult { Data = new List<object>(), GroupCount = 0 };
            }

            var mongoFieldName = DevExtremeMongoAdapter.ResolveMongoFieldName<T>(groupField);

            // Aggregation pipeline: $match → $group → $sort
            var pipeline = new List<BsonDocument>();

            // Mevcut filtreleri uygula
            if (_filter != Builders<T>.Filter.Empty)
            {
                var serializerRegistry = BsonSerializer.SerializerRegistry;
                var documentSerializer = serializerRegistry.GetSerializer<T>();
                pipeline.Add(new BsonDocument("$match",
                    _filter.Render(new RenderArgs<T>(documentSerializer, serializerRegistry))));
            }

            // $group: benzersiz değerleri topla
            pipeline.Add(new BsonDocument("$group", new BsonDocument
            {
                { "_id", "$" + mongoFieldName }
            }));

            // $sort: alfabetik sırala
            pipeline.Add(new BsonDocument("$sort", new BsonDocument("_id", 1)));

            var sw = Stopwatch.StartNew();
            var cursor = await _collection.AggregateAsync<BsonDocument>(
                PipelineDefinition<T, BsonDocument>.Create(pipeline), cancellationToken: ct);
            var results = await cursor.ToListAsync(ct);
            sw.Stop();
            CheckAndHealIndexes(sw, _collection, _filter);

            // DevExtreme headerFilter formatı: [{key: "value1"}, {key: "value2"}, ...]
            var groupData = results
                .Select(doc =>
                {
                    var idValue = doc["_id"];
                    object key = idValue.IsBsonNull ? null : BsonTypeMapper.MapToDotNetValue(idValue);
                    return new { key };
                })
                .ToList<object>();

            return new ServerSideLoadResult
            {
                Data = groupData,
                GroupCount = options.RequireGroupCount ? groupData.Count : -1,
                TotalCount = -1
            };
        }

        private async Task<List<T>> ExecuteAggregationAsync(CancellationToken ct)
        {
            var pipeline = new List<BsonDocument>();
            
            if (_filter != Builders<T>.Filter.Empty)
            {
                var serializerRegistry = BsonSerializer.SerializerRegistry;
                var documentSerializer = serializerRegistry.GetSerializer<T>();
                pipeline.Add(new BsonDocument("$match", _filter.Render(new RenderArgs<T>(documentSerializer, serializerRegistry))));
            }
            
            pipeline.AddRange(_lookupStages);
            
            if (_sort != null)
            {
                var serializerRegistry = BsonSerializer.SerializerRegistry;
                var documentSerializer = serializerRegistry.GetSerializer<T>();
                pipeline.Add(new BsonDocument("$sort", _sort.Render(new RenderArgs<T>(documentSerializer, serializerRegistry))));
            }
            
            if (_skip.HasValue) pipeline.Add(new BsonDocument("$skip", _skip.Value));
            if (_take.HasValue) pipeline.Add(new BsonDocument("$limit", _take.Value));

            var sw = Stopwatch.StartNew();
            var cursor = await _collection.AggregateAsync<T>(PipelineDefinition<T, T>.Create(pipeline), cancellationToken: ct);
            var results = await cursor.ToListAsync(ct);
            sw.Stop();
            CheckAndHealIndexes(sw, _collection, _filter);
            return results;
        }

        private static string GetMongoFieldName<TSource, TReturn>(Expression<Func<TSource, TReturn>> expression)
        {
            var propInfo = GetPropertyInfo(expression);
            
            var bsonElementAttr = propInfo.GetCustomAttribute<BsonElementAttribute>();
            if (bsonElementAttr != null && !string.IsNullOrEmpty(bsonElementAttr.ElementName))
            {
                return bsonElementAttr.ElementName;
            }

            var bsonIdAttr = propInfo.GetCustomAttribute<BsonIdAttribute>();
            if (bsonIdAttr != null || propInfo.Name == "Id")
            {
                return "_id";
            }

            if (BsonClassMap.IsClassMapRegistered(typeof(TSource)))
            {
                var classMap = BsonClassMap.LookupClassMap(typeof(TSource));
                var memberMap = classMap.GetMemberMap(propInfo.Name);
                if (memberMap != null) return memberMap.ElementName;
            }

            return propInfo.Name;
        }

        private static PropertyInfo GetPropertyInfo<TSource, TReturn>(Expression<Func<TSource, TReturn>> expression)
        {
            MemberExpression? member = expression.Body as MemberExpression;

            if (member == null && expression.Body is UnaryExpression unary)
            {
                member = unary.Operand as MemberExpression;
            }

            if (member == null)
                throw new ArgumentException("Expression bir üye erişimi (member expression) olmalıdır.");

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException("Expression bir özellik erişimi (property access) olmalıdır.");

            return propInfo;
        }

        private static string GetCollectionName<TEntity>() where TEntity : MongoDbEntity
        {
            var attr = typeof(TEntity).GetCustomAttribute<BsonCollectionAttribute>();
            return attr?.CollectionName ?? typeof(TEntity).Name;
        }

        private void CheckAndHealIndexes<THeal>(Stopwatch sw, IMongoCollection<THeal> collection, FilterDefinition<THeal> filter, string? extraField = null) where THeal : MongoDbEntity
        {
            if (sw.Elapsed.TotalSeconds >= AUTO_HEAL_THRESHOLD_SECONDS)
            {
                // Discard ile explicit fire-and-forget — unobserved task exception'ı önler
                _ = Task.Run(async () => 
                {
                    try 
                    {
                        var serializerRegistry = BsonSerializer.SerializerRegistry;
                        var documentSerializer = serializerRegistry.GetSerializer<THeal>();
                        var rendered = filter.Render(new RenderArgs<THeal>(documentSerializer, serializerRegistry));
                        
                        var fields = new HashSet<string>();
                        
                        if (extraField != null)
                        {
                            fields.Add(extraField);
                        }

                        var extracted = ExtractFields(rendered);
                        foreach (var f in extracted)
                        {
                            fields.Add(f);
                        }

                        if (fields.Count > 0)
                        {
                            var indexKeysBuilder = Builders<THeal>.IndexKeys;
                            IndexKeysDefinition<THeal>? indexDefinition = null;

                            foreach (var field in fields)
                            {
                                if (indexDefinition == null)
                                    indexDefinition = indexKeysBuilder.Ascending(field);
                                else
                                    indexDefinition = indexDefinition.Ascending(field);
                            }

                            var indexName = $"AUTO_HEAL_idx_{string.Join("_", fields)}";
                            
                            // MongoDB index name limiti: max 127 byte
                            if (indexName.Length > 120)
                            {
                                indexName = indexName.Substring(0, 120);
                            }

                            var createIndexOptions = new CreateIndexOptions { Name = indexName, Background = true };
                            var indexModel = new CreateIndexModel<THeal>(indexDefinition, createIndexOptions);
                            
                            await collection.Indexes.CreateOneAsync(indexModel);

                            Debug.WriteLine(
                                $"[AUTO-HEAL] Index oluşturuldu: {collection.CollectionNamespace.CollectionName}.{indexName} " +
                                $"(Süre: {sw.Elapsed.TotalSeconds:F1}s)");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Auto-heal hatası asıl uygulamayı durdurmamalı — loglayıp devam
                        Debug.WriteLine(
                            $"[AUTO-HEAL] Index oluşturma hatası ({typeof(THeal).Name}): {ex.Message}");
                    }
                });
            }
        }

        /// <summary>
        /// BsonDocument'ten filtrelenen alan adlarını recursive olarak çıkarır.
        /// Auto-heal index oluşturma için kullanılır.
        /// </summary>
        private HashSet<string> ExtractFields(BsonValue bson)
        {
            var fields = new HashSet<string>();
            if (bson.IsBsonDocument)
            {
                foreach (var element in bson.AsBsonDocument)
                {
                    if (element.Name.StartsWith("$"))
                    {
                        if (element.Value.IsBsonArray)
                        {
                            foreach (var item in element.Value.AsBsonArray)
                            {
                                foreach (var sf in ExtractFields(item)) fields.Add(sf);
                            }
                        }
                        else
                        {
                            foreach (var sf in ExtractFields(element.Value)) fields.Add(sf);
                        }
                    }
                    else
                    {
                        fields.Add(element.Name);
                    }
                }
            }
            return fields;
        }
    }
}
