using System;
using System.Data;
using System.Text;
using System.Linq;
using Dapper;
using Entity;
using Common.DBHelper;
using BusinessLogic.Answer;

namespace DataAccess.Answer
{
    public class ShopDAL : I_Shop
    {





        /// <summary>
        /// 店铺信息
        /// </summary>
        /// <param name="clubid"></param>
        /// <returns></returns>
        public T_ShopInfo GetShopinfo(int id)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT * from T_ShopInfo where id =@id ");
                param.Add("@id", id);

                var list = conn.Query<T_ShopInfo>(sb.ToString(), param).FirstOrDefault();
                return list;
            }
        }



        public int SaveShopInfo(T_ShopInfo model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string addSQL = @"INSERT INTO T_ShopInfo (logo,shopName,shopPhone,shopAddress,ShopCo_ordinate,shopInfo,createTime)VALUES
                     (@logo,@shopName,@shopPhone,@shopAddress,@ShopCo_ordinate,@shopInfo,@createTime)";
                return conn.Execute(addSQL, model);
            }
        }

        public int UpdateShopInfo(T_ShopInfo model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string updateSql = "UPDATE T_ShopInfo SET logo=@logo,shopName=@shopName,shopPhone=@shopPhone,shopAddress=@shopAddress,ShopCo_ordinate=@ShopCo_ordinate,shopInfo=@shopInfo where id=@id;";
                return conn.Execute(updateSql, model);
            }
        }



    }

}
