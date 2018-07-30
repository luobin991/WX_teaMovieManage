using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Entity.SysManage
{
    public class Sys_Authorize
    {

        public string authorizeId { get; set; }

        /// <summary>
        /// 对象分类:1-角色2-用户
        /// </summary>
        public int objectType { get; set; }

        /// <summary>
        /// 对象主键
        /// </summary>
        public string objectId { get; set; }

        /// <summary>
        /// 项目类型:1-菜单2-按钮3-视图
        /// </summary>
        public int itemType { get; set; }
        /// <summary>
        /// 项目主键
        /// </summary>
        public string itemId { get; set; }

        public DateTime createDate { get; set; }

        public int createUserId { get; set; }

       

    }
}
