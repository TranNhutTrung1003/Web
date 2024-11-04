using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_63135935
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

            routes.MapRoute
            (
                name: "Product detail",
                url: "{controller}/{action}/{id}",
                defaults: new { Controller = "Saches_63135935", action = "Details", id = UrlParameter.Optional },
                namespaces: new[] { "Project_63135935.Controllers" }
            );
        }
    }
}
