using  BusinessLogic.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Entity.SysManage;
using System.Data;
using  Common.DBHelper;
using Dapper;

namespace  DataAccess.SysManage
{
    /// <summary>
    /// 日志实现
    /// </summary>
    public class Sys_LogDAL: ISys_Log
    {
        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public int AddLog(Sys_Log log)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                //var param = new DynamicParameters();
                string sql = @"insert into sys_log (F_LogId,F_CategoryId,F_OperateUserId,F_OperateTime,F_OperateAccount,F_OperateTypeId,F_OperateType,F_Module,F_IPAddress,F_Host,F_Browser,F_ExecuteResult,F_ExecuteResultJson,F_DeleteMark)
VALUES (@F_LogId,@F_CategoryId,@F_OperateUserId,@F_OperateTime,@F_OperateAccount,@F_OperateTypeId,@F_OperateType,@F_Module,@F_IPAddress,@F_Host,@F_Browser,@F_ExecuteResult,@F_ExecuteResultJson,@F_DeleteMark);";
                int result = conn.Execute(sql, log);
                return result;
            }
        }



        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="categoryId">日志分类Id</param>
        /// <param name="keepTime">保留时间段内</param>
        public void RemoveLog(int categoryId, string keepTime)
        {
            DateTime operateTime = DateTime.Now;
            if (keepTime == "7")//保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == "1")//保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == "3")//保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }

            string del = "DELETE FROM sys_log WHERE F_CategoryId=@F_CategoryId and F_OperateTime<=@time;";
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                conn.Execute(del, new { F_CategoryId = categoryId, time = operateTime });
            }

        }




        /// <summary>
        /// 日志实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Sys_Log GetEntity(string keyValue)
        {

            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string sql = "select * FROM sys_log WHERE F_LogId=@ID;";

                return conn.Query<Sys_Log>(sql, new { ID = keyValue }).FirstOrDefault();
            }
        }


        /// <summary>
        /// 获取日志--分页
        /// </summary>
        /// <param name="user">条件信息Model</param>
        public List<Sys_Log> GetLogPage(Sys_Log log)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    StringBuilder sb = new StringBuilder();

                    sb.Append("select * FROM sys_log where 1=1 ");

                    if (log.F_CategoryId>0)
                    {
                        sb.Append(" and F_CategoryId =@F_CategoryId ");
                        param.Add("@F_CategoryId", log.F_CategoryId);
                    }

                    if (!string.IsNullOrWhiteSpace(log.F_Module))
                    {
                        sb.Append(" and ( F_Module like @F_Module or F_ExecuteResultJson like @F_ExecuteResultJson  or F_OperateAccount like @F_OperateAccount ) ");

                        param.Add("@F_Module", log.F_Module);
                        param.Add("@F_ExecuteResultJson", log.F_Module);
                        param.Add("@F_OperateAccount", log.F_Module);
                    }

                    if (!string.IsNullOrWhiteSpace(log.startDate))
                    {
                        sb.Append(" and F_OperateTime >=@startDate");
                        param.Add("@startDate", log.startDate);
                    }

                    if (!string.IsNullOrWhiteSpace(log.endDate))
                    {
                        sb.Append(" and F_OperateTime <=@endDate");
                        param.Add("@endDate", log.endDate);
                    }

                    if (!string.IsNullOrWhiteSpace(log.F_OperateUserId))
                    {
                        sb.Append(" and F_OperateUserId=@userID");
                        param.Add("@userID", log.F_OperateUserId);
                    }

                    sb.Append(" ORDER BY F_OperateTime desc ");
                    //获取总记录数
                    string sqlCount = sb.ToString().Replace("select * ", "select count(1) totalCount ");


                    //分页
                    if (log.pageIndex >= 0 && log.pageSize > 0)
                    {
                        sb.Append(" limit " + ((log.pageIndex - 1) * log.pageSize) + "," + log.pageSize);
                    }
                    //分页记录列表
                    var list = conn.Query<Sys_Log>(sb.ToString(), param).ToList();
                    if (list != null && list.Count() > 0)
                    {
                        //总记录数列表
                        dynamic identity = conn.Query(sqlCount, param).Single();
                        list[0].totalCount = Convert.ToInt64(identity.totalCount);
                        list[0].pageIndex = log.pageIndex;
                        list[0].pageSize = log.pageSize;
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }



    }
}
