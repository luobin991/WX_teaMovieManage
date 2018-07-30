using System;
using System.Data;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using Entity;
using Common.DBHelper;
using BusinessLogic.Answer;


namespace DataAccess.Answer
{
    public class LableDAL : I_Lable
    {
        public int SaveLableType(T_Lable model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string addSQL = @"INSERT INTO T_Lable (typeid,lableName,createTime) VALUE (@typeid,@lableName,@createTime);";
                return conn.Execute(addSQL, model);
            }
        }


        public int SaveLableDetail(T_LableDetail model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string addSQL = @"INSERT INTO T_LableDetail (parentID,lable,createTime,updateTime) VALUE (@parentID,@lable,@createTime,@updateTime);";
                return conn.Execute(addSQL, model);
            }
        }


        public int UpdateLableType(T_Lable model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string updateSql = "UPDATE T_Lable SET typeid=@typeid,lableName=@lableName WHERE id=@id;";
                return conn.Execute(updateSql, model);
            }
        }

        public int UpdateLableDetail(T_LableDetail model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string updateSql = "UPDATE T_LableDetail SET parentID=@parentID,lable=@lable WHERE id=@id;";
                return conn.Execute(updateSql, model);
            }
        }

        public int DelLable(int id)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                string updateSql = "DELETE FROM T_Lable where id = @id;";
                param.Add("id", id);
                return conn.Execute(updateSql, param);
            }
        }

        public int DelLableDetail(int id)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                string updateSql = "DELETE FROM T_LableDetail where id = @id;";
                param.Add("id", id);
                return conn.Execute(updateSql, param);
            }
        }

        public int DelLableDetailByParentID(int pid)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                string updateSql = "DELETE FROM T_LableDetail where parentID= @pid;";
                param.Add("pid", pid);
                return conn.Execute(updateSql, param);
            }
        }

        public T_Lable GetLable(int id, int typeid)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM T_Lable  where id = @id");
                param.Add("@id", id);
                var list = conn.Query<T_Lable>(sb.ToString(), param).FirstOrDefault();
                return list;
            }
        }

        public List<T_Lable> GetLables()
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM T_Lable ORDER BY typeid");

                var list = conn.Query<T_Lable>(sb.ToString(), param).ToList();
                return list;
            }
        }

        public List<T_Lable> GetLables(int typeid)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM T_Lable where  typeid = @typeid ORDER BY id");
                param.Add("@typeid", typeid);
                var list = conn.Query<T_Lable>(sb.ToString(), param).ToList();
                return list;
            }
        }


        public List<T_Lable> GetLable_Datail(T_Lable model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT * FROM ( ");
                sb.AppendLine("SELECT l.*,(SELECT group_concat(lable) FROM T_LableDetail where parentID=l.id) as lableDetail FROM T_Lable L where L.typeid=@typeid GROUP BY lableName");
                sb.AppendLine(" ) as tb");
                param.Add("@typeid", model.typeid);
                if (!string.IsNullOrWhiteSpace(model.lableName))
                {
                    sb.AppendLine("WHERE lableName LIKE @lableName");
                    param.Add("@lableName", "%" + model.lableName.Trim() + "%");
                }
                sb.AppendLine(" ORDER BY  " + model.orderBy);
                string sqlCount = sb.ToString().Replace("SELECT * ", " SELECT count(1) totalCount ");
                //分页记录列表
                var list = conn.Query<T_Lable>(sb.ToString(), param).ToList();
                if (list != null && list.Count() > 0)
                {
                    //总记录数列表
                    dynamic identity = conn.Query(sqlCount, param).Single();
                    list[0].totalCount = Convert.ToInt64(identity.totalCount);
                    list[0].pageIndex = model.pageIndex;
                    list[0].pageSize = model.pageSize;
                }
                return list;
            }
        }


        public T_LableDetail GetLableDetail(int id)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM T_LableDetail  where id = @id");
                param.Add("@id", id);
                var list = conn.Query<T_LableDetail>(sb.ToString(), param).FirstOrDefault();
                return list;
            }
        }

        public List<T_LableDetail> GetlableDetailPage(T_LableDetail model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM T_LableDetail where parentid= @pid");
                param.Add("@pid", model.parentID);

                string sqlCount = sb.ToString().Replace("SELECT * ", "SELECT COUNT(1) totalCount ");
                var list = conn.Query<T_LableDetail>(sb.ToString(), param).ToList();
                if (list != null && list.Count() > 0)
                {
                    dynamic identity = conn.Query(sqlCount, param).Single();
                    list[0].totalCount = Convert.ToInt64(identity.totalCount);
                    list[0].pageIndex = model.pageIndex;
                    list[0].pageSize = model.pageSize;
                }
                return list;
            }
        }



        /// <summary>
        /// 获取产品标签，包括标签明细
        /// </summary>
        /// <param name="relateType"></param>
        /// <param name="fromID"></param>
        /// <returns></returns>
        public List<T_Lable> GetLables(int relateType, int fromID)
        {
            List<T_Lable> list = new List<T_Lable>();
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {

                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM T_Lable where id in (SELECT toID from t_relate where relateType=" + relateType + " and fromID=" + fromID + ")");
                list = conn.Query<T_Lable>(sb.ToString(), param).ToList();

                foreach (var item in list)
                {
                    item.lbDetails = conn.Query<T_LableDetail>("SELECT * FROM t_labledetail where parentID =" + item.id, null).ToList();
                }
            }

            return list;
        }


    }

}
