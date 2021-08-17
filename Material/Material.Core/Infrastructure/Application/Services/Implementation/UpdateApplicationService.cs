using System;
using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Business.Services;

namespace Material.Core.Infrastructure.Application.Services.Implementation
{
    public abstract class UpdateApplicationService<TKey, TInModel, TResource> : IUpdateApplicationService<TKey, TInModel>
    {
        protected readonly IUpdateDomainService<TKey, TResource> UpdateDomainService;

        protected UpdateApplicationService(IUpdateDomainService<TKey, TResource> updateDomainService)
        {
            UpdateDomainService = updateDomainService ?? throw new ArgumentNullException(nameof(updateDomainService));
        }

        public async Task UpdateAsync(TKey id, TInModel inModel, CancellationToken cancellationToken)
        {
            ValidateOnBadModel(inModel);
            await UpdateDomainService.UpdateAsync(id, CreateResourceFromInModel(inModel), cancellationToken);
        }

        protected abstract void ValidateOnBadModel(TInModel inModel);

        protected abstract TResource CreateResourceFromInModel(TInModel inModel);
    }
}
