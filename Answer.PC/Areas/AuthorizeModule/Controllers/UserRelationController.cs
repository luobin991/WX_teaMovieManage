using System;
using System.Web.Mvc;
using System.Collections.Generic;
using  Entity;
using  Common;
using  Entity.SysManage;
using  BusinessLogic.SysManage;

namespace Answer.PC.Areas.AuthorizeModule.Controllers
{
    public class UserRelationController : MvcControllerBase
    {

        private readonly ISys_UserRelation _userR;
        private readonly ISys_User _user;
        public UserRelationController(ISys_UserRelation userR, ISys_User user)
        {
            this._user = user;
            this._userR = userR;
        }
        /// <summary>
        /// 人员选择
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SelectForm()
        {
            return View();
        }
        /// <summary>
        /// 人员选择
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LookForm()
        {
            return View();
        }


        #region 获取数据
        /// <summary>
        /// 获取用户主键列表信息
        /// </summary>
        /// <param name="objectId">用户主键</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetUserIdList(string objectId)
        {
            var data = this._userR.GetUserIdList(objectId);
            string userIds = "";
            foreach (var item in data)
            {
                if (userIds != "")
                {
                    userIds += ",";
                }
                userIds += item.F_UserId;
            }
            //var userList = userIBLL.GetListByUserIds(userIds);
            List<Sys_User> userList = null;

            if (!string.IsNullOrEmpty(userIds))
            {
                userList = new List<Sys_User>();

                string[] userStrList = userIds.Split(',');
                foreach (string userId in userStrList)
                {
                    Sys_User entity = this._user.GetUserInfoById(userId.ToInt());
                    userList.Add(entity);
                }
            }


            var datajson = new
            {
                userIds = userIds,
                userInfoList = userList
            };
            return Success(datajson);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="objectId">对象主键</param>
        /// <param name="category">分类:1-角色2-岗位</param>
        /// <param name="userIds">对用户主键列表</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string objectId, int category, string userIds)
        {

            List<Sys_UserRelation> list = new List<Sys_UserRelation>();
            string[] userIdList = userIds.Split(',');
            foreach (string userId in userIdList)
            {
                Sys_UserRelation userRelationEntity = new Sys_UserRelation();
                userRelationEntity.F_UserRelationId = Guid.NewGuid().ToString();
                userRelationEntity.F_UserId = userId;
                userRelationEntity.F_Category = category;
                userRelationEntity.F_ObjectId = objectId;
                userRelationEntity.F_CreateUserId = WebSecurityHelper.Passport.Current.UserId.ToString();
                userRelationEntity.F_CreateUserName = WebSecurityHelper.Passport.Current.UserNickName;
                userRelationEntity.F_CreateDate = DateTime.Now;

                list.Add(userRelationEntity);
            }
            this._userR.SaveEntityList(objectId, list);

            return Success("保存成功！");
        }
        #endregion




    }
}