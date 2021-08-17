using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Business.Services
{
    public interface ICreateDomainService<TKey, TResource>
    {
        Task<TKey> CreateAsync(TResource inModel, CancellationToken cancellationToken);
    }
}
