using Microsoft.EntityFrameworkCore;
using repository_unitofwork.Abstractions;
using System;
using System.Collections.Generic;

namespace repository_unitofwork.Implementations
{
    internal class UnitOfWork : IUnitOfWork
    {
        private DbContext context;

        private Dictionary<string, dynamic> repositories = new Dictionary<string, dynamic>();

        public IRepository<T> Repository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T).FullName))
            {
                var repo = new Repository<T>(this.context);
                this.repositories[typeof(T).FullName] = repo;
            }

            return this.repositories[typeof(T).FullName];
        }

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
