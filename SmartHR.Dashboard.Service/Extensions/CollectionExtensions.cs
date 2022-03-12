using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> ToPagination<T>(this IEnumerable<T> source, int pageSize, int pageIndex) where T : class
        {
            return pageSize >= 0 && pageIndex > 0
                ? source.Skip(pageSize * (pageIndex - 1)).Take(pageSize)
                : source;
        }
    }
}
