using Material.Business.Resources.Materials;
using Material.Business.Resources.Materials.Models;
using Material.Core.Infrastructure.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Material.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterBusinessResourceDependencies(this IServiceCollection services) =>
            services
                .AddScoped<IBulkRetrieveDomainService<MaterialResource>, MaterialBulkGetRetrieveDomainService>()
                .AddScoped<ICreateDomainService<string, MaterialResource>, MaterialCreateDomainService>()
                .AddScoped<IDeleteDomainService<string, MaterialResource>, MaterialDeleteDomainService>()
                .AddScoped<IRetrieveDomainService<string, MaterialResource>, MaterialRetrieveDomainService>()
                .AddScoped<IUpdateDomainService<string, MaterialResource>, MaterialUpdateDomainService>();
    }
}
