using Microsoft.Extensions.DependencyInjection;
using repository_unitofwork.Abstractions;
using repository_unitofwork.Implementations;

namespace repository_unitofwork
{
    public static class DIBootstrapper
    {
        public static IServiceCollection InitRepositoryUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
