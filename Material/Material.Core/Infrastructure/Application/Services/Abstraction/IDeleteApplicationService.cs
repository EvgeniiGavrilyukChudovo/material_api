using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Application.Services
{
    public interface IDeleteApplicationService<TKey, TResource>
    {
        Task DeleteAsync(TKey id, CancellationToken cancellationToken);
    }
}
