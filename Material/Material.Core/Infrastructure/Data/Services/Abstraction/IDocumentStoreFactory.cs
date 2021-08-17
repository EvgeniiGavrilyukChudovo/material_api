using Raven.Client.Documents;

namespace Material.Core.Infrastructure.Data.Services
{
    public interface IDocumentStoreFactory
    {
        IDocumentStore CreateDocumentStore();
    }
}
