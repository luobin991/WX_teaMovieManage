using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   Entity.Common
{
    /// <summary>
    /// 分页辅助类
    /// </summary>
    public class SearchBase
    {
        #region 辅助属性
        /// <summary>
        /// 开始时间--注册
        /// </summary>
        [DisplayName("开始时间")]
        [ExcelExportIgnore]
        public string startDate { get; set; }
        /// <summary>
        /// 结束时间--注册
        /// </summary>
        [DisplayName("结束时间")]
        [ExcelExportIgnore]
        public string endDate { get; set; }
        /// <summary>
        /// 开始时间--登录
        /// </summary>
        [DisplayName("登录开始时间")]
        [ExcelExportIgnore]
        public string startDateLogin { get; set; }
        /// <summary>
        /// 结束时间--登录
        /// </summary>
        [DisplayName("登录结束时间")]
        [ExcelExportIgnore]
        public string endDateLogin { get; set; }
        /// <summary>
        /// 页索引
        /// </summary>
        [DisplayName("页索引")]
        [ExcelExportIgnore]
        public int pageIndex { get; set; }
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        [DisplayName("每页显示记录数")]
        [ExcelExportIgnore]
        public int pageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        [DisplayName("总页数")]
        [ExcelExportIgnore]
        public int total
        {
            get
            {
                if (totalCount > 0)
                {
                    return (int)(totalCount % this.pageSize == 0 ? totalCount / this.pageSize : totalCount / this.pageSize + 1);
                }
                else
                {
                    return 0;
                }
            }
        }


        /// <summary>
        /// 总记录数
        /// </summary>
        [DisplayName("总记录数")]
        [ExcelExportIgnore]
        public long totalCount { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        [ExcelExportIgnore]
        public string orderBy { get; set; }


        #endregion

        /// <summary>
        /// 转化字符串金额
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
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
