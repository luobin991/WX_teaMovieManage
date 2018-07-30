using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Entity;
using Common;
using BusinessLogic.Answer;
using DataAccess.Answer;
namespace Answer.Api.Areas.api.InterfaceBLL
{
    public class Shop
    {

        /// <summary>
        /// 俱乐部
        /// </summary>
        private readonly I_Shop _shop;
        /// <summary>
        /// 构造函数
        /// </summary>
        public Shop()
        {
            if (_shop == null)
                this._shop = new ShopDAL();
        }


        private static Shop current { get; set; }
        /// <summary>
        /// 当前凭据
        /// </summary>
        public static Shop Current
        {
            get
            {
                if (current == null)
                    current = new Shop();

                return current;
            }
        }

        /// <summary>
        /// 俱乐部成员信息
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public _Response GetShopInfo(string json)
        {
            //JObject obj = JObject.Parse(json);

            //int userid = Convert.ToInt32(obj["userid"]);

            T_ShopInfo entity = this._shop.GetShopinfo(1);
            if(entity!=null && !string.IsNullOrWhiteSpace(entity.logo))
            {
                if (!string.IsNullOrWhiteSpace(entity.logo))
                {
                    entity.logo = Config.GetValue("BackGroundServer") + entity.logo;
                }
            }

            _Response result = new _Response(true);
            result.body = entity;

            return result;
        }
    }
}