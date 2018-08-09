using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using Autofac;
using DAL.Entities;

namespace BLL
{
    public class UserService : ServiceBase<DAL.Entities.User>, BLL.Interfaces.IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
    }
}
