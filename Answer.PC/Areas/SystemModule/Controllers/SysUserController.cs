using System;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using  Entity;
using  Common;
using  Entity.SysManage;
using  BusinessLogic.SysManage;

namespace Answer.PC.Areas.SystemModule.Controllers
{
    public class SysUserController : MvcControllerBase
    {



        /// <summary>
        /// /系统用户
        /// </summary>
        private readonly ISys_User _user;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="user"></param>
        public SysUserController(ISys_User user)
        {
            this._user = user;
        }

        /// <summary>
        /// 用户管理主页
        ///  GET: SystemModule/SysUser
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [WriteLog(StructDictCode.分类.访问)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 用户管理表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form(int id)
        {
            return View();
        }


        /// <summary>
        /// 用户管理修改密码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PassWordForm()
        {
            return View();
        }
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VerifyCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }


        /// <summary>
        /// 获取系统用户
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public ActionResult GetPageList(string pagination, string Keyword)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();

            List<Sys_User> list = _user.GetUserList(paginationobj.page, paginationobj.rows, Keyword).ToList();
            var jsonData = new
            {
                rows = list,
                total = list.Count > 0 ? list[0].total : 0,
                page = paginationobj.page,
                records = list.Count > 0 ? list[0].totalCount : 0
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="keyword">查询关键词</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList(string keyword)
        {
            List<Sys_User> list = _user.GetUserList(keyword).ToList();

            return Success(list);
        }
        /// <summary>
        /// 用户管理表单
        /// </summary>
        /// <returns></returns>
        public ActionResult SaveForm(Sys_User user)
        {
            user.UserType = 1007002;
            user.RegistIP = Common.WebCommon.GetIPAddress();
            user.Valid = 1008001;
            bool result = _user.AddUser(user) > 0;

            WebSecurityHelper.LogCommon.Current.WriteLog_Operation(OperationType.Update, result.ToString(), "系统用户", "KEY：" + user.Id);
            return result ? Success("操作成功。") : Fail("操作失败。");
        }

        /// <summary>
        /// 启用禁用账号
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult UpdateState(string keyValue, int state)
        {
            int result = _user.UpdateUserValid(keyValue.ToInt(), state);
            WebSecurityHelper.LogCommon.Current.WriteLog_Operation(OperationType.Update, result.ToString(), "系统用户状态", "KEY：" + keyValue + "修改状态：" + state);
            return Success("操作成功！");
        }

        /// <summary>
        /// 重置用户账号密码
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult ResetPassword(string keyValue)
        {
            Sys_User user = _user.GetUserInfoById(WebSecurityHelper.Passport.Current.UserId);
            if (user.UserType != 1007001)
            {
                return Fail("当前账户不能重置用户密码");
            }

            string password = Md5Helper.Encrypt(Config.GetValue("sysUserPassword"), 32).ToUpper();
            int result = _user.UpdateUserPWd(keyValue.ToInt(), password);
            WebSecurityHelper.LogCommon.Current.WriteLog_Operation(OperationType.Update, result.ToString(), "系统用户重置密码", "KEY：" + keyValue);
            return Success("操作成功！");
        }

        /// <summary>
        /// 验证旧密码
        /// </summary>
        /// <param name="OldPassword"></param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult ValidationOldPassword(string OldPassword)
        {
            Sys_User user = _user.GetUserInfoById(WebSecurityHelper.Passport.Current.UserId);
            if (OldPassword.ToUpper() != user.UserPassWord)
            {
                return Fail("原密码错误，请重新输入");
            }
            else
            {
                return Success("通过信息验证");
            }
        }

        /// <summary>
        /// 提交修改密码
        /// </summary>
        /// <param name="password">新密码</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="verifyCode">验证码</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult SubmitResetPassword(string password, string oldPassword, string verifyCode)
        {
            //verifyCode = Md5Helper.Encrypt(verifyCode.ToLower(), 16);
            //string code = SessionHelper.Get("CheckCode");
            string code =  WebHelper.GetSession("session_verifycode");
            WebHelper.RemoveSession("session_verifycode");
            if (string.IsNullOrWhiteSpace(code) || verifyCode.ToUpper() != code.ToUpper())
            {
                return Fail("验证码错误，请重新输入");
            }
            Sys_User user = _user.GetUserInfoById(WebSecurityHelper.Passport.Current.UserId);

            if (user.UserType == 1007001)
            {
                return Fail("当前账户不能修改密码");
            }
            if (oldPassword.ToUpper() != user.UserPassWord)
            {
                return Fail("原密码错误，请重新输入");
            }
            _user.UpdateUserPWd(user.Id, password);

            Session.Abandon();
            Session.Clear();
            OperatorHelper.Instance.EmptyCurrent();
            return Success("密码修改成功，请牢记新密码。\r 将会自动安全退出。");
        }


    }
}