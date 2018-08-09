using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using BLL;
using System.Web.Http;

namespace Organizer.MVC
{
    public partial class Startup
    {
        public ILifetimeScope ConfigureDI(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new ServiceModule());

            var container = builder.Build();
            //ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }
    }
}