using System;
using System.Web.Mvc;
using System.Collections.Generic;
using  Entity;
using  Common;
using  Entity.SysManage;
using  BusinessLogic.SysManage;

namespace Answer.PC.Areas.AuthorizeModule.Controllers
{
    public class AuthorizeController : MvcControllerBase
    {

        private readonly ISys_Authorize _authorize;
        public AuthorizeController (ISys_Authorize authorize)
        {
            this._authorize = authorize;
        }

        /// <summary>
        /// 功能权限设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }


        /// <summary>
        /// 获取设置信息
        /// </summary>
        /// <param name="objectId">设置对象</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string objectId)
        {
            var modules = GetItemIdList(objectId, 1);
            var buttons = GetItemIdList(objectId, 2);
            var columns = GetItemIdList(objectId, 3);
            var datajson = new
            {
                modules = modules,
                buttons = buttons,
                columns = columns
            };
            return Success(datajson);
        }

        /// <summary>
        /// 获取被授权的功能的主键字串
        /// </summary>
        /// <param name="objectId">对象主键（角色,用户）</param>
        /// <param name="itemType">项目类型:1-菜单2-按钮3-视图</param>
        /// <returns></returns>
        private List<string> GetItemIdList(string objectId, int itemType)
        {
            List<string> reslist = new List<string>();
            var list=  this._authorize.GetList(objectId, itemType);
            foreach (var item in list)
            {
                reslist.Add(item.itemId);
            }
            return reslist;
        }


        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <param name="objectType">权限分类-1角色2用户</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string objectId, int objectType, string strModuleId, string strModuleButtonId, string strModuleColumnId)
        {
            string[] moduleIds = strModuleId.Split(',');
            string[] moduleButtonIds = strModuleButtonId.Split(',');
            string[] moduleColumnIds = strModuleColumnId.Split(',');

            //authorizeIBLL.SaveAuthorize(objectType, objectId, moduleIds, moduleButtonIds, moduleColumnIds);
            this._authorize.SaveAuthorize(objectType,objectId, moduleIds, moduleButtonIds, moduleColumnIds,Answer.PC.WebSecurityHelper.Passport.Current.UserId);

            return Success("保存成功！");
        }



    }
}