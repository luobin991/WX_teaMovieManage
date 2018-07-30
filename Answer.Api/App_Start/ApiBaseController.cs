using System;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Caching;
using System.Web.Caching;

namespace Answer.Api
{
    [ControllerAllowOrigin(AllowSites = new string[] { "*" })]
    public class ApiBaseController : Controller
    {
        /// <summary>  
        /// 设置当前应用程序指定CacheKey的Cache值  
        /// </summary>  
        /// <param name="CacheKey">  
        /// <param name="objObject">  
        public static void SetCache<T>(string CacheKey, T objObject)
        {
            Cache objCache = HttpRuntime.Cache;

            //var cacheDependency = new CacheDependency();

            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>  
        /// 获取当前应用程序指定CacheKey的Cache值  
        /// </summary>  
        /// <param name="CacheKey">  
        /// <returns></returns>y  
        public static T GetCache<T>(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return (T)objCache[CacheKey];
        }


        public JsonResult Success(object obj)
        {
            var result = new JsonResult();

            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public JsonResult Fail(string msg, bool isGet = false)
        {
            var data = new
            {
                code = 0,//失败码
                msg = msg
            };
            var result = new JsonResult();
            result.Data = data;
            if (isGet)
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

    }

}