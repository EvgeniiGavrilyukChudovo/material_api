using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Database;

namespace Material.Core.Infrastructure.Business.Services.Implementation
{
    public abstract class CreateDomainService<TResource, TKey, TEntity> : ICreateDomainService<TKey, TResource>
        where TEntity : IIdentity<TKey>
    {
        public async Task<TKey> CreateAsync(TResource resource, CancellationToken cancellationToken)
        {
            await ValidateOnBusinessRulesAsync(resource, cancellationToken);
            await ValidateOnCreatePolicyAsync(resource, cancellationToken);


            var entity = CreateEntityFromResource(resource);

            return await CreateInternalAsync(entity, cancellationToken);
        }

        protected abstract Task<TKey> CreateInternalAsync(TEntity entity, CancellationToken cancellationToken);

        protected abstract Task ValidateOnBusinessRulesAsync(TResource resource, CancellationToken cancellationToken);

        protected abstract Task ValidateOnCreatePolicyAsync(TResource resource, CancellationToken cancellationToken);

        protected abstract TEntity CreateEntityFromResource(TResource resource);
    }
}
