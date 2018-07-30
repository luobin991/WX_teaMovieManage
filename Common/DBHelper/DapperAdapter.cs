using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Common.DBHelper
{
    public class DapperAdapter
    {


        /// <summary>
        /// MySQL数据库连接字符串
        /// </summary>
        private static string mySqlConnectionStr = ConfigurationHelper.MySQLConnectionStr;//默认数据库       
        /// <summary>
        /// MySQL数据库连接字符串
        /// </summary>
        public static string MySqlConnectionStr
        {
            get { return mySqlConnectionStr; }
            set { mySqlConnectionStr = value; }
        }
        /// <summary>
        /// MySQL数据库
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection MySQLOpenConnection(string connString = null)
        {
            var connection = string.IsNullOrEmpty(connString) ? new MySqlConnection(MySqlConnectionStr) : new MySqlConnection(connString);
            connection.Open();
            return connection;
        }
    }
}
