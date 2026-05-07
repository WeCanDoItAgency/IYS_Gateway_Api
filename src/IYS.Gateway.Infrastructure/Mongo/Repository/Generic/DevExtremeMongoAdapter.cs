using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using IYS.Gateway.Infrastructure.Mongo.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace IYS.Gateway.Infrastructure.Mongo.Repository.Generic
{
    /// <summary>
    /// DevExtreme grid'den gelen filter/sort/group parametrelerini
    /// MongoDB FilterDefinition / SortDefinition'a çeviren yardımcı sınıf.
    /// DevExtreme paketine BAĞIMLILIK YOKTUR — raw IList/array ile çalışır.
    /// 
    /// Desteklenen operatörler: =, &lt;&gt;, &gt;, &gt;=, &lt;, &lt;=, contains, notcontains, startswith, endswith
    /// Desteklenen mantıksal operatörler: and, or, ! (negation)
    /// 
    /// Kullanım:
    /// <code>
    /// var filter = DevExtremeMongoAdapter.ParseFilter&lt;MyEntity&gt;(rawFilterArray);
    /// var sort = DevExtremeMongoAdapter.ParseSort&lt;MyEntity&gt;(sortInfoArray);
    /// </code>
    /// </summary>
    public static class DevExtremeMongoAdapter
    {
        /// <summary>
        /// Desteklenen DevExtreme karşılaştırma operatörleri.
        /// Tanımlanmayan operatörler sessizce yok sayılır ve boş filtre döner.
        /// </summary>
        private static readonly HashSet<string> SupportedOperators = new(StringComparer.OrdinalIgnoreCase)
        {
            "=", "<>", "!=", ">", ">=", "<", "<=",
            "contains", "notcontains", "startswith", "endswith"
        };

        /// <summary>
        /// Desteklenen DevExtreme mantıksal operatörler.
        /// </summary>
        private static readonly HashSet<string> SupportedLogicalOperators = new(StringComparer.OrdinalIgnoreCase)
        {
            "and", "or"
        };

        /// <summary>
        /// Reflection sonuçlarını cache'ler. Key: "TypeFullName:PropertyName" → Value: PropertyInfo.
        /// Her filter parse çağrısında tekrarlanan GetProperty() maliyetini önler.
        /// </summary>
        private static readonly ConcurrentDictionary<string, PropertyInfo?> _propInfoCache = new();

        /// <summary>
        /// Çözümlenmiş MongoDB field adlarını cache'ler. Key: "TypeFullName:PropertyName" → Value: MongoDB field adı.
        /// </summary>
        private static readonly ConcurrentDictionary<string, string> _fieldNameCache = new();

        // ═══════════════════════════════════════════════════════════════
        // FILTER PARSE — DevExtreme JSON filter → FilterDefinition<T>
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// DevExtreme filter array'ini MongoDB FilterDefinition'a çevirir.
        /// Desteklenen formatlar:
        ///   Tekli:   ["Status", "=", "APPROVED"]
        ///   Çoklu:   [["Status","=","APPROVED"], "and", ["FirmId",">",0]]
        ///   Nested:  [["Status","=","A"], "or", [["Type","=","X"], "and", ["Phase",">",2]]]
        ///   Negated: ["!", ["Status","=","APPROVED"]]
        /// </summary>
        /// <typeparam name="T">Hedef MongoDB entity tipi.</typeparam>
        /// <param name="filter">DevExtreme'den gelen ham filtre array'i.</param>
        /// <returns>MongoDB FilterDefinition. Geçersiz filtre durumunda Empty döner.</returns>
        /// <exception cref="DevExtremeFilterParseException">Filtre yapısı tamamen bozuksa fırlatılır.</exception>
        public static FilterDefinition<T> ParseFilter<T>(IList filter) where T : MongoDbEntity
        {
            if (filter == null || filter.Count == 0)
                return Builders<T>.Filter.Empty;

            try
            {
                return ParseFilterInternal<T>(filter, depth: 0);
            }
            catch (DevExtremeFilterParseException)
            {
                throw; // Kendi hatamız — aynen fırlat
            }
            catch (Exception ex)
            {
                throw new DevExtremeFilterParseException(
                    $"DevExtreme filter parse edilirken beklenmeyen hata. Filter eleman sayısı: {filter.Count}",
                    ex);
            }
        }

        /// <summary>
        /// Recursive filter parser. Derinlik sınırı: 10 seviye.
        /// </summary>
        private static FilterDefinition<T> ParseFilterInternal<T>(IList filter, int depth) where T : MongoDbEntity
        {
            // Sonsuz döngü / stack overflow koruması
            if (depth > 10)
                throw new DevExtremeFilterParseException(
                    "Filtre derinliği 10 seviyeyi aştı. Olası döngüsel yapı tespit edildi.");

            if (filter == null || filter.Count == 0)
                return Builders<T>.Filter.Empty;

            // Negation: ["!", condition]
            if (filter.Count == 2 && filter[0] is string bang && bang == "!")
            {
                if (filter[1] is IList innerList)
                    return Builders<T>.Filter.Not(ParseFilterInternal<T>(innerList, depth + 1));

                // "!" operatöründen sonra geçersiz yapı — sessizce boş filtre dön
                return Builders<T>.Filter.Empty;
            }

            // Simple condition: ["fieldName", "operator", value]
            if (IsSimpleCondition(filter))
            {
                var fieldName = filter[0]?.ToString();
                var op = filter[1]?.ToString();
                var value = filter.Count > 2 ? filter[2] : null;
                return CreateFieldFilter<T>(fieldName, op, value);
            }

            // Combined conditions: [cond1, "and", cond2, "and", cond3, ...]
            return ParseCombinedFilter<T>(filter, depth);
        }

        /// <summary>
        /// Tekli filtre mi kontrol eder.
        /// Tekli: ilk eleman string (alan adı), ikinci eleman operatör string.
        /// Çoklu: ilk eleman IList (alt filtre).
        /// </summary>
        private static bool IsSimpleCondition(IList filter)
        {
            if (filter.Count < 2) return false;

            // İlk eleman string (alan adı) ve IList değilse → tekli filtre
            return filter[0] is string && !(filter[0] is IList);
        }

        /// <summary>
        /// Birden fazla koşulun "and"/"or" ile birleştirildiği filtreyi parse eder.
        /// Format: [cond1, "and", cond2, "or", cond3, ...]
        /// Çift indexler: koşullar, tek indexler: mantıksal operatörler.
        /// </summary>
        private static FilterDefinition<T> ParseCombinedFilter<T>(IList filter, int depth) where T : MongoDbEntity
        {
            var conditions = new List<FilterDefinition<T>>();
            var logicalOp = "and";

            for (int i = 0; i < filter.Count; i++)
            {
                if (i % 2 == 0)
                {
                    // Koşul (çift index)
                    if (filter[i] is IList subFilter)
                    {
                        conditions.Add(ParseFilterInternal<T>(subFilter, depth + 1));
                    }
                    else
                    {
                        // Beklenen IList ama farklı tip geldi — defensif: atla
                    }
                }
                else
                {
                    // Mantıksal operatör (tek index)
                    if (filter[i] is string op && SupportedLogicalOperators.Contains(op))
                    {
                        logicalOp = op.ToLowerInvariant();
                    }
                }
            }

            if (conditions.Count == 0) return Builders<T>.Filter.Empty;
            if (conditions.Count == 1) return conditions[0];

            return logicalOp == "or"
                ? Builders<T>.Filter.Or(conditions)
                : Builders<T>.Filter.And(conditions);
        }

        /// <summary>
        /// Tekli alan filtresi oluşturur. Geçersiz alan/operatör durumunda boş filtre döner.
        /// </summary>
        private static FilterDefinition<T> CreateFieldFilter<T>(string propertyName, string op, object value) where T : MongoDbEntity
        {
            if (string.IsNullOrWhiteSpace(propertyName) || string.IsNullOrWhiteSpace(op))
                return Builders<T>.Filter.Empty;

            // Desteklenmeyen operatör kontrolü
            if (!SupportedOperators.Contains(op))
                return Builders<T>.Filter.Empty;

            var mongoFieldName = ResolveMongoFieldName<T>(propertyName);
            var bsonValue = ConvertToBsonValue<T>(propertyName, value);

            switch (op.ToLowerInvariant())
            {
                case "=":
                    if (bsonValue == BsonNull.Value || bsonValue.IsBsonNull)
                        return new BsonDocumentFilterDefinition<T>(
                            new BsonDocument(mongoFieldName, BsonNull.Value));
                    return new BsonDocumentFilterDefinition<T>(
                        new BsonDocument(mongoFieldName, bsonValue));

                case "<>":
                case "!=":
                    return new BsonDocumentFilterDefinition<T>(
                        new BsonDocument(mongoFieldName, new BsonDocument("$ne", bsonValue)));

                case ">":
                    return new BsonDocumentFilterDefinition<T>(
                        new BsonDocument(mongoFieldName, new BsonDocument("$gt", bsonValue)));

                case ">=":
                    return new BsonDocumentFilterDefinition<T>(
                        new BsonDocument(mongoFieldName, new BsonDocument("$gte", bsonValue)));

                case "<":
                    return new BsonDocumentFilterDefinition<T>(
                        new BsonDocument(mongoFieldName, new BsonDocument("$lt", bsonValue)));

                case "<=":
                    return new BsonDocumentFilterDefinition<T>(
                        new BsonDocument(mongoFieldName, new BsonDocument("$lte", bsonValue)));

                case "contains":
                    return CreateRegexFilter<T>(mongoFieldName, Regex.Escape(value?.ToString() ?? ""), "i");

                case "notcontains":
                    return Builders<T>.Filter.Not(
                        CreateRegexFilter<T>(mongoFieldName, Regex.Escape(value?.ToString() ?? ""), "i"));

                case "startswith":
                    return CreateRegexFilter<T>(mongoFieldName, "^" + Regex.Escape(value?.ToString() ?? ""), "i");

                case "endswith":
                    return CreateRegexFilter<T>(mongoFieldName, Regex.Escape(value?.ToString() ?? "") + "$", "i");

                default:
                    return Builders<T>.Filter.Empty;
            }
        }

        /// <summary>Regex tabanlı filtre oluşturur (contains/startswith/endswith).</summary>
        private static FilterDefinition<T> CreateRegexFilter<T>(string mongoFieldName, string pattern, string options)
        {
            return new BsonDocumentFilterDefinition<T>(
                new BsonDocument(mongoFieldName,
                    new BsonDocument("$regex", new BsonRegularExpression(pattern, options))));
        }

        // ═══════════════════════════════════════════════════════════════
        // SORT PARSE — ServerSideSortInfo[] → SortDefinition<T>
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Sort bilgilerini MongoDB SortDefinition'a çevirir.
        /// Boş Selector'a sahip elemanlar sessizce atlanır.
        /// </summary>
        /// <typeparam name="T">Hedef MongoDB entity tipi.</typeparam>
        /// <param name="sortInfos">Sıralama bilgileri dizisi.</param>
        /// <returns>MongoDB SortDefinition. Geçerli sort yoksa null döner.</returns>
        public static SortDefinition<T> ParseSort<T>(ServerSideSortInfo[] sortInfos) where T : MongoDbEntity
        {
            if (sortInfos == null || sortInfos.Length == 0)
                return null;

            SortDefinition<T> sort = null;

            foreach (var info in sortInfos)
            {
                if (info == null || string.IsNullOrWhiteSpace(info.Selector))
                    continue;

                var mongoFieldName = ResolveMongoFieldName<T>(info.Selector);
                var fieldSort = info.Desc
                    ? Builders<T>.Sort.Descending(mongoFieldName)
                    : Builders<T>.Sort.Ascending(mongoFieldName);

                sort = sort == null ? fieldSort : Builders<T>.Sort.Combine(sort, fieldSort);
            }

            return sort;
        }

        // ═══════════════════════════════════════════════════════════════
        // PROPERTY → MONGODB FIELD NAME RESOLUTION
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// C# property adını MongoDB field adına çevirir.
        /// Çözümleme önceliği: BsonId → BsonElement → BsonClassMap → Property Name.
        /// Property bulunamazsa orijinal isim aynen döner (case-insensitive arama yapılır).
        /// </summary>
        /// <typeparam name="T">Hedef MongoDB entity tipi.</typeparam>
        /// <param name="propertyName">C# property adı (ör: "ConsentDate").</param>
        /// <returns>MongoDB field adı (ör: "_id", "consentDate", veya "ConsentDate").</returns>
        public static string ResolveMongoFieldName<T>(string propertyName) where T : MongoDbEntity
        {
            if (string.IsNullOrWhiteSpace(propertyName)) return propertyName;

            // Cache kontrolü — aynı tip + property için tekrar reflection yapılmaz
            var cacheKey = $"{typeof(T).FullName}:{propertyName}";
            if (_fieldNameCache.TryGetValue(cacheKey, out var cached))
                return cached;

            var propInfo = GetCachedPropertyInfo<T>(propertyName);

            if (propInfo == null)
            {
                _fieldNameCache.TryAdd(cacheKey, propertyName);
                return propertyName;
            }

            string resolved;

            // BsonId kontrolü
            var bsonIdAttr = propInfo.GetCustomAttribute<BsonIdAttribute>();
            if (bsonIdAttr != null || propInfo.Name == "Id")
            {
                resolved = "_id";
            }
            // BsonElement kontrolü
            else if (propInfo.GetCustomAttribute<BsonElementAttribute>() is { } bsonElementAttr
                     && !string.IsNullOrEmpty(bsonElementAttr.ElementName))
            {
                resolved = bsonElementAttr.ElementName;
            }
            else
            {
                resolved = propInfo.Name;

                // BsonClassMap kontrolü
                try
                {
                    if (BsonClassMap.IsClassMapRegistered(typeof(T)))
                    {
                        var classMap = BsonClassMap.LookupClassMap(typeof(T));
                        var memberMap = classMap.GetMemberMap(propInfo.Name);
                        if (memberMap != null) resolved = memberMap.ElementName;
                    }
                }
                catch
                {
                    // BsonClassMap erişim hatası — property adını aynen kullan
                }
            }

            _fieldNameCache.TryAdd(cacheKey, resolved);
            return resolved;
        }

        /// <summary>
        /// Cache'li PropertyInfo erişimi. Aynı Type + propertyName için tek reflection yapılır.
        /// </summary>
        private static PropertyInfo? GetCachedPropertyInfo<T>(string propertyName) where T : MongoDbEntity
        {
            var cacheKey = $"{typeof(T).FullName}:{propertyName}";
            return _propInfoCache.GetOrAdd(cacheKey, _ =>
                typeof(T).GetProperty(propertyName,
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase));
        }

        // ═══════════════════════════════════════════════════════════════
        // VALUE TYPE COERCION — JSON değerini MongoDB BsonValue'ya çevirir
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// DevExtreme'den gelen ham değeri, T entity'sindeki property tipine
        /// bakarak doğru BsonValue tipine dönüştürür.
        /// Dönüşüm başarısız olursa <see cref="BsonValue.Create"/> fallback kullanılır.
        /// </summary>
        private static BsonValue ConvertToBsonValue<T>(string propertyName, object value) where T : MongoDbEntity
        {
            if (value == null) return BsonNull.Value;

            var propInfo = GetCachedPropertyInfo<T>(propertyName);

            if (propInfo == null)
                return BsonValue.Create(value);

            var targetType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

            try
            {
                if (targetType == typeof(DateTime))
                {
                    if (value is DateTime dt)
                        return new BsonDateTime(dt);
                    if (DateTime.TryParse(value.ToString(), CultureInfo.InvariantCulture,
                            DateTimeStyles.RoundtripKind, out var parsed))
                        return new BsonDateTime(parsed);
                }

                if (targetType == typeof(int))
                    return new BsonInt32(Convert.ToInt32(value));

                if (targetType == typeof(long))
                    return new BsonInt64(Convert.ToInt64(value));

                if (targetType == typeof(double))
                    return new BsonDouble(Convert.ToDouble(value));

                if (targetType == typeof(decimal))
                    return new BsonDecimal128(Convert.ToDecimal(value));

                if (targetType == typeof(float))
                    return new BsonDouble(Convert.ToDouble(value));

                if (targetType == typeof(bool))
                    return new BsonBoolean(Convert.ToBoolean(value));

                if (targetType == typeof(string))
                    return new BsonString(value.ToString());

                if (targetType == typeof(Guid))
                    return new BsonString(value.ToString());
            }
            catch
            {
                // Dönüşüm başarısız — fallback'e devam
            }

            return BsonValue.Create(value);
        }

        // ═══════════════════════════════════════════════════════════════
        // FILTER SPLIT — Server-side / Client-side ayrıştırma
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// DevExtreme filter array'ini server-side ve client-side olarak ikiye ayırır.
        /// <paramref name="clientSideProperties"/> içindeki alanlarla ilgili filtreler
        /// client-side listesine, diğerleri server-side FilterDefinition'a eklenir.
        /// 
        /// Kullanım:
        /// <code>
        /// var result = DevExtremeMongoAdapter.SplitFilter&lt;MyEntity&gt;(filter, new HashSet&lt;string&gt; { "ComputedField" });
        /// // result.ServerSideFilter → MongoDB'ye gönderilir
        /// // result.HasClientSideFilters → bellekte uygulanacak filtre var mı?
        /// </code>
        /// </summary>
        /// <typeparam name="T">Hedef MongoDB entity tipi.</typeparam>
        /// <param name="filter">DevExtreme'den gelen ham filtre array'i.</param>
        /// <param name="clientSideProperties">Client-side'da işlenecek property isimleri.</param>
        /// <returns>Server-side ve client-side filtreleri içeren sonuç.</returns>
        public static FilterSplitResult<T> SplitFilter<T>(IList filter, HashSet<string> clientSideProperties) where T : MongoDbEntity
        {
            var result = new FilterSplitResult<T>();

            if (filter == null || filter.Count == 0 || clientSideProperties == null || clientSideProperties.Count == 0)
            {
                // Client-side property yoksa hepsini server-side olarak parse et
                result.ServerSideFilter = ParseFilter<T>(filter);
                return result;
            }

            // Tekli filtre kontrolü
            if (IsSimpleCondition(filter))
            {
                var fieldName = filter[0]?.ToString();
                if (fieldName != null && clientSideProperties.Contains(fieldName))
                {
                    result.HasClientSideFilters = true;
                    result.ClientSideFilterRaw = filter;
                }
                else
                {
                    result.ServerSideFilter = ParseFilter<T>(filter);
                }
                return result;
            }

            // Çoklu filtre: server-side olanları ayır, client-side olanları işaretle
            var serverConditions = new List<FilterDefinition<T>>();
            var hasClientSide = false;

            for (int i = 0; i < filter.Count; i++)
            {
                if (i % 2 == 0 && filter[i] is IList subFilter)
                {
                    // Bu alt filtre client-side property mi kontrol et
                    if (IsSimpleCondition(subFilter) && subFilter[0] is string fieldName &&
                        clientSideProperties.Contains(fieldName))
                    {
                        hasClientSide = true;
                    }
                    else
                    {
                        serverConditions.Add(ParseFilter<T>(subFilter));
                    }
                }
            }

            result.HasClientSideFilters = hasClientSide;

            if (serverConditions.Count == 1)
                result.ServerSideFilter = serverConditions[0];
            else if (serverConditions.Count > 1)
                result.ServerSideFilter = Builders<T>.Filter.And(serverConditions);

            return result;
        }
    }

    /// <summary>
    /// Server-side / Client-side filtre ayrıştırma sonucu.
    /// </summary>
    /// <typeparam name="T">Hedef MongoDB entity tipi.</typeparam>
    public class FilterSplitResult<T> where T : MongoDbEntity
    {
        /// <summary>MongoDB'ye gönderilecek server-side filtre.</summary>
        public FilterDefinition<T> ServerSideFilter { get; set; } = Builders<T>.Filter.Empty;

        /// <summary>Client-side'da işlenecek filtre var mı?</summary>
        public bool HasClientSideFilters { get; set; }

        /// <summary>Client-side filtrenin ham hali (bellekte uygulanacak).</summary>
        public IList ClientSideFilterRaw { get; set; }
    }

    // ═══════════════════════════════════════════════════════════════
    // CUSTOM EXCEPTION
    // ═══════════════════════════════════════════════════════════════

    /// <summary>
    /// DevExtreme filter parse işlemi sırasında oluşan hataları temsil eder.
    /// Yapısal sorunlar (sonsuz döngü, bozuk format) için fırlatılır.
    /// Tek alan hataları sessizce boş filtre döner — bu exception fırlatılmaz.
    /// </summary>
    public class DevExtremeFilterParseException : InvalidOperationException
    {
        /// <summary>Hata mesajı ile yeni instance oluşturur.</summary>
        public DevExtremeFilterParseException(string message) : base(message) { }

        /// <summary>Hata mesajı ve inner exception ile yeni instance oluşturur.</summary>
        public DevExtremeFilterParseException(string message, Exception innerException) : base(message, innerException) { }
    }
}
