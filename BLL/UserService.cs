using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DTO;
using BLL.Interfaces;

namespace BLL
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteUser(User entity)
        {
            base.Delete(entity);
        }

        public void DeleteUser(Guid id)
        {
            base.Delete(id);
        }

        public User GetPostById(Guid id)
        {
            return base.GetById(id);
        }

        public void NewUser(User entity)
        {
            base.Create(entity);
        }

        public void UpdateUser(User entity)
        {
            base.Update(entity);
        }
    }
}
