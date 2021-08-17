using System;
using System.Threading;
using System.Threading.Tasks;
using Material.Business.Resources.Materials.Models;
using Material.Core.Infrastructure.Business.Services.Implementation;
using Material.Core.Infrastructure.Data.Services;
using Material.Core.Infrastructure.Data.Services.Implementation.RavenDb;

namespace Material.Business.Resources.Materials
{
    public class MaterialRetrieveDomainService : RetrieveDomainService<string, MaterialResource, Data.Resources.Material>
    {
        protected readonly IDocumentSessionFactory DocumentSessionFactory;
        protected readonly IDocumentStoreFactory DocumentStoreFactory;

        public MaterialRetrieveDomainService(
            IDocumentSessionFactory documentSessionFactory,
            IDocumentStoreFactory documentStoreFactory)
        {
            DocumentSessionFactory = documentSessionFactory ?? throw new ArgumentNullException(nameof(documentSessionFactory));
            DocumentStoreFactory = documentStoreFactory ?? throw new ArgumentNullException(nameof(documentStoreFactory));
        }

        protected override MaterialResource CreateResourceFromEntity(Data.Resources.Material entity)
        {
            var resource = new MaterialResource(
                entity.Id,
                entity.Name,
                entity.IsVisible,
                MaterialResourceTypeOfPhaseMapper.MapFromEntity(entity.TypeOfPhase),
                entity.MaterialFunction != null ?
                    new MaterialFunctionResource(entity.MaterialFunction.MinTemperature, entity.MaterialFunction.MaxTemperature)
                    :
                    null);

            return resource;
        }

        protected override async Task<Data.Resources.Material> RetrieveInternalAsync(string id, CancellationToken cancellationToken)
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
    }
}
