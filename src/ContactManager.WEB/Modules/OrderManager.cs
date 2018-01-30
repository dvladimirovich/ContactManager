using ContactManager.Domain.Abstract;
using System;
using System.Linq.Expressions;
using System.Reflection;
using E = System.Linq.Expressions.Expression; // for brevity

namespace ContactManager.WEB.Modules
{
    public class OrderManager
    {
        public static Expression<Func<T, TKey>> GenerateOrderBy<T, TKey>(string column) 
            where T : class, IEntity
        {
            if (string.IsNullOrWhiteSpace(column))
                return null;

            ParameterExpression peTrafic = E.Parameter(typeof(T), "trafic");
            E property = E.Property(peTrafic, peTrafic.Type.GetProperty(column));

            // Формируем лямбду с условием
            return E.Lambda<Func<T, TKey>>(property, peTrafic);
        }
    }
}
