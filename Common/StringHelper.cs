using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace  Common
{
    public class StringHelper
    {
        /// <summary>
        /// Md5加密
        /// 2017-02-28
        /// </summary>
        /// <param name="password">明文密码</param>
        /// <returns></returns>
        public static string GetMd5(string password)
        {
            byte[] md5Bytes = ASCIIEncoding.Default.GetBytes(password);
            byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            encodedBytes = md5.ComputeHash(md5Bytes);
            string newPassword = BitConverter.ToString(encodedBytes);
            newPassword = Regex.Replace(newPassword, "-", "");//因为转化完的都是34-2d这样的，所以替换掉- 
            //newPassword = newPassword.ToLower();//根据需要转化成小写;
            return newPassword;
        }

        ///// <summary>
        ///// 进行MD5效验
        ///// </summary>
        ///// <param name="strmd5"></param>
        ///// <returns></returns>
        //public static string GetMd5(string strmd5)
        //{
        //    byte[] md5Bytes = ASCIIEncoding.Default.GetBytes(strmd5);
        //    byte[] encodedBytes;
        //    MD5 md5;
        //    md5 = new MD5CryptoServiceProvider();
        //    //FileStream fs= new FileStream(filepath,FileMode.Open,FileAccess.Read);
        //    encodedBytes = md5.ComputeHash(md5Bytes);
        //    string nn = BitConverter.ToString(encodedBytes);
        //    nn = Regex.Replace(nn, "-", "");//因为转化完的都是34-2d这样的，所以替换掉- 
        //    nn = nn.ToLower();//根据需要转化成小写
        //    //fs.Close();
        //    return nn;
        //}

        /// <summary>
        /// string转化为int, false:返回 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int TryGetInt(string value)
        {
            int n = 0;
            int result = 0;
            if (int.TryParse(value, out n) && n <= Int32.MaxValue)
            {
                result = Convert.ToInt32(n);
            }
            return result;
        }
        /// <summary>
        /// 获取int类型 返回object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object TryGetIntObject(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                int n = 0;
                int result = 0;
                if (int.TryParse(value, out n) && n <= Int32.MaxValue)
                {
                    result = Convert.ToInt32(n);
                }
                return result;
            }
            else
            {
                return null;
            }
        }


        public static short TryGetShort(string value)
        {
            short n = 0;
            short result = 0;
            if (short.TryParse(value, out n) && n <= Int16.MaxValue)
            {
                result = Convert.ToInt16(n);
            }
            return result;
        }

        /// <summary>
        /// 获取short类型返回object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object TryGetShortObject(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                short n = 0;
                short result = 0;
                if (short.TryParse(value, out n) && n <= Int16.MaxValue)
                {
                    result = Convert.ToInt16(n);
                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public static byte TryGetByte(string value)
        {
            byte result = 0;
            byte.TryParse(value, out result);
            return result;
        }

        public static bool TryGetBool(string value)
        {
            bool result = false;
            if (value == "1") return true;
            bool.TryParse(value, out result);
            return result;
        }
        /// <summary>
        /// 转换布尔
        /// </summary>
        /// <param name="value">判断的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <remarks>侯湘岳</remarks>
        /// <returns></returns>
        public static bool TryGetBool(string value, bool defaultValue)
        {
            if (string.IsNullOrEmpty(value))
                return defaultValue;
            value = value.ToUpper();
            return (value == "YES" || value == "TRUE" || value == "1");
        }

        public static long TryGetLong(string value)
        {
            long n = 0;
            long result = 0;
            if (long.TryParse(value, out n))
            {
                result = Convert.ToInt64(n);
            }
            return result;
        }

        public static object TryGetLongObject(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                long n = 0;
                long result = 0;
                if (long.TryParse(value, out n))
                {
                    result = Convert.ToInt64(n);
                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public static float TryGetFloat(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Replace(",", "");
            }

            float result = 0;
            float.TryParse(value, out result);
            return result;
        }

        /// <summary>
        /// 获取Float类型返回Object类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object TryGetFloatObject(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Replace(",", "");
                float result = 0;
                float.TryParse(value, out result);
                return result;
            }
            else
            {
                return null;
            }
        }

        public static double TryGetDouble(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Replace(",", "");
            }
            double result = 0;
            double.TryParse(value, out result);
            return result;
        }
        /// <summary>
        /// 获取double类型返回object类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object TryGetDoubleObject(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Replace(",", "");
                double result = 0;
                double.TryParse(value, out result);
                return result;
            }
            else
            {
                return null;
            }
        }

        public static DateTime TryGetDateTime(string value)
        {
            DateTime result = default(DateTime);
            DateTime.TryParse(value, out result);
            return result;
        }
        /// <summary>
        /// 将时间转换成字符串
        /// </summary>
        /// <param name="date"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string TryGetDateTimeFormat(DateTime? date, string format)
        {
            if (date == null || date == default(DateTime) || date <= DateTime.MinValue)
            {
                return "";
            }
            return Convert.ToDateTime(date).ToString(format);
        }

        /// <summary>
        /// 保留小数位数
        /// byte
        /// </summary>
        /// <param name="d">数值</param>
        /// <param name="decimals">保留几位小数位数</param>
        /// <param name="roundOff">是否四舍五入</param>
        /// <returns></returns>
        public static string RoundCorrect(double d, int decimals, bool roundOff)
        {
            double multiplier = Math.Pow(10, decimals), result;

            if (d < 0)
                multiplier *= -1;
            if (roundOff)
                result = Math.Floor((d * multiplier) + 0.51) / multiplier;
            else
                result = Math.Floor((d * multiplier)) / multiplier;
            return result.ToString("f" + decimals.ToString());
        }

        public class DateTimeFormat
        {
            public static string yyyyMMdd = "yyyyMMdd";
            public static string yyyy_MM_dd = "yyyy-MM-dd";
            public static string yyyyMM = "yyyyMM";
            public static string yyyy_MM_dd_hh_mm_ss = "yyyy-MM-dd HH:mm:ss";
        }

        /// <summary>
        /// 将datetime转化为string,格式为：yyyy-MM-dd
        /// </summary>
        public static string TryGetDateTimeFormat(object value, DateTime dt)
        {
            string format = DateTimeFormat.yyyy_MM_dd;
            return TryGetDateTimeFormat(value, format, dt);
        }
        /// <summary>
        /// 获取当前天的最后时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime GetCurDayLastTime(DateTime dt)
        {
            string str = " 23:59:59";
            str = dt.ToString("yyyy-MM-dd") + str;
            return Convert.ToDateTime(str);
        }
        /// <summary>
        /// 将datetime转化为string可以自定义格,格式类：DateTimeFormat
        /// </summary>
        public static string TryGetDateTimeFormat(object value, string format, DateTime dt)
        {
            string result;
            if (value == null || Convert.ToString(value) == "")
            {
                result = dt.ToString(format);
            }
            else
            {
                try
                {
                    result = Convert.ToDateTime(value).ToString(format);
                }
                catch { result = ""; }
            }
            return result;
        }

        public static decimal TryGetDecimal(string value)
        {
            decimal result = default(decimal);
            decimal.TryParse(value, out result);
            return result;
        }
        /// <summary>
        /// 获取Decimal类型 
        /// </summary>
        /// <param name="value">输入值</param>
        /// <returns>如果没有值返回null</returns>
        public static object TryGetDecimalObject(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            else
            {
                decimal result = default(decimal);
                decimal.TryParse(value, out result);
                return result;
            }
        }
        /// <summary>
        /// 指定长度随机数字字符串
        /// </summary>
        /// <param name="length">随机数长度</param>
        /// <param name="isZero">是否以0开头</param>
        /// <returns></returns>
        public static string RndNumberString(int length, bool isZero = true)
        {
            int i = 1;
            string returnstring = "";
            Random rnd = new Random();
            //随机数0开头
            if (!isZero)
            {
                returnstring += rnd.Next(1, 10).ToString();
                i = 2;
            }
            while (i <= length)
            {
                returnstring += rnd.Next(0, 10).ToString();
                i++;
            }
            return returnstring;
        }
        /// <summary>
        /// 验证随机数中是否存在连续数字
        /// </summary>
        /// <param name="randNumber">字符串</param>
        /// <param name="length">连续位数</param>
        /// <returns></returns>
        public static bool IsContinuous(string randNumber, int length)
        {
            List<string> list = null;
            //不连续
            bool falg = false;
            switch (length)
            {
                case 1:
                    list = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                    break;
                case 2:
                    list = new List<string> { "11", "22", "33", "44", "55", "66", "77", "88", "99", "00" };
                    break;
                case 3:
                    list = new List<string> { "111", "222", "333", "444", "555", "666", "777", "888", "999", "000" };
                    break;
                case 4:
                    list = new List<string> { "1111", "2222", "3333", "4444", "5555", "6666", "7777", "8888", "9999", "0000" };
                    break;
                case 5:
                    list = new List<string> { "11111", "22222", "33333", "44444", "55555", "66666", "77777", "88888", "99999", "00000" };
                    break;
                case 6:
                    list = new List<string> { "111111", "222222", "333333", "444444", "555555", "666666", "777777", "888888", "999999", "000000" };
                    break;
            }
            //是否连续
            foreach (var item in list)
            {
                if (randNumber.IndexOf(item) != -1)
                {
                    //连续
                    falg = true;
                    break;
                }
            }
            return falg;

        }
        /// <summary>
        /// 获取4位验证码
        /// </summary>
        /// <returns></returns>
        public static string GetCode()
        {
            string veriCode = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
            return veriCode = veriCode.Substring(veriCode.Length - 6, 4);
        }
        private static char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        /// <summary>
        /// 取随机字符串。只含数字及小写字母
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GenerateRandomString(int length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(74);
            Random rd = new Random();
            int len = constant.Length;
            for (int i = 0; i < length; i++)
            {
                newRandom.Append(constant[rd.Next(len)]);
            }
            return newRandom.ToString();
        }
        /// <summary>
        /// Html转为实体
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string HtmlToString(string html)
        {
            html = html.Replace("&amp;", "&");
            html = html.Replace("&lt;", "<");
            html = html.Replace("&gt;", ">");
            html = html.Replace("&quot;", "\"");
            html = html.Replace("&nbsp;", " ");
            html = html.Replace("&copy;", "©");
            html = html.Replace("&reg;", "®");
            html = html.Replace("&qult;", "“");
            html = html.Replace("&qurt;", "”");

            return html;
        }
        /// <summary>
        /// 将int数组转换成","分隔的字符串
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static string ConvertToString(int[] ints)
        {
            if (ints == null)
            {
                return null;
            }
            if (ints.Length < 1)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            foreach (int str in ints)
            {
                sb.Append(str).Append(",");
            }
            return sb.ToString().TrimEnd(',');
        }
        /// <summary>
        /// 将string数组转换成","分隔的字符串
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public static string ConvertToString(string[] strings)
        {
            if (strings == null)
            {
                return null;
            }
            if (strings.Length < 1)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            foreach (string str in strings)
            {
                sb.Append(str).Append(",");
            }
            return sb.ToString().TrimEnd(',');
        }
        /// <summary>
        /// 判断一个字符串是否为合法整数(不限制长度)
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool CheckInteger(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }
            string pattern = @"^\d+$";
            return Regex.IsMatch(s, pattern);
        }
        /// <summary>
        /// 判断一个字符串是否为整数或小数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            Regex reg = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return reg.IsMatch(str);
        }
        /// <summary>
        /// 去除字符串所有空格
        /// 创建人：曾智磊，2014-11-10
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimBlank(string str)
        {
            if (str == null)
            {
                return null;
            }
            return Regex.Replace(str, @"\s", "");
        }
        /// <summary>
        /// 验证座机电话格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckTelephone(string str)
        {
            return Regex.IsMatch(str, "^(\\d{3,4}\\-?)?\\d{7,8}$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckPhone(string str)
        {
            return Regex.IsMatch(str, @"^[1]+[3,4,5,7,8]+\d{9}$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 验证邮箱格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckEmail(string str)
        {
            return Regex.IsMatch(str, "^([a-zA-Z0-9]+[_|\\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\\.]?)*[a-zA-Z0-9]+\\.[a-zA-Z]{2,3}$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 验证数字字母
        /// </summary>
        /// <param name="str">要验证的字符串</param>
        ///  <param name="minVal">最小长度</param>
        ///   <param name="maxVal">最大长度</param>
        /// <returns></returns>
        public static bool CheckStrLen(string str,int minVal,int maxVal)
        {
            return Regex.IsMatch(str, "^[0-9A-Za-z]{"+ minVal + ","+ maxVal + "}$", RegexOptions.Compiled);
        }

        /// <summary>
        /// 生成业务编号
        /// </summary>
        /// <param name="afterNo"></param>
        /// <returns>长度为10的编号</returns>
        public static string GetEntrustNo(string afterNo)
        {
            //return afterNo.PadLeft(10, '0'); //左边补齐0，长度为10
            //return String.Format("{0:0000000}", afterNo.VInt());

            switch (afterNo.Length)
            {
                case 1:
                    afterNo = string.Format("000000000{0}", afterNo);
                    break;
                case 2:
                    afterNo = string.Format("00000000{0}", afterNo);
                    break;
                case 3:
                    afterNo = string.Format("0000000{0}", afterNo);
                    break;
                case 4:
                    afterNo = string.Format("000000{0}", afterNo);
                    break;
                case 5:
                    afterNo = string.Format("00000{0}", afterNo);
                    break;
                case 6:
                    afterNo = string.Format("0000{0}", afterNo);
                    break;
                case 7:
                    afterNo = string.Format("000{0}", afterNo);
                    break;
                case 8:
                    afterNo = string.Format("00{0}", afterNo);
                    break;
                case 9:
                    afterNo = string.Format("0{0}", afterNo);
                    break;
                default: break;

            }
            return afterNo;
        }



        public static string DecToString(decimal n)
        {

            string[] num = n.ToString().Split('.');
            string ksh = Convert.ToDecimal(num[0]).ToString("N");
            ksh = ksh.Split('.')[0];
            if (num.Length > 1)
            {
                return ksh + "." + (num[1].Length > 1 ? num[1].Substring(0, 2) : num[1] + "0");
            }
            else
            {
                return ksh + ".00";
            }
        }

    }
}
