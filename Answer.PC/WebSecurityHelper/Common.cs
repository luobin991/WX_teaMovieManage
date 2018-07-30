using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Answer.PC.WebSecurityHelper
{
    public class CommonController : Controller
    {

        public string GetURL(string path)
        {
            string scheme = System.Web.HttpContext.Current.Request.Url.Scheme;
            string Host = System.Web.HttpContext.Current.Request.Url.Host;
            string Port = System.Web.HttpContext.Current.Request.Url.Port.ToString();
            return scheme + "://" + Host+":" + Port+"/"+path;
        }

        /// <summary>
        /// 本地路径转换成URL相对路径
        /// </summary>
        /// <param name="imagesurl1"></param>
        /// <returns></returns>
        public string urlconvertor(string imagesurl1)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = imagesurl1.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl2 = imagesurl2.Replace(@"\", @"/");
            return imagesurl2;
        }
        /// <summary>
        /// 相对路径转换成服务器本地物理路径
        /// </summary>
        /// <param name="imagesurl1"></param>
        /// <returns></returns>
        public string urlconvertorlocal(string imagesurl1)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = tmpRootDir + imagesurl1.Replace(@"/", @"\"); //转换成绝对路径
            return imagesurl2;
        }


    }
}