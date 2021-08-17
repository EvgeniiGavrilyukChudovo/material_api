using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Models;

namespace Material.Core.Infrastructure.Data.Services
{
    public interface IBulkRetrieveRepository<TEntity> : IRepository
    {
        Task<IPagedCollection<TEntity>> RetrievePageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken);

        Task<int> CountAsync(CancellationToken cancellationToken);
    }
}
