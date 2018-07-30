using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Common;
using Entity;
using Entity.SysManage;
using BusinessLogic.SysManage;
using Answer.PC.WebSecurityHelper;

namespace Answer.PC.Controllers
{
    [CustomError]
    public class LoginController : Controller
    {
        /// <summary>
        /// 系统用户
        /// </summary>
        private readonly ISys_User _user;
        /// <summary>
        /// 构造函数
        /// </summary>
        public LoginController(ISys_User user)
        {
            this._user = user;
        }
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (true)
            {

                var user = _user.GetUserInfo("admin", StringHelper.GetMd5("123123"));//StringHelper.GetMd5(userPassWord)

                //更新用户登录信息
                string userIP = WebCommon.GetIPAddress();
                int result = _user.UpdateUserLoginInfo(user.Id, userIP);
                //唯一标识ID
                string userGuid = WebCommon.GetOnlyCode();
                //拼接cookies字符串
                var userData = user.Id + "|" + user.UserName + "|" + user.UserNickName + "|" + user.UserType + "|" + user.RegistIP + "|" + userIP + "|" + userGuid;
                //用户信息写入cookies
                FormsAuthentication.SetAuthCookie(userData, false);
                var cookie = new HttpCookie("remember");
                cookie.Value = userData;
                Response.Cookies.Add(cookie);

                string resultStr = OperatorHelper.Instance.AddLoginUser(user.UserName, Entity.Enum.ReadonlyKey.LoginAppId);//写入缓存信息

                return RedirectToAction("index", "Home");
            }

            return View();
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Verify_Code()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPassWord">用户密码</param>
        /// <param name="yzm">验证码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string userName, string userPassWord, string checkCode)
        {
            string msg = "";
            try
            {
                bool falg = UserLogin(userName, userPassWord, checkCode, out msg);
                if (falg)
                {
                    return Content(new ResParameter { code = ResponseCode.success, info = msg, data = new object { } }.ToJson());
                }
                else
                {
                    return Content(new ResParameter { code = ResponseCode.fail, info = msg, data = 1 }.ToJson());
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex, "/Home/Login");
                return Content(new ResParameter { code = ResponseCode.fail, info = ex.Message, data = 1 }.ToJson());
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPassWord">用户密码</param>
        /// <param name="yzm">验证码</param>
        [NonAction]
        public bool UserLogin(string userName, string userPassWord, string checkCode, out string msg)
        {

            if (string.IsNullOrEmpty(userName.Trim()))
            {
                msg = "登录失败,用户名不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(userPassWord.Trim()))
            {
                msg = "登录失败,用户密码不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(checkCode.Trim()))
            {
                msg = "登录失败,验证码不能为空";
                return false;
            }
            try
            {
                string code = WebHelper.GetSession("session_verifycode");
                if (code.ToLower() != checkCode.ToLower())
                {
                    msg = "登录失败,验证码错误";
                    return false;
                }
                var user = _user.GetUserInfo(userName, userPassWord);//StringHelper.GetMd5(userPassWord)
                if (user == null)
                {
                    msg = "登录失败,用户名或密码不正确";
                    return false;
                }
                if (user.Valid == StructDictCode.状态.注销)
                {
                    msg = "登录失败,该用户已经注销";
                    return false;
                }
                //更新用户登录信息
                string userIP = WebCommon.GetIPAddress();
                int result = _user.UpdateUserLoginInfo(user.Id, userIP);
                //唯一标识ID
                string userGuid = WebCommon.GetOnlyCode();
                //拼接cookies字符串
                var userData = user.Id + "|" + user.UserName + "|" + user.UserNickName + "|" + user.UserType + "|" + user.RegistIP + "|" + userIP + "|" + userGuid;
                //用户信息写入cookies
                FormsAuthentication.SetAuthCookie(userData, false);
                var cookie = new HttpCookie("remember");
                cookie.Value = userData;
                Response.Cookies.Add(cookie);

                string resultStr = OperatorHelper.Instance.AddLoginUser(user.UserName, Entity.Enum.ReadonlyKey.LoginAppId);//写入缓存信息
                WebSecurityHelper.LogCommon.Current.WriteLog_Login(true, true);
                msg = "登录成功";
                //删除验证码
                WebHelper.RemoveSession("session_verifycode");
                return true;
            }
            catch (Exception ex)
            {
                msg = "登录失败,网络异常";
                LogCommon.Current.WriteLog_Exception(msg + "===" + ex.Message);
                LogHelper.Error(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            string guid = Passport.Current.UserGuid;
            //清除Session
            SessionHelper.DelAll();
            //清除cookies
            FormsAuthentication.SignOut();
            CacheHelper.Remove("GetMenuList/" + Passport.Current.UserId);
            CacheHelper.Remove("GetMenuList/" + StructDictCode.状态.正常);
            OperatorHelper.Instance.EmptyCurrent();
            WebSecurityHelper.LogCommon.Current.WriteLog_Login(false, true);
            return RedirectToAction("Index");
        }


        /// <summary>
        /// 获取用户登录信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetUserInfo()
        {
            var data = new
            {
                realName = Passport.Current.UserName,
                isSystem = true
            };
            return Content(new ResParameter { code = ResponseCode.success, info = "响应成功", data = data }.ToJson());
        }

    }
}