using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using BusinessLogic.SysManage;
using DataAccess.SysManage;
using BusinessLogic.Answer;
using DataAccess.Answer;
using BusinessLogic.youdao;
using DataAccess.youdao;
namespace Answer.Api.WebSecurityHelper
{

    /// <summary>
    /// Ninject 轻量级IOC依赖注入框架辅助类
    /// </summary>
    public class NinjectFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectFactory()
        {
            //创建Ninject内核实例
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //获得实现接口的对象实例
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        /// <summary>
        /// 绑定接口到实现了该接口的类
        /// </summary>
        private void AddBindings()
        {
            //绑定接口到实现了该接口的类
            //系统功能
            ninjectKernel.Bind<IT_User>().To<T_UserDAL>();
            ninjectKernel.Bind<ISys_User>().To<Sys_UserDAL>(); 
            ninjectKernel.Bind<ISys_Log>().To<Sys_LogDAL>();

            //商品数据
            ninjectKernel.Bind<I_Shop>().To<ShopDAL>();


            //有道
            ninjectKernel.Bind<I_Youdao>().To<youdao>();



        }
    }

}