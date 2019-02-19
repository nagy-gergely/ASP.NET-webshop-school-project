﻿using System.Web;
using System.Web.Mvc;

namespace musicweb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorHandler.AiHandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
