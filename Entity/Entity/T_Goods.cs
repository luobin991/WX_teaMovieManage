using System;
using  Entity.Common;
using System.Collections.Generic;

namespace  Entity
{
    /// <summary>
    /// 商品信息
    /// </summary>
    public class T_Goods : SearchBase
    {
        public int id { get; set; }
        public int parentID { get; set; }
        public string img { get; set; }
        public string GoodsName { get; set; }
        public decimal Price { get; set; }
        public int status { get; set; }
        public string GoodsInfo { get; set; }

        public DateTime updateTime { get; set; }
        public DateTime createTime { get; set; }

        public string updateTimeStr { get { return updateTime.ToString("yyyy-MM-dd HH:mm"); } }
        public string createTimeStr { get { return createTime.ToString("yyyy-MM-dd HH:mm"); } }


        public string lables { get; set; }
        public List<T_Lable> lbs { get; set; }

    }



    /// <summary>
    /// 标签类
    /// </summary>
    public class T_MenuGoods : SearchBase
    {
        public int id { get; set; }
        public int typeid { get; set; }

        public string lableName { get; set; }

        public List<T_Goods> goods = new List<T_Goods>();

    }


}
