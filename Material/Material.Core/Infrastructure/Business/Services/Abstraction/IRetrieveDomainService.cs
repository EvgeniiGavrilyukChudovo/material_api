using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Business.Services
{
    public interface IRetrieveDomainService<TKey, TResource>
    {
        Task<TResource> RetrieveAsync(TKey id, CancellationToken cancellationToken);
    }
}
