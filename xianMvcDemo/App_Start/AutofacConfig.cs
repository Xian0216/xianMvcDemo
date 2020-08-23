using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using NLog;

namespace xianMvcDemo.App_Start
{
    public class AutofacConfig
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Logic", StringComparison.Ordinal))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Da", StringComparison.Ordinal))
                .AsImplementedInterfaces();


            ////C.註冊所有父類別為BaseMethod的物件
            //builder.RegisterAssemblyTypes(assembly)
            //    .Where(x => x.BaseType == typeof(BaseMethod)).AsImplementedInterfaces();

            ////D.註冊實作某個介面的物件
            //builder.RegisterAssemblyTypes(assembly)
            //    .Where(x => x.GetInterfaces().Contains(typeof(ICommonMethod))).AsImplementedInterfaces();
            
            builder.RegisterControllers(assembly);
            
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}