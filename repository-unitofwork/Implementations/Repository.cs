using Microsoft.EntityFrameworkCore;
using repository_unitofwork.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace repository_unitofwork.Implementations
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;

        private readonly DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            this.dbSet.AddRange(entities);
        }

        public T Get(Guid id)
        {
            return this.dbSet.Find(id);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> query)
        {
            return this.dbSet.Include(query).AsEnumerable();
        }
        public void Update(T entity)
        {
            this.dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);
        }
    }
}
