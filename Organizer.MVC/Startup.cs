using Microsoft.Owin;
using Owin;
using Autofac;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(Organizer.MVC.Startup))]
namespace Organizer.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureApp(app);
            ConfigureAuth(app);
        }

        private void ConfigureApp(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            var container = ConfigureDI(configuration);
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}
