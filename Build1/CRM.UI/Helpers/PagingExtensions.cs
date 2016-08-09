
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Helpers
{
    public static class PagingExtensions
    {
        public static MvcHtmlString PagedList(this HtmlHelper helper, int pageSize, long totalRecords, int curentPage)
        {
            int totalPages =(int) (totalRecords / pageSize + 0.5);
            bool nextExists = false;
            if (curentPage < totalPages - 4) nextExists = true;
            bool prevExists = false;
            if (curentPage > 5) prevExists = true;
            string s = "";
            if (prevExists) s += string.Format("<a href='./page/{0}' >{1}</a>", curentPage - 1, "Prev");
            for (int i = (curentPage - 1) / 5 * 5 + 1, c = 1; c <= 5 && i <= totalPages; i++,c++)
            {
                s += string.Format("<a style='padding-right:5px' href='./page/{0}' >{1}</a>", i, i);
            }
            if (nextExists) s += string.Format("<a href='./page/{0}' >{1}</a>", curentPage - 1, "Next");
            return new MvcHtmlString(s);
        }
    }
}