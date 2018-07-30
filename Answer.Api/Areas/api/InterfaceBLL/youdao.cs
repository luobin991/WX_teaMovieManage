using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Entity;
using Common;
using BusinessLogic.youdao;
using DataAccess.youdao;
using Entity.youdao;

namespace Answer.Api.Areas.api.InterfaceBLL
{
    public class youdao
    {
        /// <summary>
        /// 俱乐部
        /// </summary>
        private readonly I_Youdao _youdao;
        /// <summary>
        /// 构造函数
        /// </summary>
        public youdao()
        {
            if (_youdao == null)
                this._youdao = new DataAccess.youdao.youdao();
        }


        private static youdao current { get; set; }
        /// <summary>
        /// 当前凭据
        /// </summary>
        public static youdao Current
        {
            get
            {
                if (current == null)
                    current = new youdao();

                return current;
            }
        }



        public  _Response GeTxtPage(string json)
        {
            JObject obj = JObject.Parse(json);

            int pageIndex = Convert.ToInt32(obj["pageIndex"]);

            List<int> ids = new List<int>();
            for (int i = 0; i < 10;)
            {
                int num = new Random().Next(2000);
                if (num > 1999)
                {
                    continue;
                }
                if (!ids.Contains(num))
                {
                    ids.Add(num);
                    i++;
                }
            }

            List<youdaoQusery> rows = _youdao.GeTxtPage(pageIndex, string.Join(",", ids));

            List<youdaoResponse> list = new List<youdaoResponse>();
            foreach (var item in rows)
            {
                if (!string.IsNullOrWhiteSpace(item.responseJson))
                {
                    youdaoResponse response = JSONHelper.JSONToObject<youdaoResponse>(item.responseJson);
                    list.Add(response);
                }
            }
            _Response result = new _Response(true);
            result.body = list;

            return result;
        }

    }
}