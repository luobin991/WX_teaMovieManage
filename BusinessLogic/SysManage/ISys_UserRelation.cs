using System;
using System.Collections.Generic;
using  Entity.SysManage;

namespace  BusinessLogic.SysManage
{
    public interface ISys_UserRelation
    {

        /// <summary>
        /// 获取对象主键列表信息
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="category">分类:1-角色2-岗位</param>
        /// <returns></returns>
        IEnumerable<Sys_UserRelation> GetObjectIdList(string userId, int category);

        /// <summary>
        /// 获取用户主键列表信息
        /// </summary>
        /// <param name="objectId">用户主键</param>
        /// <returns></returns>
        IEnumerable<Sys_UserRelation> GetUserIdList(string objectId);

        /// <summary>
        /// 获取用户角色列表信息
        /// </summary>
        /// <param name="objectId">用户主键</param>
        /// <returns></returns>
        IEnumerable<Sys_UserRelation> GetRoleIdList(string UserId);


        /// <summary>
        /// 保存用户对应对象数据
        /// </summary>
        /// <param name="userRelationEntityList">列表</param>
        void SaveEntityList(string objectId, List<Sys_UserRelation> userRelationEntityList);


    }

}
