using System;
using System.Threading;
using System.Threading.Tasks;
using Raven.Client.Documents.Session;

namespace Material.Core.Infrastructure.Data.Services.Implementation.RavenDb
{
    public abstract class RavenRepositoryBase : IRepository
    {
        protected readonly IDocumentSession Session;

        public RavenRepositoryBase(IDocumentSession session)
        {
            Session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public Task SaveChanges(CancellationToken cancellationToken)
        {
            Session.SaveChanges();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Session.Dispose();
        }
    }
}
