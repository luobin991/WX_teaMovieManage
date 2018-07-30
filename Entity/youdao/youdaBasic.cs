using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.youdao
{

    /// <summary>
    /// // 有道词典-基本词典,查词时才有
    /// </summary>
    public class youdaBasic
    {

        public int id { get; set; }

        public int responseId { get; set; }
        /// <summary>
        /// 默认音标，默认是英式音标，英文查词成功，一定存在
        /// </summary>
        public string phonetic { get; set; }
        /// <summary>
        /// us-phonetic	美式音标，英文查词成功，一定存在
        /// </summary>
        public string us_phonetic { get; set; }

        /// <summary>
        /// uk-phonetic	英式音标，英文查词成功，一定存在
        /// </summary>
        public string uk_phonetic { get; set; }

        /// <summary>
        /// uk-speech  英式发音，英文查词成功，一定存在
        /// </summary>
        public string uk_speech { get; set; }

        /// <summary>
        /// 美式发音，英文查词成功，一定存在
        /// </summary>
        public string us_speech { get; set; }

        /// <summary>
        /// 基本释义
        /// </summary>
        public List<string> explains { get; set; }

    }

}
