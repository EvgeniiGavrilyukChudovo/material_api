using Material.Application.Resources.Materials.Common.Exceptions;
using Material.Business.Resources.Materials.Models;
using Material.Core.Infrastructure.Application.Services.Implementation;
using Material.Core.Infrastructure.Business.Services;

namespace Material.Application.Resources.Materials.V1
{
    public class MaterialUpdateV1ApplicationService : UpdateApplicationService<string, MaterialV1UpdateModel, MaterialResource>
    {
        public MaterialUpdateV1ApplicationService(IUpdateDomainService<string, MaterialResource> updateDomainService)
            : base(updateDomainService)
        { }

        protected override MaterialResource CreateResourceFromInModel(MaterialV1UpdateModel inModel)
        {
            return new MaterialResource(
                inModel.Name,
                inModel.IsVisible,
                MaterialModelTypeOfPhaseV1Mapper.MapFromModel(inModel.TypeOfPhase),
                inModel.MaterialFunction != null ?
                    new MaterialFunctionResource(
                        inModel.MaterialFunction.MinTemperature,
                        inModel.MaterialFunction.MaxTemperature)
                    :
                    null);
        }

        protected override void ValidateOnBadModel(MaterialV1UpdateModel inModel)
        {
            // TODO: Should be separated in IValidation<T> service.
            if (inModel.MaterialFunction != null)
            {
                if (inModel.MaterialFunction.MinTemperature > inModel.MaterialFunction.MaxTemperature)
                {
                    throw new MinTemperatureLowerApplicationException();
                }
            }
        }
    }
}
