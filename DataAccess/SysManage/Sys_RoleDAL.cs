using Dapper;
using  BusinessLogic.SysManage;
using  Common.DBHelper;
using  Entity.SysManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  DataAccess.SysManage
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Sys_RoleDAL : ISys_Role
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int AddRole(Sys_Role role)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string sql = @"INSERT INTO sys_Role(F_RoleId,F_Category,F_EnCode,F_FullName,F_SortCode,F_DeleteMark,F_EnabledMark,F_Description,F_CreateDate,F_CreateUserId,F_CreateUserName)
    VALUES(@F_RoleId, @F_Category, @F_EnCode, @F_FullName, @F_SortCode, @F_DeleteMark, @F_EnabledMark, @F_Description, @F_CreateDate, @F_CreateUserId, @F_CreateUserName); ";
                return conn.Execute(sql, role);
            }
        }


        /// <summary>
        ///更新字段
        /// </summary>
        /// <param name="role">更新的实体</param>
        /// <returns></returns>
        public int UpdateRole(Sys_Role role)
        {

            var sb = new StringBuilder();
            sb.Append(@" UPDATE sys_Role SET F_Category=@F_Category,F_EnCode=@F_EnCode,F_FullName=@F_FullName,F_SortCode=@F_SortCode,F_DeleteMark=@F_DeleteMark,
            F_EnabledMark = @F_EnabledMark, F_Description = @F_Description, F_ModifyDate = @F_ModifyDate, F_ModifyUserId = @F_ModifyUserId, F_ModifyUserName = @F_ModifyUserName
            WHERE F_RoleId = @F_RoleId; ");

            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                return conn.Execute(sb.ToString(), role);
            }
        }


        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="report">报表条件obj</param>
        /// <returns></returns>
        public List<Sys_Role> GetList(string keyword)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM sys_role where F_DeleteMark=0 and F_EnabledMark=1  ");
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sb.Append("and f_FullName LIKE @RoleName");
                    param.Add("@RoleName", keyword);
                }
                sb.Append(" ORDER BY  F_SortCode asc, F_RoleId ");
                //分页记录列表
                var list = conn.Query<Sys_Role>(sb.ToString(), param).ToList();

                return list;
            }
        }


        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="report">报表条件obj</param>
        /// <returns></returns>
        public List<Sys_Role> GetListPage(Sys_Role role)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM sys_role where F_DeleteMark=0 and F_EnabledMark=1  ");
                if (!string.IsNullOrWhiteSpace(role.F_FullName))
                {
                    sb.Append("and f_FullName LIKE @RoleName");
                    param.Add("@RoleName", role.F_FullName);
                }


                //获取总记录数
                string sqlCount = "SELECT COUNT(1) as totalCount from (" + sb.ToString() + " ) as tb";

                if (role.pageIndex > -1)
                {
                    if (!string.IsNullOrWhiteSpace(role.orderBy))
                    {
                        sb.Append(role.orderBy);
                    }
                    else
                        sb.Append(" ORDER BY  F_SortCode asc, F_RoleId ");
                    sb.Append(" limit " + ((role.pageIndex - 1) * role.pageSize) + "," + role.pageSize);
                }

                //分页记录列表
                var list = conn.Query<Sys_Role>(sb.ToString(), param).ToList();
                if (list != null && list.Count() > 0)
                {
                    //总记录数列表
                    dynamic identity = conn.Query(sqlCount, param).Single();
                    list[0].totalCount = Convert.ToInt64(identity.totalCount);
                    list[0].pageIndex = role.pageIndex;
                    list[0].pageSize = role.pageSize;
                }

                return list;
                /*
                    一言以蔽之，就是越往后分页，LIMIT语句的偏移量就会越大，速度也会明显变慢。
	                此时，我们可以通过子查询的方式来提高分页效率，大致如下：
                   select * from sys_user where  id >=(select id from sys_user where id = 123 order by id limit 10000, 1) limit pageSize              
                 */
            }
        }


        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="ID">主键</param>
        /// <param name="isDel">是否真删除</param>
        public void DeleteRole(string ID, bool isDel)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string sql = string.Empty;

                if (isDel)
                    sql = "DELETE FROM sys_role WHERE F_RoleId=@role";
                else
                    sql = "UPDATE sys_role SET F_DeleteMark=1  WHERE F_RoleId=@role";

                conn.Execute(sql, new { role = ID });
            }
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns></returns>
        public Sys_Role GetRole(string ID)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                var sb = new StringBuilder();
                sb.Append(" SELECT * FROM sys_role where F_RoleId=@RoleID;");
                var obj = conn.Query<Sys_Role>(sb.ToString(), new { RoleID = ID }).FirstOrDefault();
                return obj;
            }
        }



    }
}
