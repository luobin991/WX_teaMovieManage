using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;

namespace Answer.Api.Areas.api.InterfaceBLL
{

    /// <summary>
    /// app 返回模型
    /// </summary>
    public class _Response
    {
       public _Response() { }

        /// <summary>
        ///  code = result ? 1 : 0;
        /// </summary>
        /// <param name="result"></param>
        public _Response(bool result)
        {
            code = result ? 1 : 0;
        }

        public int code { get; set; }

        private string _msg;

        public string msg
        {
            get
            {
                if (string.IsNullOrEmpty(_msg))
                {
                    return code == 1 ? "请求成功" : "请求失败";
                }
                else
                    return _msg;
            }
            set { _msg = value; }
        }

        public int totalCount { get; set; }

        public object body { get; set; }



    }
}