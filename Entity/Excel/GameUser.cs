using  Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Entity.Excel
{
    /// <summary>
    /// 用户管理Model--导出
    /// </summary>
    public class GameUser : SearchBase
    {
        /// <summary>
        /// 用户手机号
        /// </summary>
        [DisplayName("用户名")]
        public string phone_number { get; set; }
        /// <summary>
        /// 筹码
        /// </summary>
        [DisplayName("全部余额")]
        public long chip { get; set; }
        /// <summary>
        /// 泥码
        /// </summary>
        [DisplayName("泥码")]
        [ExcelExportIgnore]
        public long nima { get; set; }
        #region 辅助属性 可提现金额  chip-nima
        /// <summary>
        /// 可提现金额
        /// </summary>
        [DisplayName("可提现金额")]
        public long Withdraw
        {
            get
            {
                if (chip > 0 && chip > nima)
                {

                    return (chip - nima);
                }
                return 0;
            }
        }
        #endregion
        /// <summary>
        /// 注册时间
        /// </summary>
        [DisplayName("注册时间")]
        public DateTime create_time { get; set; }
        /// <summary>
        /// 是否已存款（0表示未存款1已存款）
        /// </summary>
        [DisplayName("是否已存款")]
        [ExcelExportIgnore]
        public int Ischarged { get; set; }
        #region 辅助属性 存款状态名称
        /// <summary>
        /// 存款状态
        /// </summary>
        [DisplayName("存款状态")]
        public string IschargedName
        {
            get
            {
                if (Ischarged > -1)
                {
                    return Ischarged == 0 ? "未存过" : "已存过";
                }
                return "";
            }
        }
        #endregion
        ///// <summary>
        ///// 返水比例
        ///// </summary>
        //[DisplayName("返水比例")]
        //public int waterRate { get; set; }

        /// <summary>
        /// 反水比例(牛牛)
        /// </summary>
        [DisplayName("牛牛返水比例")]
        public decimal waterRateBull { get; set; }
        /// <summary>
        /// 反水比例(百家乐)
        /// </summary>
        [DisplayName("百家乐返水比例")]
        public decimal waterRateBaccarat { get; set; }
        /// <summary>
        /// 反水比例(百家乐庄抽水模式)
        /// </summary>
        [DisplayName("百家乐庄抽水模式返水比例")]
        public decimal waterRateBanker { get; set; }
        /// <summary>
        /// 用户注册IP
        /// </summary>
        [DisplayName("用户注册IP")]
        public string registerIP { get; set; }
    }
}
