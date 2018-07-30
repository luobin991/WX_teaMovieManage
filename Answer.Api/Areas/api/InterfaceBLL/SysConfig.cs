using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Entity;
using Common;
using System.Web.Mvc;

using System.Web;
namespace Answer.Api.Areas.api.InterfaceBLL
{
    public class SysConfig
    {


        private static SysConfig current { get; set; }
        /// <summary>
        /// 当前凭据
        /// </summary>
        public static SysConfig Current
        {
            get
            {
                if (current == null)
                    current = new SysConfig();

                return current;
            }
        }


        /// <summary>
        /// 获取图片地址
        /// </summary>
        /// <returns></returns>
        public _Response GetNoticeImgs()
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/NoticeImg");
            string[] imgurl = Common.FileHelper.Context().GetFileNames(path);
            for (int i = 0; i < imgurl.Count(); i++)
            {
                
                string tmpRootDir = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录

                string imagesurl2 = imgurl[i].Replace(tmpRootDir, ""); //转换成相对路径

                imagesurl2 = imagesurl2.Replace(@"\", @"/");
                
                imgurl[i] = HttpContext.Current.Request.Url.Scheme+"://"+HttpContext.Current.Request.Url.Authority + "/"+ imagesurl2;
            }

            _Response result = new _Response(true);
            result.body = imgurl;

            return result;
        }



    }
}