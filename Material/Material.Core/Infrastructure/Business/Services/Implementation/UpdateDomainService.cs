using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Business.Services.Implementation
{
    public abstract class UpdateDomainService<TKey, TResource, TEntity> : IUpdateDomainService<TKey, TResource>
    {
        public async Task UpdateAsync(TKey id, TResource inModel, CancellationToken cancellationToken)
        {
            var entity = CreateEntityFromResource(inModel);
            await ValidateOnUpdatePolicyAsync(entity, cancellationToken);
            await ValidateBusinessRulesAsync(entity, cancellationToken);
            await UpdateInternalAsync(id, entity, cancellationToken);
        }

        protected abstract Task UpdateInternalAsync(TKey id, TEntity entity, CancellationToken cancellationToken);

        protected abstract TEntity CreateEntityFromResource(TResource inModel);

        protected abstract Task ValidateOnUpdatePolicyAsync(TEntity entity, CancellationToken cancellationToken);

        protected abstract Task ValidateBusinessRulesAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
