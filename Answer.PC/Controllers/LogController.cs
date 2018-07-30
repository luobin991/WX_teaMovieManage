using System;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using Entity;
using Common;
using Entity.SysManage;
using BusinessLogic.SysManage;
using Newtonsoft.Json;


namespace Answer.PC.Controllers
{
    public class LogController : MvcControllerBase
    {

        private readonly ISys_Log _log;

        public LogController(ISys_Log log)
        {
            this._log = log;
        }

        /// <summary>
        /// 日志管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [WriteLog(StructDictCode.分类.访问)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }


        /// <summary>
        ///  分页查询
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询条件函数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson)
        {

            Pagination paginationobj = pagination.ToObject<Pagination>();
            var queryParam = queryJson.ToJObject();

            Sys_Log log = new Sys_Log();
            log.pageIndex = paginationobj.page;
            log.pageSize = paginationobj.rows;

            GetQueryVal(log, queryJson);

            List<Sys_Log> list = _log.GetLogPage(log);

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
        /// 分页查询(本人数据)
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageListByMy(string pagination, string queryJson)
        {

            Pagination paginationobj = pagination.ToObject<Pagination>();
            int userid = WebSecurityHelper.Passport.Current.UserId;

            Sys_Log log = new Sys_Log();
            log.pageIndex = paginationobj.page;
            log.pageSize = paginationobj.rows;

            GetQueryVal(log, queryJson);

            log.F_OperateUserId = userid.ToString();

            List<Sys_Log> list = _log.GetLogPage(log);

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
        /// 解析参数
        /// </summary>
        /// <param name="log"></param>
        /// <param name="queryJson"></param>
        private void GetQueryVal(Sys_Log log, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            // 关键字
            if (!queryParam["keyword"].IsEmpty())
            {

                log.F_Module = queryParam["keyword"].ToString();
            }

            // 日志分类
            if (!queryParam["CategoryId"].IsEmpty())
            {
                log.F_CategoryId = queryParam["CategoryId"].ToInt();
            }

            // 操作时间
            if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                log.startDate = queryParam["StartTime"].ToString();
                log.endDate = queryParam["EndTime"].ToString();
            }

            // 操作用户Id
            if (!queryParam["OperateUserId"].IsEmpty())
            {
                log.F_OperateUserId = queryParam["OperateUserId"].ToString();
            }
            // 操作用户账户
            if (!queryParam["OperateAccount"].IsEmpty())
            {
                log.F_OperateAccount = queryParam["OperateAccount"].ToString();
            }

            // 操作类型
            if (!queryParam["OperateType"].IsEmpty())
            {
                log.F_OperateType = queryParam["OperateType"].ToString();
            }

            // 功能模块
            if (!queryParam["Module"].IsEmpty())
            {
                log.F_Module = queryParam["Module"].ToString();
            }

        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="categoryId">日志分类Id</param>
        /// <param name="keepTime">保留时间段内</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveRemoveLog(int categoryId, string keepTime)
        {
            this._log.RemoveLog(categoryId, keepTime);

            return Success("清空成功。");
        }

        /// <summary>
        /// 访问功能
        /// </summary>
        /// <param name="moduleName">功能模块</param>
        /// <param name="moduleUrl">访问路径</param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult VisitModules(string moduleName, string moduleUrl)
        {
            Sys_Log logEntity = new Sys_Log();

            logEntity.F_CategoryId = StructDictCode.分类.访问;
            logEntity.F_OperateTypeId = ((int)OperationType.Visit).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Visit);

            logEntity.F_OperateAccount = WebSecurityHelper.Passport.Current.UserName + "(" + WebSecurityHelper.Passport.Current.UserNickName + ")";
            logEntity.F_OperateUserId = WebSecurityHelper.Passport.Current.UserId.ToString();
            logEntity.F_Module = moduleName;
            logEntity.F_ExecuteResult = "1";
            logEntity.F_ExecuteResultJson = "访问地址：" + moduleUrl;

            this._log.AddLog(logEntity);

            return Success("");

        }




    }
}