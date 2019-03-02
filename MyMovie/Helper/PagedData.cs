using System.Collections.Generic;

namespace MyMovie.Helper
{
    public class PagedData<T> where T : class
    {
        public IEnumerable<T> DataObject { get; set; }

        public bool IsEnd { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }
    }
}