using  BusinessLogic.SysManage;
using  Common;
using  DataAccess.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Answer.PC
{
    public class WriteLogAttribute : ActionFilterAttribute
    {

        private static int funType;
        public WriteLogAttribute(int _funType)
        {
            funType = _funType;
        }

        /// <summary>
        /// 在执行操作方法后由 ASP.NET MVC 框架调用。  
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var areaName = filterContext.RouteData.DataTokens["area"] + "/";            //获取当前区域
            var controllerName = filterContext.RouteData.Values["controller"] + "/";    //获取控制器
            var action = filterContext.RouteData.Values["Action"];                      //获取当前Action
            string currentUrl = "/" + areaName + controllerName + action;               //拼接构造完整url


            ISys_MenuModule menu = new Sys_MenuModuleDAL();
           Entity.ModuleEntity model = menu.GetMenuList(StructDictCode.状态.正常).Where(w => w.F_UrlAddress.Contains(currentUrl.Trim('/'))).FirstOrDefault();

            switch (funType)
            {
                case StructDictCode.分类.访问:

                    WebSecurityHelper.LogCommon.Current.WriteLog_Visit(model == null ? "" : model.F_FullName, currentUrl);
                    break;
            }
            base.OnActionExecuted(filterContext);
        }
        


    }

}