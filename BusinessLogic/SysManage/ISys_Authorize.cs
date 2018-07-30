using System;
using System.Collections.Generic;
using  Entity.SysManage;

namespace  BusinessLogic.SysManage
{
    public interface ISys_Authorize
    {
        /// <summary>
        /// 获取授权功能主键数据列表
        /// </summary>
        /// <param name="objectId">对象主键（角色,用户）</param>
        /// <param name="itemType">项目类型:1-菜单2-按钮3-视图</param>
        /// <returns></returns>
        IEnumerable<Sys_Authorize> GetList(string objectId, int itemType);

        /// <summary>
        /// 添加授权
        /// </summary>
        /// <param name="objectType">权限分类-1角色2用户</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <param name="createId">添加Id</param>
        void SaveAuthorize(int objectType, string objectId, string[] moduleIds, string[] moduleButtonIds, string[] moduleColumnIds, int createId);


    }
}
