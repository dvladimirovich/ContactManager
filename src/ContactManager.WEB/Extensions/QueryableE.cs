using System;
using System.Linq;
using E = System.Linq.Expressions.Expression; // for brevity

namespace ContactManager.WEB.Extensions
{
    public static class QueryableE
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> query, string field, bool ascending)
        {
            var param = E.Parameter(typeof(T), "par");
            var prop = E.Property(param, field);
            var lambda = E.Lambda(prop, param);
            string method = ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { query.ElementType, lambda.Body.Type };
            var mce = E.Call(typeof(Queryable), method, types, query.Expression, lambda);
            return query.Provider.CreateQuery<T>(mce);
        }
    }
}
