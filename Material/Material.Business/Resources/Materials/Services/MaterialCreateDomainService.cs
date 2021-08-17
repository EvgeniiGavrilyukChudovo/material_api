using System;
using System.Threading;
using System.Threading.Tasks;
using Material.Business.Resources.Materials.Models;
using Material.Core.Infrastructure.Business.Services.Implementation;
using Material.Core.Infrastructure.Data.Services;
using Material.Core.Infrastructure.Data.Services.Implementation.RavenDb;
using Material.Data.Resources;

namespace Material.Business.Resources.Materials
{
    public class MaterialCreateDomainService : CreateDomainService<MaterialResource, string, Data.Resources.Material>
    {
        protected readonly IDocumentSessionFactory DocumentSessionFactory;
        protected readonly IDocumentStoreFactory DocumentStoreFactory;

        public MaterialCreateDomainService(
            IDocumentSessionFactory documentSessionFactory,
            IDocumentStoreFactory documentStoreFactory)
        {
            DocumentSessionFactory = documentSessionFactory ?? throw new ArgumentNullException(nameof(documentSessionFactory));
            DocumentStoreFactory = documentStoreFactory ?? throw new ArgumentNullException(nameof(documentStoreFactory));
        }

        protected override Data.Resources.Material CreateEntityFromResource(MaterialResource resource)
        {
            var entity = new Data.Resources.Material(
                resource.Id,
                resource.Name,
                resource.IsVisible,
                MaterialResourceTypeOfPhaseMapper.MapFromResource(resource.TypeOfPhase),
                resource.MaterialFunction != null ?
                    new MaterialFunction(
                        resource.MaterialFunction.MinTemperature,
                        resource.MaterialFunction.MaxTemperature)
                    :
                    null);

            return entity;
        }

        protected override async Task<string> CreateInternalAsync(Data.Resources.Material entity, CancellationToken cancellationToken)
        {
            using (var documentStore = DocumentStoreFactory.CreateDocumentStore())
            {
                using (var documentSession = DocumentSessionFactory.CreateDocumentSession(documentStore))
                {
                    using (var createRepository = new RavenCreateRepository<Data.Resources.Material>(documentSession))
                    {
                        await createRepository.CreateAsync(entity, cancellationToken);
                        await createRepository.SaveChanges(cancellationToken);
                        return entity.Id;
                    }
                }
            }
        }

        protected override Task ValidateOnBusinessRulesAsync(MaterialResource resource, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        protected override Task ValidateOnCreatePolicyAsync(MaterialResource resource, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
