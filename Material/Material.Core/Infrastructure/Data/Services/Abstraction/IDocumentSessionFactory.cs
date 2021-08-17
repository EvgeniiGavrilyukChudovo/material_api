using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Material.Core.Infrastructure.Data.Services
{
    public interface IDocumentSessionFactory
    {
        IDocumentSession CreateDocumentSession(IDocumentStore store);
    }
}
