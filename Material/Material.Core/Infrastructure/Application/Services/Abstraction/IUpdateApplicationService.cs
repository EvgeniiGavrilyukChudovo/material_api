using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Application.Services
{
    public interface IUpdateApplicationService<TKey, TInModel>
    {
        Task UpdateAsync(TKey id, TInModel inModel, CancellationToken cancellationToken);
    }
}
