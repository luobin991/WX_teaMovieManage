using Dapper;
using  BusinessLogic.SysManage;
using  Common;
using  Common.DBHelper;
using  Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  DataAccess.SysManage
{
    /// <summary>
    /// 系统模块实现类
    /// </summary>
    public class Sys_MenuModuleDAL : ISys_MenuModule
    {


        /// <summary>
        /// 菜单模块实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleEntity GetModuleEntity(string keyValue)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string sql = "select * from sys_menu where F_ModuleId =@F_ModuleId";
                var moduleEntity = conn.Query<ModuleEntity>(sql, new { F_ModuleId = keyValue });
                return moduleEntity.FirstOrDefault();
            }
        }




        /// <summary>
        /// 根据Id获取菜单模块列表
        /// </summary>
        /// <param name="valid">菜单状态</param>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetMenuList(int valid)
        {
            List<ModuleEntity> tmplist = CacheHelper.Get<List<ModuleEntity>>("GetMenuList/" + valid);
            if (tmplist == null || tmplist.Count() <= 0)
            {
                using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
                {
                    string sql = "select * from sys_menu where F_DeleteMark=0 and F_EnabledMark=@valid order by F_SortCode asc";
                    var menulist = conn.Query<ModuleEntity>(sql, new { valid = valid });
                    if (menulist != null && menulist.Count() > 0)
                        CacheHelper.Set<List<ModuleEntity>>("GetMenuList/" + valid, menulist.ToList());
                    return menulist;
                }
            }
            return tmplist;
        }

        /// <summary>
        /// 根据UserId获取菜单模块列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<ModuleEntity> GetMenuList(string userid)
        {
            List<ModuleEntity> tmplist = CacheHelper.Get<List<ModuleEntity>>("GetMenuList/" + userid);
            return tmplist;
        }

        /// <summary>
        /// 根据Id获取菜单模块列表
        /// </summary>
        /// <param name="valid">菜单状态</param>
        /// <param name="idArray">菜单ID列表</param>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetMenuList(int valid, string idArray, string userid)
        {
            List<ModuleEntity> tmplist = CacheHelper.Get<List<ModuleEntity>>("GetMenuList/" + userid);
            if (tmplist == null || tmplist.Count() <= 0)
            {
                using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
                {
                    string sql = "select * from sys_menu where F_DeleteMark=0 and F_EnabledMark=@F_EnabledMark ";
                    if (!string.IsNullOrWhiteSpace(idArray))
                    {
                        sql += " and F_ModuleId in ( ";
                        foreach (var item in idArray.Split(','))
                        {
                            sql += "'" + item + "',";
                        }
                        sql = sql.TrimEnd(',')+" ) ";
                    }
                    sql += "order by F_SortCode asc";
                    var menulist = conn.Query<ModuleEntity>(sql, new { F_EnabledMark = valid });
                    if (menulist != null && menulist.Count() > 0)
                        CacheHelper.Set<List<ModuleEntity>>("GetMenuList/" + userid, menulist.ToList());
                    return menulist;
                }
            }
            return tmplist;
        }


        /// <summary>
        /// 获取菜单模块列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetMenuList()
        {
            List<ModuleEntity> tmplist = CacheHelper.Get<List<ModuleEntity>>("GetMenuList/ALL");
            if (tmplist == null || tmplist.Count() <= 0)
            {
                using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
                {
                    string sql = "select * from sys_menu where F_DeleteMark=0 order by F_SortCode asc";
                    var menulist = conn.Query<ModuleEntity>(sql, null);
                    if (menulist != null && menulist.Count() > 0)
                        CacheHelper.Set<List<ModuleEntity>>("GetMenuList/ALL", menulist.ToList());
                    return menulist;
                }
            }
            return tmplist;
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        private void RemoveCacheHelper(string key)
        {
            CacheHelper.Remove(key);
        }

        /// <summary>
        /// 查询目录
        /// </summary>
        /// <param name="keyword">目录关键字</param>
        /// <param name="parentId">父级ID</param>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleListByParentId(string keyword, string parentId)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sb = new StringBuilder();

                sb.Append("select * from sys_menu where  F_ParentId=@F_ParentId  "); //F_DeleteMark=0 AND

                param.Add("@F_ParentId", parentId);

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sb.Append(" and F_FullName LIKE @F_FullName");
                    param.Add("@F_FullName", keyword);
                }

                sb.Append(" order by F_SortCode asc ");
                var menulist = conn.Query<ModuleEntity>(sb.ToString(), param);
                return menulist;
            }
        }



        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int AddModuleEntity(ModuleEntity entity)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"INSERT INTO sys_menu(F_ModuleId,F_ParentId,F_EnCode,F_FullName,F_Icon,F_UrlAddress,F_Target,F_IsMenu,F_AllowExpand,F_IsPublic,F_AllowEdit,F_AllowDelete,
                    F_SortCode,F_DeleteMark, F_EnabledMark, F_Description, F_CreateDate, F_CreateUserId, F_CreateUserName)
                    VALUES
                    (@F_ModuleId, @F_ParentId, @F_EnCode, @F_FullName, @F_Icon, @F_UrlAddress, @F_Target, @F_IsMenu, @F_AllowExpand, @F_IsPublic, @F_AllowEdit, @F_AllowDelete, 
                    @F_SortCode, @F_DeleteMark, @F_EnabledMark, @F_Description, NOW(), @F_CreateUserId, @F_CreateUserName); ");

                var num = conn.Execute(sb.ToString(), entity);
                RemoveCacheHelper("GetMenuList/ALL");
                return num;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpdateModuleEntity(ModuleEntity entity)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"UPDATE sys_menu  SET F_ParentId=@F_ParentId,F_EnCode=@F_EnCode,F_FullName=@F_FullName,F_Icon=@F_Icon,F_UrlAddress=@F_UrlAddress,
                    F_Target=@F_Target,F_IsMenu=@F_IsMenu,F_AllowExpand=@F_AllowExpand,F_IsPublic=@F_IsPublic,F_AllowEdit=@F_AllowEdit,F_AllowDelete=@F_AllowDelete,
                    F_SortCode=@F_SortCode,F_DeleteMark=@F_DeleteMark,F_EnabledMark=@F_EnabledMark,F_Description=@F_Description,
                    F_ModifyDate=@F_ModifyDate,F_ModifyUserId=@F_ModifyUserId,F_ModifyUserName=@F_ModifyUserName WHERE F_ModuleId=@F_ModuleId; ");

                var num = conn.Execute(sb.ToString(), entity);
                RemoveCacheHelper("GetMenuList/ALL");
                return num;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="F_ModuleId">主键</param>
        /// <param name="isTuer">是否真删除</param>
        /// <returns></returns>
        public int DeleteModuleEntity(string F_ModuleId, bool isTuer)
        {
            string sql = string.Empty;
            if (isTuer)
                sql = "DELETE FROM sys_menu WHERE F_ModuleId=@F_ModuleId;";
            else
                sql = "UPDATE sys_menu SET F_DeleteMark=1 WHERE F_ModuleId=@F_ModuleId;";

            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                var num = conn.Execute(sql, new { F_ModuleId = F_ModuleId });
                RemoveCacheHelper("GetMenuList/ALL");
                return num;
            }
        }


    }
}
