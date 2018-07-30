using BusinessLogic.SysManage;
using Common;
using DataAccess.SysManage;
using Entity;
using Entity.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Answer.Api.WebSecurityHelper
{/// <summary>
 /// 登录凭据
 /// </summary>
    public class Passport
    {
        /// <summary>
        /// 当前登录凭据
        /// </summary>
        public static Passport Current
        {
            get
            {
                return new Passport();
            }
        }
        /// <summary>
        /// 当前用户是否已登录
        /// </summary>
        public bool IsAuthenticated { get { return HttpContext.Current.User.Identity.IsAuthenticated; } }

        /// <summary>
        /// 当前登录用户Id
        /// </summary>
        public string User
        {
            get
            {
                //if (IsAuthenticated)
                //{
                //    return StringHelper.TryGetInt(HttpContext.Current.User.Identity.Name.Split('|')[0]);
                //}
                return "API USER";
            }
        }




    }
}