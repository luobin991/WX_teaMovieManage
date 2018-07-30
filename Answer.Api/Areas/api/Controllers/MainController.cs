using System;
using System.Web;
using System.Web.Mvc;
using Entity.SysManage;
using Common;
using Answer.Api.Areas.api.InterfaceBLL;

namespace Answer.Api.Areas.api.Controllers
{
    public partial class MainController : ApiBaseController
    {


        //根据方法调取接口
        [HttpGet]
        public JsonResult GetData(string functionname, string body)
        {
            

            //T_User user = GetCache<T_User>("session_user");

            switch (functionname)
            {


                case "GetNoticeImgs": //起始界面图
                    return Success(SysConfig.Current.GetNoticeImgs());

                case "GetMenus":
                    return Success(Goods.Current.GetMenus());
                case "GetTeaList":
                    return Success(Goods.Current.GetTeaList());

                case "GetShopInfo": //获取当前代理购买钻石情况
                    return Success(Shop.Current.GetShopInfo(body));


                case "GetOrderPage":
                    return Success(Order.Current.GetOrderPage(body));

                case "GeTxtPage": //获取当前代理购买钻石情况
                    return Success(youdao.Current.GeTxtPage(body));

                default:
                    return Fail("未知请求！", true);
            }

        }

        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="functionname"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PostData(string functionname, string body)
        {
            //T_User user = GetCache<T_User>("session_user");

            switch (functionname)
            {
                case "CreateOrder":  // 创建订单
                    return Success(Order.Current.CreateOrder(body));

                default:
                    return Fail("未知请求！", true);
            }
        }



    }

}