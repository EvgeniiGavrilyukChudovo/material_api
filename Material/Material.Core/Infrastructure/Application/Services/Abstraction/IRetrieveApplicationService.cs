using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Application.Services
{
    public interface IRetrieveApplicationService<TKey, TOutModel>
    {
        Task<TOutModel> RetrieveAsync(TKey id, CancellationToken cancellationToken);
    }
}
