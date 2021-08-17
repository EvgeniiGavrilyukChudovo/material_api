using Material.Core.Infrastructure.Data.Services.Implementation.RavenDb.Configurations;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;

namespace Material.Core.Infrastructure.Data.Services.Implementation.RavenDb
{
    public sealed class DocumentStoreFactory : IDocumentStoreFactory
    {
        private DocumentStoreConfiguration _documentStoreConfiguration;

        public DocumentStoreFactory(IOptions<DocumentStoreConfiguration> configuration)
        {
            _documentStoreConfiguration = configuration.Value;
        }

        public IDocumentStore CreateDocumentStore()
        {
            IDocumentStore store = new DocumentStore
            {
                Urls = new[]
                    {
                        _documentStoreConfiguration.DatabaseAddress
                    },
                Database = _documentStoreConfiguration.DatabaseName,
                Conventions = { }
            };

            return store;
        }
    }
}
