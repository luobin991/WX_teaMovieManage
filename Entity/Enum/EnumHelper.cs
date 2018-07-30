using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Entity.Enum
{
    public class EnumHelper
    {

        /// <summary>
        /// 返回状态码
        /// </summary>
        public enum ReturnStatus
        {

            /// <summary>
            /// 成功
            /// </summary>
            success = 1,
            /// <summary>
            /// 无数据
            /// </summary>
            noData = 0,
            /// <summary>
            /// 失败
            /// </summary>
            fail = -1,
            /// <summary>
            /// 网络异常
            /// </summary>
            internetException = -99

        }


        



    }
}
