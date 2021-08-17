using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Data.Services
{
    public interface ICreateRepository<TEntity> : IRepository
    {
        Task CreateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
