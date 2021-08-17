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
    public class MaterialUpdateDomainService : UpdateDomainService<string, MaterialResource, Data.Resources.Material>
    {
        protected readonly IDocumentSessionFactory DocumentSessionFactory;
        protected readonly IDocumentStoreFactory DocumentStoreFactory;

        public MaterialUpdateDomainService(
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

        protected override async Task UpdateInternalAsync(string id, Data.Resources.Material entity, CancellationToken cancellationToken)
        {
            var unescapedId = Uri.UnescapeDataString(id);

            using (var documentStore = DocumentStoreFactory.CreateDocumentStore())
            {
                using (var documentSession = DocumentSessionFactory.CreateDocumentSession(documentStore))
                {
                    using (var retrieveRepository = new RavenRetrieveRepository<Data.Resources.Material>(documentSession))
                    {
                        var entityToChange = await retrieveRepository.RetrieveAsync(unescapedId, cancellationToken);
                        TransitTo(entityToChange, entity);

                        using (var updateRepository = new RavenUpdateRepository<Data.Resources.Material>(documentSession))
                        {
                            await updateRepository.UpdateAsync(entityToChange, cancellationToken);
                            await updateRepository.SaveChanges(cancellationToken);
                        }
                    }
                }
            }
        }

        protected override Task ValidateOnUpdatePolicyAsync(Data.Resources.Material entity, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }


        protected void TransitTo(Data.Resources.Material oldEntity, Data.Resources.Material newEntity)
        {
            oldEntity.Name = newEntity.Name;
            oldEntity.IsVisible = newEntity.IsVisible;
            oldEntity.MaterialFunction = newEntity.MaterialFunction;
            oldEntity.TypeOfPhase = newEntity.TypeOfPhase;
        }

        protected override Task ValidateBusinessRulesAsync(Data.Resources.Material entity, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
