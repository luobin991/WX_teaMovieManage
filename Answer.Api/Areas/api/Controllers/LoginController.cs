using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Common;
using Entity;
using Entity.SysManage;
using BusinessLogic.SysManage;
using  Answer.Api.WebSecurityHelper;

namespace Answer.Api.Areas.api.Controllers
{
    public class LoginController : ApiBaseController
    {

        public LoginController() { }
        /// <summary>
        /// 系统用户
        /// </summary>
        private readonly IT_User _user;
        /// <summary>
        /// 构造函数
        /// </summary>
        public LoginController(IT_User user)
        {
            this._user = user;
        }

        [HttpGet]
        public JsonResult Index()
        {
            var result = new JsonResult();
            result.Data = "Welcome to Api";
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Verify_Code()
        {
            string imgBase64 = Convert.ToBase64String(new VerifyCode().GetVerifyCode());

            string code = WebHelper.GetSession("session_verifycode");
            WebHelper.RemoveSession("session_verifycode");

            string md5Code = Md5Helper.Encrypt(code.ToLower(), 16);

            SetCache<string>("cacheCode", md5Code);

            var data = new
            {
                code = 1,
                verificaCode = imgBase64,
                verificaCode1 = md5Code
            };
            return Success(data);
        }

        [HttpPost]
        public JsonResult userlogin()
        {
            string userName = "13855551111";
            string msg = "";
            try
            {
          
                T_User user =new DataAccess.SysManage.T_UserDAL().GetUserByPhone(userName);

                //用户信息写入cookies
                FormsAuthentication.SetAuthCookie(userName, false);

                string resultStr = OperatorHelper.Instance.AddLoginUser(userName, Entity.Enum.ReadonlyKey.LoginAppId);//写入缓存信息

                SetCache<T_User>("session_user", user);
                var data = new
                {
                    code = 1,
                    msg = "登录成功"
                };
                return Success(data);
            }
            catch (Exception ex)
            {
                msg = "API :: 登录失败,网络异常";
                LogCommon.Current.WriteLog_Exception(msg + "===" + ex.Message);
                LogHelper.Error(ex);
                return Fail(msg);
            }

        }

        //[HttpPost]
        //public JsonResult userlogin(string userName, string userPwd, string verificaCode, string verificaCode1)
        //{
        //    string msg = "";
        //    try
        //    {
        //        #region 验证用户
        //        if (string.IsNullOrEmpty(userName.Trim()))
        //        {
        //            return Fail("登录失败,用户名不能为空");
        //        }
        //        else if (string.IsNullOrEmpty(userPwd.Trim()))
        //        {
        //            return Fail("登录失败,用户密码不能为空");
        //        }
        //        else if (string.IsNullOrEmpty(verificaCode.Trim()))
        //        {
        //            return Fail("登录失败,验证码不能为空");
        //        }
        //        else if (string.IsNullOrEmpty(verificaCode1.Trim()))
        //        {
        //            return Fail("登录失败,验证码错误");
        //        }

        //        string code = GetCache<string>("cacheCode");

        //        if (Md5Helper.Encrypt(verificaCode.ToLower(), 16) != code || code != verificaCode1)
        //        {
        //            return Fail("验证码错误,请刷新");
        //        }

        //        //var user = _user.GetUserInfo(userName, StringHelper.GetMd5(userPwd));
        //        T_User user = _user.GetUserByPhone(userName);
        //        if (user == null)
        //        {
        //            return Fail("登录失败,用户名或密码不正确");
        //        }
        //        else if (user.isProxy != 1)
        //        {
        //            return Fail("非代理不允许登录");
        //        }

        //        #endregion

        //        //唯一标识ID
        //        string userGuid = WebCommon.GetOnlyCode();

        //        //拼接cookies字符串
        //        //用户信息写入cookies
        //        FormsAuthentication.SetAuthCookie(userName, false);
        //        var cookie = new HttpCookie("remember");
        //        cookie.Value = userName;
        //        Response.Cookies.Add(cookie);

        //        string resultStr = OperatorHelper.Instance.AddLoginUser(userName, Entity.Enum.ReadonlyKey.LoginAppId);//写入缓存信息

        //        SessionHelper.Del("CheckCode");     //删除验证码
        //        WebHelper.RemoveSession("session_verifycode");

        //        SetCache<T_User>("session_user", user);

        //        var data = new
        //        {
        //            code = 1,
        //            body = new { access_token = userGuid },
        //            msg = "登录成功"
        //        };
        //        return Success(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = "API :: 登录失败,网络异常";
        //        LogCommon.Current.WriteLog_Exception(msg + "===" + ex.Message);
        //        LogHelper.Error(ex);
        //        return Fail(msg);
        //    }

        //}



    }
}