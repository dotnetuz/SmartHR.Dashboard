using System.Collections.Generic;

namespace SmartHR.Dashboard.Domain.Common
{
    public class CollectionResult<TSource>
    {
        public CollectionResult(int? count = null, IEnumerable<TSource> items = null)
        {
            Count = count;
            Items = items;
        }
        public int? Count { get; set; }
        public IEnumerable<TSource> Items { get; set; }
    }
}
