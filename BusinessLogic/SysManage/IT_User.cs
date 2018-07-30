using  Entity.Excel;
using  Entity.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  BusinessLogic.SysManage
{
    /// <summary>
    ///  游戏用户接口
    /// </summary>
    public interface IT_User
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        T_User GetUserInfo(string userId);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        T_User GetUserByPhone(string phone);


        /// <summary>
        /// 获取游戏用户列表
        /// </summary>
        /// <param name="user">用户Model</param>
        /// <returns></returns>
        List<T_User> GetUserList(T_User user);
        

        /// <summary>
        ///根据Id更新指定字段
        /// </summary>
        /// <param name="user">主键Id，更新字段值</param>
        /// <param name="attr">更新字段 数组</param>
        /// <returns></returns>
        int UpdateUser(T_User user, string[] attr);



        /// <summary>
        /// 根据用户组获取数据
        /// </summary>
        /// <param name="userArr"></param>
        /// <returns></returns>
        List<T_User> GetAgentList(int[] userArr);



    }
}
