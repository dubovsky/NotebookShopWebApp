using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lb2mvc.Models
{
    public class PageListViewModel <T>:List<T>
    {
        public int TotalPages { get; private set; }
        public int CurrentPage { get; private set; }
       private PageListViewModel(List<T> items, int total, int current)
        {
            this.AddRange(items);
            TotalPages = total;
            CurrentPage = current;
        }
        public static PageListViewModel<T> CreatePage(IEnumerable<T> items, int current, int PageSize)
        {
            var totalCount = items.Count();
            var pagesCount = (int)Math.Ceiling(totalCount / (double)PageSize);
            var list = items.Skip(PageSize * (current - 1)).Take(PageSize).ToList();
            return new PageListViewModel<T>(list, pagesCount, current);
        }
    }
}