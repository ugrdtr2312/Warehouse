using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    public static class LinqAsyncWhere
    {
        public static async Task<IEnumerable<T>> WhereAsync<T>(this IQueryable<T> source, Func<T, Task<bool>> predicate)
        {
            var results = new ConcurrentQueue<T>();
            var tasks = source.AsEnumerable().Select(
                async x =>
                {
                    if (await predicate(x))
                        results.Enqueue(x);
                });
            await Task.WhenAll(tasks);
            return results;
        }
    }
}