using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.youdao
{
    public class youdaoQusery
    {
        public int id { get; set; }

        public string queryTxt { get; set; }


        public string responseJson { get; set; }


        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

    }
}
