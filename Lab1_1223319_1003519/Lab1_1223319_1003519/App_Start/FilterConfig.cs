﻿using System.Web;
using System.Web.Mvc;

namespace Lab1_1223319_1003519
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
