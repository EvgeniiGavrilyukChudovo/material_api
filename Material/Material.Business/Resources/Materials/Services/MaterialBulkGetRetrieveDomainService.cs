using System;
using System.Threading;
using System.Threading.Tasks;
using Material.Business.Resources.Materials.Models;
using Material.Core.Infrastructure.Business.Services.Implementation;
using Material.Core.Infrastructure.Data.Services;
using Material.Core.Infrastructure.Data.Services.Implementation.RavenDb;
using Material.Core.Infrastructure.Models;

namespace Material.Business.Resources.Materials
{
    public class MaterialBulkGetRetrieveDomainService : BulkRetrieveDomainService<MaterialResource, Data.Resources.Material>
    {
        protected readonly IDocumentSessionFactory DocumentSessionFactory;
        protected readonly IDocumentStoreFactory DocumentStoreFactory;

        public MaterialBulkGetRetrieveDomainService(
            IDocumentSessionFactory documentSessionFactory,
            IDocumentStoreFactory documentStoreFactory)
        {
            DocumentSessionFactory = documentSessionFactory ?? throw new ArgumentNullException(nameof(documentSessionFactory));
            DocumentStoreFactory = documentStoreFactory ?? throw new ArgumentNullException(nameof(documentStoreFactory));
        }

        protected override async Task<IPagedCollection<Data.Resources.Material>> BulkRetrieveInternal(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            using (var documentStore = DocumentStoreFactory.CreateDocumentStore())
            {
                using (var documentSession = DocumentSessionFactory.CreateDocumentSession(documentStore))
                {
                    using (var bulkRetrieveRepository = new RavenBulkRetrieveRepository<Data.Resources.Material>(documentSession))
                    {

                        var pagedResult = await bulkRetrieveRepository.RetrievePageAsync(pageIndex, pageSize, cancellationToken);
                        return pagedResult;
                    }
                }
            }
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
    }
}
