using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Application.Services
{
    public interface ICreateApplicationService<TInModel, TKey>
    {
        Task<TKey> CreateAsync(TInModel inModel, CancellationToken cancellationToken);
    }
}
