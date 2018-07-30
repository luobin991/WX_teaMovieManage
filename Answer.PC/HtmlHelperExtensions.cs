using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using  Common;
using System.Collections.Generic;

namespace Answer.PC
{
    /// <summary>
    /// 日 期：2017.03.07
    /// 描 述：对HtmlHelper类进行扩展
    /// </summary>
    public static class HtmlHelperExtensions
    {

        /// <summary>
        ///  加载js文件
        /// </summary>
        /// <param name="htmlHelper">需要扩展对象</param>
        /// <param name="jsFile">文件路径</param>
        /// <returns></returns>
        public static MvcHtmlString RenderJsFile(this HtmlHelper htmlHelper, params string[] jsFiles)
        {
            StringBuilder content = new StringBuilder();
            string executionFilePath = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Replace("~/", "");
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (!string.IsNullOrEmpty(executionFilePath))
            {
                int startindex = url.LastIndexOf(executionFilePath);
                url = url.Remove(startindex, url.Length - startindex);
            }
            string jsFormat = "<script type=\"text/javascript\" src=\"{0}\"></script>";
            string jsFile = "";
            foreach (string file in jsFiles)
            {
                if (jsFile != "")
                {
                    jsFile += ",";
                }
                jsFile += file;
            }
            content.AppendFormat(jsFormat, url + "Utility/GetJSFile?filePath=" + jsFile);
            return new MvcHtmlString(content.ToString());
        }
        /// <summary>
        /// 往页面中写入js文件
        /// </summary>
        /// <param name="htmlHelper">需要扩展对象</param>
        /// <param name="jsFiles">文件路径</param>
        /// <returns></returns>
        public static MvcHtmlString AppendJsFile(this HtmlHelper htmlHelper, params string[] jsFiles)
        {
            StringBuilder content = new StringBuilder();
            string jsFormat = "<script>{0}</script>";
            string jsStr = JsCssHelper.ReadJSFile(jsFiles);
            content.AppendFormat(jsFormat, jsStr);
            return new MvcHtmlString(content.ToString());
        }

        /// <summary>
        ///  加载css文件
        /// </summary>
        /// <param name="htmlHelper">需要扩展对象</param>
        /// <param name="jsFile">文件路径</param>
        /// <returns></returns>
        public static MvcHtmlString RenderCssFile(this HtmlHelper htmlHelper, params string[] cssFiles)
        {
            StringBuilder content = new StringBuilder();
            string executionFilePath = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Replace("~/", "");
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (!string.IsNullOrEmpty(executionFilePath))
            {
                int startindex = url.LastIndexOf(executionFilePath);
                url = url.Remove(startindex, url.Length - startindex);
            }
            string cssFile = "";
            foreach (string file in cssFiles)
            {
                if (cssFile != "")
                {
                    cssFile += ",";
                }
                cssFile += file;
            }

            string cssFormat = "<link href=\"{0}\" rel=\"stylesheet\" />";
            content.AppendFormat(cssFormat, url + "Utility/GetCssFile?filePath=" + cssFile);
            return new MvcHtmlString(content.ToString());
        }
        /// <summary>
        /// 往页面中写入css样式
        /// </summary>
        /// <param name="htmlHelper">需要扩展对象</param>
        /// <param name="cssFiles">文件路径</param>
        /// <returns></returns>
        public static MvcHtmlString AppendCssFile(this HtmlHelper htmlHelper, params string[] cssFiles)
        {
            StringBuilder content = new StringBuilder();
            string cssFormat = "<style>{0}</style>";
            string cssStr = JsCssHelper.ReadCssFile(cssFiles);
            content.AppendFormat(cssFormat, cssStr);
            return new MvcHtmlString(content.ToString());
        }

        #region 权限模块
        /// <summary>
        /// 获取当前页面的按钮
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString GetModuleButtonList(this HtmlHelper htmlHelper)
        {
            string currentUrl = (string)WebHelper.GetHttpItems("currentUrl");
            BusinessLogic.SysManage.ISys_ModuleButton _but = new  DataAccess.SysManage.Sys_ModuleButtonDAL();
            IEnumerable< Entity.SysManage.Sys_ModuleButton> buttonList = null;

            
            List<Entity.ModuleEntity> list = WebSecurityHelper.Passport.Current.MenuModuleList;
            Entity.ModuleEntity module = list.Find(t => t.F_UrlAddress == currentUrl);
            if (module == null)
            {
                buttonList = new List<Entity.SysManage.Sys_ModuleButton>();
            }
            else
            {
                buttonList = _but.GetButtonList(module.F_ModuleId);  //new ModuleBLL().GetButtonListByUrl(currentUrl);

                //查找 当前用户的权限->控件
                BusinessLogic.SysManage.ISys_Authorize _authorize = new  DataAccess.SysManage.Sys_AuthorizeDAL();
                IEnumerable<Entity.SysManage.Sys_Authorize> authorizeList = _authorize.GetList(WebSecurityHelper.Passport.Current.UserId.ToString(), 2);
          
            }

            Dictionary<string, string> dicButton = new Dictionary<string, string>();
            foreach (var item in buttonList)
            {
                if (!dicButton.ContainsKey(item.EnCode))
                {
                    dicButton.Add(item.EnCode, item.FullName);
                }
            }
            string strButtonList = dicButton.ToJson();
            return new MvcHtmlString("<script>var lrMouduleButtonList=" + strButtonList + "</script>");
        }
        /// <summary>
        /// 获取当前页面的列表
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString GetModuleColumnList(this HtmlHelper htmlHelper)
        {
            string currentUrl = (string)WebHelper.GetHttpItems("currentUrl");
            BusinessLogic.SysManage.ISys_ModuleColumn _but = new  DataAccess.SysManage.Sys_ModuleColumnDAL();
            IEnumerable< Entity.SysManage.Sys_ModuleColumn> columnList = null;

            List<Entity.ModuleEntity> list = WebSecurityHelper.Passport.Current.MenuModuleList;
            Entity.ModuleEntity module = list.Find(t => t.F_UrlAddress == currentUrl);
            if (module == null)
            {
                columnList = new List<Entity.SysManage.Sys_ModuleColumn>();
            }
            else
            {
                columnList = _but.GetColumnList(module.F_ModuleId);
            }

            //List<ModuleColumnEntity> columnList = new ModuleBLL().GetColumnListByUrl(currentUrl);
            Dictionary<string, string> dicColumn = new Dictionary<string, string>();
            foreach (var item in columnList)
            {
                if (!dicColumn.ContainsKey(item.EnCode))
                {
                    dicColumn.Add(item.EnCode.ToLower(), item.FullName);
                }
            }

            string strColumnList = dicColumn.ToJson();
            return new MvcHtmlString("<script>var lrMouduleColumnList=" + strColumnList + "</script>");
        }
        #endregion
    }
}