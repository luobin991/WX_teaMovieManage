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

namespace Answer.PC.Areas.Goods.Controllers
{
    public class TeaController : MvcControllerBase
    {

        private readonly I_Goods _goods;
        public readonly I_Lable _lable;
        public readonly I_Relate _letale;
        public TeaController(I_Goods goods, I_Lable lable, I_Relate letate)
        {
            this._goods = goods;
            this._lable = lable;
            this._letale = letate;
        }

        #region TEA Menu

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            T_Lable lable = this._lable.GetLable(id, (int)Entity.Enum.RelateEnum.tea);
            if (null == lable)
            {
                lable = new T_Lable();
                lable.typeid = (int)RelateEnum.tea;
            }
            return View(lable);
        }

        public ActionResult GetTeaMenuList()
        {
            List<T_Lable> list = this._lable.GetLables((int)Entity.Enum.RelateEnum.tea);
            return Success(list);
        }

        [HttpPost]
        public ActionResult SaveLable(T_Lable model)
        {
            int result = 0;

            if (model.id == 0)
            {
                model.createTime = DateTime.Now;
                model.typeid = (int)RelateEnum.tea;
                result = this._lable.SaveLableType(model);
            }
            else
            {
                model.typeid = (int)RelateEnum.tea;
                result = this._lable.UpdateLableType(model);
            }
            return Response(result);
        }

        [HttpPost]
        public ActionResult DelTeaMenu(int id)
        {
            //删除标签，包括旗下所有子项目
            int result = this._lable.DelLable(id);
            if (result > 0)
            {
                result = this._goods.DelGoodsByparentID(id);
            }
            return Success(result);
        }
        #endregion

        #region GOODS


        public ActionResult GetGoodsPage(string pagination, string pid, string keyword)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            T_Goods goods = new T_Goods();
            goods.pageIndex = paginationobj.page;
            goods.pageSize = paginationobj.rows;
            goods.totalCount = paginationobj.total;
            goods.orderBy = paginationobj.sidx + " " + paginationobj.sord;
            goods.parentID = pid.ToInt();
            goods.GoodsName = keyword;
            List<T_Goods> list = this._goods.GetGoodsPage(goods);
            List<int> ids = new List<int>();
            WebSecurityHelper.CommonController comm = new WebSecurityHelper.CommonController();
            foreach (var item in list)
            {
                if (!string.IsNullOrWhiteSpace(item.img))
                {
                    item.img = comm.GetURL("/Content/img/") + item.img;
                }
                ids.Add(item.id);
            }

            List<T_RelateLable> relates = this._letale.GetRelateLables(string.Join(",", ids));
            foreach (var item in list)
            {
                IEnumerable<T_RelateLable> items = relates.Where(w => w.fromID == item.id);
                string html = "";
                foreach (var lable in items)
                {
                    html += "<span class='label label-primary'>" + lable.lableName + "</span>&nbsp;";
                }
                item.lables = html;
            }

            var jsonData = new
            {
                rows = list,
                total = list.Count > 0 ? list[0].total : 0,
                page = paginationobj.page,
                records = list.Count > 0 ? list[0].totalCount : 0
            };
            return Success(jsonData);
        }

        public ActionResult EditGoods(int id, int pid)
        {
            T_Goods goods = this._goods.GetGoodsData(id);
            if (null == goods)
            {
                goods = new T_Goods();

                goods.parentID = pid;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(goods.img))
                {
                    goods.img = new WebSecurityHelper.CommonController().GetURL("/Content/img/") + goods.img;
                }
            }
            return View(goods);
        }

        public ActionResult BindTea_Lable(int fid)
        {

            //List<T_Relate> list = _letale.GetRelates((int)Entity.Enum.RelateEnum.label, fid);
            //string nums = "";
            //foreach (var item in list)
            //{
            //    nums += item.toID + ",";
            //}

            //ViewBag.nums = nums.TrimEnd(',');
            return View();
        }

        [HttpPost]
        public ActionResult SaveGoodsTea(T_Goods model)
        {
            int result = 0;
            if(!string.IsNullOrEmpty(model.img))
            {
                LogHelper.Info("img is exist and length" + model.img.Length);
            }

            if (model.id == 0)
            {
                model.updateTime = model.createTime = DateTime.Now;
                model.status = 1;

                string path = Server.MapPath("~/Content/img/");

                string imgPath = Common.ImgBase64.Base64StringToImage(model.img, path);
                model.img = imgPath;

                result = this._goods.SaveGoods(model);
            }
            else
            {
                T_Goods oldData = this._goods.GetGoodsData(model.id);
                if (oldData.img != model.img)
                {
                    if (model.img.Contains(oldData.img))
                    {
                        model.img = oldData.img;
                    }
                    else
                    {
                        string path = Server.MapPath("~/Content/img/");
                   
                        string imgPath = Common.ImgBase64.Base64StringToImage(model.img, path);
                        model.img = imgPath;
                        LogHelper.Info("img is exist and path:" + imgPath);
                    }
                }
                model.updateTime = DateTime.Now;
                result = this._goods.UpdateGoods(model);
            }
            return Response(result);
        }

        [HttpPost]
        public ActionResult UpdateGoodsStatus(int id, int status)
        {
            int result = this._goods.UpdateGoodsStatus(id, status);
            return Response(result);
        }

        public ActionResult DelGoodsTEA(int id)
        {
            int result = this._goods.DelGoodsByID(id);
            if (result > 0)
            {

            }
            return Response(result);
        }

        [HttpPost]
        public ActionResult SaveTea_Lable(int fid, string lables)
        {
            int result = 0;
            if (fid > 0)
            {
                result = this._letale.DelRelate((int)RelateType.tea_label, fid);
                if (!string.IsNullOrWhiteSpace(lables))
                {
                    string[] lableList = lables.Split(',');
                    foreach (var item in lableList)
                    {
                        T_Relate relate = new T_Relate();
                        relate.relateType = (int)RelateType.tea_label;
                        relate.fromID = fid;
                        relate.toID = item.ToInt();
                        relate.createUserID = PC.WebSecurityHelper.Passport.Current.UserId;
                        relate.createTime = DateTime.Now;

                        result += this._letale.SaveRelate(relate);
                    }
                }
            }
            return Response(result);
        }


        #endregion




    }
}