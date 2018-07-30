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
    public class Order
    {

        /// <summary>
        /// 俱乐部
        /// </summary>
        private readonly I_Order _order;
        /// <summary>
        /// 构造函数
        /// </summary>
        public Order()
        {
            if (_order == null)
                this._order = new OrderDAL();
        }


        private static Order current { get; set; }
        /// <summary>
        /// 当前凭据
        /// </summary>
        public static Order Current
        {
            get
            {
                if (current == null)
                    current = new Order();

                return current;
            }
        }

        public _Response CreateOrder(string json)
        {
            //JObject obj = JObject.Parse(json);
            //int num = Convert.ToInt32(obj["num"]);
            T_orderDetail list =     JSONHelper.JsonToObject<T_orderDetail>(json);

            T_Order order = T_Order.createEntiy();
            order.orderNumber = list.num;
            order.orderSumPrice = list.sumPrice;
            order.orderUser = list.user.userID;
            order.orderUserName = list.user.userName;
            order.orderUserPhone = list.user.userPhone;
            order.orderUserAdder = list.user.userAddress;

            int result= _order.SaveOrder(order);
            if(result>0)
            {
                foreach (var item in list.list)
                {
                    item.orderid = result;
                    item.GoodsInfoStr = string.Join(",", item.GoodsInfo);
                    item.createTime = DateTime.Now;
                    _order.SaveOrderDetail(item);
                }
            }

            _Response response = new _Response(true);
            response.body = "数据保存成功";

            return response;
        }


        public List<T_Order> GetOrderPage(string json)
        {
            JObject obj = JObject.Parse(json);

            int pageIndex = Convert.ToInt32(obj["pageIndex"]);
            string userName = obj["userName"].ToString();

            List<T_Order> orders = this._order.GetOrderPage(pageIndex, userName);

            foreach (var order in orders)
            {
                order.list = this._order.GetOrderDetail(order.id).ToList();
            }

            return orders;
        }






    }
}