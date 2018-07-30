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
    public class OrderDAL :I_Order
    {


        /******   接口存入数据 ************/
        public int SaveOrder(T_Order model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string addSQL = @"INSERT INTO T_Order (orderNum,tradingNum,merchantCode,orderTime,orderStatus,orderNumber,orderSumPrice,orderUser,orderUserName,orderUserPhone,orderUserAdder,isOutside,createTime)
                        VALUE (@orderNum,@tradingNum,@merchantCode,@orderTime,@orderStatus,@orderNumber,@orderSumPrice,@orderUser,@orderUserName,@orderUserPhone,@orderUserAdder,@isOutside,@createTime);
                        Select  @@identity as num ;";
                //return conn.Execute(addSQL, model);
                dynamic identity = conn.Query(addSQL, model).Single();
                int result = Convert.ToInt32(identity.num);
                return result;
            }
        }


        public int SaveOrderDetail(T_orderList model)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string addSQL = @"INSERT INTO t_orderDetail (orderid,details,rightIndex,GoodsName,GoodsInfoStr,Price,num,SumPrice,createTime)
                        VALUE (@orderid,@details,@rightIndex,@GoodsName,@GoodsInfoStr,@Price,@num,@SumPrice,@createTime);";
                return conn.Execute(addSQL, model);
            }
        }


        public List<T_Order> GetOrderPage(int pageIndex, string userName)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                var sb = new StringBuilder();

                int pageSize = 10;

                sb.Append("select * from t_order ");
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    sb.Append(" where orderUserName = @keyword ");
                    param.Add("@keyword", userName.Trim());
                }
                sb.Append(" ORDER BY id desc ");
                //分页
                sb.Append(" limit " + ((pageIndex - 1) * pageSize) + "," + pageSize);

                //获取总记录数
                string sqlCount = sb.ToString().Replace("select * ", "select count(1) totalCount ");
                var user = conn.Query<T_Order>(sb.ToString(), param).ToList();
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




        ///////////////////////////////////////////////////////


        public IEnumerable<T_Order> GetOrderPage(int pageIndex, int pageSize, string keyword)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                var sb = new StringBuilder();
                sb.Append("select * from t_order ");
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sb.Append(" where orderUserName LIKE @keyword ");
                    param.Add("@keyword", "%" + keyword.Trim() + "%");
                }
                sb.Append(" ORDER BY id desc ");
                //分页
                if (pageIndex >= 0 && pageSize > 0)
                {
                    sb.Append(" limit " + ((pageIndex - 1) * pageSize) + "," + pageSize);
                }

                //获取总记录数
                string sqlCount = sb.ToString().Replace("select * ", "select count(1) totalCount ");
                var user = conn.Query<T_Order>(sb.ToString(), param).ToList();
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




        public IEnumerable<T_orderList> GetOrderDetail(int orderId)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                var sb = new StringBuilder();
                sb.Append("select * from t_orderdetail where 1=1");
                if(orderId>0)
                {
                    sb.Append(" and orderid = @orderid ");
                    param.Add("@orderid", orderId);
                }
                sb.Append(" ORDER BY id desc ");

                //获取总记录数
                var user = conn.Query<T_orderList>(sb.ToString(), param).ToList();
             
                return user;
            }
        }


    }

}
