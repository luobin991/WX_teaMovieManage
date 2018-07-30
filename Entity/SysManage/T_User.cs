using  Entity.Common;
using System;

namespace  Entity.SysManage
{
    /// <summary>
    /// 游戏用户Model
    /// </summary>
    public class T_User : SearchBase
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int userId { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string phoneNum { get; set; }

        /// <summary>
        /// 微信的Id
        /// </summary>
        public string wxId { get; set; }
        /// <summary>
        /// 微信性别
        /// </summary>
        public int sex { get; set; }

        /// <summary>
        /// 微信昵称
        /// </summary>
        public string nickName { get; set; }

        /// <summary>
        /// 微信头像url
        /// </summary>
        public string headImgUrl { get; set; }

        /// <summary>
        /// 最新登录的地理位置
        /// </summary>
        public string loginAddress { get; set; }

        /// <summary>
        /// 最新登录的Ip
        /// </summary>
        public string registerIp { get; set; }
        /// <summary>
        /// loginIp
        /// </summary>
        public string loginIp { get; set; }
        /// <summary>
        /// 玩家在游戏内的钻石
        /// </summary>
        public int diamond { get; set; }

        /// <summary>
        /// 已玩局数
        /// </summary>
        public int roundNum { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime registerTime { get; set; }
        /// <summary>
        /// 最后的更新时间
        /// </summary>
        public DateTime loginTime { get; set; }
        /// <summary>
        /// 是否冻结，0-未冻结 1-冻结
        /// </summary>
        public int isFrozen { get; set; }
        /// <summary>
        /// 是否代理
        /// </summary>
        public int isProxy { get; set; }

        /// <summary>
        /// 会话Id  用于自动登录时使用
        /// </summary>
        public string sessionId { get; set; }

        /// <summary>
        /// 绑定的推荐码
        /// </summary>
        public int inviteCode { get; set; }

        /// <summary>
        /// 申请加入俱乐部数量
        /// </summary>
        public int applyClubCount { get; set; }
        /// <summary>
        /// 加入俱乐部数量
        /// </summary>
        public int clubCount { get; set; }

    }
}
