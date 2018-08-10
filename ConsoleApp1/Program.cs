using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Autofac;
using BLL.Interfaces;
using DAL.Entities;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ServiceModule());

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var userServ = scope.Resolve<IUserService>();

                var newUser = new User()
                {
                    Login = "foo",
                    Pasword = "52531"
                };

                userServ.Create(newUser);

            }
        }
    }
}
