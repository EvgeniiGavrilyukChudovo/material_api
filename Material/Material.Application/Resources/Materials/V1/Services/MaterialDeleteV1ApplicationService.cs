using Material.Business.Resources.Materials.Models;
using Material.Core.Infrastructure.Application.Services.Implementation;
using Material.Core.Infrastructure.Business.Services;

namespace Material.Application.Resources.Materials.V1
{
    public class MaterialDeleteV1ApplicationService : DeleteApplicationService<string, MaterialResource>
    {
        public MaterialDeleteV1ApplicationService(IDeleteDomainService<string, MaterialResource> deleteDomainService) : base(deleteDomainService)
        { }
    }
}
