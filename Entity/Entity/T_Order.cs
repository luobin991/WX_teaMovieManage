using System;
using  Entity.Common;
using System.Collections.Generic;

namespace  Entity
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public class T_Order : SearchBase
    {
        public int id { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string orderNum { get; set; }
        /// <summary>
        /// 交易单号
        /// </summary>
        public string tradingNum { get; set; }
        /// <summary>
        /// 商户单号
        /// </summary>
        public string merchantCode { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime orderTime { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string orderStatus { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public int orderNumber { get; set; }
        /// <summary>
        /// 订单总价
        /// </summary>
        public int orderSumPrice { get; set; }
        /// <summary>
        /// 订单用户ID
        /// </summary>
        public string orderUser { get; set; }
        /// <summary>
        /// 订单用户名
        /// </summary>
        public string orderUserName { get; set; }
        /// <summary>
        /// 订单用户电话
        /// </summary>
        public string orderUserPhone { get; set; }
        /// <summary>
        /// 订单用户地址
        /// </summary>
        public string orderUserAdder { get; set; }
        /// <summary>
        /// 是否外送 默认0
        /// </summary>
        public int isOutside { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }

        public string createTimeStr { get { return createTime.ToString("yyyy-MM-dd HH:mm"); } }

        public static T_Order createEntiy()
        {
            T_Order order = new T_Order();
            order.id = 0;
            order.orderNum = Guid.NewGuid().ToString("N");
            order.tradingNum = DateTime.Now.Ticks.ToString();// TimeZone.CurrentTimeZone.ToLocalTime( DateTime.Now);
            order.merchantCode = "CNL"+ DateTime.Now.Ticks.ToString();
            order.orderTime = DateTime.Now;
            order.orderStatus = "待取";
            order.orderNumber = 0;
            order.orderSumPrice = 0;
            order.orderUser = "orderUser";
            order.orderUserName = "orderUserName";
            order.orderUserPhone = "orderUserPhone";
            order.orderUserAdder = "orderUserAdder";
            order.isOutside = 0;
            order.createTime = DateTime.Now;

            return order;
        }

        public List<T_orderList> list { get; set; }
    }




    public class  T_orderDetail
    {
        /// <summary>
        /// 订单数量
        /// </summary>
        public int num { get; set; }
        /// <summary>
        /// 订单明细
        /// </summary>
        public int sumPrice { get; set; }
        /// <summary>
        /// 订单明细
        /// </summary>
        public List<T_orderList> list { get; set; }

        public T_OrderUser user { get; set; }
    }


    public class T_orderList
    {

        /// <summary>
        /// 属于T_Order ID
        /// </summary>
        public int orderid { get; set; }

        /// <summary>
        /// 属于那个菜单类下标  
        /// </summary>
        public int details { get; set; }
        /// <summary>
        /// 菜单类下菜单下标
        /// </summary>
        public int rightIndex { get; set; }
        
        /// <summary>
        /// 订单名
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 订单说明
        /// </summary>
        public string[] GoodsInfo { get; set; }
        public string GoodsInfoStr { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int num { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public int SumPrice { get; set; }


        public DateTime createTime { get; set; }
    }


    /// <summary>
    /// 订单 的用户
    /// </summary>
    public class T_OrderUser
    {
        public string userID { get; set; }

        public string userName { get; set; }

        public string userPhone { get; set; }

        public string userAddress { get; set; }
    }

}
