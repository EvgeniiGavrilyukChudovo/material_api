using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Models;

namespace Material.Core.Infrastructure.Business.Services.Implementation
{
    public abstract class BulkRetrieveDomainService<TResource, TEntity> : IBulkRetrieveDomainService<TResource>
    {
        public async Task<IPagedCollection<TResource>> BulkGetAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var pagedResult = await BulkRetrieveInternal(pageIndex, pageSize, cancellationToken);

            return new PagedCollection<TResource>(
                pageIndex,
                pageSize,
                pagedResult.Items.Select(item => CreateResourceFromEntity(item)).ToList(),
                pagedResult.TotalCount);
        }

        protected abstract TResource CreateResourceFromEntity(TEntity entity);

        protected abstract Task<IPagedCollection<TEntity>> BulkRetrieveInternal(int pageIndex, int pageSize, CancellationToken cancellationToken);
    }
}
