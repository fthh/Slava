using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Autofac;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new BLL.ServiceModule());

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var userServ = scope.Resolve<BLL.Interfaces.IUserService>();

                var newUser = new DAL.Entities.User()
                {
                    Login = "foo",
                    Pasword = "52531"
                };

                userServ.Create(newUser);

            }
        }
    }
}
