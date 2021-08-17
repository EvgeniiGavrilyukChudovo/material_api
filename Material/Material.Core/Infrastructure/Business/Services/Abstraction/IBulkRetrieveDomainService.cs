using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Models;

namespace Material.Core.Infrastructure.Business.Services
{
    public interface IBulkRetrieveDomainService<TResource>
    {
        Task<IPagedCollection<TResource>> BulkGetAsync(int pageIndex, int pageSize, CancellationToken cancellationToken);
    }
}
