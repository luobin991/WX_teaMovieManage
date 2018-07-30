using System;
using System.Web.Mvc;
using Entity;
using Common;
using System.Text;
namespace Answer.Api
{
    /// <summary>
    /// 全局页面控制器异常记录
    /// </summary>
    public class CustomErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //base.OnException(filterContext);

            //设置为true阻止golbal里面的错误执行
            filterContext.ExceptionHandled = true;
            StringBuilder strInfo = new StringBuilder();
            strInfo.AppendLine("Url：" + filterContext.HttpContext.Request.RawUrl);
            strInfo.AppendLine("Message：" + filterContext.Exception.Message); 
            WebSecurityHelper.LogCommon.Current.WriteLog_Exception(strInfo.ToString());  //写入数据库

            LogHelper.Error(strInfo.ToString()); //写入文件
        }
    }


}