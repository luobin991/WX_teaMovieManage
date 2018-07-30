using System;
using System.Collections.Generic;
using  Entity.SysManage;

namespace  BusinessLogic.SysManage
{
    public interface ISys_ModuleButton
    {

        /// <summary>
        /// 获取按钮列表数据
        /// </summary>
        /// <param name="moduleId">模块Id</param>
        /// <returns></returns>
        IEnumerable<Sys_ModuleButton> GetButtonList(string moduleId);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int AddModuleButton(Sys_ModuleButton entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int UpdateModuleButton(Sys_ModuleButton entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ModuleId">主键</param>
        /// <returns></returns>
        int DeleteModuleButton(string ModuleId);

    }

}
