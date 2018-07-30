using System;
using System.Collections.Generic;
using System.Linq;
using  Common;
using  Entity;
using  Entity.SysManage;
using  DataAccess.SysManage;
using  BusinessLogic.SysManage;

namespace Answer.PC.WebSecurityHelper
{
    public class LogCommon
    {
        private readonly ISys_Log log;
        public LogCommon()
        {
            if (log == null)
            {
                this.log = new Sys_LogDAL();
            }
        }
        /// <summary>
        /// 当前凭据
        /// </summary>
        public static LogCommon Current
        {
            get
            {
                return new LogCommon();
            }
        }

        private Sys_Log logEntity = new Sys_Log();
        private void GetlogEntity()
        {

            logEntity.F_LogId = Guid.NewGuid().ToString();
            logEntity.F_OperateAccount = Passport.Current.UserName + "(" + Passport.Current.UserNickName + ")";
            logEntity.F_OperateUserId = Passport.Current.UserId.ToString();
            logEntity.F_OperateTime = DateTime.Now;
            logEntity.F_IPAddress = WebCommon.GetIPAddress();
            logEntity.F_Host = WebHelper.Host;
            logEntity.F_Browser = WebCommon.GetClientBrowserVersions();

            logEntity.F_DeleteMark = false;
        }

        /// <summary>
        /// 写入登录日志
        /// </summary>
        /// <param name="isLogin">是否登录</param>
        /// <param name="LoginOk">结果</param>
        /// <returns></returns>
        public void WriteLog_Login(bool isLogin, bool LoginOk)
        {
            GetlogEntity();
            logEntity.F_CategoryId = StructDictCode.分类.登陆;
            logEntity.F_OperateTypeId = ((int)OperationType.Login).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Login);
            logEntity.F_Module = Config.GetValue("SoftName");
            logEntity.F_ExecuteResult = LoginOk ? "1" : "0";
            logEntity.F_ExecuteResultJson = isLogin ? (LoginOk ? "登录成功" : "登录失败") : "退出系统";
            this.log.AddLog(logEntity);
        }

        /// <summary>
        /// 写入访问日志
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="moduleUrl">模块地址</param>
        /// <returns></returns>
        public void WriteLog_Visit(string moduleName, string moduleUrl)
        {
            GetlogEntity();
            logEntity.F_CategoryId = StructDictCode.分类.访问;
            logEntity.F_OperateTypeId = ((int)OperationType.Visit).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Visit);

            logEntity.F_Module = moduleName;
            logEntity.F_ExecuteResult = "1";
            logEntity.F_ExecuteResultJson = "访问地址：" + moduleUrl;

            this.log.AddLog(logEntity);
        }

        /// <summary>
        /// 写入访问日志
        /// </summary>
        /// <returns></returns>
        public void WriteLog_Visit()
        {
            string url = WebHelper.GetHttpItems("currentUrl").ToString();
            var menu = WebSecurityHelper.Passport.Current.MenuModuleList;
            string name = "";
            var entity = menu.Where(w => w.F_UrlAddress == url).FirstOrDefault();
            if (entity != null)
                name = entity.F_FullName;
            WebSecurityHelper.LogCommon.Current.WriteLog_Visit(name, url);
        }


        /// <summary>
        /// 写入操作日志
        /// </summary>
        /// <param name="oType">操作类型</param>
        /// <param name="result">执行结果状态  1 or 0</param>
        /// <param name="moduleName">模块名称</param>
        /// <param name="mark">操作描述</param>
        /// <returns></returns>
        public void WriteLog_Operation(OperationType oType,string result, string moduleName, string mark)
        {
            GetlogEntity();
            logEntity.F_CategoryId = StructDictCode.分类.操作;
            logEntity.F_OperateTypeId = ((int)oType).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(oType);

            logEntity.F_Module = moduleName;
            logEntity.F_ExecuteResult = result;
            logEntity.F_ExecuteResultJson = mark;

            this.log.AddLog(logEntity);
        }


        /// <summary>
        /// 写入异常日志
        /// </summary>
        /// <param name="mark">异常描述</param>
        /// <returns></returns>
        public void WriteLog_Exception(string mark)
        {

            GetlogEntity();
            logEntity.F_CategoryId = StructDictCode.分类.异常;
            logEntity.F_OperateTypeId = ((int)OperationType.Exception).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Exception);
            logEntity.F_Module = "";
            logEntity.F_ExecuteResult = "0";
            logEntity.F_ExecuteResultJson = mark;

            this.log.AddLog(logEntity);
        }


        /*
           string url = WebHelper.GetHttpItems("currentUrl").ToString();
            var menu = WebSecurityHelper.Passport.Current.MenuModuleList;
            string name = "";
            var entity = menu.Where(w => w.F_UrlAddress == url).FirstOrDefault();
            if (entity != null)
                name = entity.F_FullName;
            WebSecurityHelper.LogCommon.Current.WriteLog_Exception(name + "::" + url + "::" + info);
         */

    }

}