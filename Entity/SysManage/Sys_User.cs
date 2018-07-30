using System;
using Entity.Common;

namespace Entity.SysManage
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public class Sys_User :  SearchBase
    {
        /// <summary>
        /// 用户Id；主键、自增
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassWord { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNickName { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }
        /// <summary>
        /// 注册IP地址
        /// </summary>
        public string RegistIP { get; set; }
        /// <summary>
        /// 是否有效(1009001: 启用; 1009002: 禁用)
        /// </summary>
        public int Valid { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginDate { get; set; }
        /// <summary>
        /// 登录IP地址
        /// </summary>
        public string LoginIP { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyDate { get; set; }
        /// <summary>
        /// 所属角色
        /// </summary>
        public String Roles { get; set; }
    }
}
