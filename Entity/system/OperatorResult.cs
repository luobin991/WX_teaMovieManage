using System;
using  Entity.SysManage;

namespace  Entity.system
{
    /// <summary>
    /// 日 期：2017.11.08
    /// 描 述：当前连接用户信息返回数据
    /// </summary>
    public class OperatorResult
    {
        /// <summary>
        /// 状态码-1未登录,1登录成功,0登录过期
        /// </summary>
        public int stateCode { get; set; }
        /// <summary>
        /// 登录者用户信息
        /// </summary>
        public Sys_LoginLog userInfo { get; set; }
    }

}
