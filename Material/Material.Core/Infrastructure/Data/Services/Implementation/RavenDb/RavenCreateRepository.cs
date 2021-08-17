using System.Threading;
using System.Threading.Tasks;
using Raven.Client.Documents.Session;

namespace Material.Core.Infrastructure.Data.Services.Implementation.RavenDb
{
    public class RavenCreateRepository<TEntity> : RavenRepositoryBase, ICreateRepository<TEntity>
    {
        public RavenCreateRepository(IDocumentSession session)
            : base(session)
        { }

        public Task CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Session.Store(entity);
            return Task.CompletedTask;
        }
    }
}
