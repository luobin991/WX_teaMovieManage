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

namespace Answer.PC.Areas.Order.Controllers
{
    public class OrderController : MvcControllerBase
    {


        private readonly I_Order _order;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="user"></param>
        public OrderController(I_Order _order)
        {
            this._order = _order;
        }


        [HttpGet]
        [WriteLog(StructDictCode.分类.访问)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPageList(string pagination, string Keyword)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();

            List<T_Order> list = _order.GetOrderPage(paginationobj.page, paginationobj.rows, Keyword).ToList();
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
        public ActionResult OrderDetail()
        {
            return View();
        }




        [HttpGet]
        public ActionResult GetOrderDetail(string pagination, int id)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();

            List<T_orderList> list = _order.GetOrderDetail(id).ToList();
            var jsonData = new
            {
                rows = list,
                total = 1,
                page = paginationobj.page,
                records = list.Count
            };
            return Success(jsonData);
        }

    }
}