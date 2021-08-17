using System;
using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Business.Services;

namespace Material.Core.Infrastructure.Application.Services.Implementation
{
    public abstract class RetrieveApplicationService<TKey, TOutModel, TResource> : IRetrieveApplicationService<TKey, TOutModel>
    {
        protected readonly IRetrieveDomainService<TKey, TResource> RetrieveDomainService;

        public RetrieveApplicationService(IRetrieveDomainService<TKey, TResource> retrieveDomainService)
        {
            RetrieveDomainService = retrieveDomainService ?? throw new ArgumentNullException(nameof(retrieveDomainService));
        }

        public async Task<TOutModel> RetrieveAsync(TKey id, CancellationToken cancellationToken)
        {
            TResource resource = await RetrieveDomainService.RetrieveAsync(id, cancellationToken);
            return CreateOutModelFromResource(resource);
        }

        protected abstract TOutModel CreateOutModelFromResource(TResource resource);
    }
}
