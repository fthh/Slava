using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace BLL
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DAL.RepositoryModule());
            builder.RegisterGeneric(typeof(ServiceBase<>)).AsSelf();

            builder.RegisterType<PostService>().As<BLL.Interfaces.IPostService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<BLL.Interfaces.IUserService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
