using System;
using System.Data;
using System.Text;
using System.Linq;
using Dapper;
using Entity;
using Common.DBHelper;
using BusinessLogic.youdao;
using System.Collections.Generic;

namespace DataAccess.youdao
{

    public class youdao : I_Youdao
    {

        public int AddyoudaoQusery(string txt, string json)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                var param = new DynamicParameters();
                string sql = @"INSERT INTO youdaoqusery (queryTxt,responseJson,createTime,updateTime) values (@queryTxt,@json,NOW(),NOW())";

                param.Add("@queryTxt", txt);
                param.Add("@json", json);

                int result = conn.Execute(sql, param);
                return result;
            }
        }



        public List<Entity.youdao.youdaoQusery> GetyoudaoQusery(string txt)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                var param = new DynamicParameters();
                string sql = "SELECT * from youdaoqusery where queryTxt=@txt";

                param.Add("@txt", txt);
                return conn.Query<Entity.youdao.youdaoQusery>(sql, param).ToList();
            }
        }


        public List<Entity.youdao.youdaoQusery> GeTxtPage(int pageIndex, string ids)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                var param = new DynamicParameters();
                if (pageIndex == 1)
                    pageIndex = 0;
                else
                    pageIndex = (pageIndex - 1) * 10;
                string sql = "SELECT * from youdaoqusery where id in ( " + ids + ") ";// LIMIT " + pageIndex + ",10";ws 

                return conn.Query<Entity.youdao.youdaoQusery>(sql, param).ToList();
            }
        }
    }



}