using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using repository_unitofwork.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace repository_unitofwork.Implementations
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;

        private readonly DbSet<TEntity> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.dbSet.AddRange(entities);
        }

        public TEntity Get(Guid id)
        {
            return this.dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> query)
        {
            IQueryable<TEntity> queryable = this.dbSet;

            if (query != null)
            {
                queryable = queryable.Where(query);
            }

            return queryable.AsEnumerable();
        }
        public void Update(TEntity entity)
        {
            this.dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public IIncludableQueryable<TEntity, TProperty> Include<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            return this.dbSet.Include(expression);
        }
    }
}
