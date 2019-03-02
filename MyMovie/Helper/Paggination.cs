using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMovie.Helper
{
    public static class Paggination
    {
        public static PagedData<T> PagedResult<T>(this List<T> list, int PageNumber, int PageSize) where T : class
        {
            var result = new PagedData<T>();
            result.DataObject = list.Skip(PageSize * (PageNumber - 1)).Take(PageSize).ToList();
            result.CurrentPage = PageNumber;

            if (list.Count() == 0)
            {
                result.IsEnd = true;
            }
            else
            {
                result.IsEnd = Math.Ceiling((double)list.Count() / PageSize) == PageNumber;
            }

            return result;
        }
    }
}