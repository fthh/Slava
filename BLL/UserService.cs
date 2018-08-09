using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using Autofac;

namespace BLL
{
    public class UserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DAL.Entities.User GetUser(Guid id)
        {
            return _unitOfWork.GetRepository<DAL.Entities.User>().GetById(id);
        }
    }
}
