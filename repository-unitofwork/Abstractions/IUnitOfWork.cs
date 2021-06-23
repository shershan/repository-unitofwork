using System;

namespace repository_unitofwork.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        IRepository<T> Repository<T>() where T : class;
    }
}
