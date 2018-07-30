using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Entity.Enum
{
    public static class ReadonlyKey
    {

        /// <summary>
        /// 当前连接用户信息
        /// adms_operator_
        /// </summary>
        public static readonly string cacheKeyOperator = "adms_operator_";

        /// <summary>
        /// 登录者token
        /// adms_token_
        /// </summary>
        public static readonly string cacheKeyToken = "adms_token_";
        /// <summary>
        /// 错误标识
        /// adms_error_
        /// </summary>
        public static readonly string cacheKeyError = "adms_error_";

        /// <summary>
        /// 秘钥
        /// adms_token_
        /// </summary>
        public static readonly string LoginUserToken = "adms_token_";

        /// <summary>
        /// 标记登录的浏览器
        /// adms_mark_
        /// </summary>
        public static readonly string LoginUserMarkKey = "adms_mark_";

        /// <summary>
        /// 应用id
        /// adms_pc_
        /// </summary>
        public static readonly string LoginAppId = "adms_pc_";
    }
}
