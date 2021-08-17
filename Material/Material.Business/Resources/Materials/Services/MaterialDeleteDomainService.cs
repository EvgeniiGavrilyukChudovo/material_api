using System;
using System.Threading;
using System.Threading.Tasks;
using Material.Business.Resources.Materials.Models;
using Material.Core.Infrastructure.Business.Services.Implementation;
using Material.Core.Infrastructure.Data.Services;
using Material.Core.Infrastructure.Data.Services.Implementation.RavenDb;

namespace Material.Business.Resources.Materials
{
    public class MaterialDeleteDomainService : DeleteDomainService<string, MaterialResource, Data.Resources.Material>
    {
        protected readonly IDocumentSessionFactory DocumentSessionFactory;
        protected readonly IDocumentStoreFactory DocumentStoreFactory;

        public MaterialDeleteDomainService(
            IDocumentSessionFactory documentSessionFactory,
            IDocumentStoreFactory documentStoreFactory)
        {
            DocumentSessionFactory = documentSessionFactory ?? throw new ArgumentNullException(nameof(documentSessionFactory));
            DocumentStoreFactory = documentStoreFactory ?? throw new ArgumentNullException(nameof(documentStoreFactory));
        }

        protected override async Task DeleteInternalAsync(Data.Resources.Material entity, CancellationToken cancellationToken)
        {
            using (var documentStore = DocumentStoreFactory.CreateDocumentStore())
            {
                using (var documentSession = DocumentSessionFactory.CreateDocumentSession(documentStore))
                {
                    using (var deleteRepository = new RavenDeleteRepository<Data.Resources.Material>(documentSession))
                    {
                        await deleteRepository.DeleteAsync(entity, cancellationToken);
                        await deleteRepository.SaveChanges(cancellationToken);
                    }
                }
            }
        }

        protected override async Task<Data.Resources.Material> RetreiveInternalAsync(string id, CancellationToken cancellationToken)
        {
            var unescapedId = Uri.UnescapeDataString(id);
            using (var documentStore = DocumentStoreFactory.CreateDocumentStore())
            {
                using (var documentSession = DocumentSessionFactory.CreateDocumentSession(documentStore))
                {
                    using (var retrieveRepository = new RavenRetrieveRepository<Data.Resources.Material>(documentSession))
                    {
                        return await retrieveRepository.RetrieveAsync(unescapedId, cancellationToken);
                    }
                }
            }
        }

        protected override Task ValidateOnDeletePolicyAsync(Data.Resources.Material entity, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
