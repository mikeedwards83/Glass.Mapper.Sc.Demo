using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Glass.Mapper.Sc.Demo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "CommentsSearch",
                url: "search/comments/{name}",
                defaults: new {controller = "CommentsSearch", action = "Index"}
                );

            routes.MapRoute(
             name: "RateBacon",
             url: "rate/bacon/{itemId}/{ratingNumber}/{rating}",
             defaults: new { controller = "RateBacon", action = "Rate" }
             );
            routes.MapRoute(
             name: "Temp",
             url: "tempface",
             defaults: new { controller = "Temp", action = "Index" }
             );
        }
    }
}