using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Models;
using Raven.Client.Documents.Session;

namespace Material.Core.Infrastructure.Data.Services.Implementation.RavenDb
{
    public class RavenBulkRetrieveRepository<TEntity> : RavenRepositoryBase, IBulkRetrieveRepository<TEntity>, IDisposable
    {
        public RavenBulkRetrieveRepository(IDocumentSession session)
            : base(session)
        { }

        public Task<int> CountAsync(CancellationToken cancellationToken)
        {
            int totalCount = Session.Query<TEntity>().Count();
            return Task.FromResult(totalCount);
        }

        public void Dispose()
        {
            Session.Dispose();
        }

        public async Task<IPagedCollection<TEntity>> RetrievePageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            IReadOnlyCollection<TEntity> entities = Session
                .Query<TEntity>()
                .Skip(pageIndex * pageSize).Take(pageSize)
                .ToList();

            int totalCount = await CountAsync(cancellationToken);

            return new PagedCollection<TEntity>(pageIndex, pageSize, entities, totalCount);
        }
    }
}
