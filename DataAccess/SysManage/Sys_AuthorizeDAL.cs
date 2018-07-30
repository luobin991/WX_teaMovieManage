using  BusinessLogic.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using  Common;
using  Entity.SysManage;
using System.Data;
using  Common.DBHelper;
using Dapper;

namespace  DataAccess.SysManage
{
    public class Sys_AuthorizeDAL: ISys_Authorize
    {

        /// <summary>
        /// 获取授权功能主键数据列表
        /// </summary>
        /// <param name="objectId">对象主键（角色,用户）</param>
        /// <param name="itemType">项目类型:1-菜单2-按钮3-视图</param>
        /// <returns></returns>
        public IEnumerable<Sys_Authorize> GetList(string objectId, int itemType)
        {
            List<Sys_Authorize> tmplist = CacheHelper.Get<List<Sys_Authorize>>("GetMenuList/" + objectId + "-" + itemType);
            if (tmplist == null || tmplist.Count() <= 0)
            {
                using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
                {
                    string sql = "SELECT * from  sys_authorize WHERE  objectId=@objectId AND itemType=@itemType ORDER BY  itemtype ,createDate";
                    var menulist = conn.Query<Sys_Authorize>(sql, new { objectId = objectId, itemType = itemType });
                    if (menulist != null && menulist.Count() > 0)
                        CacheHelper.Set<List<Sys_Authorize>>("GetMenuList/" + objectId + "-" + itemType, menulist.ToList());
                    return menulist;
                }
            }
            return tmplist;
        }

        /// <summary>
        /// 添加授权
        /// </summary>
        /// <param name="objectType">权限分类-1角色2用户</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <param name="createId">添加Id</param>
        public void SaveAuthorize(int objectType, string objectId, string[] moduleIds, string[] moduleButtonIds, string[] moduleColumnIds, int createId)
        {
            try
            {
                using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
                {
                    string delSql = "DELETE FROM sys_authorize WHERE  objectId=@userId;";
                    conn.Execute(delSql, new { userId = objectId });

                    string addSql = "INSERT INTO sys_authorize (authorizeId,objectId,objectType,itemType,itemId,createUserId,createDate)VALUES(@authorizeId,@objectId,@objectType,@itemType,@itemId,@createUserId,@createDate);";
                    //菜单
                    foreach (string item in moduleIds)
                    {
                        Sys_Authorize model = new Sys_Authorize();
                        model.authorizeId = Guid.NewGuid().ToString();
                        model.objectId = objectId;
                        model.objectType = objectType;
                        model.itemType = 1;
                        model.itemId = item;
                        model.createUserId = createId;
                        model.createDate = DateTime.Now;
                        conn.Execute(addSql, model);
                    }
                    //按钮
                    foreach (string item in moduleButtonIds)
                    {
                        Sys_Authorize model = new Sys_Authorize();
                        model.authorizeId = Guid.NewGuid().ToString();
                        model.objectId = objectId;
                        model.objectType = objectType;
                        model.itemType = 2;
                        model.itemId = item;
                        model.createUserId = createId;
                        model.createDate = DateTime.Now;
                        conn.Execute(addSql, model);
                    }
                    //视图
                    foreach (string item in moduleColumnIds)
                    {
                        Sys_Authorize model = new Sys_Authorize();
                        model.authorizeId = Guid.NewGuid().ToString();
                        model.objectId = objectId;
                        model.objectType = objectType;
                        model.itemType = 3;
                        model.itemId = item;
                        model.createUserId = createId;
                        model.createDate = DateTime.Now;
                        conn.Execute(addSql, model);
                    }

                }
            }
            catch (Exception)
            {
                throw new Exception("添加授权出错");
            }
        }


    }
}
