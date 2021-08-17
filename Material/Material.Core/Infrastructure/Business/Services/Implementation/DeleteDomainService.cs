using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Database;

namespace Material.Core.Infrastructure.Business.Services.Implementation
{
    public abstract class DeleteDomainService<TKey, TResource, TEntity> : IDeleteDomainService<TKey, TResource>
        where TEntity : IIdentity<TKey>
    {

        public async Task DeleteAsync(TKey id, CancellationToken cancellationToken)
        {
            var entity = await RetreiveInternalAsync(id, cancellationToken);
            await ValidateOnDeletePolicyAsync(entity, cancellationToken);
            await DeleteInternalAsync(entity, cancellationToken);
        }

        protected abstract Task<TEntity> RetreiveInternalAsync(TKey id, CancellationToken cancellationToken);

        protected abstract Task DeleteInternalAsync(TEntity entity, CancellationToken cancellationToken);

        protected abstract Task ValidateOnDeletePolicyAsync(TEntity entity, CancellationToken cancellationToken);
    }
}

