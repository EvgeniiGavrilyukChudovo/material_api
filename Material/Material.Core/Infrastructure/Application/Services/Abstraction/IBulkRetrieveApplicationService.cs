using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Models;

namespace Material.Core.Infrastructure.Application.Services
{
    public interface IBulkRetrieveApplicationService<TOutModel>
    {
        Task<IPagedCollection<TOutModel>> BulkGetAsync(int pageIndex, int pageSize, CancellationToken cancellationToken);
    }
}
