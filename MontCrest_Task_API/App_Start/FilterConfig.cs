﻿using System.Web;
using System.Web.Mvc;

namespace MontCrest_Task_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
