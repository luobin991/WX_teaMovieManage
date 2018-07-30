using  Entity.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  BusinessLogic.SysManage
{
    /// <summary>
    /// 登录日志接口
    /// </summary>
    public interface ISys_Log
    {
        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        int AddLog(Sys_Log log);



        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="categoryId">日志分类Id</param>
        /// <param name="keepTime">保留时间段内</param>
        void RemoveLog(int categoryId, string keepTime);


        /// <summary>
        /// 日志实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        Sys_Log GetEntity(string keyValue);


        /// <summary>
        /// 获取日志--分页
        /// </summary>
        /// <param name="user">条件信息Model</param>
        List<Sys_Log> GetLogPage(Sys_Log log);





    }
}
