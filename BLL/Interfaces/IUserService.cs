using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
        void NewUser(User entity);
        void UpdateUser(User entity);
        void DeleteUser(User entity);
        void DeleteUser(Guid id);
        User GetPostById(Guid id);
    }
}
