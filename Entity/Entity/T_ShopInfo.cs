using System;
using  Entity.Common;


namespace  Entity
{
    /// <summary>
    /// 店铺信息
    /// </summary>
    public class T_ShopInfo : SearchBase
    {
        public int id { get; set; }
        public string logo { get; set; }
        public string shopName { get; set; }
        public string shopPhone { get; set; }
        public string shopAddress { get; set; }
        public string shopCo_ordinate { get; set; }
        public string shopInfo { get; set; }
        public DateTime updateTime { get; set; }
        public DateTime createTime { get; set; }

        public string updateTimeStr { get { return updateTime.ToString("yyyy-MM-dd HH:mm"); } }
        public string createTimeStr { get { return createTime.ToString("yyyy-MM-dd HH:mm"); } }
    }


}
