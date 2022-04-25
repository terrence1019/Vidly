using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //The ordering of Routing is CRITICAL

            //ATTRIBUTE ROUTING:
            //Enable Feature
            routes.MapMvcAttributeRoutes();


            //Default Route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //Custom Route with multiple Parameters
            //Creating a custom Route for /movies/ReleaseDate/Rel_Yr/Rel_Mth
            //Example: /movies/ReleaseDate/2022/02
            //This Route will have the associated action/method in the Movies controller (MoviesController.cs)
            routes.MapRoute(
                name: "Year and Month of Release",
                url: "{controller}/{action}/{Rel_Yr}/{Rel_Mth}",
                defaults: new
                {
                    controller = "Movies",
                    action = "ReleaseDate",
                    Rel_Yr = @"\d{4}", //4-digit year
                    Rel_Mth = @"\d{2}" //2-digit month
                }
                );


            
        }
    }
}
