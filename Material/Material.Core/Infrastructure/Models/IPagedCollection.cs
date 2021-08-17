using System.Collections.Generic;

namespace Material.Core.Infrastructure.Models
{
    public interface IPagedCollection<TOutModel>
    {
        int PageIndex { get; }

        int PageSize { get; }

        IReadOnlyCollection<TOutModel> Items { get; }

        int TotalCount { get; }
    }
}
