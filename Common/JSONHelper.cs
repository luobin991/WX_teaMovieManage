﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

namespace Common
{
    /// <summary> 
    /// JSON帮助类 
    /// </summary> 
    public class JSONHelper
    {
        /// <summary>
        /// 统一返回的json格式，全部属性小写
        /// </summary>
        [Serializable]
        public class ReturnData
        {
            public int returntype { get; set; } //1为正确
            public object returntext { get; set; }
            public object data { get; set; }
            public object debug { get; set; }
        }

        [Serializable]
        public class ExceptionData
        {
            public string source { get; set; }
            public string message { get; set; }
            public string trace { get; set; }
        }

        /// <summary>
        /// 统一返回json列表数据的格式
        /// </summary>
        public class ListData
        {
            private int _page = 1;
            public int page { get { return _page; } set { _page = value; } }
            private int _total = 0;
            public int total { get { return _total; } set { _total = value; } }
            public object rows { get; set; }
        }
        /// <summary>
        /// 带debug的json返回
        /// 修改人rock 20151201：添加参数isLog
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="status"></param>
        /// <param name="message"></param>
        /// <param name="debug"></param>
        /// <param name="isLog">true为异常时自动写入日志，false为不写入</param>
        /// <returns></returns>
        public static string GetJson(object obj, int status, string message, object debug, bool isLog = true)
        {
            ReturnData data = new JSONHelper.ReturnData();
            data.returntype = status;
            if (obj != null && obj.GetType().Name.IndexOf("DataTable") >= 0)
                data.data = JSONHelper.DataTableToList((DataTable)obj);
            else
                data.data = obj;
#if DEBUG
            if (debug != null && debug.GetType().Name.IndexOf("Exception") >= 0)
            {
                Exception ex = (Exception)debug;
                ExceptionData de = new ExceptionData();
                de.source = ex.Source;
                de.message = ex.Message;
                de.trace = ex.StackTrace;
                debug = de;
                if (isLog)
                {
                    LogHelper.Error(ex);
                }
            }
            data.debug = debug;
#endif
            data.returntext = message;
            return ObjectToJSON(data);
        }

        /// <summary> 
        /// 对象转JSON 
        /// </summary> 
        /// <param name="obj">对象</param> 
        /// <returns>JSON格式的字符串</returns> 
        public static string ObjectToJSON(object obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            //评估发展中心使用时房号数太多，先把最大值设大点，待评估发展中心取数据修改后去掉设置值
            jss.MaxJsonLength = 10240000;

            try
            {
                //string json = jss.Serialize(obj);
                //Regex reg = new Regex("[\"][a-zA-Z0-9_]*[\"]:null[ ]*[,]?");
                //json = reg.Replace(json, string.Empty);
                //return json;
                return jss.Serialize(obj);//.Replace(":null",":\"\"");
            }
            catch (Exception ex)
            {
                throw new Exception("JSONHelper.ObjectToJSON(): " + ex.Message);
            }
        }

        /// <summary>
        /// 对象转JSON 格式化时间
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJSONDateFormat(object obj)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            List<JsonConverter> jcs = new List<JsonConverter>(){
                timeFormat
            };

            JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                Converters = jcs
            };

