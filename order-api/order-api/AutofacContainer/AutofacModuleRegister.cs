using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace order_api.AutofacContainer
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //注册Services
            var assemblyServices = Assembly.Load("Services");
            builder.RegisterAssemblyTypes(assemblyServices)
                .InstancePerDependency()   //瞬时单例，每次容器返回的都是新的对象
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors();
            //注册仓储Repository
            var assemblyRepository = Assembly.Load("Repository");
            builder.RegisterAssemblyTypes(assemblyRepository)
                .InstancePerDependency()
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors();
        }
    }
}
