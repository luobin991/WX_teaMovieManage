using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Entity.SysManage
{
    /// <summary>
    /// 登录日志
    /// </summary>
    public class Sys_LoginLog
    {
        /// <summary>
        /// 主键、自增
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 系统用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 登录唯一标识
        /// </summary>
        public string LoginGuid { get; set; }
        /// <summary>
        /// 浏览器类型
        /// </summary>
        public string BrowserType { get; set; }
        /// <summary>
        /// 创建时间(登录时间)
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 修改时间(退出时间)
        /// </summary>
        public DateTime ModifyDate { get; set; }
    }
}
