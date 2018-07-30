using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Common;

namespace Answer.Api
{
    /// <summary>
    /// 日 期：2017.03.08
    /// 描 述：登录认证（会话验证组件）
    /// </summary>
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        //private DataAuthorizeIBLL dataAuthorizeIBLL = new DataAuthorizeBLL();
        private FilterMode _customMode;
        /// <summary>默认构造</summary>
        /// <param name="Mode">认证模式</param>
        public HandlerLoginAttribute(FilterMode Mode)
        {
            _customMode = Mode;
        }
        /// <summary>
        /// 响应前执行登录验证,查看当前用户是否有效 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //登录拦截是否忽略
            if (_customMode == FilterMode.Ignore)
            {
                return;
            }

            //调试用
            var areaName = filterContext.RouteData.DataTokens["area"] + "/";            //获取当前区域
            var controllerName = filterContext.RouteData.Values["controller"] + "/";    //获取控制器
            var action = filterContext.RouteData.Values["Action"];                      //获取当前Action
            //string currentUrl = "/" + areaName + controllerName + action;               //拼接构造完整url


            //验证登录状态
            int res = OperatorHelper.Instance.IsOnLine().stateCode;

            if (res != 1)// 登录过期或者未登录
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
                return;
            }
     
            // 判断当前接口是否需要加载数据权限
            if (!this.DataAuthorize(filterContext))
            {
                filterContext.Result = new ContentResult { Content = new ResParameter { code = ResponseCode.fail, info = "没有该数据权限" }.ToJson() };
                return;
            }
        }
        
        /// <summary>
        /// 执行权限认证
        /// </summary>
        /// <param name="filterContext">当前连接</param>
        /// <returns></returns>
        private bool DataAuthorize(AuthorizationContext filterContext)
        {
            var areaName = filterContext.RouteData.DataTokens["area"] + "/";            //获取当前区域
            var controllerName = filterContext.RouteData.Values["controller"] + "/";    //获取控制器
            var action = filterContext.RouteData.Values["Action"];                      //获取当前Action
            string currentUrl = "/" + areaName + controllerName + action;               //拼接构造完整url

            WebHelper.AddHttpItems("currentUrl", currentUrl);
            //return dataAuthorizeIBLL.SetWhereSql(currentUrl);
            return true;
        }

    }

}