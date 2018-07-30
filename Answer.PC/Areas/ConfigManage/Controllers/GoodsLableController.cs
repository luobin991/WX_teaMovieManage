using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Common;
using Entity.Enum;
using Entity.SysManage;
using BusinessLogic.Answer;

namespace Answer.PC.Areas.ConfigManage.Controllers
{
    public class GoodsLableController : MvcControllerBase
    {
        public readonly I_Lable _lable;
        public GoodsLableController(I_Lable lable)
        {
            this._lable = lable;
        }

        #region Lable
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            T_Lable lable = this._lable.GetLable(id, (int)Entity.Enum.RelateEnum.label);
            if (null == lable)
            {
                lable = new T_Lable();
            }
            return View(lable);
        }

        [HttpGet]
        public ActionResult GetPageList(string pagination, string keyword)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            T_Lable lable = new T_Lable();
            lable.pageIndex = paginationobj.page;
            lable.pageSize = paginationobj.rows;
            lable.totalCount = paginationobj.total;
            lable.lableName = keyword;
            lable.orderBy = paginationobj.sidx + " " + paginationobj.sord;
            lable.typeid = (int)RelateEnum.label;
            List<T_Lable> list = this._lable.GetLable_Datail(lable);
            var jsonData = new
            {
                rows = list,
                total = list.Count > 0 ? list[0].total : 0,
                page = paginationobj.page,
                records = list.Count > 0 ? list[0].totalCount : 0
            };
            return Success(jsonData);
        }


        [HttpPost]
        public ActionResult DelLable(int id)
        {
            //删除标签，包括旗下所有子标签
            int result = this._lable.DelLable(id);
            if (result > 0)
            {
                result = this._lable.DelLableDetailByParentID(id);
            }
            return Response(result);
        }

        [HttpPost]
        public ActionResult SaveLable(T_Lable model)
        {
            int result = 0;

            if (model.id == 0)
            {
                model.createTime = DateTime.Now;
                model.typeid = (int)RelateEnum.label;
                result = this._lable.SaveLableType(model);
            }
            else
            {
                model.typeid = (int)RelateEnum.label;
                result = this._lable.UpdateLableType(model);
            }
            return Response(result);
        }

        #endregion

        /***************************************************************************************************/

        #region LableDetail

        [HttpGet]
        public ActionResult DetailIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDetailPageList(string pagination, int pid)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            T_LableDetail lable = new T_LableDetail();
            lable.pageIndex = paginationobj.page;
            lable.pageSize = paginationobj.rows;
            lable.totalCount = paginationobj.total;
            lable.orderBy = paginationobj.sidx + " " + paginationobj.sord;
            lable.parentID = pid;
            List<T_LableDetail> list = this._lable.GetlableDetailPage(lable);
            var jsonData = new
            {
                rows = list,
                total = list.Count > 0 ? list[0].total : 0,
                page = paginationobj.page,
                records = list.Count > 0 ? list[0].totalCount : 0
            };
            return Success(jsonData);
        }


        [HttpGet]
        public ActionResult EditDetail(int pid, int id)
        {
            T_LableDetail lable = this._lable.GetLableDetail(id);
            if (null == lable)
            {
                lable = new T_LableDetail();
            }
            lable.parentID = pid;
            return View(lable);
        }


        [HttpPost]
        public ActionResult DelLableDetail(int id)
        {
            int result = this._lable.DelLableDetail(id);

            return Response(result);
        }


        [HttpPost]
        public ActionResult SaveLableDetail(T_LableDetail model)
        {
            int result = 0;

            if (model.id == 0)
            {
                model.createTime = DateTime.Now;
                model.updateTime = DateTime.Now;
                result = this._lable.SaveLableDetail(model);
            }
            else
            {
                result = this._lable.UpdateLableDetail(model);
            }
            return Response(result);
        }

        #endregion



    }
}