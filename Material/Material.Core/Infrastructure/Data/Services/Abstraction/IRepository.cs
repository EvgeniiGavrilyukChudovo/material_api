using System;
using System.Threading;
using System.Threading.Tasks;

namespace Material.Core.Infrastructure.Data.Services
{
    public interface IRepository : IDisposable
    {
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
