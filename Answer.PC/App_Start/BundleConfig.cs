using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Answer.PC
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region 后台引用公共CSS 压缩
            bundles.Add(new StyleBundle("~/Css/CommonCss")

            );
            #endregion

            #region 后台引用公共Js 压缩
            bundles.Add(new ScriptBundle("~/Scripts/CommonJs")

                );
            #endregion
        }

    }
}