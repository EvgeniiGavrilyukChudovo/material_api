using Material.Application.Resources.Materials.V1;
using Material.Business.Resources.Materials.Models;
using Material.Core.Infrastructure.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Material.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplicationResourceDependencies(this IServiceCollection services) =>
            services
                .AddScoped<IBulkRetrieveApplicationService<MaterialV1OutModel>, MaterialBulkGetV1ApplicationService>()
                .AddScoped<ICreateApplicationService<MaterialV1CreateModel, string>, MaterialCreateV1ApplicationService>()
                .AddScoped<IDeleteApplicationService<string, MaterialResource>, MaterialDeleteV1ApplicationService>()
                .AddScoped<IRetrieveApplicationService<string, MaterialV1OutModel>, MaterialRetrieveV1ApplicationService>()
                .AddScoped<IUpdateApplicationService<string, MaterialV1UpdateModel>, MaterialUpdateV1ApplicationService>();
    }
}
