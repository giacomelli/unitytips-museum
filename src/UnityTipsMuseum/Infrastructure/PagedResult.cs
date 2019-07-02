using System;
using System.Linq;
using System.Collections.Generic;

namespace UnityTipsMuseum.Infrastructure
{
    public class PagedResult<TItem> : IPagedResult
    {
        public PagedResult(IEnumerable<TItem> allItems, Paging paging)
        {
            Paging = paging;
            TotalItems = allItems.Count();

            if (paging.PageNumber > TotalPages)
                paging.PageNumber = TotalPages;
                
            PageItems = paging.Paginate(allItems);            
        }
        public Paging Paging { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages => Convert.ToInt32(Math.Ceiling((double)TotalItems / Paging.PageSize));

        public IEnumerable<TItem> PageItems { get; private set; }
    }

    public interface IPagedResult
    {
        Paging Paging { get; }
        int TotalItems { get; }
        int TotalPages { get; }
    }
}