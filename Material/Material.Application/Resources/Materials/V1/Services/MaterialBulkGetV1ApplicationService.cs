using Material.Business.Resources.Materials.Models;
using Material.Core.Infrastructure.Application.Services.Implementation;
using Material.Core.Infrastructure.Business.Services;

namespace Material.Application.Resources.Materials.V1
{
    public class MaterialBulkGetV1ApplicationService : BulkRetrieveApplicationService<MaterialV1OutModel, MaterialResource>
    {
        public MaterialBulkGetV1ApplicationService(IBulkRetrieveDomainService<MaterialResource> bulkRetrieveDomainService)
            : base(bulkRetrieveDomainService)
        { }

        protected override MaterialV1OutModel CreateOutModelFromResource(MaterialResource resource)
        {
            //TODO: Should be separated in mapping factory.

            return new MaterialV1OutModel(
                resource.Id,
                resource.Name,
                resource.IsVisible,
                MaterialModelTypeOfPhaseV1Mapper.MapFromResource(resource.TypeOfPhase),
                resource.MaterialFunction != null ?
                    new MaterialFunctionV1OutModel(
                        resource.MaterialFunction.MinTemperature,
                        resource.MaterialFunction.MaxTemperature)
                    :
                    null);
        }
    }
}
