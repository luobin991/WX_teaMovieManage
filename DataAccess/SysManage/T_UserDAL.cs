using Dapper;
using  BusinessLogic.SysManage;
using  Common.DBHelper;
using  Entity.Excel;
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
    /// 游戏用户实现
    /// </summary>
    public class T_UserDAL : IT_User
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public T_User GetUserInfo(string userId)
        {
            string sql = "select * from t_user where userId=@userId";
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                var user = conn.Query<T_User>(sql, new { userId = userId }).FirstOrDefault();
                return user;
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
       public  T_User GetUserByPhone(string phone)
        {
            string sql = "select * from t_user where phoneNum=@phone";
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                var user = conn.Query<T_User>(sql, new { phone = phone }).FirstOrDefault();
                return user;
            }
        }



        /// <summary>
        /// 获取游戏用户列表--分页
        /// </summary>
        /// <param name="user">条件信息Model</param>
        public List<T_User> GetUserList(T_User user)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                try
                {

                    DynamicParameters param;
                    StringBuilder sb;
                    GetSQL(user, out param, out sb);
                    //获取总记录数
                    string sqlCount = sb.ToString().Replace("select * ", "select count(1) totalCount ");

                    sb.Append(" order by "+ user.orderBy);
                    //分页
                    if (user.pageIndex >= 0 && user.pageSize > 0)
                    {
                        sb.Append(" limit " + ((user.pageIndex - 1) * user.pageSize) + "," + user.pageSize);
                    }
                    //分页记录列表
                    var list = conn.Query<T_User>(sb.ToString(), param).ToList();
                    if (list != null && list.Count() > 0)
                    {
                        //总记录数列表
                        dynamic identity = conn.Query(sqlCount, param).Single();
                        list[0].totalCount = Convert.ToInt64(identity.totalCount);
                        list[0].pageIndex = user.pageIndex;
                        list[0].pageSize = user.pageSize;
                    }
                    return list;
                    /*
                        一言以蔽之，就是越往后分页，LIMIT语句的偏移量就会越大，速度也会明显变慢。
                        此时，我们可以通过子查询的方式来提高分页效率，大致如下：
                       select * from sys_user where  id >=(select id from sys_user where id = 123 order by id limit 10000, 1) limit pageSize              
                     */

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }


        /// <summary>
        ///根据Id更新指定字段
        /// </summary>
        /// <param name="user">主键Id，更新字段值</param>
        /// <param name="attr">更新字段 数组</param>
        /// <returns></returns>
        public int UpdateUser(T_User user, string[] attr)
        {
            if (attr == null || attr.Length <= 0)
                return 0;
            var sb = new StringBuilder();
            sb.Append(" update t_user ");

            for (int i = 0; i < attr.Length; i++)
            {
                if (i == 0)
                    sb.Append(" set " + attr[i] + " = @" + attr[i]);
                else
                    sb.Append(" ," + attr[i] + "=@" + attr[i]);
            }
            sb.Append(" where userId = @userId");
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                return conn.Execute(sb.ToString(), user);
            }
        }

        /// <summary>
        /// 更新用户代理身份标识
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="isProxy"></param>
        public void UpdateIsProxy(int userid, bool isProxy)
        {
            T_User u = new T_User();
            u.userId = userid;
            u.isProxy = isProxy ? 1 : 0;
            string[] arr = new string[] { "isProxy" };

            UpdateUser(u, arr);
        }

        /// <summary>
        /// 获取SQL脚本
        /// </summary>
        /// <param name="user">条件信息Model</param>
        /// <param name="param">参数</param>
        /// <param name="sb">脚本字符串</param>
        private void GetSQL(T_User user, out DynamicParameters param, out StringBuilder sb)
        {
            param = new DynamicParameters();
            sb = new StringBuilder();
            sb.Append("select * from t_user us where 1=1 ");
            //用户名(手机号)
            if (!string.IsNullOrEmpty(user.nickName))
            {
                sb.Append(" and us.nickName like @nickName  or us.phoneNum like @nickName ");
                param.Add("@nickName", "%" + user.nickName.Trim() + "%");
            }


            //注册开始时间
            if (!string.IsNullOrEmpty(user.startDate))
            {
                sb.Append(" and us.registerTime>=@startDate ");
                param.Add("@startDate", user.startDate);
            }
            //注册结束时间
            if (!string.IsNullOrEmpty(user.endDate))
            {
                sb.Append(" and us.registerTime<=@endDate ");
                param.Add("@endDate", user.endDate);
            }
            //登录开始时间
            if (!string.IsNullOrEmpty(user.startDateLogin))
            {
                sb.Append(" and us.loginTime>=@startDateLogin ");
                param.Add("@startDateLogin", user.startDateLogin);
            }
            //登录结束时间
            if (!string.IsNullOrEmpty(user.endDateLogin))
            {
                sb.Append(" and us.loginTime<=@endDateLogin ");
                param.Add("@endDateLogin", user.endDateLogin);
            }

        }


        /// <summary>
        /// 根据用户组获取数据
        /// </summary>
        /// <param name="userArr"></param>
        /// <returns></returns>
        public List<T_User> GetAgentList(int[] userArr)
        {

            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {

                string sql = "SELECT* from t_user where  isProxy = 1";
                if (userArr.Length > 0)
                {
                    sql += " and userid in ( ";
                    foreach (var item in userArr)
                    {
                        sql += "'" + item + "',";
                    }
                    sql = sql.TrimEnd(',') + " ) ";
                }

                var list = conn.Query<T_User>(sql).ToList();

                return list;
            }
        }



    }
}
