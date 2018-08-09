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

        public DAL.Entities.User GetUser(Guid id)
        {
            return _unitOfWork.GetRepository<DAL.Entities.User>().GetById(id);
        }

        public User GetUserById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
