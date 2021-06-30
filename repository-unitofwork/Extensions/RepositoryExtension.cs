using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq.Expressions;

namespace repository_unitofwork.Extensions
{
    public static class RepositoryExtension
    {
        public static IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(this IIncludableQueryable<TEntity, TProperty> items, Expression<Func<TEntity, TProperty>> expression)
        {
            return items.Include(expression);
        }
    }
}
