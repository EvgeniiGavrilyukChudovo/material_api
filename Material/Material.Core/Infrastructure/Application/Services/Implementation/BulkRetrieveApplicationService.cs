using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Business.Services;
using Material.Core.Infrastructure.Models;

namespace Material.Core.Infrastructure.Application.Services.Implementation
{
    public abstract class BulkRetrieveApplicationService<TOutModel, TResource> : IBulkRetrieveApplicationService<TOutModel>
    {
        protected readonly IBulkRetrieveDomainService<TResource> BulkRetrieveDomainService;

        protected BulkRetrieveApplicationService(IBulkRetrieveDomainService<TResource> bulkRetrieveDomainService)
        {
            BulkRetrieveDomainService = bulkRetrieveDomainService ?? throw new ArgumentNullException(nameof(bulkRetrieveDomainService));
        }

        public async Task<IPagedCollection<TOutModel>> BulkGetAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            IPagedCollection<TResource> pagedCollection = await BulkRetrieveDomainService.BulkGetAsync(pageIndex, pageSize, cancellationToken);

            return new PagedCollection<TOutModel>(
                pagedCollection.PageIndex,
                pagedCollection.PageSize,
                pagedCollection.Items.Select(resource => CreateOutModelFromResource(resource)).ToList(),
                pagedCollection.TotalCount);
        }

        protected abstract TOutModel CreateOutModelFromResource(TResource resource);
    }
}
