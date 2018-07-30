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
    public class ModuleController : MvcControllerBase
    {

        private readonly ISys_MenuModule _meun;
        private readonly ISys_ModuleButton _but;
        private readonly ISys_ModuleColumn _col;

        public ModuleController(ISys_MenuModule menu, ISys_ModuleButton but, ISys_ModuleColumn col)
        {
            this._meun = menu;
            this._but = but;
            this._col = col;
        }


        /// <summary>
        /// 菜单目录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetModuleList()
        {
            ICollection<Entity.ModuleEntity> list = WebSecurityHelper.Passport.Current.MenuModuleList;
            return this.Success(list);
        }
        #region 视图
        /// <summary>
        /// 功能模块管理视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [WriteLog(StructDictCode.分类.访问)]
        public ActionResult Index()
        {
            WebSecurityHelper.LogCommon.Current.WriteLog_Visit();
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// 按钮编辑表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ButtonForm()
        {
            return View();
        }
        /// <summary>
        /// 视图编辑表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ColumnForm()
        {
            return View();
        }

        #endregion


        #region 功能模块
        /// <summary>
        /// 获取功能模块数据列表 无勾选框
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetModuleList_NotCheck()
        {

            List<TreeModel> treeList = new List<TreeModel>();
            foreach (var item in _meun.GetMenuList())
            {
                TreeModel node = new TreeModel();
                node.id = item.F_ModuleId;
                node.text = item.F_FullName;
                node.value = item.F_EnCode;
                node.showcheck = false;
                node.checkstate = 0;
                node.isexpand = (item.F_AllowExpand == 1);
                node.icon = item.F_Icon;
                node.parentId = item.F_ParentId;
                treeList.Add(node);
            }
            return this.Success(treeList.ToTree());
        }

        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetModuleTree_Check()
        {
            //var data = moduleIBLL.GetModuleTree();
            List<TreeModel> treeList = new List<TreeModel>();
            foreach (var item in _meun.GetMenuList())
            {
                TreeModel node = new TreeModel();
                node.id = item.F_ModuleId;
                node.text = item.F_FullName;
                node.value = item.F_EnCode;
                node.showcheck = true;
                node.checkstate = 0;
                node.isexpand = true;
                node.icon = item.F_Icon;
                node.parentId = item.F_ParentId;
                treeList.Add(node);
            }
            return this.Success(treeList.ToTree());
        }

        /// 获取列表数据根据父级id
        /// </summary>
        /// <param name = "parentId" > 父级id </ param >
        /// < param name="type">功能类型</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetModuleListByParentId(string keyword, string parentId)
        {
            var jsondata = _meun.GetModuleListByParentId(keyword, parentId);
            return this.Success(jsondata);
        }

        /// <summary>
        /// 获取树形数据(带勾选框)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetCheckTree()
        {
            var moduleList = _meun.GetMenuList();

            #region GetmoduleListTree
            List<TreeModel> moduleListTreeList = new List<TreeModel>();
            foreach (var item in moduleList)
            {
                TreeModel node = new TreeModel();
                node.id = item.F_ModuleId;
                node.text = item.F_FullName;
                node.value = item.F_EnCode;
                node.showcheck = true;
                node.checkstate = 0;
                node.isexpand = true;
                node.icon = item.F_Icon;
                node.parentId = item.F_ParentId;
                moduleListTreeList.Add(node);
            }

            #endregion

            #region GetButtonCheckTree
            //var buttonList = moduleIBLL.GetButtonCheckTree();
            List<TreeModel> buttonListTreeList = new List<TreeModel>();
            foreach (var module in moduleList)
            {
                TreeModel node = new TreeModel();
                node.id = module.F_ModuleId + "_luo_moduleId";
                node.text = module.F_FullName;
                node.value = module.F_EnCode;
                node.showcheck = true;
                node.checkstate = 0;
                node.isexpand = true;
                node.icon = module.F_Icon;
                node.parentId = module.F_ParentId + "_luo_moduleId";
                if (module.F_Target != "expand")
                {
                    List<Sys_ModuleButton> buttonList = _but.GetButtonList(module.F_ModuleId).ToList();
                    if (buttonList.Count > 0)
                    {
                        buttonListTreeList.Add(node);
                    }
                    foreach (var button in buttonList)
                    {
                        TreeModel buttonNode = new TreeModel();
                        buttonNode.id = button.ModuleButtonId;
                        buttonNode.text = button.FullName;
                        buttonNode.value = button.EnCode;
                        buttonNode.showcheck = true;
                        buttonNode.checkstate = 0;
                        buttonNode.isexpand = true;
                        buttonNode.icon = "fa fa-wrench";
                        buttonNode.parentId = (button.ParentId == "0" ? button.ModuleId + "_luo_moduleId" : button.ParentId);
                        buttonListTreeList.Add(buttonNode);
                    };
                }
                else
                {
                    buttonListTreeList.Add(node);
                }
            }
            #endregion

            #region GetColumnCheckTree
            List<TreeModel> columnListTreeList = new List<TreeModel>();
            //var columnList = moduleIBLL.GetColumnCheckTree();
            foreach (var module in moduleList)
            {
                TreeModel node = new TreeModel();
                node.id = module.F_ModuleId + "_luo_moduleId";
                node.text = module.F_FullName;
                node.value = module.F_EnCode;
                node.showcheck = true;
                node.checkstate = 0;
                node.isexpand = true;
                node.icon = module.F_Icon;
                node.parentId = module.F_ParentId + "_luo_moduleId";

                if (module.F_Target != "expand")
                {
                    List<Sys_ModuleColumn> columnList = this._col.GetColumnList(module.F_ModuleId).ToList();
                    if (columnList.Count > 0)
                    {
                        columnListTreeList.Add(node);
                    }
                    foreach (var column in columnList)
                    {
                        TreeModel columnNode = new TreeModel();
                        columnNode.id = column.ModuleColumnId;
                        columnNode.text = column.FullName;
                        columnNode.value = column.EnCode;
                        columnNode.showcheck = true;
                        columnNode.checkstate = 0;
                        columnNode.isexpand = true;
                        columnNode.icon = "fa fa-filter";
                        columnNode.parentId = column.ModuleId + "_luo_moduleId";
                        columnListTreeList.Add(columnNode);
                    };
                }
                else
                {
                    columnListTreeList.Add(node);
                }
            }
            #endregion

            var mList = moduleListTreeList.ToTree();
            var bList = buttonListTreeList.ToTree();
            var cList = columnListTreeList.ToTree();
            var jsonData = new
            {
                moduleList = mList,
                buttonList = bList,
                columnList = cList
            };

            return this.Success(jsonData);
        }



        /// <summary>
        /// 获取功能列表的树形数据(只有展开项)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetExpendModuleTree()
        {
            List<TreeModel> treeList = new List<TreeModel>();
            foreach (var item in _meun.GetMenuList())
            {
                if (item.F_Target == "expand")
                {
                    TreeModel node = new TreeModel();
                    node.id = item.F_ModuleId;
                    node.text = item.F_FullName;
                    node.value = item.F_EnCode;
                    node.showcheck = false;
                    node.checkstate = 0;
                    node.isexpand = true;
                    node.icon = item.F_Icon;
                    node.parentId = item.F_ParentId;
                    treeList.Add(node);
                }
            }
            return this.Success(treeList.ToTree());
        }
        #endregion





        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var module = _meun.GetModuleEntity(keyValue);

            var btns = _but.GetButtonList(keyValue);
            var cols = _col.GetColumnList(keyValue);
            var jsondata = new
            {
                moduleEntity = module,
                moduleButtons = btns,
                moduleColumns = cols
            };
            return this.Success(jsondata);
        }


        #region 提交数据


        /// <summary>
        /// 保存功能表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="moduleEntity">功能实体</param>
        /// <param name="moduleButtonListJson">按钮实体列表</param>
        /// <param name="moduleColumnListJson">视图实体列表</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string moduleEntityJson, string moduleButtonListJson, string moduleColumnListJson)
        {
            var moduleButtonList = moduleButtonListJson.ToList<Entity.SysManage.Sys_ModuleButton>();
            var moduleColumnList = moduleColumnListJson.ToList<Sys_ModuleColumn>();
            var moduleEntity = moduleEntityJson.ToObject<ModuleEntity>();
            if (string.IsNullOrWhiteSpace(moduleEntity.F_ParentId))
                moduleEntity.F_ParentId = "0";
            //新增
            if (string.IsNullOrWhiteSpace(keyValue))
            {
                moduleEntity.F_ModuleId = Guid.NewGuid().ToString();
                moduleEntity.F_CreateDate = DateTime.Now;
                moduleEntity.F_CreateUserId = Passport.Current.UserId.ToString();
                moduleEntity.F_CreateUserName = Passport.Current.UserName;
                moduleEntity.F_DeleteMark = 0;

                this._meun.AddModuleEntity(moduleEntity);
                WebSecurityHelper.LogCommon.Current.WriteLog_Operation(OperationType.Create, StructDictCode.状态.成功, "功能管理", moduleEntity.F_ModuleId);
            }
            //修改
            else
            {
                moduleEntity.F_ModuleId = keyValue;
                moduleEntity.F_ModifyDate = DateTime.Now;
                moduleEntity.F_ModifyUserId = Passport.Current.UserId.ToString();
                moduleEntity.F_ModifyUserName = Passport.Current.UserName;
                moduleEntity.F_DeleteMark = 0;


                this._meun.UpdateModuleEntity(moduleEntity);
                WebSecurityHelper.LogCommon.Current.WriteLog_Operation(OperationType.Update, StructDictCode.状态.成功, "功能管理", moduleEntity.F_ModuleId);
            }

            //moduleButtonList
            if (moduleButtonList != null && moduleButtonList.Count > 0)
            {
                this._but.DeleteModuleButton(moduleEntity.F_ModuleId);
                foreach (var item in moduleButtonList)
                {
                    item.ModuleId = moduleEntity.F_ModuleId;

                    if (moduleButtonList.Find(t => t.ModuleButtonId == item.ParentId) == null)
                        item.ParentId = "0";

                    item.ModuleButtonId = Guid.NewGuid().ToString();
                    this._but.AddModuleButton(item);
                }
            }

            //moduleColumnList
            if (moduleColumnList != null && moduleColumnList.Count > 0)
            {
                this._col.DeleteModuleColumn(moduleEntity.F_ModuleId);
                foreach (var item in moduleColumnList)
                {
                    item.ModuleId = moduleEntity.F_ModuleId;
                    item.ModuleColumnId = Guid.NewGuid().ToString();
                    this._col.AddModuleColumn(item);
                }
            }

            return Success("保存成功。");
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
            bool res = this._meun.DeleteModuleEntity(keyValue, true) > 0;

            WebSecurityHelper.LogCommon.Current.WriteLog_Operation(OperationType.Delete, res ? StructDictCode.状态.成功 : StructDictCode.状态.失败, "功能管理", keyValue + "-->" + res.ToString());
            if (res)
            {
                return Success("删除成功。");
            }
            else
            {
                return Fail("有子节点无法删除。");
            }

        }


        #endregion


    }
}