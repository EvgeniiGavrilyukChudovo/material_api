using System.Collections.Generic;

namespace Material.Core.Infrastructure.Models
{
    public class PagedCollection<TOutModel> : IPagedCollection<TOutModel>
    {
        public int PageIndex { get; }

        public int PageSize { get; }

        public IReadOnlyCollection<TOutModel> Items { get; }

        public int TotalCount { get; }

        public PagedCollection(int pageIndex, int pageSize, IReadOnlyCollection<TOutModel> items, int totalCount)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Items = items;
            TotalCount = totalCount;
        }
    }
}
