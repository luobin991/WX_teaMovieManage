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
    /// 系统用户实现类
    /// </summary>
    public class Sys_UserDAL : ISys_User
    {

        /// <summary>
        /// 获取系统用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Sys_User> GetUserList(int pageIndex, int pageSize, string keyword)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                var sb = new StringBuilder();
                sb.Append("select * from sys_user ");
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sb.Append(" where UserName LIKE @keyword or  UserNickName LIKE @keyword");
                    param.Add("@keyword", "%" + keyword.Trim() + "%");
                }
                //分页
                if (pageIndex >= 0 && pageSize > 0)
                {
                    sb.Append(" limit " + ((pageIndex - 1) * pageSize) + "," + pageSize);
                }

                //获取总记录数
                string sqlCount = sb.ToString().Replace("select * ", "select count(1) totalCount ");
                /*
                    一言以蔽之，就是越往后分页，LIMIT语句的偏移量就会越大，速度也会明显变慢。
	                此时，我们可以通过子查询的方式来提高分页效率，大致如下：
                   select * from sys_user where  id >=(select id from sys_user where id = 123 order by id limit 10000, 1) limit pageSize              
                 */

                var user = conn.Query<Sys_User>(sb.ToString(), param).ToList();
                if (user != null && user.Count() > 0)
                {
                    //总记录数列表
                    dynamic identity = conn.Query(sqlCount, param).Single();
                    user[0].totalCount = Convert.ToInt64(identity.totalCount);
                    user[0].pageIndex = pageIndex;
                    user[0].pageSize = pageSize;
                }
                return user;
            }
        }


        /// <summary>
        /// 获取系统用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Sys_User> GetUserList(string keyword)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                var sb = new StringBuilder();
                sb.Append("select * from sys_user ");
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sb.Append(" where UserName LIKE @keyword or  UserNickName LIKE @keyword");
                    param.Add("@keyword", "%" + keyword.Trim() + "%");
                }
                
                var user = conn.Query<Sys_User>(sb.ToString(), param).ToList();
                return user;
            }
        }



        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(Sys_User user)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                var param = new DynamicParameters();
                param.Add("$UserName", user.UserName);
                param.Add("$UserPassWord", user.UserPassWord);
                param.Add("$UserNickName", user.UserNickName);
                param.Add("$UserType", user.UserType);
                param.Add("$RegistIP", user.RegistIP);
                param.Add("$Valid", user.Valid);
                param.Add("$NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                conn.Execute("Pro_AddUser", param, null, null, CommandType.StoredProcedure);
                int outPutId = param.Get<int>("$NewId");
                return outPutId;
            }
        }

        /// <summary>
        /// 根据用户名称和密码获取管理员信息
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPwd">用户密码</param>
        /// <returns></returns>
        public Sys_User GetUserInfo(string userName, string userPwd)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                var user = conn.Query<Sys_User>("Pro_GetUserInfo", new { UName = userName, UPwd = userPwd }, null, true, null, CommandType.StoredProcedure).FirstOrDefault();
                return user;
            }
        }

        /// <summary>
        /// 根据用户Id获取管理员信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public Sys_User GetUserInfoById(int userId)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                var user = conn.Query<Sys_User>("Pro_GetUserInfoById", new { UId = userId }, null, true, null, CommandType.StoredProcedure).FirstOrDefault();
                return user;
            }
        }
        /// <summary>
        /// 根据用户Id更新用户登录信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="userIP">IP地址</param>
        /// <returns></returns>
        public int UpdateUserLoginInfo(int userId, string userIP)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                int result = conn.Execute("Pro_UpdateUserLoginInfo", new { UId = userId, UIP = userIP }, null, null, CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// 根据用户Id更新密码
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="newPwd">新密码</param>
        /// <returns></returns>
        public int UpdateUserPWd(int userId, string newPwd)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                int result = conn.Execute("Pro_UpdateUserPWd", new { UId = userId, PWd = newPwd }, null, null, CommandType.StoredProcedure);
                return result;
            }
        }
        /// <summary>
        /// 根据用户Id更新状态
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="valid">用户状态</param>
        /// <returns></returns>
        public int UpdateUserValid(int userId, int valid)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                int result = conn.Execute("Pro_UpdateUserValid", new { UId = userId, VId = valid }, null, null, CommandType.StoredProcedure);
                return result;
            }
        }


        /// <summary>
        /// 判断登录账号是否存在
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public int ExistsName(string loginName)
        {
            string sql = "SELECT COUNT(0) FROM sys_user where UserName=@name";
            var param = new DynamicParameters();
            param.Add("@name", loginName);
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                int number = conn.Execute(sql, param);
                return number;
            }
        }

    }
}
