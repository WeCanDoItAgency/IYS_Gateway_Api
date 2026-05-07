using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Mongo.Repository.Generic
{
    /// <summary>
    /// Sayfalanmış sorgu sonucunu taşıyan immutable DTO.
    /// <see cref="IGenericMongoQueryBuilder{T}.ToPagedListAsync"/> tarafından döner.
    /// </summary>
    /// <typeparam name="T">Entity tipi.</typeparam>
    public class PagedResult<T>
    {
        /// <summary>Filtreye uyan toplam kayıt sayısı (Skip/Take uygulanmadan önce).</summary>
        public long TotalCount { get; }

        /// <summary>Bu sayfadaki kayıtlar. Boş olabilir ama asla null değildir.</summary>
        public List<T> Data { get; }

        /// <summary>
        /// Yeni bir sayfalanmış sonuç oluşturur.
        /// </summary>
        /// <param name="totalCount">Toplam kayıt sayısı.</param>
        /// <param name="data">Bu sayfadaki kayıtlar. Null ise boş liste kullanılır.</param>
        public PagedResult(long totalCount, List<T> data)
        {
            TotalCount = Math.Max(0, totalCount);
            Data = data ?? new List<T>();
        }
    }
}
