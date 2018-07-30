using System.Web.Mvc;

namespace Answer.PC.Areas.AuthorizeModule
{
    public class AuthorizeModuleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AuthorizeModule";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AuthorizeModule_default",
                "AuthorizeModule/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}