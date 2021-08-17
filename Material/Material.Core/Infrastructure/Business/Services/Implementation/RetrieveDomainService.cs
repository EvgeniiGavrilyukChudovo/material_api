using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Business.Services.Implementation
{
    public abstract class RetrieveDomainService<TKey, TResource, TEntity> : IRetrieveDomainService<TKey, TResource>
    {
        public async Task<TResource> RetrieveAsync(TKey id, CancellationToken cancellationToken)
        {
            var entity = await RetrieveInternalAsync(id, cancellationToken);
            return CreateResourceFromEntity(entity);
        }

        protected abstract Task<TEntity> RetrieveInternalAsync(TKey id, CancellationToken cancellationToken);

        protected abstract TResource CreateResourceFromEntity(TEntity entity);
    }
}
