﻿using System.Web;
using System.Web.Mvc;

namespace HW6.PingPongWithSignalR
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
