using System;
using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Business.Services;

namespace Material.Core.Infrastructure.Application.Services.Implementation
{
    public abstract class DeleteApplicationService<TKey, TResource> : IDeleteApplicationService<TKey, TResource>
    {
        protected readonly IDeleteDomainService<TKey, TResource> DeleteDomainService;

        protected DeleteApplicationService(IDeleteDomainService<TKey, TResource> deleteDomainService)
        {
            DeleteDomainService = deleteDomainService ?? throw new ArgumentNullException(nameof(deleteDomainService));
        }

        public async Task DeleteAsync(TKey id, CancellationToken cancellationToken)
        {
            await DeleteDomainService.DeleteAsync(id, cancellationToken);
            await DeletePostAction(id, cancellationToken);
        }

        protected virtual Task DeletePostAction(TKey id, CancellationToken cancellationToken) =>
            Task.CompletedTask;
    }
}
