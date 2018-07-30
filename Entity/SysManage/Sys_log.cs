using System;
using  Entity.Common;

namespace  Entity.SysManage
{
    public class Sys_Log: SearchBase
    {

        public string F_LogId { get; set; }
        /// <summary>
        /// 分类 StructDictCode.分类
        /// </summary>
        public int F_CategoryId { get; set; }
        /// <summary>
        /// 操作用户Id
        /// </summary>
        public string F_OperateUserId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? F_OperateTime { get; set; }
        /// <summary>
        /// 操作用户
        /// </summary>
        public string F_OperateAccount { get; set; }
        /// <summary>
        /// 操作类型Id
        /// </summary>
        public string F_OperateTypeId { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public string F_OperateType { get; set; }
        /// <summary>
        /// 系统功能
        /// </summary>
        public string F_Module { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string F_IPAddress { get; set; }
        /// <summary>
        /// 主机
        /// </summary>
        public string F_Host { get; set; }
        /// <summary>
        /// 浏览器
        /// </summary>
        public string F_Browser { get; set; }
        /// <summary>
        /// 执行结果状态
        /// </summary>
        public string F_ExecuteResult { get; set; }
        /// <summary>
        /// 执行结果信息
        /// </summary>
        public string F_ExecuteResultJson { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public bool F_DeleteMark { get; set; }
    }


}
