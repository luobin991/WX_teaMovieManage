using System;
using System.Collections.Generic;
using System.Linq;
using  Common;
using  Entity.SysManage;
using System.Data;
using  Common.DBHelper;
using Dapper;
using System.Text;
using  BusinessLogic.SysManage;

namespace  DataAccess.SysManage
{
    public class Sys_UserRelationDAL: ISys_UserRelation
    {
        /// <summary>
        /// 获取对象主键列表信息
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="category">分类:1-角色2-岗位</param>
        /// <returns></returns>
        public IEnumerable<Sys_UserRelation> GetObjectIdList(string userId, int category)
        {
            var strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM Sys_UserRelation t WHERE t.F_UserId = @userId AND t.F_Category =  @category ");
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                return conn.Query<Sys_UserRelation>(strSql.ToString(), new { userId = userId, category = category });
            }
        }



        /// <summary>
        /// 获取用户主键列表信息
        /// </summary>
        /// <param name="objectId">用户主键</param>
        /// <returns></returns>
        public IEnumerable<Sys_UserRelation> GetUserIdList(string objectId)
        {
            var strSql = new StringBuilder();
            strSql.Append(" SELECT *  FROM Sys_UserRelation t WHERE t.F_ObjectId = @objectId");
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                return conn.Query<Sys_UserRelation>(strSql.ToString(), new { objectId = objectId });
            }
        }



        /// <summary>
        /// 获取用户角色列表信息
        /// </summary>
        /// <param name="objectId">用户主键</param>
        /// <returns></returns>
        public IEnumerable<Sys_UserRelation> GetRoleIdList(string UserId)
        {
            var strSql = new StringBuilder();
            strSql.Append("SELECT t.*  FROM Sys_UserRelation t INNER JOIN sys_role r on t.F_objectId=r.F_RoleId WHERE r.f_deleteMark=0  and  t.F_UserId = @F_UserId ");
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                return conn.Query<Sys_UserRelation>(strSql.ToString(), new { F_UserId = UserId });
            }
        }



        /// <summary>
        /// 保存用户对应对象数据
        /// </summary>
        /// <param name="userRelationEntityList">列表</param>
        public void SaveEntityList(string objectId, List<Sys_UserRelation> userRelationEntityList)
        {
            using (IDbConnection conn = DapperAdapter.MySQLOpenConnection(ConfigurationHelper.MySQLConnectionStr))
            {
                string delSQL = "delete from Sys_UserRelation where F_ObjectId=@F_ObjectId";
                conn.Execute(delSQL, new { F_ObjectId = objectId });

                string addSQL = @"INSERT INTO Sys_UserRelation (F_UserRelationId,F_Category,F_UserId,F_ObjectId,F_CreateDate,F_CreateUserId,F_CreateUserName)VALUES
(@F_UserRelationId,@F_Category,@F_UserId,@F_ObjectId,@F_CreateDate,@F_CreateUserId,@F_CreateUserName);";
                foreach (var item in userRelationEntityList)
                {
                    conn.Execute(addSQL, item);
                }
            }
        }





    }

}
