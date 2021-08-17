using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Business.Services
{
    public interface IUpdateDomainService<TKey, TResource>
    {
        Task UpdateAsync(TKey id, TResource inModel, CancellationToken cancellationToken);
    }
}
