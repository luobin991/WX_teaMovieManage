using System;
using System.Data;
using System.Text;
using System.Linq;
using Dapper;
using Entity;
using Common.DBHelper;
using BusinessLogic.Answer;
using System.Collections.Generic;

namespace DataAccess.Answer
{
    public class RelateDAL : I_Relate
    {



        public int SaveRelate(T_Relate model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string addSQL = @" INSERT INTO t_relate (relateType,fromID,toID,createUserID,CreateTime) 
	                            VALUES
                            (@relateType,@fromID,@toID,@createUserID,@CreateTime)";

                return conn.Execute(addSQL, model);
            }
        }


        public int DelRelate(int relateType, int fromID)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                string updateSql = "DELETE FROM t_relate where  relateType =@relateType and fromID= @fromID;";

                param.Add("relateType", relateType);
                param.Add("fromID", fromID);

                return conn.Execute(updateSql, param);
            }
        }




        public List<T_Relate> GetRelates(int relateType, int fromID)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();

                string sql = @" SELECT * FROM t_relate WHERE fromID = " + fromID + " AND relateType = " + relateType;

                var list = conn.Query<T_Relate>(sql, param);
                return list.ToList();
            }
        }


        public List<T_RelateLable> GetRelateLables(string ids)
        {
            string sql = @"
SELECT r.id, r.relateType,r.fromID,r.toID,l.lableName,l.typeid from t_relate r LEFT JOIN t_lable l on r.toID = l.id
where fromID in (" + ids + ")";

            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {

                var list = conn.Query<T_RelateLable>(sql, null);
                return list.ToList();
            }
        }



    }

}
