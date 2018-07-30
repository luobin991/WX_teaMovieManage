using  Entity.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  BusinessLogic.SysManage
{
    /// <summary>
    /// 系统用户接口
    /// </summary>
    public interface ISys_User
    {
        /// <summary>
        /// 获取系统用户列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<Sys_User> GetUserList(int pageIndex, int pageSize,string keyword);

        /// <summary>
        /// 获取系统用户列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<Sys_User> GetUserList(string keyword);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int AddUser(Sys_User user);
        /// <summary>
        /// 根据用户名称和密码获取管理员信息
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPwd">用户密码</param>
        /// <returns></returns>
        Sys_User GetUserInfo(string userName, string userPwd);
        /// <summary>
        /// 根据用户Id获取管理员信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        Sys_User GetUserInfoById(int userId);
        /// <summary>
        /// 根据用户Id更新用户登录信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="userIP">IP地址</param>
        /// <returns></returns>
        int UpdateUserLoginInfo(int userId, string userIP);
        /// <summary>
        /// 根据用户Id更新密码
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="newPwd">新密码</param>
        /// <returns></returns>
        int UpdateUserPWd(int userId, string newPwd);
        /// <summary>
        /// 根据用户Id更新状态
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="valid">用户状态</param>
        /// <returns></returns>
        int UpdateUserValid(int userId, int valid);



        /// <summary>
        /// 判断登录账号是否存在
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        int ExistsName(string loginName);

    }
}
