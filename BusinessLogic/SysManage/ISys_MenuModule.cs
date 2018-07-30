using  Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  BusinessLogic.SysManage
{
    /// <summary>
    /// 菜单模块接口
    /// </summary>
    public interface ISys_MenuModule
    {


        /// <summary>
        /// 菜单模块实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        ModuleEntity GetModuleEntity(string keyValue);

        /// <summary>
        /// 获取菜单模块列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<ModuleEntity> GetMenuList();

        /// <summary>
        /// 根据Id获取菜单模块列表
        /// </summary>
        /// <param name="valid">菜单状态</param>
        /// <returns></returns>
        IEnumerable<ModuleEntity> GetMenuList(int valid);

        /// <summary>
        /// 根据UserId获取菜单模块列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        List<ModuleEntity> GetMenuList(string userid);

        /// <summary>
        /// 根据Id获取菜单模块列表
        /// </summary>
        /// <param name="valid">菜单状态</param>
        /// <param name="idArray">菜单ID列表</param>
        /// <returns></returns>
        IEnumerable<ModuleEntity> GetMenuList(int valid, string idArray, string userid);

        /// <summary>
        /// 查询目录
        /// </summary>
        /// <param name="keyword">目录关键字</param>
        /// <param name="parentId">父级ID</param>
        /// <returns></returns>
        IEnumerable<ModuleEntity> GetModuleListByParentId(string keyword, string parentId);



        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int AddModuleEntity(ModuleEntity entity);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int UpdateModuleEntity(ModuleEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="F_ModuleId">主键</param>
        /// <param name="isTuer">是否真删除</param>
        /// <returns></returns>
        int DeleteModuleEntity(string F_ModuleId, bool isTuer);


    }
}
