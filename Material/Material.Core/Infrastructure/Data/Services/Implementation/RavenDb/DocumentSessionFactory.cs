using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Material.Core.Infrastructure.Data.Services.Implementation.RavenDb
{
    public class DocumentSessionFactory : IDocumentSessionFactory
    {
        public IDocumentSession CreateDocumentSession(IDocumentStore store)
        {
            store.Initialize();
            return store.OpenSession();
        }
    }
}
