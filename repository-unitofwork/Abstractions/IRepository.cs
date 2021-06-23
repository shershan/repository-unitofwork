using System.Threading.Tasks;

namespace repository_unitofwork.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
    }
}

