using System;
using System.Collections.Generic;
using  Entity.SysManage;
namespace  BusinessLogic.SysManage
{
    public interface ISys_ModuleColumn
    {
        /// <summary>
        /// 获取视图列表数据
        /// </summary>
        /// <param name="moduleId">模块Id</param>
        /// <returns></returns>
        IEnumerable<Sys_ModuleColumn> GetColumnList(string moduleId);


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int AddModuleColumn(Sys_ModuleColumn entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int UpdateModuleColumn(Sys_ModuleColumn entity);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ModuleColumnId">主键</param>
        /// <returns></returns>
        int DeleteModuleColumn(string ModuleColumnId);

    }


}
