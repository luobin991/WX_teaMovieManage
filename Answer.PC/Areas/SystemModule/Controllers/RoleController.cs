using System;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using  Entity;
using  Common;
using  Entity.system;
using  BusinessLogic.SysManage;
using  Entity.SysManage;
using Answer.PC.WebSecurityHelper;

namespace Answer.PC.Areas.SystemModule.Controllers
{
    public class RoleController : MvcControllerBase
    {
        private readonly ISys_Role _role;
        public RoleController(ISys_Role role)
        {
            this._role = role;
        }

        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [WriteLog(StructDictCode.分类.访问)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }



        /// <summary>
        /// 获取角色列表信息
        /// </summary>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList(string keyword)
        {
            var data = this._role.GetList(keyword);
            return Success(data);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string keyword)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();

            Sys_Role role = new Sys_Role();
            role.F_FullName = keyword;
            role.pageIndex = paginationobj.page;
            role.pageSize = paginationobj.rows;

            var data = this._role.GetListPage(role);
            var jsonData = new
            {
                rows = data,
                total = data.Count > 0 ? data[0].total : 0,
                page = paginationobj.page,
                records = data.Count > 0 ? data[0].totalCount : 0
            };
            return Success(jsonData);

        }



        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, Sys_Role entity)
        {
            entity.F_DeleteMark = 0;
            if (string.IsNullOrWhiteSpace(keyValue))
            {
                entity.F_RoleId = Guid.NewGuid().ToString();
                entity.F_CreateDate = DateTime.Now;
                entity.F_CreateUserId = Answer.PC.WebSecurityHelper.Passport.Current.UserId.ToString();
                entity.F_CreateUserName = Passport.Current.UserNickName;
                this._role.AddRole(entity);
            }
            else
            {
                entity.F_RoleId = keyValue;
                entity.F_ModifyDate = DateTime.Now;
                entity.F_ModifyUserId = Answer.PC.WebSecurityHelper.Passport.Current.UserId.ToString();
                entity.F_ModifyUserName = Passport.Current.UserNickName;
                this._role.UpdateRole(entity);
            }

            return Success("保存成功！");
        }

        /// <summary>
        /// 删除表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteForm(string keyValue)
        {
            this._role.DeleteRole(keyValue, false);
            return Success("删除成功！");
        }




    }
}