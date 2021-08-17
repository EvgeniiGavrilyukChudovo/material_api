using System.Threading;
using System.Threading.Tasks;
using Raven.Client.Documents.Session;

namespace Material.Core.Infrastructure.Data.Services.Implementation.RavenDb
{
    public class RavenRetrieveRepository<TEntity> : RavenRepositoryBase, IRetrieveRepository<string, TEntity>
    {
        public RavenRetrieveRepository(IDocumentSession session) : base(session)
        { }

        public Task<TEntity> RetrieveAsync(string id, CancellationToken cancellationToken)
        {
            TEntity entity = Session.Load<TEntity>(id);
            if (entity == null)
            {
                throw new System.Exception("Entity is not found.");
            }
            return Task.FromResult(entity);
        }
    }
}
