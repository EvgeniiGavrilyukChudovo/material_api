using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Data.Services
{
    public interface IUpdateRepository<TEntity> : IRepository
    {
        Task UpdateAsync(TEntity inModel, CancellationToken cancellationToken);
    }
}
