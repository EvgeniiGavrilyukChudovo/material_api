using System.Threading;
using System.Threading.Tasks;
using Raven.Client.Documents.Session;

namespace Material.Core.Infrastructure.Data.Services.Implementation.RavenDb
{
    public class RavenUpdateRepository<TEntity> : RavenRepositoryBase, IUpdateRepository<TEntity>
    {
        public RavenUpdateRepository(IDocumentSession session)
            : base(session)
        { }

        public Task UpdateAsync(TEntity inModel, CancellationToken cancellationToken)
        {
            Session.Store(inModel);
            return Task.CompletedTask;
        }
    }
}
