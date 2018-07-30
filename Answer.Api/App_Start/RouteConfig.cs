using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using System.Web.Cors;
using System.Web.Http.Cors;

namespace Answer.Api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "Answer.Api.Controllers" }

            );

            //routes.MapRoute(
            //     "ApiDefault", // 路由名称  
            //     "{controller}/{action}/{id}", // 带有参数的 URL  
            //     new { controller = "Login", action = "Index", id = UrlParameter.Optional } // 参数默认值  
            //     , new string[] { "Answer.Api.Areas.api.Controllers" }
            // );
        }
    }
}
