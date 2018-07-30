using Dapper;
using  BusinessLogic.SysManage;
using  Common;
using  Common.DBHelper;
using  Entity.SysManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace  DataAccess.SysManage
{
    public class Sys_ModuleColumnDAL: ISys_ModuleColumn
    {

        /// <summary>
        /// 获取视图列表数据
        /// </summary>
        /// <param name="moduleId">模块Id</param>
        /// <returns></returns>
        public IEnumerable<Sys_ModuleColumn> GetColumnList(string moduleId)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT * FROM Sys_ModuleColumn t WHERE t.ModuleId = @moduleId ORDER BY t.SortCode ");
                var Sys_ModuleColumnList = conn.Query<Sys_ModuleColumn>(strSql.ToString(), new { moduleId = moduleId });
                return Sys_ModuleColumnList;
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int AddModuleColumn(Sys_ModuleColumn entity)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"INSERT INTO sys_modulecolumn (ModuleColumnId,ModuleId,ParentId,EnCode,FullName,SortCode,Description)
VALUES (@ModuleColumnId,@ModuleId,@ParentId,@EnCode,@FullName,@SortCode,@Description);");

                var num = conn.Execute(sb.ToString(), entity);
                return num;
            }
        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpdateModuleColumn(Sys_ModuleColumn entity)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"UPDATE sys_modulecolumn SET ModuleId=@ModuleId,ParentId=@ParentId,EnCode=@EnCode,FullName=@FullName,SortCode=@SortCode,Description=@Description WHERE ModuleColumnId=@ModuleColumnId;");

                var num = conn.Execute(sb.ToString(), entity);
                return num;
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ModuleId">关联主键</param>
        /// <returns></returns>
        public int DeleteModuleColumn(string ModuleId)
        {
            string sql = " DELETE FROM sys_modulecolumn  WHERE ModuleId=@ModuleId; ";

            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                var num = conn.Execute(sql, new { ModuleId = ModuleId });
                return num;
            }
        }

        


    }
}
