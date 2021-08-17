using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Business.Services
{
    public interface IDeleteDomainService<TKey, TResource>
    {
        Task DeleteAsync(TKey id, CancellationToken cancellationToken);
    }
}
