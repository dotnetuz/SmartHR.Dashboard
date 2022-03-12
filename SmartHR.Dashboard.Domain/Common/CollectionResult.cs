using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
