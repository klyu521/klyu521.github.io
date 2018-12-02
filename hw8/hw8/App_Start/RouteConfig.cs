﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace hw8
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Items", action = "HomePage", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Search",
                url: "{controller}/{action}/{search}",
                defaults: new { controller = "Bid", action = "ItemBids", }
            );
        }
    }
}
