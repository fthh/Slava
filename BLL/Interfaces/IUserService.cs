using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : IServiceBase<DAL.Entities.User>
    {
        void RegisterUser(DAL.Entities.User entity);
        DAL.Entities.User GetUserById(Guid Id);
    }
}
