using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProgramacionAvanzada
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "CarLista",
                url: "car/lista",
                defaults: new { controller = "Car", action = "Index" }
            );

            routes.MapRoute(
                name: "PersonLista",
                url: "person/lista",
                defaults: new { controller = "person", action = "Index" }
            );

            routes.MapRoute(
                name: "JobLista",
                url: "job/lista",
                defaults: new { controller = "job", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PersonCreate",
                url: "person/crear",
                defaults: new{controller = "person", action = "crear"}
            );

            routes.MapRoute(
                name: "CarNuevo",
                url: "car/nuevo",
                defaults: new { controller = "car", action = "nuevo" }
            );
        }
    }
}
