using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Common.Models
{
    public class PageViewModel<T>
    {
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<T> Items { get; set; }

        public PageViewModel(int totalPages, int totalItems, int currentPage, int pageSize, List<T> items)
        {
            TotalPages = totalPages;
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Items = items;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }
    }
}
