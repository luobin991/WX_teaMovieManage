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
    public class Goods
    {

        /// <summary>
        /// 商品
        /// </summary>
        private readonly I_Goods _goods;
        /// <summary>
        /// 类别
        /// </summary>
        private readonly I_Lable _lable;
        /// <summary>
        /// 构造函数
        /// </summary>
        public Goods()
        {
            if (_goods == null)
                this._goods = new GoodsDAL();

            if (_lable == null)
                this._lable = new LableDAL();

        }


        private static Goods current { get; set; }
        /// <summary>
        /// 当前凭据
        /// </summary>
        public static Goods Current
        {
            get
            {
                if (current == null)
                    current = new Goods();

                return current;
            }
        }

        private List<T_Lable> menus;

        public _Response GetMenus()
        {

            List<T_Lable> entity = this._lable.GetLables((int)Entity.Enum.RelateEnum.tea);
            menus = entity;
            _Response result = new _Response(true);
            result.body = entity;
            result.totalCount = entity.Count;

            return result;
        }

        public _Response GetTeaList()
        {
            List<T_MenuGoods> list = new List<T_MenuGoods>();
            if (menus == null)
            {
                menus = this._lable.GetLables((int)Entity.Enum.RelateEnum.tea);
            }
            foreach (var item in menus)
            {
                T_MenuGoods entity = new T_MenuGoods();
                entity.id = item.id;
                entity.lableName = item.lableName;
                entity.goods = this._goods.GetGoodsBypid(item.id);
                if (entity.goods != null)
                {
                    foreach (var goods in entity.goods)
                    {
                        if (!string.IsNullOrWhiteSpace(goods.img))
                        {
                            goods.img = Config.GetValue("BackGroundServer") + goods.img;
                        }
                        goods.lbs = this._lable.GetLables((int)Entity.Enum.RelateEnum.label, goods.id);

                    }
                }
                list.Add(entity);
            }

            _Response result = new _Response(true);
            result.body = list;
            result.totalCount = list.Count;

            return result;
        }



    }
}