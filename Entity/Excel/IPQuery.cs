using  Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Entity.Excel
{
    /// <summary>
    /// IP查询--导出
    /// </summary>
    public class IPQuery : SearchBase
    {
        /// <summary>
        /// 用户手机号
        /// </summary>
        [DisplayName("用户名")]
        public string phone_number { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        [DisplayName("注册时间")]
        public DateTime create_time { get; set; }
        /// <summary>
        /// 用户注册IP
        /// </summary>
        [DisplayName("用户注册IP")]
        public string registerIP { get; set; }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        [DisplayName("最后登录IP")]
        public string loginIP { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        [DisplayName("最后登录时间")]
        public DateTime login_time { get; set; }
    }
}
