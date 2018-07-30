using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using  Common;
using  Entity;
using  Entity.SysManage;
using  BusinessLogic.SysManage;
using Answer.PC.WebSecurityHelper;

namespace Answer.PC.Controllers
{
    public class HomeController : MvcControllerBase
    {
      

        /// <summary>
        /// 首页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string learn_UItheme = WebHelper.GetCookie("L2017_UItheme");
            switch (learn_UItheme)
            {
                case "1":
                    return View("AdminDefault");      // 经典版本
                case "2":
                    return View("AdminAccordion");    // 手风琴版本
                case "3":
                    return View("AdminWindos");       // Windos版本
                case "4":
                    return View("AdminTop");          // 顶部菜单版本
                default:
                    return View("AdminDefault");      // 经典版本
            }
        }
        /// <summary>
        /// 首页桌面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktop()
        {
            return View();
        }
        /// <summary>
        /// 首页模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktopTemp()
        {
            return View();
        }


        #region 清空缓存
        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult ClearRedis()
        {
            //for (int i = 0; i < 16; i++)
            //{
            //    cache.RemoveAll(i);
            //}
            return Success("清空成功");
        }
        #endregion


        /// <summary>
        /// 访问功能
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <param name="moduleName">功能模块</param>
        /// <param name="moduleUrl">访问路径</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult VisitModule(string moduleName, string moduleUrl)
        {
            return Success("ok");
        }

    }
}