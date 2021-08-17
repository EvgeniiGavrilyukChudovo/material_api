using Material.Application.Resources.Materials.Common.Exceptions;
using Material.Business.Resources.Materials.Models;
using Material.Core.Infrastructure.Application.Services.Implementation;
using Material.Core.Infrastructure.Business.Services;

namespace Material.Application.Resources.Materials.V1
{
    public class MaterialCreateV1ApplicationService : CreateApplicationService<MaterialV1CreateModel, string, MaterialResource>
    {
        public MaterialCreateV1ApplicationService(ICreateDomainService<string, MaterialResource> createDomainService)
            : base(createDomainService)
        { }

        protected override MaterialResource CreateResourceFromInModel(MaterialV1CreateModel inModel)
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

        protected override void ValidateOnBadModel(MaterialV1CreateModel inModel)
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
