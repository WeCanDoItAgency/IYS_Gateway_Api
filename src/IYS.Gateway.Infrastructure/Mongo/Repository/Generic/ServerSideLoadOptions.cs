using System.Collections;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Mongo.Repository.Generic
{
    /// <summary>
    /// DevExtreme grid'den gelen server-side yükleme parametrelerini taşıyan DTO.
    /// DevExtreme paketine bağımlılık YOKTUR — raw parametreler kullanılır.
    /// 
    /// Varsayılan davranış: Tüm operasyonlar (filter, sort, paging) MongoDB'de çalışır.
    /// İstenirse property bazlı veya toplu olarak client-side'a düşürülebilir.
    /// </summary>
    public class ServerSideLoadOptions
    {
        // ═══════════════════════════════════════════════════════════════
        // GRID PARAMETRELERİ (DevExtreme'den gelen raw değerler)
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// DevExtreme JSON filter array. Örnek: ["Status","=","APPROVED"]
        /// veya nested: [["Status","=","APPROVED"],"and",["FirmId","&gt;",0]]
        /// </summary>
        public IList Filter { get; set; }

        /// <summary>
        /// Sıralama bilgileri. Örnek: [{Selector:"ConsentDate", Desc:true}]
        /// </summary>
        public ServerSideSortInfo[] Sort { get; set; }

        /// <summary>
        /// Gruplama bilgileri (headerFilter distinct değerleri için).
        /// </summary>
        public ServerSideGroupInfo[] Group { get; set; }

        /// <summary>Atlanacak kayıt sayısı (paging).</summary>
        public int Skip { get; set; }

        /// <summary>Çekilecek kayıt sayısı (paging). Varsayılan: 20.</summary>
        public int Take { get; set; } = 20;

        /// <summary>Toplam kayıt sayısı gerekli mi? Varsayılan: true.</summary>
        public bool RequireTotalCount { get; set; } = true;

        /// <summary>Grup sayısı gerekli mi? (headerFilter için)</summary>
        public bool RequireGroupCount { get; set; }

        // ═══════════════════════════════════════════════════════════════
        // SERVER-SIDE / CLIENT-SIDE OPSİYONLARI
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// true (varsayılan): Filtreleme MongoDB sorgusunda çalışır.
        /// false: Filtreleme bellekte (ToListAsync sonrası) uygulanır.
        /// </summary>
        public bool ServerSideFiltering { get; set; } = true;

        /// <summary>
        /// true (varsayılan): Sıralama MongoDB sorgusunda çalışır.
        /// false: Sıralama bellekte uygulanır.
        /// </summary>
        public bool ServerSideSorting { get; set; } = true;

        /// <summary>
        /// true (varsayılan): Sayfalama MongoDB Skip/Take ile çalışır.
        /// false: Tüm veri çekilir, bellekte sayfalanır.
        /// </summary>
        public bool ServerSidePaging { get; set; } = true;

        /// <summary>
        /// Belirli property'lerin server-side filtrelemeden hariç tutulmasını sağlar.
        /// Bu listedeki alanlar için gelen filtreler MongoDB'ye gönderilmez, bellekte uygulanır.
        /// Örnek kullanım: Hesaplanmış (computed) veya MongoDB'de olmayan alanlar.
        /// </summary>
        public HashSet<string> ClientSideProperties { get; set; }
    }

    /// <summary>
    /// Sıralama bilgisi — DevExtreme SortingInfo'nun paket-bağımsız karşılığı.
    /// </summary>
    public class ServerSideSortInfo
    {
        /// <summary>Sıralama yapılacak alan adı (C# property name).</summary>
        public string Selector { get; set; }

        /// <summary>Azalan sıralama mı?</summary>
        public bool Desc { get; set; }
    }

    /// <summary>
    /// Gruplama bilgisi — DevExtreme GroupingInfo'nun paket-bağımsız karşılığı.
    /// </summary>
    public class ServerSideGroupInfo
    {
        /// <summary>Gruplanacak alan adı (C# property name).</summary>
        public string Selector { get; set; }
    }

    /// <summary>
    /// Server-side yükleme sonucu. DevExtreme LoadResult formatıyla uyumlu JSON üretir.
    /// </summary>
    public class ServerSideLoadResult
    {
        /// <summary>Veri listesi (List&lt;T&gt; veya group data).</summary>
        public object Data { get; set; }

        /// <summary>Toplam kayıt sayısı. -1 ise hesaplanmadı.</summary>
        public long TotalCount { get; set; } = -1;

        /// <summary>Grup sayısı (headerFilter için). -1 ise hesaplanmadı.</summary>
        public int GroupCount { get; set; } = -1;
    }
}
