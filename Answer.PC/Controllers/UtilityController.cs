using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  Common;
using  Entity;

namespace Answer.PC.Controllers
{
    public class UtilityController : Controller
    {
        #region 加载js和css文件
        /// <summary>
        /// 获取js文件
        /// </summary>
        /// <param name="filePath">文件地址</param>
        [HttpGet]
        public void GetJSFile(string filePath)
        {
            JsCssHelper.DownJSFile(filePath);
        }
        /// <summary>
        /// 获取css文件
        /// </summary>
        /// <param name="filePath">文件地址</param>
        [HttpGet]
        public void GetCssFile(string filePath)
        {
            JsCssHelper.DownCssFile(filePath);
        }
        #endregion


        /// <summary>
        /// 图标的选择
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerLogin(FilterMode.Enforce)]
        public ActionResult Icon()
        {
            return View();
        }




    }
}