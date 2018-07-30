using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Common
{ /// <summary>
  /// 数据字典Code
  /// </summary>
    public struct StructDictCode
    {

        #region 后台配置


        /// <summary>
        /// 用户类型1007
        /// </summary>
        public struct 用户类型
        {
            public const int 超级管理员 = 1007001;

            public const int 普通管理员 = 1007002;
        }
        /// <summary>
        /// 系统状态
        /// </summary>
        public struct 状态
        {
            public const int 正常 = 1;

            public const int 注销 = 0;

            public const string 成功 = "1";

            public const string 失败 = "0";
        }
        /// <summary>
        /// 分类
        /// </summary>
        public struct 分类
        {
            public const int 登陆 = 1;
            public const int 访问 = 2;
            public const int 操作 = 3;
            public const int 异常 = 4;
        }
        /// <summary>
        /// 站内信状态1010
        /// </summary>
        public struct 站内信状态
        {
            public const int 未读 = 1010001;

            public const int 已读 = 1010002;
        }

        /// <summary>
        /// 报表类型
        /// </summary>
        public struct 报表类型
        {
            public const int 会员 = 1;

            public const int 团队 = 2;
        }
        #endregion

        /// <summary>
        /// Json状态码
        /// </summary>
        public struct Json状态码
        {
            public const int 失败 = 0;

            public const int 成功 = 1;

            public const int 网络异常 = -99;
        }
    }
}
