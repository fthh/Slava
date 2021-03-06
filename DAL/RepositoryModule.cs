﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using System.Data.Entity;
using DAL.Interfaces;

namespace DAL
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>));
            builder.RegisterType<Context>().AsSelf().As<DbContext>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            base.Load(builder);
        }
    }
}