            return JsonConvert.SerializeObject(obj, Settings);
        }

        /// <summary> 
        /// 数据表转键值对集合 
        /// 把DataTable转成 List集合, 存每一行  
        /// 集合中放的是键值对字典,存每一列 
        /// </summary> 
        /// <param name="dt">数据表</param> 
        /// <returns>哈希表数组</returns> 
        public static List<Dictionary<string, object>> DataTableToList(DataTable dt)
        {
            List<Dictionary<string, object>> list
            = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    dic.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                list.Add(dic);
            }
            return list;
        }

        public static List<Dictionary<string, object>> DataTableToOrderList(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        dic.Add(dt.Columns[j].ColumnName, dt.Rows[i][j]);
                    }
                    list.Add(dic);
                }
            }
            return list;
        }

        /// <summary> 
        /// 数据集转键值对数组字典 
        /// </summary> 
        /// <param name="dataSet">数据集</param> 
        /// <returns>键值对数组字典</returns> 
        public static Dictionary<string, List<Dictionary<string, object>>> DataSetToDic(DataSet ds)
        {
            Dictionary<string, List<Dictionary<string, object>>> result = new Dictionary<string, List<Dictionary<string, object>>>();
            foreach (DataTable dt in ds.Tables)
                result.Add(dt.TableName, DataTableToList(dt));
            return result;
        }
        /// <summary> 
        /// 数据表转JSON 
        /// </summary> 
        /// <param name="dataTable">数据表</param> 
        /// <returns>JSON字符串</returns> 
        public static string DataTableToJSON(DataTable dt)
        {
            return ObjectToJSON(DataTableToList(dt));
        }
        /// <summary> 
        /// JSON文本转对象,泛型方法 
        /// </summary> 
        /// <typeparam name="T">类型</typeparam> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>指定类型的对象</returns> 
        public static T JSONToObject<T>(string jsonText)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                jss.MaxJsonLength = int.MaxValue;
                return jss.Deserialize<T>(jsonText);
            }
            catch (Exception ex)
            {
                throw new Exception("JSONHelper.JSONToObject(): " + ex.Message);
            }
        }

        /// <summary>
        /// 将对象序列化为JSON格式(add:王锐)
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeObject(object o)
        {
            string json = JsonConvert.SerializeObject(o);
            return json;
        }

        public static List<T> JSONStringToList<T>(string JsonStr)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                jss.MaxJsonLength = int.MaxValue;
                return jss.Deserialize<List<T>>(JsonStr);
            }
            catch (Exception ex)
            {
                throw new Exception("JSONHelper.JSONToObject(): " + ex.Message);
            }
        }
        public static T JsonToObject<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
           System.IO. MemoryStream ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T jsonObject = (T)ser.ReadObject(ms);
            ms.Close();
            return jsonObject;
        }


        /// <summary> 
        /// 将JSON文本转换为数据表数据 
        /// </summary> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>数据表字典</returns> 
        public static Dictionary<string, List<Dictionary<string, object>>> TablesDataFromJSON(string jsonText)
        {
            return JSONToObject<Dictionary<string, List<Dictionary<string, object>>>>(jsonText);
        }
        /// <summary> 
        /// 将JSON文本转换成数据行 
        /// </summary> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>数据行的字典</returns> 
        public static Dictionary<string, object> DataRowFromJSON(string jsonText)
        {
            return JSONToObject<Dictionary<string, object>>(jsonText);
        }

        /// <summary>
        /// 将JSON文本转换成DataTable caoq 2014-1-28
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static DataTable JsonToDataTable(string strJson)
        {
            if (string.IsNullOrEmpty(strJson) || strJson == "[]" || strJson == "null") return null;
            //取出表名  
            Regex rg = new Regex(@"(?<={)[^:]+(?=:/[^:])", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名  
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据  
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split(',');

                //创建表  
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        DataColumn dc = new DataColumn();
                        string[] strCell = str.Split(':');
                        dc.ColumnName = strCell[0].ToString().Replace("\"", "");
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容  
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split(':')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }
            return tb;
        }

        /// <summary>
        /// 将字符串转换为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static T JsonStringToObject<T>(string result)
        {
            JObject jobject = JObject.Parse(result);
            return JSONToObject<T>(jobject.Value<string>("data"));
        }
    }


    /// <summary>
    /// 将json的属性key转换为小写key
    /// Added: dongpc
    /// Time: 2015-10-12 11:40
    /// </summary>
    public class LowercaseJsonSerializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new LowercaseContractResolver()
        };

        public static string SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.None, Settings);
        }

        public class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }
        }
    }
}
