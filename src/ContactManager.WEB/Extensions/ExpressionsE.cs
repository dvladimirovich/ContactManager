using ContactManager.Domain.Abstract;
using ContactManager.WEB.Modules;
using System;
using System.Linq.Expressions;

namespace ContactManager.WEB.Extensions
{
    public static class ExpressionsE
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right) 
            where T : class, IEntity
        {
            if (left == null)
                return right;
            else
            {
                if (right == null)
                    return left;
            }
            var replacedBody = new ParameterReplacer(right.Parameters[0], left.Parameters[0]).Visit(right.Body);
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Body, replacedBody), left.Parameters[0]);
        }

        public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right) 
            where T : class, IEntity
        {
            if (left == null)
                return right;
            else
            {
                if (right == null)
                    return left;
            }
            var replacedBody = new ParameterReplacer(right.Parameters[0], left.Parameters[0]).Visit(right.Body);
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left.Body, replacedBody), left.Parameters[0]);
        }
    }
}
