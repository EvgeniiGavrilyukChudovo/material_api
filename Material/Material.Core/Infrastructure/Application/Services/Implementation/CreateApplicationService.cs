using System;
using System.Threading;
using System.Threading.Tasks;
using Material.Core.Infrastructure.Business.Services;

namespace Material.Core.Infrastructure.Application.Services.Implementation
{
    public abstract class CreateApplicationService<TInModel, TKey, TResource> : ICreateApplicationService<TInModel, TKey>
    {
        protected readonly ICreateDomainService<TKey, TResource> CreateDomainService;

        protected CreateApplicationService(ICreateDomainService<TKey, TResource> createDomainService)
        {
            CreateDomainService = createDomainService ?? throw new ArgumentNullException(nameof(createDomainService));
        }

        public async Task<TKey> CreateAsync(TInModel inModel, CancellationToken cancellationToken)
        {
            ValidateOnBadModel(inModel);
            TResource resource = CreateResourceFromInModel(inModel);
            return await CreateDomainService.CreateAsync(resource, cancellationToken);
        }

        protected abstract TResource CreateResourceFromInModel(TInModel inModel);

        protected abstract void ValidateOnBadModel(TInModel inModel);
    }
}
