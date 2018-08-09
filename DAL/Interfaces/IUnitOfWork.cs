﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
        IRepository<T> GetRepository<T>() where T : DAL.Entities.Entity;
    }
}