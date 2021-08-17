using System;
using System.Threading;
using System.Threading.Tasks;
using Material.Application.Resources.Materials.V1;
using Material.Business.Resources.Materials.Models;
using Material.Core.Infrastructure.Application.Services;
using Material.Core.Infrastructure.Models;
using Material.WebApi.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Material.WebApi.Resources.Materials
{
    [ApiController]
    [Route("api/materials")]
    public class MaterialV1Controller : ControllerBase
    {
        protected readonly IBulkRetrieveApplicationService<MaterialV1OutModel> BulkGetApplicationService;
        protected readonly ICreateApplicationService<MaterialV1CreateModel, string> CreateApplicationService;
        protected readonly IDeleteApplicationService<string, MaterialResource> DeleteApplicationService;
        protected readonly IRetrieveApplicationService<string, MaterialV1OutModel> RetrieveApplicationService;
        protected readonly IUpdateApplicationService<string, MaterialV1UpdateModel> UpdateApplicationService;

        public MaterialV1Controller(IBulkRetrieveApplicationService<MaterialV1OutModel> bulkGetApplicationService, ICreateApplicationService<MaterialV1CreateModel, string> createApplicationService, IDeleteApplicationService<string, MaterialResource> deleteApplicationService, IRetrieveApplicationService<string, MaterialV1OutModel> retrieveApplicationService, IUpdateApplicationService<string, MaterialV1UpdateModel> updateApplicationService)
        {
            BulkGetApplicationService = bulkGetApplicationService ?? throw new ArgumentNullException(nameof(bulkGetApplicationService));
            CreateApplicationService = createApplicationService ?? throw new ArgumentNullException(nameof(createApplicationService));
            DeleteApplicationService = deleteApplicationService ?? throw new ArgumentNullException(nameof(deleteApplicationService));
            RetrieveApplicationService = retrieveApplicationService ?? throw new ArgumentNullException(nameof(retrieveApplicationService));
            UpdateApplicationService = updateApplicationService ?? throw new ArgumentNullException(nameof(updateApplicationService));
        }

        [HttpGet("{key}")]
        public Task<MaterialV1OutModel> RetrieveAsync([FromRoute] string key, CancellationToken cancellationToken) =>
           RetrieveApplicationService.RetrieveAsync(key, cancellationToken);

        [HttpGet]
        public Task<IPagedCollection<MaterialV1OutModel>> RetrievePageAsync([FromQuery] int? pageIndex, [FromQuery] int? pageSize, CancellationToken cancellationToken) =>
           BulkGetApplicationService.BulkGetAsync(pageIndex ?? ApiConstants.DefaultPageIndex, pageSize ?? ApiConstants.DefaultPageSize, cancellationToken);

        [HttpPost]
        public async Task<MaterialV1OutModel> CreateAsync([FromBody] MaterialV1CreateModel inModel, CancellationToken cancellationToken)
        {
            var key = await CreateApplicationService.CreateAsync(inModel, cancellationToken);
            return await RetrieveApplicationService.RetrieveAsync(key, cancellationToken);
        }

        [HttpPut("{key}")]
        public async Task<MaterialV1OutModel> UpdateAsync([FromRoute] string key, [FromBody]MaterialV1UpdateModel inModel, CancellationToken cancellationToken)
        {
            await UpdateApplicationService.UpdateAsync(key, inModel, cancellationToken);
            return await RetrieveApplicationService.RetrieveAsync(key, cancellationToken);
        }

        [HttpDelete("{key}")]
        public Task DeleteAsync([FromRoute] string key, CancellationToken cancellationToken) =>
           DeleteApplicationService.DeleteAsync(key, cancellationToken);
    }
}
