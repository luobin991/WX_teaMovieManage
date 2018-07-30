using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Entity.SysManage
{


    public class Sys_UserRelation
    {

        public string F_UserRelationId { get; set; }
        /// <summary>
        /// 分类:1-角色2-岗位
        /// </summary>
        public int F_Category { get; set; }

        /// <summary>
        /// 用户主键
        /// </summary>
        public string F_UserId { get; set; }

        /// <summary>
        ///对象主键
        /// </summary>
        public string  F_ObjectId { get; set; }

        public DateTime? F_CreateDate { get; set; }

        public string F_CreateUserId { get; set; }

        public string F_CreateUserName { get; set; }

    }


}
