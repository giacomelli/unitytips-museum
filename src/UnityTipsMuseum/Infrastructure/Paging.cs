using System.Collections.Generic;
using System.Linq;

namespace UnityTipsMuseum.Infrastructure
{
    public class Paging
    {
        public Paging(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public IEnumerable<TItem> Paginate<TItem>(IEnumerable<TItem> allItems)
        {
            return allItems.Skip((PageNumber - 1) * PageSize).Take(PageSize);
        }
    }
}