using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ExamChess
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Game",
                url: "{controller}/{action}/{userId}",
                defaults: new { controller = "Game", action = "Index", userId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Admin",
                url: "{controller}/{action}/{userId}",
                defaults: new { controller = "Admin", action = "Index", userId = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Block", 
            //    url: "{controller}/{action}/{id}?block",
            //    defaults: new { controller = "Admin", action = "Block", id = UrlParameter.Optional, block = UrlParameter.Optional }
            //);
        }
    }
}
