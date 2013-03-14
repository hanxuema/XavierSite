using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace XavierSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 "Default",
                 "{controller}/{action}/{id}",
                 new { controller = "Home", action = "Index", id = "" },
                 new string[] { "XavierSite.Controllers" } //looking for a controller in the main controllers folder first and then the areas.
                 );

            //routes.MapRoute(
            //    "hahah",
            //    "OnlineStore/{controller}/{action}/{id}",
            //    new { controller = "Home", action = "Index", id = "" }
            //    //new string[] { "XavierSite.Controllers" }
            //    );

            routes.MapRoute(
                  "postDetails",
                  "post/details/{id}/{postTitle}",
                  new { controller = "post", action = "Details", id = "", postTitle = "" }
                 );

            //routes.MapRoute("catchallroute", "query/{query-name}/{*extrastuff}");

        }
    }
}