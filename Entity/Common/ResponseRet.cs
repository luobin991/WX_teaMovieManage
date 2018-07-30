using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Entity.Common
{
    public class ResponseRet
    {
        /// <summary>
        /// 游戏服务返回码
        /// </summary>
        public int ret { get; set; }

        public bool result { get { return ret == 0; } }
    }

}
