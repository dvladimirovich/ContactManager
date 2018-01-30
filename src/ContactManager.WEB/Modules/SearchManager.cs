using ContactManager.Domain.Abstract;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using E = System.Linq.Expressions.Expression; // for brevity

namespace ContactManager.WEB.Modules
{
    public class SearchManager
    {
        public static Expression<Func<T, bool>> GenerateWhere<T>(string context)
            where T : class, IEntity
        {
            if (string.IsNullOrWhiteSpace(context))
            {
                return null;
            }

            E condition = null;
            ParameterExpression peEntity = E.Parameter(typeof(T), "ent");
            MethodInfo mContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            // проход по всем свойствам строкового типа и генерируем поисковое условие
            foreach (PropertyInfo info in peEntity.Type.GetProperties().Where(info => info.PropertyType == typeof(string) && info.CanRead && info.CanWrite))
            {
                ConditionDivByOr(ref condition, E.Property(peEntity, peEntity.Type.GetProperty(info.Name, typeof(string))), mContains, context);
            }

            // Формируем лямбду с условием
            return E.Lambda<Func<T, bool>>(condition, peEntity);
        }

        private static void ConditionDivByOr(ref E condition, E target, MethodInfo mInfo, string value)
        {
            if (condition == null)
                condition = (E)E.Call(target, mInfo, E.Constant(value));
            else
                condition = E.OrElse(condition, E.Call(target, mInfo, E.Constant(value)));
        }
    }
}
