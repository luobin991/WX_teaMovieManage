using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Answer.Api
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region 后台引用公共CSS 压缩
            bundles.Add(new StyleBundle("~/Content/CommonCss")
            .Include("~/Content/comoncss/demo.css")
            .Include("~/Content/comoncss/jquery.mmenu.all.css")
            .Include("~/Content/bootstrap.css")
            .Include("~/Content/comoncss/base.css")
            .Include("~/Content/comoncss/index.css")
            );
            #endregion

            #region 后台引用公共Js 压缩
            bundles.Add(new ScriptBundle("~/Scripts/CommonJs")
                .Include("~/Scripts/comonjs/jquery-2.2.0.js")
                .Include("~/Scripts/comonjs/jquery.mmenu.all.min.js")
                .Include("~/Scripts/comonjs/base.js")
                .Include("~/Scripts/comonjs/left.js")
                );
            #endregion

            #region 代理商 相关页面js压缩           

            //赠送用户钻石界面
            bundles.Add(new ScriptBundle("~/Scripts/givenuserdiamonds").Include("~/Scripts/pageJs/givenuserdiamonds.js"));

            //赠送钻石记录
            bundles.Add(new ScriptBundle("~/Scripts/giverecord").Include("~/Scripts/pageJs/giverecord.js"));

            //登录界面
            bundles.Add(new ScriptBundle("~/Scripts/login").Include("~/Scripts/pageJs/login.js"));

            //我的提现页面
            bundles.Add(new ScriptBundle("~/Scripts/reflect").Include("~/Scripts/pageJs/reflect.js"));
            //我的提现页面One
            bundles.Add(new ScriptBundle("~/Scripts/reflectOne").Include("~/Scripts/pageJs/reflectOne.js"));
            //我的提现页面Two
            bundles.Add(new ScriptBundle("~/Scripts/reflectTwo").Include("~/Scripts/pageJs/reflectTwo.js"));
            //我的提现页面Three
            bundles.Add(new ScriptBundle("~/Scripts/reflectThree").Include("~/Scripts/pageJs/reflectThree.js"));

            //我的提现记录页面
            bundles.Add(new ScriptBundle("~/Scripts/reflectrecord").Include("~/Scripts/pageJs/reflectrecord.js"));
            #endregion

            #region 个人设置 相关页面js压缩
            //修改密码
            bundles.Add(new ScriptBundle("~/Scripts/passwordset").Include("~/Scripts/pageJs/MySet/passwordset.js"));

            //代理商玩家ID设置
            bundles.Add(new ScriptBundle("~/Scripts/playeridset").Include("~/Scripts/pageJs/MySet/playeridset.js"));
            #endregion

            #region 统计报表 相关页面js压缩
            //新增统计
            bundles.Add(new ScriptBundle("~/Scripts/addcount").Include("~/Scripts/pageJs/UserStatistics/addcount.js"));

            //线上统计
            bundles.Add(new ScriptBundle("~/Scripts/totalcount").Include("~/Scripts/pageJs/UserStatistics/totalcount.js"));

            //线下统计
            bundles.Add(new ScriptBundle("~/Scripts/totalcountdown").Include("~/Scripts/pageJs/UserStatistics/totalcountdown.js"));
            //牌局统计
            bundles.Add(new ScriptBundle("~/Scripts/tablecount").Include("~/Scripts/pageJs/UserStatistics/tablecount.js"));


            //用户消费记录
            bundles.Add(new ScriptBundle("~/Scripts/userconsumerecord").Include("~/Scripts/pageJs/UserStatistics/userconsumerecord.js"));

            //用户查询
            bundles.Add(new ScriptBundle("~/Scripts/userquery").Include("~/Scripts/pageJs/UserStatistics/userquery.js"));

            //用户充值记录页面
            bundles.Add(new ScriptBundle("~/Scripts/userrecharge").Include("~/Scripts/pageJs/UserStatistics/userrecharge.js"));

            //开房牌局页面
            bundles.Add(new ScriptBundle("~/Scripts/userroomcondition").Include("~/Scripts/pageJs/UserStatistics/userroomcondition.js"));

            //牌桌查询
            bundles.Add(new ScriptBundle("~/Scripts/tablequery").Include("~/Scripts/pageJs/UserStatistics/tablequery.js"));
            //分成统计
            bundles.Add(new ScriptBundle("~/Scripts/dividedmoneycount").Include("~/Scripts/pageJs/UserStatistics/dividedmoneycount.js"));
            #endregion

            #region 下级代理商管理
            //添加代理商
            bundles.Add(new ScriptBundle("~/Scripts/addagent").Include("~/Scripts/pageJs/NextAgents/addagents.js"));

            //代理商列表
            bundles.Add(new ScriptBundle("~/Scripts/agentlist").Include("~/Scripts/pageJs/NextAgents/agentlist.js"));

            //代理商编辑
            bundles.Add(new ScriptBundle("~/Scripts/nextagenteditl").Include("~/Scripts/pageJs/NextAgents/nextAgentEditl.js"));
            #endregion
            #region admind直属代理商管理
            //直属代理商管理
            bundles.Add(new ScriptBundle("~/Scripts/agentManager").Include("~/Scripts/adminjs/AgentMaint/agentManager.js"));
            //直属代理商管理详情
            bundles.Add(new ScriptBundle("~/Scripts/agentManagerDetail").Include("~/Scripts/adminjs/AgentMaint/agentManagerDetail.js"));
            //玩家查询及详情
            bundles.Add(new ScriptBundle("~/Scripts/palyuserManager").Include("~/Scripts/adminjs/AgentMaint/palyuserManager.js"));
            //玩家详情
            bundles.Add(new ScriptBundle("~/Scripts/palyuserManagerDetail").Include("~/Scripts/adminjs/AgentMaint/palyuserManagerDetail.js"));
            //添加直属代理
            bundles.Add(new ScriptBundle("~/Scripts/AddSubAgent").Include("~/Scripts/adminjs/AgentMaint/addSubAgent.js"));
            #endregion
            #region admind数据统计
            //充值记录
            bundles.Add(new ScriptBundle("~/Scripts/chargerecordslist").Include("~/Scripts/adminjs/DataStatistics/chargerecordslist.js"));
            //用户留存率
            bundles.Add(new ScriptBundle("~/Scripts/userkeeprate").Include("~/Scripts/adminjs/DataStatistics/userkeeprate.js"));

            #endregion
        }

    }
}