using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Common.DBHelper
{
    /// <summary>
    /// 配置文件辅助类
    /// </summary>
    public class ConfigurationHelper
    {
        /// <summary>
        /// Mysql链接字符串
        /// </summary>
        public static readonly string MySQLConnectionStr = GetStr(ConfigurationManager.AppSettings["MySQL_GameStr"].ToString());
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="str">连接字符串</param>
        /// <returns></returns>
        public static string GetStr(string str)
        {
            return str;
        }
    }
}
