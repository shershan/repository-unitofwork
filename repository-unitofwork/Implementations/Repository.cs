using Microsoft.EntityFrameworkCore;
using repository_unitofwork.Abstractions;
using System.Threading.Tasks;

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

        public async Task Add(T entity)
        {
            await this.dbSet.AddAsync(entity);
        }
    }
}
