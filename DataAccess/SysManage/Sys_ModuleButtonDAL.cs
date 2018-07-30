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


    public class Sys_ModuleButtonDAL : ISys_ModuleButton
    {
        /// <summary>
        /// 获取按钮列表数据
        /// </summary>
        /// <param name="moduleId">模块Id</param>
        /// <returns></returns>
        public IEnumerable<Sys_ModuleButton> GetButtonList(string moduleId)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT * FROM Sys_ModuleButton t WHERE t.ModuleId = @moduleId ORDER BY t.SortCode ");
                var Sys_ModuleButtonList = conn.Query<Sys_ModuleButton>(strSql.ToString(), new { moduleId = moduleId });
                return Sys_ModuleButtonList;
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int AddModuleButton(Sys_ModuleButton entity)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"INSERT INTO sys_modulebutton (ModuleButtonId,ModuleId,ParentId,Icon,EnCode,FullName,ActionAddress,SortCode)
        VALUES (@ModuleButtonId,@ModuleId,@ParentId,@Icon,@EnCode,@FullName,@ActionAddress,@SortCode);");

                var num = conn.Execute(sb.ToString(), entity);
                return num;
            }
        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpdateModuleButton(Sys_ModuleButton entity)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"UPDATE sys_modulebutton SET ModuleId=@ModuleId,ParentId=@ParentId,Icon=@Icon,EnCode=@EnCode,FullName=@FullName,ActionAddress=@ActionAddress,SortCode=@SortCode WHERE ModuleButtonId=@ModuleButtonId; ");

                var num = conn.Execute(sb.ToString(), entity);
                return num;
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ModuleId">关联主键</param>
        /// <returns></returns>
        public int DeleteModuleButton(string ModuleId)
        {
            string sql = " DELETE FROM sys_modulebutton WHERE ModuleId=@ModuleId; ";

            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                var num = conn.Execute(sql, new { ModuleId = ModuleId });
                return num;
            }
        }

    }
}
