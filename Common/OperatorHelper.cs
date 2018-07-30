using System;
using System.Collections.Generic;
using System.Web;
using  Entity.system;
using  Entity.Enum;

namespace  Common
{
    public class OperatorHelper
    {

        /// <summary>
        /// 获取实例
        /// </summary>
        public static OperatorHelper Instance
        {
            get { return new OperatorHelper(); }
        }


        /// <summary>
        /// 登录者信息添加到缓存中
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="appId">应用id</param>
        /// <param name="cookie">是否保存cookie，默认是</param>
        /// <returns></returns>
        public string AddLoginUser(string account, string appId,bool cookie = true)
        {
            string token = Guid.NewGuid().ToString();
            try
            {
                Operator operatorInfo = new Operator();
                operatorInfo.appId = appId;
                operatorInfo.account = account;
                operatorInfo.logTime = DateTime.Now;
                operatorInfo.iPAddress = WebCommon.GetIPAddress();
                operatorInfo.browser = WebCommon.GetClientBrowserVersions();
                operatorInfo.token = token;

                if (cookie) //是否保存cookie
                {
                    string cookieMark = WebHelper.GetCookie(ReadonlyKey.LoginUserMarkKey).ToString();
                    if (string.IsNullOrWhiteSpace(cookieMark))
                    {
                        WebHelper.WriteCookie(ReadonlyKey.LoginUserMarkKey, operatorInfo.account); //写入登录者标识
                    }
                    WebHelper.WriteCookie(ReadonlyKey.cacheKeyOperator + operatorInfo.account, operatorInfo.token); //adms_operator_XX = token
                }

                WebHelper.WriteCookie(ReadonlyKey.LoginUserToken, operatorInfo.token); // 写入登录秘钥

                CacheHelper.Set<Operator>(ReadonlyKey.cacheKeyOperator + operatorInfo.account, operatorInfo); //写入缓存信息：当前连接用户

                return operatorInfo.token;
                #region  code fail
                //if (cookie) //是否保存cookie
                //{
                //    string cookieMark = WebHelper.GetCookie(ReadonlyKey.LoginUserMarkKey).ToString(); //标记登录的浏览器
                //    if (string.IsNullOrWhiteSpace(cookieMark))
                //    {
                //        //operatorInfo.loginMark = Guid.NewGuid().ToString(); //创建登录者标识
                //        WebHelper.WriteCookie(ReadonlyKey.LoginUserMarkKey, operatorInfo.browser + "|" + operatorInfo.iPAddress); //写入登录者标识
                //    }
                //    else
                //        operatorInfo.loginMark = cookieMark;// 登录者标识 = 标记登录的浏览器

                //    WebHelper.WriteCookie(ReadonlyKey.LoginUserToken, token); // 写入登录秘钥
                //}
                //else
                //    operatorInfo.loginMark = loginMark; // 登录者标识 = 设备标识

                //当前用户信息
                //Dictionary<string, string> dic = new Dictionary<string, string>();
                //dic[ReadonlyKey.cacheKeyToken + account] = "1";
                //Dictionary<string, string> dicOld = CacheHelper.Get<Dictionary<string, string>>(ReadonlyKey.cacheKeyToken + account);
                //if (dicOld != null && dicOld.Count > 0)
                //{
                //    CacheHelper.Remove(ReadonlyKey.cacheKeyToken + account);
                //}
                //CacheHelper.Set<Dictionary<string, string>>(ReadonlyKey.cacheKeyToken + account, dic);

                //CacheHelper.Set<Operator>(ReadonlyKey.cacheKeyOperator + operatorInfo.loginMark, operatorInfo); //写入缓存信息：当前连接用户
                //return token; 
                #endregion
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 清空当前登录信息
        /// </summary>
        /// <param name="token">登录票据</param>
        /// <param name="loginMark">登录设备标识</param>
        public void EmptyCurrent()
        {
            string loginMark = WebHelper.GetCookie(ReadonlyKey.LoginUserMarkKey).ToString();

            try
            {
                Operator operatorInfo = CacheHelper.Get<Operator>(ReadonlyKey.cacheKeyOperator + loginMark);
                if (operatorInfo != null)
                {
                    CacheHelper.Remove(ReadonlyKey.cacheKeyOperator + operatorInfo.account);
                    WebHelper.RemoveCookie(ReadonlyKey.cacheKeyOperator + operatorInfo.account);
                }

                WebHelper.RemoveCookie(ReadonlyKey.LoginUserToken);
                WebHelper.RemoveCookie(ReadonlyKey.LoginUserMarkKey);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// 判断登录状态
        /// </summary>
        /// <param name="token">登录票据</param>
        /// <param name="loginMark">登录设备标识</param>
        /// <returns>-1未登录,1登录成功,0登录过期</returns>
        public OperatorResult IsOnLine()
        {
            //string token = WebHelper.GetCookie(ReadonlyKey.LoginUserToken).ToString();
            string loginMark = WebHelper.GetCookie(ReadonlyKey.LoginUserMarkKey).ToString();


            OperatorResult operatorResult = new OperatorResult();
            operatorResult.stateCode = -1; // -1未登录,1登录成功,0登录过期
            try
            {
                if (string.IsNullOrEmpty(loginMark))
                {
                    return operatorResult;
                }
                Operator operatorInfo = CacheHelper.Get<Operator>(ReadonlyKey.cacheKeyOperator + loginMark);
                if (operatorInfo != null)
                {

                    TimeSpan span = (TimeSpan)(DateTime.Now - operatorInfo.logTime);
                    if (span.TotalHours >= 2)// 登录操作过12小时移除
                    {
                        EmptyCurrent();
                    }
                    else
                    {
                         Entity.SysManage.Sys_LoginLog userInfo = new Entity.SysManage.Sys_LoginLog();

                        if (!string.IsNullOrWhiteSpace(operatorInfo.account))
                        {
                            userInfo.CreateDate = operatorInfo.logTime;
                            userInfo.IPAddress = operatorInfo.iPAddress;
                            userInfo.BrowserType = operatorInfo.browser;

                            if (HttpContext.Current != null)
                            {
                                HttpContext.Current.Items.Add("LoginUserInfo", userInfo);
                            }
                            operatorResult.userInfo = userInfo;
                            operatorResult.stateCode = 1;

                            operatorInfo.logTime = DateTime.Now;
                            CacheHelper.Set<Operator>(ReadonlyKey.cacheKeyOperator + operatorInfo.account, operatorInfo); //写入缓存信息：当前连接用户
                        }
                        else
                        {
                            operatorResult.stateCode = 0;
                        }
                    }
                }
                return operatorResult;
            }
            catch (Exception)
            {
                return operatorResult;
            }
        }






    }


}
