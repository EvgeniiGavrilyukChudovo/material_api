using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Data.Services
{
    public interface IDeleteRepository<TEntity> : IRepository
    {
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
