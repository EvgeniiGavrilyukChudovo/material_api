using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Data.Services
{
    public interface IRetrieveRepository<TKey, TEntity> : IRepository
    {
        Task<TEntity> RetrieveAsync(TKey id, CancellationToken cancellationToken);
    }
}
