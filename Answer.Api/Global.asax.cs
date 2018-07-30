using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace Answer.Api
{
    using Entity.SysManage;
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BundleTable.EnableOptimizations = true;//是否启用优化

            //Ninject初始化
            ControllerBuilder.Current.SetControllerFactory(new WebSecurityHelper.NinjectFactory());
            Areas.api.Controllers.LoginController l = new Areas.api.Controllers.LoginController();
            l.userlogin();
        }
        
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {

                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*"); // "http://192.168.0.104:22222,http://192.168.0.104:8007");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Origin,X-Requested-With,Content-Type,Accept,key,Ticket");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
                
            }
            if (Context.Request.FilePath == "/") Context.RewritePath("index.html");
        }
        
    }
}
