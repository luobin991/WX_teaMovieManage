using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.youdao
{
    public class youdaoResponse
    {

        public int id { get; set; }

        /// <summary>
        /// 错误返回码	一定存在
        /// </summary>
        public string errorCode { get; set; }
        /// <summary>
        /// 源语言	查询正确时，一定存在
        /// </summary>
        public string query { get; set; }

        /// <summary>
        /// 翻译结果	查询正确时一定存在
        /// </summary>
        public List<string> translation { get; set; }

        /// <summary>
        /// 词义	基本词典,查词时才有
        /// </summary>
        public youdaBasic basic { get; set; }

        /// <summary>
        /// 词义	网络释义，该结果不一定存在
        /// </summary>
        public List<WebItem> web { get; set; }
        /// <summary>
        /// 源语言和目标语言	一定存在
        /// </summary>
        public string l { get; set; }
        /// <summary>
        /// 词典deeplink	查询语种为支持语言时，存在
        /// </summary>
        public Dict dict { get; set; }
        /// <summary>
        /// webdeeplink	查询语种为支持语言时，存在
        /// </summary>
        public Webdict webdict { get; set; }
        /// <summary>
        /// 翻译结果发音地址	翻译成功一定存在
        /// </summary>
        public string tSpeakUrl { get; set; }
        /// <summary>
        /// 源语言发音地址	翻译成功一定存在
        /// </summary>
        public string speakUrl { get; set; }


    }



    public class WebItem
    {
        public string key { get; set; }
        public List<string> value { get; set; }


    }

    public class Dict
    {
        public string url { get; set; }
    }

    public class Webdict
    {
        public string url { get; set; }
    }
}
