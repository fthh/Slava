using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BLL.Interfaces;
using DAL;

namespace BLL
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterGeneric(typeof(ServiceBase<>)).AsSelf();

            builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
