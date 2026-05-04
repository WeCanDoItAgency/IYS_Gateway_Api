using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Mongo.Repository.Generic
{
    public class PagedResult<T>
    {
        public long TotalCount { get; set; }
        public List<T> Data { get; set; } = new();

        public PagedResult(long totalCount, List<T> data)
        {
            TotalCount = totalCount;
            Data = data ?? new List<T>();
        }
    }
}
