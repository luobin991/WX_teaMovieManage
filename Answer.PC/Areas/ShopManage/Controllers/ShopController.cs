using System;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using Entity;
using Common;
using BusinessLogic.Answer;

namespace Answer.PC.Areas.ShopManage.Controllers
{
    public class ShopController : MvcControllerBase
    {
        private readonly I_Shop _shop;

        public ShopController(I_Shop shop)
        { this._shop = shop; }

        [HttpGet]
        public ActionResult Index()
        {
            T_ShopInfo model = this._shop.GetShopinfo(1);
            if (model == null)
            {
                model = new T_ShopInfo();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(model.logo))
                {
                    model.logo = new WebSecurityHelper.CommonController().GetURL("/Content/img/") + model.logo;
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            T_ShopInfo model = this._shop.GetShopinfo(id);
            if (model == null)
            {
                model = new T_ShopInfo();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(model.logo))
                {
                    model.logo = new WebSecurityHelper.CommonController().GetURL("/Content/img/") + model.logo;
                }
            }

            return View(model);
        }



        [HttpPost]
        public ActionResult SaveShopInfo(T_ShopInfo shop)
        {
            int result = 0;
            if (shop.id < 1)
            {
                shop.createTime = shop.updateTime = DateTime.Now;

                if (!string.IsNullOrWhiteSpace(shop.logo))
                {
                    string path = Server.MapPath("~/Content/img/");
                    path = Common.ImgBase64.Base64StringToImage(shop.logo, path);
                    shop.logo = path;
                }
                result = this._shop.SaveShopInfo(shop);
            }
            else
            {
                shop.updateTime = DateTime.Now;

                T_ShopInfo oldmodel = this._shop.GetShopinfo(shop.id);
                if (oldmodel.logo != shop.logo)
                {
                    if (shop.logo.Contains(oldmodel.logo))
                        shop.logo = oldmodel.logo;
                    else
                    {
                        string path = Server.MapPath("~/Content/img/");
                        string imgPath = Common.ImgBase64.Base64StringToImage(shop.logo, path);
                        shop.logo = imgPath;
                    }
                }
                result = this._shop.UpdateShopInfo(shop);
            }



            return Response(result);
        }

    }
}