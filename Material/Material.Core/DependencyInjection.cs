using Material.Core.Infrastructure.Data.Services;
using Material.Core.Infrastructure.Data.Services.Implementation.RavenDb;
using Microsoft.Extensions.DependencyInjection;

namespace Material.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection services) =>
            services
                .AddScoped<IDocumentSessionFactory, DocumentSessionFactory>()
                .AddScoped<IDocumentStoreFactory, DocumentStoreFactory>();
    }
}
