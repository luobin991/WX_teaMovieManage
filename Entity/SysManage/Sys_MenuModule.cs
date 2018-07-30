using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Entity.SysManage
{
    /// <summary>
    ///菜单模块
    /// </summary>
    public class Sys_MenuModule
    {
        /// <summary>
        /// Id；主键、自增
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        ///父节点Id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string LinkUrl { get; set; }
        /// <summary>
        ///是否有效(1009001: 启用; 1009002: 禁用)
        /// </summary>
        public int Valid { get; set; }
        /// <summary>
        /// 样式名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyDate { get; set; }


        /// <summary>
        /// 图标名称
        /// </summary>
        public string icon { get; set; }


        /// <summary>
        /// 是否菜单选项
        /// </summary>
        public int ismenu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string target { get; set; }



    }
}
