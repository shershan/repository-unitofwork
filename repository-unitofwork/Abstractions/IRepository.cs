using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace repository_unitofwork.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        TEntity Get(Guid id);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> query);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IIncludableQueryable<TEntity, TProperty> Include<TProperty>(Expression<Func<TEntity, TProperty>> expression);
    }
}

