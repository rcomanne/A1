﻿using System.Web;
using System.Web.Mvc;

namespace CinemaTicketSystem.TouchUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
