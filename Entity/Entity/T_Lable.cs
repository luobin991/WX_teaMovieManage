using System;
using  Entity.Common;
using System.Collections.Generic;

namespace  Entity
{
    /// <summary>
    /// 标签类
    /// </summary>
    public class T_Lable:SearchBase
    {
        public int id { get; set; }
        public int typeid { get; set; }
        public string lableName { get; set; }
        public DateTime updateTime { get; set; }
        public DateTime createTime { get; set; }

        public string updateTimeStr { get { return updateTime.ToString("yyyy-MM-dd HH:mm"); } }
        public string createTimeStr { get { return createTime.ToString("yyyy-MM-dd HH:mm"); } }


        public string lableDetail { get; set; }
        public List<T_LableDetail> lbDetails { get; set; }

    }


    /// <summary>
    /// 标签
    /// </summary>
    public class T_LableDetail:SearchBase
    {
        public int id { get; set; }
        public int parentID { get; set; }
        
        public string lable { get; set; }
        public DateTime updateTime { get; set; }
        public DateTime createTime { get; set; }

        public string updateTimeStr { get { return updateTime.ToString("yyyy-MM-dd HH:mm"); } }
        public string createTimeStr { get { return createTime.ToString("yyyy-MM-dd HH:mm"); } }
    }




    }
