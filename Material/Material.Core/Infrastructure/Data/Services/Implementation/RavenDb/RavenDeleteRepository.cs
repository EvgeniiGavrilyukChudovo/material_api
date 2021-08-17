using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Database;
using Raven.Client.Documents.Session;

namespace Material.Core.Infrastructure.Data.Services.Implementation.RavenDb
{
    public class RavenDeleteRepository<TEntity> : RavenRepositoryBase, IDeleteRepository<TEntity>
        where TEntity : IIdentity<string>
    {
        public RavenDeleteRepository(IDocumentSession session)
            : base(session)
        { }

        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Session.Delete(entity.Id);
            return Task.CompletedTask;
        }
    }
}
