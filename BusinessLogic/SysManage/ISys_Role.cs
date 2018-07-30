using  Entity.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  BusinessLogic.SysManage
{
    /// <summary>
    /// 角色接口
    /// </summary>
    public interface ISys_Role
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int AddRole(Sys_Role role);

        /// <summary>
        ///更新字段
        /// </summary>
        /// <param name="role">更新的实体</param>
        /// <returns></returns>
        int UpdateRole(Sys_Role role);


        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="report">报表条件obj</param>
        /// <returns></returns>
        List<Sys_Role> GetList(string keyword);


        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="report">报表条件obj</param>
        /// <returns></returns>
        List<Sys_Role> GetListPage(Sys_Role role);


        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="ID">主键</param>
        /// <param name="isDel">是否真删除</param>
        void DeleteRole(string ID, bool isDel);


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns></returns>
        Sys_Role GetRole(string ID);



        

    }
}
