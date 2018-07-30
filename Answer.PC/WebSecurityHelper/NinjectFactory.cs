using System;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLogic.SysManage;
using BusinessLogic.Answer;
using DataAccess.SysManage;
using DataAccess.Answer;

namespace Answer.PC.WebSecurityHelper
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
            ninjectKernel.Bind<ISys_User>().To<Sys_UserDAL>();
            ninjectKernel.Bind<ISys_Role>().To<Sys_RoleDAL>();
            ninjectKernel.Bind<ISys_MenuModule>().To<Sys_MenuModuleDAL>();
            ninjectKernel.Bind<ISys_Authorize>().To<Sys_AuthorizeDAL>();
            ninjectKernel.Bind<ISys_ModuleButton>().To<Sys_ModuleButtonDAL>();
            ninjectKernel.Bind<ISys_ModuleColumn>().To<Sys_ModuleColumnDAL>();
            ninjectKernel.Bind<ISys_UserRelation>().To<Sys_UserRelationDAL>();
            ninjectKernel.Bind<ISys_Log>().To<Sys_LogDAL>();

            ninjectKernel.Bind<IT_User>().To<T_UserDAL>();

            ninjectKernel.Bind<I_Shop>().To<ShopDAL>();
            ninjectKernel.Bind<I_Goods>().To<GoodsDAL>();
            ninjectKernel.Bind<I_Lable>().To<LableDAL>();
            ninjectKernel.Bind<I_Relate>().To<RelateDAL>();
            ninjectKernel.Bind<I_Order>().To<OrderDAL>();


        }
    }

}