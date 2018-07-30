using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  Entity;
using  Common;
using  Entity.SysManage;
using  BusinessLogic.SysManage;

namespace Answer.PC.Areas.User.Controllers
{
    public class UserController : MvcControllerBase
    {
        /// <summary>
        /// 玩家用户
        /// </summary>
        private readonly IT_User _user;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="user"></param>
        public UserController(IT_User user)
        {
            this._user = user;
        }

        /// <summary>
        /// 玩家信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [WriteLog(StructDictCode.分类.访问)]
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 充/扣钻石
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CKfangka(string id)
        {
            ViewBag.userID = id;
            return View();
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageList(string pagination, string keyword, string sdate, string edate)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            T_User user = new T_User();
            user.pageIndex = paginationobj.page;
            user.pageSize = paginationobj.rows;
            user.totalCount = paginationobj.total;
            user.nickName = keyword;
            user.startDate = sdate;
            user.endDate = edate;
            user.orderBy = paginationobj.sidx + " " + paginationobj.sord;
            List<T_User> list = _user.GetUserList(user);
            var jsonData = new
            {
                rows = list,
                total = list.Count > 0 ? list[0].total : 0,
                page = paginationobj.page,//list[0].pageIndex,
                records = list.Count > 0 ? list[0].totalCount : 0
            };
            return Success(jsonData);
        }


        /// <summary>
        /// 启用/禁用
        /// state: 0启用  1冻结
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateState(int keyValue, int state)
        {

            // statue     0-正常  1-冻结
            var data = new
            {
                userId = keyValue,
                statue = state
            };

            string json = JSONHelper.ObjectToJSON(data);

            Entity.Common.ResponseRet ret_data = WebSecurityHelper.GameServerApi.ToPost("setUserFrozenStatue", json);

            WebSecurityHelper.LogCommon.Current.WriteLog_Operation( Entity.OperationType.Update, (ret_data.ret == 0 ? "1" : "0"), "用户管理", keyValue + " Frozen =>" + state);

            switch (ret_data.ret)
            {
                case 0:
                    return Success("设置成功");
                case 303:
                    return Fail("设置失败,玩家已经在好友场游戏房间桌子坐下，冻结失败，请在玩家玩完本局之后再冻结");
                case 304:
                    return Fail("设置失败,玩家在俱乐部游戏房间坐下，冻结失败，请在玩家玩完本局游戏之后再冻结");
                default:
                    return Fail("设置失败");
            }

        }



        /// <summary>
        /// 充/扣钻石
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CKfangka(string user, decimal num, int type, string remark)
        {
            string url = Config.GetValue("BackGroundServer");
            var data = new
            {
                userId = user,
                diamond = num,
                remark = remark
            };
            string json = JSONHelper.ObjectToJSON(data);

          Entity.Common.ResponseRet result = null; //0成功，非0表示失败

            if (type == 1)
                result  = WebSecurityHelper.GameServerApi.ToPost("deductDiamond", json);//充值钻石协议
            else
                result = WebSecurityHelper.GameServerApi.ToPost("deductDiamond", json);//扣除钻石协议


            string str = "";
            if (result.result)
            {
                str = (result.result ? "接口成功" : "接口失败") + "::" + user + (type == 1 ? "  充值  " : "  扣除  ") + num + " ps::" + remark;
            }
            else if (result.ret == 101)

                str = "服务检查不到账号：" + user;
            else if (result.ret == 215)

                str = "扣除超出余额";
            else
                str = "服务请求失败";

            WebSecurityHelper.LogCommon.Current.WriteLog_Operation(OperationType.Submit, result.result ? "1" : "0", "充/扣钻石", str);

            return result.result ? Success("操作成功。") : Fail(str);
        }




    }
}