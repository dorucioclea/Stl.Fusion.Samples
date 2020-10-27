using System;
using Microsoft.Extensions.DependencyInjection;

namespace Samples.Helpers
{
    public abstract class DbServiceBase<TDbContext>
        where TDbContext : ScopedDbContext
    {
        protected IServiceProvider Services { get; }

        protected DbServiceBase(IServiceProvider services) => Services = services;

        protected TDbContext RentDbContext()
            => Services.RentDbContext<TDbContext>();

        protected IBatchEntityResolver<TKey, TEntity> GetBatchEntityResolver<TKey, TEntity>()
            where TKey : notnull
            where TEntity : class
            => Services.GetRequiredService<BatchEntityResolver<TDbContext, TKey, TEntity>>();
    }
}