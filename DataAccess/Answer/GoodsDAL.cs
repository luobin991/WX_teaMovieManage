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
    public class GoodsDAL : I_Goods
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        /// <param name="clubid"></param>
        /// <returns></returns>
        public T_Goods GetGoodsData(int id)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT * from T_Goods where id =@id ");
                param.Add("@id", id);

                var list = conn.Query<T_Goods>(sb.ToString(), param).FirstOrDefault();
                return list;
            }
        }



        public int SaveGoods(T_Goods model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string addSQL = @"INSERT INTO T_Goods (parentID,img,GoodsName,Price,status,GoodsInfo,updateTime,createTime) VALUES(@parentID,@img,@GoodsName,@Price,@status,@GoodsInfo,@updateTime,@createTime);";
                return conn.Execute(addSQL, model);
            }
        }

        public int UpdateGoods(T_Goods model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string updateSql = "UPDATE T_Goods SET parentID=@parentID,img=@img,GoodsName=@GoodsName,Price=@Price,status=@status,GoodsInfo=@GoodsInfo,updateTime=@updateTime WHERE id=@id;";
                return conn.Execute(updateSql, model);
            }
        }



        public int DelGoodsByparentID(int pid)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                string updateSql = "DELETE FROM T_Goods where parentID= @pid;";
                param.Add("pid", pid);
                return conn.Execute(updateSql, param);
            }
        }


        public int UpdateGoodsStatus(int id, int status)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string updateSql = "UPDATE T_Goods SET status=@status,updateTime=NOW() WHERE id=@id;";
                DynamicParameters param = new DynamicParameters();
                param.Add("status", status);
                param.Add("id", id);
                return conn.Execute(updateSql, param);
            }
        }




        public List<T_Goods> GetGoodsPage(T_Goods model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT * FROM T_Goods  WHERE 1=1 ");

                if (model.parentID>0)
                {
                    sb.AppendLine(" AND parentID=@parentID ");
                    param.Add("@parentID", model.parentID);
                }

                if (!string.IsNullOrWhiteSpace(model.GoodsName))
                {
                    sb.AppendLine(" AND GoodsName LIKE @GoodsName");
                    param.Add("@GoodsName", "%" + model.GoodsName.Trim() + "%");
                }

                sb.AppendLine(" ORDER BY  " + model.orderBy);

                string sqlCount = sb.ToString().Replace("SELECT * ", " SELECT count(1) totalCount ");
                //分页记录列表
                var list = conn.Query<T_Goods>(sb.ToString(), param).ToList();
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



        public int DelGoodsByID(int id)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                string updateSql = "DELETE FROM T_Goods where id= @id;";
                param.Add("id", id);
                return conn.Execute(updateSql, param);
            }
        }




        public List<T_Goods> GetGoodsBypid(int id)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT * FROM T_Goods  WHERE 1=1 ");

                if (id > 0)
                {
                    sb.AppendLine(" AND parentID=@parentID ");
                    param.Add("@parentID", id);
                }

                sb.AppendLine(" ORDER BY  price");

                //分页记录列表
                var list = conn.Query<T_Goods>(sb.ToString(), param).ToList();
                return list;
            }
        }


    }

}
